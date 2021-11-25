using Common.Constants;
using DataTransferObjects.DTOs.Payment.Momo;
using DataTransferObjects.DTOs.Payment.Paypal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NordaShop.IntegrationApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi
{
    public class PaymentApiClient : IPaymentApiClient
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _config;

        public PaymentApiClient(IConfiguration config, IHttpClientFactory clientFactory, IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
            _config = config;
            _httpClient = clientFactory;
        }

        #region Paypal

        public async Task<decimal> GetExchangeRate(string currencyConvert)
        {
            var client = _httpClient.CreateClient();
            string apiKey = _config.GetValue<string>("ExchangeRateApiKey");
            string url = PaymentConstants.ExchangeRateUrl
                .Replace(PaymentConstants.Currency, currencyConvert)
                .Replace(PaymentConstants.ExchangeRateApiKey, apiKey);
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await client.SendAsync(requestMessage);
            string body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                dynamic deserializeObject = JsonConvert.DeserializeObject(body);
                var exchangeRate = deserializeObject[currencyConvert];
                return exchangeRate;
            }
            return PaymentConstants.DefaultExchangeRateUSD_VND;
        }

        public async Task<PaymentInformationDto> GetPaypalPayment(string accessToken, string paymentId)
        {
            var client = _httpClient.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.Timeout = TimeSpan.FromMinutes(5);

            string url = PaymentConstants.PaypalGetPaymentDetailUrl.Replace(PaymentConstants.PaymentId, paymentId);
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await client.SendAsync(requestMessage);
            string body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var deserializeObject = JsonConvert.DeserializeObject<PaymentInformationDto>(body);
                return deserializeObject;
            }
            return null;
        }

        public async Task<CreatePaymentResponseDto> PaypalCraetePayment(string accessToken, object payment)
        {
            var client = _httpClient.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.Timeout = TimeSpan.FromMinutes(5);

            var httpContent = new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, PaymentConstants.PaypalCreatePayment)
            {
                Content = httpContent
            };

            var response = await client.SendAsync(requestMessage);
            string body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var deserializeObject = JsonConvert.DeserializeObject<CreatePaymentResponseDto>(body);
                return deserializeObject;
            }
            return null;
        }

        public async Task<ExcutePaymentResponseDto> PaypalExcutePayment(string accessToken, string paymentId, string payerId)
        {
            var client = _httpClient.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.Timeout = TimeSpan.FromMinutes(5);

            var httpContent = new StringContent(JsonConvert.SerializeObject(new { payer_id = payerId }), Encoding.UTF8, "application/json");
            string url = PaymentConstants.PaypalExcuteApprovalPaymentUrl.Replace(PaymentConstants.PaymentId, paymentId);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = httpContent
            };

            var response = await client.SendAsync(requestMessage);
            string body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var deserializeObject = JsonConvert.DeserializeObject<ExcutePaymentResponseDto>(body);
                return deserializeObject;
            }
            return null;
        }

        public async Task<string> PaypalGetAccessToken()
        {
            string clientId = _config.GetValue<string>("Paypal:ClientId");
            string secretKey = _config.GetValue<string>("Paypal:SecretKey");
            byte[] byteArray = Encoding.ASCII.GetBytes($"{clientId}:{secretKey}");

            var client = _httpClient.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            client.Timeout = TimeSpan.FromMinutes(5);
           
            var dic = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" }
            };
            var reqquestContent = new FormUrlEncodedContent(dic);
            reqquestContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, PaymentConstants.PaypalGetAccessTokenUrl);
            requestMessage.Content = reqquestContent;

            var response = await client.SendAsync(requestMessage);
            string body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var deserializeObject = JsonConvert.DeserializeObject<AccessTokenResponseDto>(body);
                return deserializeObject.Access_token;
            }
            return string.Empty;
        }

        public async Task<bool> PaypalRefundSale(string accessToken, string saleId)
        {
            var client = _httpClient.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.Timeout = TimeSpan.FromMinutes(5);

            string url = PaymentConstants.PaypalRefundPament.Replace(PaymentConstants.SaleId, saleId);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            requestMessage.Content = new StringContent("", Encoding.UTF8, "application/json");

            var response = await client.SendAsync(requestMessage);
            string body = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode;
        }

        #endregion

        #region Momo

        public async Task<MomoCreatePaymentResponseDto> MomoCreatePayment(object payment)
        {
            var client = _httpClient.CreateClient();
            client.Timeout = TimeSpan.FromMinutes(5);

            var httpContent = new StringContent(JsonConvert.SerializeObject(payment), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, PaymentConstants.MomoCretePaymentInfoUrl)
            {
                Content = httpContent
            };

            var response = await client.SendAsync(requestMessage);
            string body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var deserializeObject = JsonConvert.DeserializeObject<MomoCreatePaymentResponseDto>(body);
                return deserializeObject;
            }
            return null;
        }

        #endregion

    }
}
