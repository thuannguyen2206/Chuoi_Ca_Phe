using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Constants
{
    public class DeliveryConstants
    {
        public const string ProvinceUrl = "https://online-gateway.ghn.vn/shiip/public-api/master-data/province";

        public const string DistrictUrl = "https://online-gateway.ghn.vn/shiip/public-api/master-data/district";

        public const string WardUrl = "https://online-gateway.ghn.vn/shiip/public-api/master-data/ward";

        public const string ShippingFeeUrl = "https://online-gateway.ghn.vn/shiip/public-api/v2/shipping-order/fee";

        public static decimal DefaultPriceFreeShip = 500000; // vnđ

        public static int DefaultDistrictId = 1454; // quận 12, hcm

        public const int ServiceTypeId = 2; // 1: Express, 2: Standard

        public const int DefaultHeight = 5; // chiều cao (cm)

        public const int DefaultWidth = 10; // chiều rộng (cm)

        public const int DefaultLength = 20; // chiều dài (cm)

        public const int DefaultWeight = 150; // trọng lượng (gr)
    }
}
