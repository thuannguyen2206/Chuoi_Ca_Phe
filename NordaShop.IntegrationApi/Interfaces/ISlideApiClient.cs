using DataTransferObjects.DTOs.Sliders;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface ISlideApiClient
    {
        Task<ApiResult<List<SliderDto>>> GetDashboardSlide();

        Task<ApiResult<List<SliderDto>>> GetAll();

        Task<ApiResult<SliderDto>> GetById(int id);

        Task<bool> Create(CESliderDto slider);

        Task<bool> Update(int id, CESliderDto slider);

        Task<bool> Delete(int id);
    }
}
