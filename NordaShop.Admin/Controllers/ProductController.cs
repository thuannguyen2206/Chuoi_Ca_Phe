using AutoMapper;
using Common.Constants;
using Common.Enums;
using DataTransferObjects.DTOs.Options;
using DataTransferObjects.DTOs.Products;
using DataTransferObjects.DTOs.Tags;
using DataTransferObjects.DTOs.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NordaShop.Admin.Models.Option;
using NordaShop.Admin.Models.Product;
using NordaShop.Admin.Models.Tag;
using NordaShop.IntegrationApi.Interfaces;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IProductApiClient _productApi;
        private readonly IMapper _mapper;
        private readonly ICategoryApiClient _categoryApi;
        private readonly IBrandApiClient _brandApi;
        private readonly IOptionApiClient _optionApi;
        private readonly ITagApiClient _tagApi;

        public ProductController(IHttpContextAccessor httpContext, 
            IProductApiClient productApi,
            IMapper mapper, 
            ICategoryApiClient categoryApi, 
            IBrandApiClient brandApi, 
            IOptionApiClient optionApi,
            ITagApiClient tagApi)
        {
            _httpContext = httpContext;
            _productApi = productApi;
            _mapper = mapper;
            _categoryApi = categoryApi;
            _brandApi = brandApi;
            _optionApi = optionApi;
            _tagApi = tagApi;
        }

        public async Task<IActionResult> Index()
        {
            string keyword = _httpContext.HttpContext.Request.Query["keyword"].ToString();
            int.TryParse(_httpContext.HttpContext.Request.Query["pageindex"], out int pageIndex);
            int.TryParse(_httpContext.HttpContext.Request.Query["categoryid"], out int categoryid);
            int.TryParse(_httpContext.HttpContext.Request.Query["brandid"], out int brandid);

            var paging = new ProductAdminPagingDto()
            {
                CategoryId = categoryid,
                Keyword = keyword,
                PageIndex = pageIndex,
                BrandId = brandid
            };
            var products = await _productApi.GetAdminPagings(paging);
            var categories = await _categoryApi.GetAll();
            var brands = await _brandApi.GetAll();
            var model = new PageResult<List<ProductViewModel>>()
            {
                PageIndex = products.PageIndex,
                PageSize = products.PageSize,
                TotalRecords = products.TotalRecords,
                Items = _mapper.Map<List<ProductDto>, List<ProductViewModel>>(products.Items)
            };

            ViewBag.Categories = categories.Data.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = categoryid == x.Id
            });
            ViewBag.Brands = brands.Data.Select(x => new SelectListItem()
            {
                Text = x.BrandName,
                Value = x.Id.ToString(),
                Selected = brandid == x.Id
            });
            ViewBag.Keyword = keyword;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryApi.GetAll();
            var brands = await _brandApi.GetAll();
            var options = await _optionApi.GetOptions();
            var tags = await _tagApi.GetAll();
            ViewBag.Categories = categories.Data.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            ViewBag.Brands = brands.Data.Select(x => new SelectListItem()
            {
                Text = x.BrandName,
                Value = x.Id.ToString()
            });
            var model = new ProductCreateViewModel()
            {
                Options = _mapper.Map<List<OptionDto>, List<OptionViewModel>>(options.Data),
                Tags = _mapper.Map<List<TagDto>, List<TagViewModel>>(tags.Data)
            };
            return View(model);
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            var categories = await _categoryApi.GetAll();
            var brands = await _brandApi.GetAll();
            var listOption = await _optionApi.GetOptions();
            var listTag = await _tagApi.GetAll();
            ViewBag.Categories = categories.Data.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = x.Id == model.CategoryId
            });
            ViewBag.Brands = brands.Data.Select(x => new SelectListItem()
            {
                Text = x.BrandName,
                Value = x.Id.ToString(),
                Selected = x.Id == model.BrandId
            });

            if (!ModelState.IsValid)
            {
                model.Options = _mapper.Map<List<OptionDto>, List<OptionViewModel>>(listOption.Data);
                model.Tags = _mapper.Map<List<TagDto>, List<TagViewModel>>(listTag.Data);
                return View(model);
            }

            var optionArr = Request.Form["size"].ToArray();
            int[] options = Array.ConvertAll(optionArr, int.Parse);
            var tagArr = Request.Form["tag"].ToArray();
            int[] tags = Array.ConvertAll(tagArr, int.Parse);
            var dto = new ProductCreateDto()
            {
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                CodeProduct = model.CodeProduct,
                Description = model.Description,
                IsActive = model.IsActive,
                Name = model.Name,
                OnBanner = model.OnBanner,
                OnTopHot = model.OnTopHot,
                Price = model.Price,
                DiscountPrice = model.DiscountPrice,
                Title = model.Title,
                SeoAlias = model.SeoAlias,
                Files = model.Files,
                Options = options,
                Tags = tags,
                ColorId = model.ColorId,
                OriginalPrice = model.OriginalPrice
            };
            var success = await _productApi.Create(dto);
            if (success)
            {
                SetAlert(NotificationConstants.CreateSuccess, "success");
                return RedirectToAction(nameof(ProductController.Index));
            }

            SetAlert(NotificationConstants.CreateFailed, "error");
            model.Options = _mapper.Map<List<OptionDto>, List<OptionViewModel>>(listOption.Data);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productApi.GetById(id, true);
            if (product == null || !product.Success)
            {
                SetAlert(NotificationConstants.ProductNotFound, "error");
            }

            var categories = await _categoryApi.GetAll();
            var brands = await _brandApi.GetAll();
            var options = await _optionApi.GetOptions();
            var productOptions = await _optionApi.GetOptionByProductId(id);
            var tags = await _tagApi.GetAll();
            var tagInProducts = await _tagApi.GetTagOfProduct(id);
            ViewBag.Categories = categories.Data.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            ViewBag.Brands = brands.Data.Select(x => new SelectListItem()
            {
                Text = x.BrandName,
                Value = x.Id.ToString()
            });
            var model = new ProductEditViewModel()
            {
                ProductId = id,
                ColorId = product.Data.ColorId,
                BrandId = product.Data.BrandId,
                CategoryId = product.Data.CategoryId,
                CodeProduct = product.Data.CodeProduct,
                Description = product.Data.Description,
                DiscountPrice = product.Data.DiscountPrice,
                Price = product.Data.Price,
                OriginalPrice = product.Data.OriginalPrice,
                IsActive = product.Data.IsActive,
                Name = product.Data.Name,
                OnBanner = product.Data.OnBanner,
                OnTopHot = product.Data.OnTopHot,
                SeoAlias = product.Data.SeoAlias,
                Title = product.Data.Title,
                Stock = product.Data.TotalInStock,
                Options = _mapper.Map<List<OptionDto>, List<OptionViewModel>>(options.Data),
                Tags = _mapper.Map<List<TagDto>, List<TagViewModel>>(tags.Data)
            };
            foreach (var item in model.Options ?? Enumerable.Empty<OptionViewModel>())
            {
                if (productOptions != null && productOptions.Success)
                {
                    if (productOptions.Data.Any(x => x.Id == item.Id))
                    {
                        item.Checked = true;
                    }
                }
            }
            foreach (var item in model.Tags ?? Enumerable.Empty<TagViewModel>())
            {
                if (tagInProducts != null && tagInProducts.Success)
                {
                    if (tagInProducts.Data.Any(x => x.Id == item.Id))
                    {
                        item.Checked = true;
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            var categories = await _categoryApi.GetAll();
            var brands = await _brandApi.GetAll();
            var listOptions = await _optionApi.GetOptions();
            var productOptions = await _optionApi.GetOptionByProductId(model.ProductId);
            var listTags = await _tagApi.GetAll();
            var tagInProducts = await _tagApi.GetTagOfProduct(model.ProductId);
            ViewBag.Categories = categories.Data.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = x.Id == model.CategoryId
            });
            ViewBag.Brands = brands.Data.Select(x => new SelectListItem()
            {
                Text = x.BrandName,
                Value = x.Id.ToString(),
                Selected = x.Id == model.BrandId
            });

            model.Options = _mapper.Map<List<OptionDto>, List<OptionViewModel>>(listOptions.Data);
            model.Tags = _mapper.Map<List<TagDto>, List<TagViewModel>>(listTags.Data);
            foreach (var item in model.Options ?? Enumerable.Empty<OptionViewModel>())
            {
                if (productOptions != null && productOptions.Success)
                {
                    if (productOptions.Data.Any(x => x.Id == item.Id))
                    {
                        item.Checked = true;
                    }
                }
            }
            foreach (var item in model.Tags ?? Enumerable.Empty<TagViewModel>())
            {
                if (tagInProducts != null && tagInProducts.Success)
                {
                    if (tagInProducts.Data.Any(x => x.Id == item.Id))
                    {
                        item.Checked = true;
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var optionArr = Request.Form["size"].ToArray();
            int[] optionIds = Array.ConvertAll(optionArr, int.Parse);
            var tagArr = Request.Form["tag"].ToArray();
            int[] tagIds = Array.ConvertAll(tagArr, int.Parse);
            var dto = new ProductUpdateDto()
            {
                Id = model.ProductId,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                CodeProduct = model.CodeProduct,
                Description = model.Description,
                IsActive = model.IsActive,
                Name = model.Name,
                OnBanner = model.OnBanner,
                OnTopHot = model.OnTopHot,
                Price = model.Price,
                DiscountPrice = model.DiscountPrice,
                Title = model.Title,
                SeoAlias = model.SeoAlias,
                Options = optionIds,
                Tags = tagIds,
                ColorId = model.ColorId,
                OriginalPrice = model.OriginalPrice
            };
            var success = await _productApi.Update(model.ProductId, dto);
            if (success)
            {
                SetAlert(NotificationConstants.UpDateSuccess, "success");
                return RedirectToAction(nameof(ProductController.Index));
            }

            SetAlert(NotificationConstants.UpdateFailed, "error");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productApi.Delete(id);
            if (response)
            {
                SetAlert(NotificationConstants.DeleteSuccess, "success");
            }
            else
            {
                SetAlert(NotificationConstants.DeleteFailed, "error");
            }
            return RedirectToAction(nameof(UserController.Index));
        }

        [HttpGet]
        public IActionResult LoadProductImage(int productId)
        {
            return ViewComponent("Gallery", productId);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(int productid, List<IFormFile> images)
        {
            if (images == null || images.Count < 1)
            {
                SetAlert(NotificationConstants.FileNotFound, "warning");
            }
            var success = await _productApi.UploadImages(productid, images);
            if (success)
            {
                SetAlert(NotificationConstants.FileUploadSuccess, "success");
            }
            return RedirectToAction(nameof(ProductController.Index));
        }

        [HttpGet]
        public async Task<IActionResult> RemoveAllImages(int id) // product id
        {
            if (id < 1)
            {
                SetAlert(NotificationConstants.ProductNotFound, "warning");
            }
            else
            {
                var success = await _productApi.RemoveAllImages(id);
                if (success)
                {
                    SetAlert(NotificationConstants.DeleteSuccess, "success");
                }
                else
                {
                    SetAlert(NotificationConstants.DeleteFailed, "success");
                }
            }
            return RedirectToAction(nameof(ProductController.Index));
        }



    }
}
