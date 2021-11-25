using DataTransferObjects.DTOs.Products;
using DataTransferObjects.DTOs.Utilities;
using Microsoft.AspNetCore.Http;
using Service.ApiResponse;
using System.Collections.Generic;

namespace Service.IServices
{
    public interface IProductService
    {
        /// <summary>
        /// Get all product
        /// </summary>
        /// <returns></returns>
        ApiResult<List<ProductDto>> GetAll();

        /// <summary>
        /// Get related product by id
        /// </summary>
        /// <returns></returns>
        ApiResult<List<ProductDto>> GetRelated(int productId);

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        ApiResult<ProductDto> GetById(int id, bool isAdmin = false);

        /// <summary>
        /// Get products paging
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        PageResult<List<ProductDto>> GetPaging(SitePagingDto paging);

        /// <summary>
        /// Get products paging admin
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        PageResult<List<ProductDto>> GetAdminPaging(ProductAdminPagingDto paging);

        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ApiResult<int> Create(ProductCreateDto model);

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        ApiResult<int> Update(int id, ProductUpdateDto model);

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApiResult<bool> Delete(int id);

        /// <summary>
        /// Upload images, the first image is default
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ApiResult<bool> UploadImages(int productId, List<IFormFile> images);

        /// <summary>
        /// Load product images
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        ApiResult<List<ProductImageDto>> LoadProductImages(int productId);

        /// <summary>
        /// Get 2 product on banner
        /// </summary>
        /// <returns></returns>
        ApiResult<List<ProductDto>> GetBanner();

        /// <summary>
        /// Get products by tab name
        /// </summary>
        /// <returns></returns>
        ApiResult<List<ProductDto>> GetTabProducts(string tabname);

        /// <summary>
        /// Get max price of products
        /// </summary>
        /// <returns></returns>
        ApiResult<decimal> GetMaxPrice();

        /// <summary>
        /// Get list product for auto complete search
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        ApiResult<List<ProductAutocompleteSearchDto>> Search(string keyword);

        /// <summary>
        /// Remove all product image by productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        ApiResult<bool> RemoveAllImages(int productId);

        /// <summary>
        /// Get total active products
        /// </summary>
        /// <returns></returns>
        ApiResult<int> TotalActives();

        /// <summary>
        /// Get total products sold
        /// </summary>
        /// <returns></returns>
        ApiResult<int> TotalSolds();

        /// <summary>
        /// Get rating of product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        ApiResult<List<ProductRatingDto>> GetProductRatings(int productId, bool adminRole = false);

        ApiResult<int> CreateNewRating(ProductRatingDto dto);

    }
}
