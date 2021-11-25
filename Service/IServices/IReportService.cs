using DataTransferObjects.DTOs.Charts;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Service.IServices
{
    public interface IReportService
    {
        ApiResult<List<DateRevenueStatistic>> RevenueStatistic(DateTime from, DateTime to);

        ApiResult<List<TopSellingProduct>> TopSellingProduct();

        ApiResult<List<TopSellingProduct>> TopSellingProduct(DateTime time);
    }
}
