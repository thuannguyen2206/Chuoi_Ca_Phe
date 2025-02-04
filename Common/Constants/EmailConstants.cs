﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Constants
{
    public static class EmailConstants
    {
        public const string LayoutPath = "/Pages/EmailTemplate/Layout.html";

        public const string OrderContentPath = "/Pages/EmailTemplate/OrderContent.html";

        public const string ResetPasswordPath = "/Pages/EmailTemplate/ResetPassword.html";

        public const string ConfirmEmailPath= "/Pages/EmailTemplate/ConfirmEmail.html";


        public const string MainContent = "{{Main Content}}";

        public const string ConfirmLink = "{{Confirm Link}}";

        public const string DateCreated = "{{Date Created}}";

        public const string UserName = "{{User Name}}";

        public const string OrderCode = "{{Order Code}}";

        public const string OrderItems = "{{Order Items}}";

        public const string SubPrice = "{{SubPrice}}";

        public const string TotalPrice = "{{Total Price}}";

        public const string DiscountPrice = "{{Discount Price}}";

        public const string ShippingFee = "{{Shipping Fee}}";

        public const string OrderStatus = "{{Order Status}}";

        public const string IsPaid = "{{Is Paid}}";

        public const string PhoneNumber = "{{Phone Number}}";

        public const string Address = "{{Address}}";

        public const string AddressOption = "{{Address Option}}";

        public const string OrderNote = "{{Order Note}}";

        public const string Email = "{{Email}}";

    }
}
