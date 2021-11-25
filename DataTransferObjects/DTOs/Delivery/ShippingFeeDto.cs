using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Delivery
{
    public class ShippingFeeDto
    {
        public int From_district_id { get; set; }

        public int Service_id { get; set; }

        public int Service_type_id { get; set; }

        public int To_district_id { get; set; }

        public string To_ward_code { get; set; }

        public int Height { get; set; }

        public int Length { get; set; }

        public int Weight { get; set; }

        public int Width { get; set; }

        public int Insurance_fee { get; set; }

        public string Coupon { get; set; }
    }
}
