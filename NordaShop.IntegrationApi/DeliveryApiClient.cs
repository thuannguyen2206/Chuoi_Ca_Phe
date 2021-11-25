using Common.Constants;
using DataTransferObjects.DTOs.Delivery;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NordaShop.IntegrationApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi
{
    public class DeliveryApiClient : IDeliveryApiClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContext;

        public DeliveryApiClient(IHttpClientFactory clientFactory, IConfiguration config, IHttpContextAccessor httpContext)
        {
            _clientFactory = clientFactory;
            _config = config;
            _httpContext = httpContext;
        }

        public async Task<decimal> CalShippingFee(int districtId, string wardCode, int deliveryType, decimal subtotal, int productCount)
        {
            var obj = new ShippingFeeDto()
            {
                Coupon = "",
                From_district_id = DeliveryConstants.DefaultDistrictId,
                Service_type_id = deliveryType,
                To_district_id = districtId,
                To_ward_code = wardCode,
                Width = DeliveryConstants.DefaultWidth,
                Height = DeliveryConstants.DefaultHeight * productCount,
                Weight = DeliveryConstants.DefaultWeight * productCount,
                Length = DeliveryConstants.DefaultLength,
                Insurance_fee = (int)subtotal
            };

            var client = _clientFactory.CreateClient();
            var httpContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, DeliveryConstants.ShippingFeeUrl);
            requestMessage.Headers.Add("token", _config["GHN:token"]);
            requestMessage.Headers.Add("ShopId", _config["GHN:shop_id"]);
            requestMessage.Content = httpContent;

            var response = await client.SendAsync(requestMessage);
            string body = await response.Content.ReadAsStringAsync();
            decimal shippingFee = 0;
            if (response.IsSuccessStatusCode)
            {
                dynamic deserializeObject = JsonConvert.DeserializeObject(body);
                var data = deserializeObject["data"];
                var total = data["total"];
                shippingFee = total ?? 0;
            }
            return shippingFee;
        }

        public async Task<List<DistrictDto>> LoadDistrict(int provinceId)
        {
            var data = new List<DistrictDto>();
            dynamic obj = await PostAsync(DeliveryConstants.DistrictUrl, new { province_id = provinceId });
            if (obj != null)
            {
                foreach (var item in obj["data"])
                {
                    string districtName = item["DistrictName"];
                    int districtId = item["DistrictID"];
                    data.Add(new DistrictDto()
                    {
                        ProvinceId = provinceId,
                        DistrictId = districtId,
                        DistrictName = districtName
                    });
                }
            }
            return data;
        }

        public async Task<List<ProvinceDto>> LoadProvince()
        {
            var data = new List<ProvinceDto>();
            dynamic obj = await GetAsync(DeliveryConstants.ProvinceUrl);
            if (obj != null)
            {
                foreach (var item in obj["data"])
                {
                    string provinceName = item["ProvinceName"];
                    int provinceId = item["ProvinceID"];
                    data.Add(new ProvinceDto()
                    {
                        ProvinceId = provinceId,
                        ProvinceName = provinceName
                    });
                }
            }
            return data;
        }

        public async Task<List<WardDto>> LoadWard(int districtId)
        {
            var data = new List<WardDto>();
            dynamic obj = await PostAsync(DeliveryConstants.WardUrl, new { district_id = districtId });
            if (obj != null)
            {
                foreach (var item in obj["data"])
                {
                    string wardName = item["WardName"];
                    string wardCode = item["WardCode"];
                    data.Add(new WardDto()
                    {
                        WardCode = wardCode,
                        DistrictId = districtId,
                        WardName = wardName
                    });
                }
            }
            return data;
        }

        private async Task<object> GetAsync(string url)
        {
            var client = _clientFactory.CreateClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            requestMessage.Headers.Add("token", _config["GHN:token"]);

            var response = await client.SendAsync(requestMessage);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var deserializeObject = JsonConvert.DeserializeObject(body);
                return deserializeObject;
            }
            return null;
        }

        private async Task<object> PostAsync(string url, object obj)
        {
            var client = _clientFactory.CreateClient();
            var httpContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            requestMessage.Headers.Add("token", _config["GHN:token"]);
            requestMessage.Content = httpContent;

            var response = await client.SendAsync(requestMessage);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var deserializeObject = JsonConvert.DeserializeObject(body);
                return deserializeObject;
            }
            return null;
        }

    }
}
