using DataTransferObjects.DTOs.Sliders;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IServices
{
    public interface ISliderService
    {
        ApiResult<List<SliderDto>> GetDashboard();

        ApiResult<List<SliderDto>> GetAll();

        ApiResult<SliderDto> GetById(int id);

        ApiResult<int> Create(CESliderDto dto);

        ApiResult<int> Update(int id, CESliderDto dto);

        ApiResult<int> Delete(int id);
    }
}
