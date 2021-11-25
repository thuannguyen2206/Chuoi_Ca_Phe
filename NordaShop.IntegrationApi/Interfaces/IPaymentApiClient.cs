using DataTransferObjects.DTOs.Payment.Momo;
using DataTransferObjects.DTOs.Payment.Paypal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface IPaymentApiClient
    {
        #region Paypal

        /// <summary>
        /// Get paypal access token
        /// </summary>
        /// <returns>access token</returns>
        public Task<string> PaypalGetAccessToken();

        /// <summary>
        /// Create paypal payment
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="payment"></param>
        /// <returns></returns>
        public Task<CreatePaymentResponseDto> PaypalCraetePayment(string accessToken, object payment);

        /// <summary>
        /// Excute payment after customer's approval
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="payerId"></param>
        /// <returns></returns>
        public Task<ExcutePaymentResponseDto> PaypalExcutePayment(string accessToken, string paymentId, string payerId);

        /// <summary>
        /// Get payment info after excute success
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        public Task<PaymentInformationDto> GetPaypalPayment(string accessToken, string paymentId);

        /// <summary>
        /// Refund money if occur error
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="saleId"></param>
        /// <returns></returns>
        public Task<bool> PaypalRefundSale(string accessToken, string saleId);

        public Task<decimal> GetExchangeRate(string currencyConvert);

        #endregion


        #region Momo

        /// <summary>
        /// Create paypal payment
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public Task<MomoCreatePaymentResponseDto> MomoCreatePayment(object payment);

        //public Task<ExcutePaymentResponseDto> MomoExcutePayment(string accessToken, string paymentId, string payerId);

        //public Task<PaymentInformationDto> GetMomoPayment(string accessToken, string paymentId);

        //public Task<bool> MomoRefundSale(string accessToken, string saleId);

        #endregion


        #region NganLuong




        #endregion

    }
}
