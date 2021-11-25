using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Constants
{
    public static class SystemConstants
    {
        // number
        public static int ExpireTimeConfirmEmail = 48; // hours

        public static int ExpireTimeSignInToken = 3; // hours

        public static int Banner = 2;

        public static int DashboardSlide = 2;

        public static int AutocompleteSearch = 10;

        public static int TabProductQuantity = 12;

        public static int TopBrands = 5;

        public static int TopRatings = 10;

        public static int TopProductTag = 5;
        
        public static int TopPostTag = 5;

        public static int ProductRelated = 4;

        public static int DefaultMaxPrice = 400;

        public static int StandarPoint = 10;

        public static int VipPoint = 20;

        public static int UserOrderCount = 30;

        public static int TopSellingProduct = 10;

        public static int PostInPage = 8;

        public static int LastestPostComment = 10;

        public static int LastestPost = 5;

        public static int RelatedPost = 5;


        public const string Token = "Token";

        public const string UserId = "UserId";

        public const string Username = "Username";

        public const string Email = "Email";

        public const string Role = "Role";

        public const string CartSession = "CartSession";

        public const string CheckoutSession = "CheckoutSession";

        public const string PaypalAccessToken = "PaypalAccessToken";

        public const string PaypalSaleId = "PaypalSaleId";

        public const string WishlistSession = "WishlistSession";

        public const string DefaultImage = "/assets/images/default.png";

        public const string UserDefault = "/assets/images/users/user.png";

        public static class Tab
        {
            public const string BestSellers = "bestsellers";

            public const string NewArrivals = "newarrivals";

            public const string Trending = "trending";

            public const string TopSales = "topsales";
        }
    }
}
