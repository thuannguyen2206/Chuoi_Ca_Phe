using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Charts
{
    public class DateRevenueStatistic // thống kê doanh thu ngày trong tháng
    {
        public decimal Revenue { get; set; } // doanh thu theo ngày

        public decimal Profit { get; set; } // lợi nhuận theo ngày

        public DateTime Date { get; set; }

        public int OrderCount { get; set; }
    }
}
