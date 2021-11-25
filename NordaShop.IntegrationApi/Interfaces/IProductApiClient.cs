using DataTransferObjects.DTOs.Products;
using DataTransferObjects.DTOs.Utilities;
using Microsoft.AspNetCore.Http;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface IProductApiClient
    {
        Task<ApiResult<List<ProductDto>>> GetAll();

        Task<int> GetMaxPrice();

        Task<bool> Delete(int id);

        Task<bool> Create(ProductCreateDto dto);

        Task<bool> Update(int id, ProductUpdateDto dto);

        Task<ApiResult<List<ProductDto>>> GetRelated(int productId);

        Task<ApiResult<List<ProductRatingDto>>> GetProductRating(int productId);

        Task<ApiResult<int>> CreateNewRating(ProductRatingDto dto);

        Task<PageResult<List<ProductDto>>> GetPagings(SitePagingDto paging);

        Task<PageResult<List<ProductDto>>> GetAdminPagings(ProductAdminPagingDto paging);

        /// <summary>
        /// If role is admin, then set isAdmin parameter is true
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        Task<ApiResult<ProductDto>> GetById(int id, bool isAdmin = false);

        Task<ApiResult<List<ProductDto>>> Banners();

        Task<ApiResult<List<ProductDto>>> GetTabProducts(string tabname);

        Task<ApiResult<List<ProductAutocompleteSearchDto>>> Search(string keyword);

        Task<ApiResult<List<ProductImageDto>>> LoadProductImages(int productId);

        Task<bool> UploadImages(int productId, List<IFormFile> images);

        Task<bool> RemoveAllImages(int productId);

        Task<int> ToTalActives();

        Task<int> TotalSold();

    }
}
