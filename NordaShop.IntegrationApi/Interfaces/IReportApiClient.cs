using DataTransferObjects.DTOs.Charts;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface IReportApiClient
    {
        /// <summary>
        /// Get revenue statistic
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        Task<ApiResult<List<DateRevenueStatistic>>> RevenueStatistic(string from, string to);

        /// <summary>
        /// Top selling product for all
        /// </summary>
        /// <returns></returns>
        Task<ApiResult<List<TopSellingProduct>>> TopAllSellingProducts();

        /// <summary>
        /// Top selling product for month
        /// </summary>
        /// <param name="time"> Format yyyy-MM-dd HH:mm:ss</param>
        /// <returns></returns>
        Task<ApiResult<List<TopSellingProduct>>> TopMonthSellingProducts(string time);

    }
}
