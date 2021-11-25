using DataTransferObjects.DTOs.Products;
using DataTransferObjects.DTOs.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using System;
using System.Collections.Generic;

namespace NordaShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("list")]
        [AllowAnonymous]
        public IActionResult GetPaging([FromQuery] SitePagingDto paging, [FromQuery(Name ="brand")] int[] brands, [FromQuery(Name = "option")] int[] options)
        {
            paging.Brands = brands;
            paging.Options = options;
            var result = _productService.GetPaging(paging);
            return Ok(result);
        }

        [HttpGet("admin-role/list")]
        public IActionResult GetAdminPaging([FromQuery] ProductAdminPagingDto paging)
        {
            var result = _productService.GetAdminPaging(paging);
            return Ok(result);
        }

        [HttpGet("{id}/related")]
        [AllowAnonymous]
        public IActionResult GetRelated(int id)
        {
            var result = _productService.GetRelated(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}/adminrole={isAdmin}")]
        [Route("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id, bool isAdmin = false)
        {
            var result = _productService.GetById(id, isAdmin);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("create"), DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        public IActionResult Create([FromForm] ProductCreateDto dto)
        {
            var result = _productService.Create(dto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}/update")]
        [Consumes("multipart/form-data")]
        public IActionResult Update(int id, [FromForm] ProductUpdateDto dto)
        {
            var result = _productService.Update(id, dto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("{productId}/upload-images")]
        public IActionResult UploadImage(int productId, [FromForm] List<IFormFile> images)
        {
            var result = _productService.UploadImages(productId, images);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{productId}/images")]
        public IActionResult LoadImages(int productId)
        {
            var result = _productService.LoadProductImages(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("banner")]
        [AllowAnonymous]
        public IActionResult GetBanner()
        {
            var result = _productService.GetBanner();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("tabname={tabname}")]
        [AllowAnonymous]
        public IActionResult GetTabProducts(string tabname)
        {
            var result = _productService.GetTabProducts(tabname);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("max-price")]
        [AllowAnonymous]
        public IActionResult GetMaxPrice()
        {
            var result = _productService.GetMaxPrice();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("keyword={keyword}")]
        [AllowAnonymous]
        public IActionResult Search(string keyword)
        {
            var result = _productService.Search(keyword);
            return Ok(result);
        }

        [HttpDelete("{productId}/remove-all-images")]
        public IActionResult RemoveAllImages(int productId)
        {
            var result = _productService.RemoveAllImages(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("total-actives")]
        public IActionResult TotalActives()
        {
            var result = _productService.TotalActives();
            return Ok(result);
        }

        [HttpGet("total-sold")]
        public IActionResult TotalSold()
        {
            var result = _productService.TotalSolds();
            return Ok(result);
        }

        [HttpGet("{productId}/ratings")]
        [AllowAnonymous]
        public IActionResult GetProductRating(int productId)
        {
            var result = _productService.GetProductRatings(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("create-rating")]
        [AllowAnonymous]
        public IActionResult CreateNewRating(ProductRatingDto dto)
        {
            var result = _productService.CreateNewRating(dto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
