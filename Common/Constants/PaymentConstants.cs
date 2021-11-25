using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Constants
{
    public static class PaymentConstants
    {
        #region Paypal

        public const string PaypalGetAccessTokenUrl = "https://api-m.sandbox.paypal.com/v1/oauth2/token";

        public const string PaypalCreatePayment = "https://api-m.sandbox.paypal.com/v1/payments/payment";

        public const string PaypalExcuteApprovalPaymentUrl = "https://api-m.sandbox.paypal.com/v1/payments/payment/{{PaymentId}}/execute";

        public const string PaypalRefundPament = "https://api-m.sandbox.paypal.com/v1/payments/sale/{{SaleId}}/refund";

        public const string PaypalGetPaymentDetailUrl = "https://api-m.sandbox.paypal.com/v1/payments/payment/{{PaymentId}}";

        public const string ExchangeRateUrl = "https://free.currconv.com/api/v7/convert?q={{Currency}}&compact=ultra&apiKey={{ApiKey}}";

        public const string PaymentId = "{{PaymentId}}";

        public const string SaleId = "{{SaleId}}";

        public const string ExchangeRateApiKey = "{{ApiKey}}";

        public const string Currency = "{{Currency}}";


        public const decimal DefaultExchangeRateUSD_VND = 23000;


        public static class CurrencyConvert
        {
            public const string USD_VND = "USD_VND";

            public const string VND_USD = "VND_USD";
        }
        #endregion

        #region Momo

        public const string MomoEnvUrl = "https://test-payment.momo.vn";

        public const string MomoApiEndPoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";

        public const string MomoCretePaymentInfoUrl = "https://test-payment.momo.vn/v2/gateway/api/create";


        #endregion

    }
}
