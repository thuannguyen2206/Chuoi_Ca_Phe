using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NordaShop.Admin.Models;
using NordaShop.Admin.Models.Home;
using NordaShop.IntegrationApi.Interfaces;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Drawing.Chart.Style;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductApiClient _productApi;
        private readonly IOrderApiClient _orderApi;
        private readonly IUserApiClient _userApi;
        private readonly IReportApiClient _reportApi;

        public HomeController(IProductApiClient productApi, IReportApiClient reportApi,
            IOrderApiClient orderApi, IUserApiClient userApi)
        {
            _productApi = productApi;
            _orderApi = orderApi;
            _userApi = userApi;
            _reportApi = reportApi;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel()
            {
                ActiveProduct = await _productApi.ToTalActives(),
                MonthlyIncome = await _orderApi.MonthlyIncome(),
                ProductSold = await _productApi.TotalSold(),
                TotalIncome = await _orderApi.TotalIncome(),
                TotalOrders = await _orderApi.TotalOrders(),
                TotalUsers = await _userApi.TotalActive()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetRevenueStatistic(DateTime from, DateTime to)
        {
            if (from == DateTime.MinValue || to == DateTime.MinValue)
            {
                to = DateTime.Now;
                from = to.AddMonths(-1);
            }
            ViewBag.From = from;
            ViewBag.To = to;
            var response = await _reportApi.RevenueStatistic(from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"));
            if (response != null && response.Success)
            {
                return Json(response.Data);
            }
            return Json(null);
        }

        [HttpGet]
        public async Task<IActionResult> TopAllSellingProduct()
        {
            var response = await _reportApi.TopAllSellingProducts();
            if (response != null && response.Success)
            {
                return Json(response.Data);
            }
            return Json(null);
        }

        [HttpGet]
        public async Task<IActionResult> TopMonthSellingProduct()
        {
            var response = await _reportApi.TopMonthSellingProducts(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (response != null && response.Success)
            {
                return Json(response.Data);
            }
            return Json(null);
        }

        #region Export excel

        public async Task<IActionResult> ExportRevenueStatisticToExcel(DateTime from, DateTime to)
        {
            if (from == DateTime.MinValue || to == DateTime.MinValue)
            {
                to = DateTime.Now;
                from = to.AddMonths(-1);
            }
            var stream = await this.GetRevenueStatisticStream(from, to);
            if (stream != null)
            {
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"revenue_{DateTime.Now.ToString("ddMMyyyy")}.xlsx");
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ExportWebsiteStatisticToExcel()
        {
            var stream = await this.GetWebsiteStatisticStream();
            if (stream != null)
            {
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"website_{DateTime.Now.ToString("ddMMyyyy")}.xlsx");
            }
            return RedirectToAction("Index", "Home");
        }

        private async Task<Stream> GetRevenueStatisticStream(DateTime from, DateTime to)
        {
            var response = await _reportApi.RevenueStatistic(from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"));
            if (response != null && response.Success)
            {
                var stream = new MemoryStream();
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (var xlPackage = new ExcelPackage(stream))
                {
                    var worksheet = xlPackage.Workbook.Worksheets.Add("Revenue Statistic");
                    var namedStyle = xlPackage.Workbook.Styles.CreateNamedStyle("HyperLink");
                    namedStyle.Style.Font.UnderLine = true;
                    namedStyle.Style.Font.Color.SetColor(Color.Blue);
                    const int startRow = 5;
                    var row = startRow;

                    //Create Headers and format them
                    worksheet.Cells["A1"].Value = $"Doanh thu từ {from.ToString("dd/MM/yyyy")} đến {to.ToString("dd/MM/yyyy")}";
                    using (var r = worksheet.Cells["A1:E1"])
                    {
                        r.Merge = true;
                        r.Style.Font.Color.SetColor(Color.White);
                        r.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                        r.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                    }


                    worksheet.Cells["A3"].Value = "STT";
                    worksheet.Cells["B3"].Value = "Ngày";
                    worksheet.Cells["c3"].Value = "Doanh thu";
                    worksheet.Cells["D3"].Value = "Lợi nhuận";
                    worksheet.Cells["E3"].Value = "Số lượng đơn";
                    worksheet.Cells["A3:E3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells["A3:E3"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                    worksheet.Cells["A3:E3"].Style.Font.Bold = true;

                    row = 4;
                    int i = 1;
                    foreach (var item in response.Data)
                    {
                        worksheet.Cells[row, 1].Value = i;
                        worksheet.Cells[row, 2].Value = item.Date.ToString("dd/MM/yyyy");
                        worksheet.Cells[row, 3].Value = item.Revenue;
                        worksheet.Cells[row, 4].Value = item.Profit;
                        worksheet.Cells[row, 5].Value = item.OrderCount;
                        row++;
                        i++;
                    }
                    worksheet.Cells[$"A3:E{row}"].AutoFitColumns();

                    // draw chart
                    ExcelChart chart = worksheet.Drawings.AddChart("Chart", eChartType.ColumnClustered);
                    chart.Title.Text = "Thống kê doanh thu";
                    chart.SetPosition(1, 0, 7, 0);
                    chart.SetSize(1000, 500);
                    var ser1 = chart.Series.Add(worksheet.Cells[$"C4:C{row-1}"], worksheet.Cells[$"B4:B{row-1}"]);
                    ser1.Header = "Doanh thu";
                    var ser2 = chart.Series.Add(worksheet.Cells[$"D4:D{row-1}"], worksheet.Cells[$"B4:B{row-1}"]);
                    ser2.Header = "Lợi nhuận";

                    // set some core property values
                    xlPackage.Workbook.Properties.Title = "Revenue Statistic";
                    xlPackage.Workbook.Properties.Author = "Admin";
                    xlPackage.Workbook.Properties.Subject = "Revenue Statistic";
                    // save the new spreadsheet
                    xlPackage.Save();
                }
                stream.Position = 0;
                return stream;
            }
            return null;
        }

        private async Task<Stream> GetWebsiteStatisticStream()
        {
            var topAllSelling = await _reportApi.TopAllSellingProducts();
            var topMonthSelling = await _reportApi.TopMonthSellingProducts(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            var activeProduct = await _productApi.ToTalActives();
            var monthlyIncome = await _orderApi.MonthlyIncome();
            var productSold = await _productApi.TotalSold();
            var totalIncome = await _orderApi.TotalIncome();
            var totalOrders = await _orderApi.TotalOrders();
            var totalUsers = await _userApi.TotalActive();

            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (var xlPackage = new ExcelPackage(stream))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("Website Statistic");
                var namedStyle = xlPackage.Workbook.Styles.CreateNamedStyle("HyperLink");
                namedStyle.Style.Font.UnderLine = true;
                namedStyle.Style.Font.Color.SetColor(Color.Blue);
                const int startRow = 7;
                int psm_row  = startRow, psa_row = startRow;

                //Create Headers and format them
                worksheet.Cells["A1"].Value = $"Thống kê website đến ngày {DateTime.Now.ToString("dd/MM/yyyy")}";
                using (var r = worksheet.Cells["A1:B1"])
                {
                    r.Merge = true;
                    r.Style.Font.Color.SetColor(Color.White);
                    r.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    r.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                }

                worksheet.Cells["D1"].Value = $"Top 10 sản phẩm bán chạy trong tháng {DateTime.Now.ToString("MM/yyyy")}";
                using (var r = worksheet.Cells["D1:F1"])
                {
                    r.Merge = true;
                    r.Style.Font.Color.SetColor(Color.White);
                    r.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    r.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 193));
                }

                worksheet.Cells["H1"].Value = $"Top 10 sản phẩm bán chạy nhất";
                using (var r = worksheet.Cells["H1:J1"])
                {
                    r.Merge = true;
                    r.Style.Font.Color.SetColor(Color.White);
                    r.Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                    r.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 155, 93));
                }

                // website statistic
                worksheet.Cells["A3"].Value = "Sản phẩm đang bán";
                worksheet.Cells["A4"].Value = "Số lượng đặt mua";
                worksheet.Cells["A5"].Value = "Tài khoản hoạt động";
                worksheet.Cells["A6"].Value = "Tổng đơn hàng";
                worksheet.Cells["A7"].Value = "Doanh thu trong tháng (vnđ)";
                worksheet.Cells["A8"].Value = "Tổng doanh thu (vnđ)";

                worksheet.Cells["B3"].Value = activeProduct;
                worksheet.Cells["B4"].Value = productSold;
                worksheet.Cells["B5"].Value = totalUsers;
                worksheet.Cells["B6"].Value = totalOrders;
                worksheet.Cells["B7"].Value = monthlyIncome;
                worksheet.Cells["B8"].Value = totalIncome;

                // product statistic
                worksheet.Cells["D3"].Value = worksheet.Cells["H3"].Value = "STT";
                worksheet.Cells["E3"].Value = worksheet.Cells["I3"].Value = "Tên sản phẩm";
                worksheet.Cells["F3"].Value = worksheet.Cells["J3"].Value = "Số lượng bán";

                worksheet.Cells["A3:A8"].Style.Fill.PatternType = 
                    worksheet.Cells["D3:F3"].Style.Fill.PatternType = 
                    worksheet.Cells["H3:J3"].Style.Fill.PatternType = ExcelFillStyle.Solid;

                worksheet.Cells["A3:A8"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                worksheet.Cells["D3:F3"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                worksheet.Cells["H3:J3"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));

                worksheet.Cells["A3:A8"].Style.Font.Bold = 
                    worksheet.Cells["D3:F3"].Style.Font.Bold = 
                    worksheet.Cells["H3:J3"].Style.Font.Bold = true;

                // product selling in month
                psm_row = 4;
                int i = 1;
                foreach (var item in topMonthSelling.Data)
                {
                    worksheet.Cells[psm_row, 4].Value = i;
                    worksheet.Cells[psm_row, 5].Value = item.Name;
                    worksheet.Cells[psm_row, 6].Value = item.OrderCount;
                    psm_row++;
                    i++;
                }
                // product selling in all
                psa_row = 4;
                int y = 1;
                foreach (var item in topAllSelling.Data)
                {
                    worksheet.Cells[psa_row, 8].Value = y;
                    worksheet.Cells[psa_row, 9].Value = item.Name;
                    worksheet.Cells[psa_row, 10].Value = item.OrderCount;
                    psa_row++;
                    y++;
                }

                worksheet.Cells[$"A3:B8"].AutoFitColumns();
                worksheet.Cells[$"D3:F{psm_row}"].AutoFitColumns();
                worksheet.Cells[$"H3:J{psa_row}"].AutoFitColumns();

                // draw chart selling in month
                ExcelChart mchart = worksheet.Drawings.AddChart("Monthly Chart", eChartType.ColumnClustered);
                mchart.Title.Text = "Sản phẩm bán chạy trong tháng";
                mchart.SetPosition(15, 0, 0, 0);
                mchart.SetSize(600, 400);
                var ser1 = mchart.Series.Add(worksheet.Cells[$"F4:F{psm_row-1}"], worksheet.Cells[$"E4:E{psm_row-1}"]);
                ser1.Header = "Số lượng bán";

                // draw chart selling in all
                ExcelChart achart = worksheet.Drawings.AddChart("All Chart", eChartType.ColumnClustered);
                achart.Title.Text = "Sản phẩm bán chạy nhất";
                achart.SetPosition(15, 0, 7, 0);
                achart.SetSize(600, 400);
                var ser2 = achart.Series.Add(worksheet.Cells[$"J4:J{psa_row-1}"], worksheet.Cells[$"I4:I{psa_row-1}"]);
                ser2.Header = "Số lượng bán";

                // add chart of type Pie.
                //var myChart = worksheet.Drawings.AddChart("chart", eChartType.Pie);
                //var series = myChart.Series.Add("C2: C4", "B2: B4");
                //myChart.Border.Fill.Color = System.Drawing.Color.Green;
                //myChart.Title.Text = "My Chart";
                //myChart.SetSize(400, 400);
                //myChart.SetPosition(6, 0, 6, 0);

                // set some core property values
                xlPackage.Workbook.Properties.Title = "Website Statistic";
                xlPackage.Workbook.Properties.Author = "Admin";
                xlPackage.Workbook.Properties.Subject = "Website Statistic";
                // save the new spreadsheet
                xlPackage.Save();
            }
            stream.Position = 0;
            return stream;
        }

        #endregion

    }
}
