using Common.Constants;
using DataAccess.Entities;
using DataAccess.Enums;
using DataTransferObjects.DTOs.Charts;
using Repositories;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _uow;

        public ReportService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ApiResult<List<DateRevenueStatistic>> RevenueStatistic(DateTime from, DateTime to)
        {
            var orders = _uow.GetRepository<Order>()
                .QueryConditionReadOnly(x => x.OrderStatus == OrderStatus.Successed &&
                                        x.IsPaid && x.DateCreated >= from && x.DateCreated <= to)
                .Select(x => new { x.ShippingFee, x.DateCreated, x.DiscountPrice, x.Id, x.TotalPrice })
                .AsEnumerable()
                .GroupBy(x => x.DateCreated.Date);

            var orderDetailRepo = _uow.GetRepository<OrderDetail>().QueryAllReadOnly();

            var result = new List<DateRevenueStatistic>();
            decimal revenue = 0;
            decimal profit = 0;
            int orderCount = 0;
            foreach (var group in orders) // list order
            {
                foreach (var item in group) //list order day
                {
                    revenue += item.TotalPrice - item.ShippingFee;
                    orderCount++;

                    profit += orderDetailRepo.Where(x => x.OrderId == item.Id)
                       .Select(x => new { x.OriginalPrice, x.Price, x.Quantity })
                       .Sum(x => x.Quantity * x.Price - x.Quantity * x.OriginalPrice);
                    profit -= item.DiscountPrice;
                }
                result.Add(new DateRevenueStatistic()
                {
                    Date = group.Key,
                    Profit = Math.Round(profit, 0),
                    Revenue = Math.Round(revenue, 0),
                    OrderCount = orderCount
                });
                revenue = 0;
                profit = 0;
                orderCount = 0;
            }
            return new ApiResult<List<DateRevenueStatistic>>(true, data: result);
        }

        public ApiResult<List<TopSellingProduct>> TopSellingProduct()
        {
            var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => !x.IsDelete);
            var result = productRepo.OrderByDescending(x => x.OrderCount)
                .ThenBy(x => x.Name)
                .Take(SystemConstants.TopSellingProduct)
                .Select(x => new TopSellingProduct()
                {
                    OrderCount = x.OrderCount,
                    Name = x.Name
                }).ToList();
            return new ApiResult<List<TopSellingProduct>>(true, result);
        }

        public ApiResult<List<TopSellingProduct>> TopSellingProduct(DateTime time)
        {
            var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => !x.IsDelete);
            var orderRepo = _uow.GetRepository<Order>().QueryConditionReadOnly(x => x.DateCreated.Year == time.Year && x.DateCreated.Month == time.Month);
            var orderDetailRepo = _uow.GetRepository<OrderDetail>().QueryAllReadOnly();

            var query = (from a in orderRepo
                         join b in orderDetailRepo on a.Id equals b.OrderId
                         where a.DateCreated.Day <= time.Day
                         select new
                         {
                             b.Quantity,
                             b.ProductId
                         }).AsEnumerable()
                         .GroupBy(x => x.ProductId)
                         .Take(SystemConstants.TopSellingProduct)
                         .Select(x => new { ProductId = x.Key, Quantity = x.Sum(y => y.Quantity) })
                         .OrderByDescending(x => x.Quantity);

            var result = new List<TopSellingProduct>();
            foreach (var group in query)
            {
                var productName = productRepo.Where(x => x.Id == group.ProductId).Select(x => x.Name).FirstOrDefault();
                result.Add(new TopSellingProduct() { Name = productName, OrderCount = group.Quantity });
            }
            return new ApiResult<List<TopSellingProduct>>(true, data: result);
        }


    }
}
