using Common.Constants;
using Common.Messages;
using DataAccess.Entities;
using DataTransferObjects.DTOs.Sliders;
using Repositories;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class SliderService : ISliderService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUtilityService _utilityService;

        public SliderService(IUnitOfWork uow, IUtilityService utilityService)
        {
            _uow = uow;
            _utilityService = utilityService;
        }

        public ApiResult<int> Create(CESliderDto dto)
        {
            try
            {
                string path = _utilityService.SaveFile(dto.ImageFile, "images/sliders/");
                var entity = new Slide()
                {
                    Name = dto.Name,
                    SortOrder = dto.SortOrder,
                    Title = dto.Title,
                    ImageLink = path,
                    IsActive = dto.IsActive,
                    DateCreated = DateTime.Now,
                    IsDelete = false
                };
                _uow.GetRepository<Slide>().Insert(entity);
                _uow.SaveChanges();
                return new ApiResult<int>(true, entity.Id);
            }
            catch (Exception)
            {
                return new ApiResult<int>(false);
            }
        }

        public ApiResult<int> Delete(int id)
        {
            var slideRepo = _uow.GetRepository<Slide>();
            var slide = slideRepo.FindById(id);
            if (slide != null)
            {
                slide.IsDelete = true;
                slide.IsActive = false;
                slideRepo.Update(slide);
                _uow.SaveChanges();
                return new ApiResult<int>(true, data: slide.Id);
            }
            return new ApiResult<int>(false, errorCode: SliderMessage.NotFound);
        }

        public ApiResult<List<SliderDto>> GetDashboard()
        {
            var slideRepo = _uow.GetRepository<Slide>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);

            var result = slideRepo.OrderBy(x => x.SortOrder)
                .ThenByDescending(x => x.DateCreated)
                .Take(SystemConstants.DashboardSlide)
                .Select(x => new SliderDto()
                {
                    DateCreated = x.DateCreated,
                    Title = x.Title,
                    Id = x.Id,
                    ImageLink = x.ImageLink,
                    IsActive = x.IsActive,
                    Name = x.Name,
                    SortOrder = x.SortOrder
                }).ToList();

            return new ApiResult<List<SliderDto>>(true, data: result);
        }

        public ApiResult<SliderDto> GetById(int id)
        {
            var slide = _uow.GetRepository<Slide>().FindById(id);
            if (slide != null)
            {
                var result = new SliderDto()
                {
                    Id = slide.Id,
                    DateCreated = slide.DateCreated,
                    Title = slide.Title,
                    ImageLink = slide.ImageLink,
                    IsActive = slide.IsActive,
                    Name = slide.Name,
                    SortOrder = slide.SortOrder
                };

                return new ApiResult<SliderDto>(true, data: result);
            }
            return new ApiResult<SliderDto>(false, errorCode: SliderMessage.NotFound);
        }

        public ApiResult<int> Update(int id, CESliderDto dto)
        {
            var slideRepo = _uow.GetRepository<Slide>();

            var slide = slideRepo.FindById(id);
            if (slide != null)
            {
                if (dto.ImageFile != null)
                {
                    string path = _utilityService.SaveFile(dto.ImageFile, "images/sliders/");
                    slide.ImageLink = path;
                }

                slide.DateModified = DateTime.Now;
                slide.Title = dto.Title;
                slide.IsActive = dto.IsActive;
                slide.Name = dto.Name;
                slide.SortOrder = dto.SortOrder;

                slideRepo.Update(slide);
                _uow.SaveChanges();
                return new ApiResult<int>(true, data: slide.Id);
            }
            return new ApiResult<int>(false, errorCode: SliderMessage.NotFound);
        }

        public ApiResult<List<SliderDto>> GetAll()
        {
            var slideRepo = _uow.GetRepository<Slide>().QueryConditionReadOnly(x => !x.IsDelete);

            var result = slideRepo.OrderBy(x => x.SortOrder)
                .ThenByDescending(x => x.DateCreated)
                .Select(x => new SliderDto()
                {
                    DateCreated = x.DateCreated,
                    Title = x.Title,
                    Id = x.Id,
                    ImageLink = x.ImageLink,
                    IsActive = x.IsActive,
                    Name = x.Name,
                    SortOrder = x.SortOrder
                }).ToList();

            return new ApiResult<List<SliderDto>>(true, data: result);
        }
    }
}
