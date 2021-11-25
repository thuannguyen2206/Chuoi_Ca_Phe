using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using System;

namespace NordaShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("revenue-statistic")]
        public IActionResult RevenueStatistic([FromQuery]DateTime from, [FromQuery]DateTime to)
        {
            var respose = _reportService.RevenueStatistic(from, to);
            return Ok(respose);
        } 
        
        [HttpGet("top-all-selling-product")]
        public IActionResult TopAllSellingProducts()
        {
            var respose = _reportService.TopSellingProduct();
            return Ok(respose);
        }

        [HttpGet("{time}/top-month-selling-product")]
        public IActionResult TopMonthSellingProducts(DateTime time)
        {
            var respose = _reportService.TopSellingProduct(time);
            return Ok(respose);
        }


    }
}
