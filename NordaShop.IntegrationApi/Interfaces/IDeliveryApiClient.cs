using DataTransferObjects.DTOs.Delivery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface IDeliveryApiClient
    {
        Task<List<ProvinceDto>> LoadProvince();

        Task<List<DistrictDto>> LoadDistrict(int proviceId);

        Task<List<WardDto>> LoadWard(int districtId);

        Task<decimal> CalShippingFee(int districtId, string wardCode, int deliveryType, decimal subtotal, int productCount);
    }
}
