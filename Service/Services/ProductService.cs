using Common.Constants;
using Common.Enums;
using Common.Helper;
using Common.Messages;
using DataAccess.Entities;
using DataTransferObjects.DTOs.Products;
using DataTransferObjects.DTOs.Utilities;
using Microsoft.AspNetCore.Http;
using Repositories;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUtilityService _utilityService;

        public ProductService(IUnitOfWork uow, IUtilityService utilityService)
        {
            _uow = uow;
            _utilityService = utilityService;
        }

        public ApiResult<int> Create(ProductCreateDto dto)
        {
            var productRepo = _uow.GetRepository<Product>();

            try
            {
                var prodDetails = new List<ProductDetail>();
                var productDetail = new ProductDetail()
                {
                    Description = dto.Description,
                    Title = dto.Title,
                    SeoAlias = FriendlyStringHelper.GetFriendlyString(dto.SeoAlias)
                };
                prodDetails.Add(productDetail);

                var proImages = new List<ProductImage>();
                if (dto.Files != null && dto.Files.Count > 0)
                {
                    foreach (var item in dto.Files)
                    {
                        string path = _utilityService.SaveFile(item, "images/products/");
                        proImages.Add(new ProductImage()
                        {
                            ImageLink = path,
                            IsDefault = false,
                            DateCreated = DateTime.Now,
                        });
                    }
                    proImages.FirstOrDefault().IsDefault = true;
                }

                var proOptions = new List<ProductOption>();
                if (dto.Options != null && dto.Options.Length > 0)
                {
                    foreach (var item in dto.Options)
                    {
                        proOptions.Add(new ProductOption()
                        {
                            IsDefault = false,
                            OptionId = item
                        });
                    }
                }

                var tagInProduct = new List<TagInProduct>();
                if (dto.Tags != null && dto.Tags.Length > 0)
                {
                    foreach (var item in dto.Tags)
                    {
                        tagInProduct.Add(new TagInProduct()
                        {
                            TagId = item
                        });
                    }
                }

                var product = new Product()
                {
                    BrandId = dto.BrandId,
                    Name = dto.Name,
                    ColorId = dto.ColorId,
                    CodeProduct = dto.CodeProduct,
                    Price = dto.Price,
                    TotalInStock = dto.Stock,
                    IsActive = dto.IsActive,
                    CategoryId = dto.CategoryId,
                    ProductDetails = prodDetails,
                    DateCreated = DateTime.Now,
                    OnTopHot = dto.OnTopHot,
                    IsDelete = false,
                    OnBanner = dto.OnBanner,
                    ProductImages = proImages,
                    ProductOptions = proOptions,
                    DiscountPrice = dto.DiscountPrice,
                    TagInProducts = tagInProduct,
                    OriginalPrice = dto.OriginalPrice
                };

                productRepo.Insert(product);
                _uow.SaveChanges();
                return new ApiResult<int>(true, product.Id);
            }
            catch (Exception)
            {
                return new ApiResult<int>(false, errorCode: ProductMessage.CreateFailed);
            }
        }

        public ApiResult<bool> Delete(int id)
        {
            var productRepo = _uow.GetRepository<Product>();
            var product = productRepo.FindById(id);
            if (product != null)
            {
                product.IsActive = false;
                product.IsDelete = true;

                _uow.SaveChanges();
                return new ApiResult<bool>(true);
            }
            return new ApiResult<bool>(false, errorCode: ProductMessage.NotFound);
        }

        public ApiResult<List<ProductDto>> GetAll()
        {
            try
            {
                var categoryRepo = _uow.GetRepository<Category>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
                var brandRepo = _uow.GetRepository<Brand>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
                var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
                var productImageRepo = _uow.GetRepository<ProductImage>().QueryConditionReadOnly(x => x.IsDefault);
                var productDetailRepo = _uow.GetRepository<ProductDetail>().QueryAllReadOnly();

                var result = (from a in productRepo
                              join b in productImageRepo on a.Id equals b.ProductId into pi
                              from b in pi.DefaultIfEmpty()
                              join c in brandRepo on a.BrandId equals c.Id
                              join d in categoryRepo on a.CategoryId equals d.Id
                              join e in productDetailRepo on a.Id equals e.ProductId
                              select new ProductDto()
                              {
                                  Id = a.Id,
                                  BrandName = c.BrandName,
                                  CategoryName = d.Name,
                                  Name = a.Name,
                                  CodeProduct = a.CodeProduct,
                                  DateCreated = a.DateCreated,
                                  Description = e.Description,
                                  IsActive = a.IsActive,
                                  Price = a.Price,
                                  Title = e.Title,
                                  TotalInStock = a.TotalInStock,
                                  DefaultImage = b.ImageLink
                              }).ToList();

                return new ApiResult<List<ProductDto>>(true, data: result);
            }
            catch (Exception)
            {
                return new ApiResult<List<ProductDto>>(false, errorCode: ProductMessage.NotFound);
            }
        }

        // Get product and increment view count
        public ApiResult<ProductDto> GetById(int id, bool isAdmin = false)
        {
            var brandRepo = _uow.GetRepository<Brand>().QueryConditionReadOnly(x => x.IsActive);
            var categoryRepo = _uow.GetRepository<Category>().QueryConditionReadOnly(x => x.IsActive);
            var productDetailRepo = _uow.GetRepository<ProductDetail>().Single(x => x.ProductId == id);
            var ratingRepo = _uow.GetRepository<Rating>().QueryConditionReadOnly(x => x.ProductId == id);
            var productRepo = _uow.GetRepository<Product>();
            var product = productRepo.Single(x => x.Id == id && !x.IsDelete);
            var optionRepo = _uow.GetRepository<Option>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);

            if (product != null)
            {
                if (!isAdmin && !product.IsActive)
                {
                    return new ApiResult<ProductDto>(false, errorCode: ProductMessage.NotFound);
                }

                var productImages = _uow.GetRepository<ProductImage>()
                .QueryConditionReadOnly(x => x.ProductId == id)
                .Select(x => new ProductImageDto()
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    DateCreated = x.DateCreated,
                    ImageLink = x.ImageLink,
                    IsDefault = x.IsDefault
                }).ToList();

                var color = optionRepo.FirstOrDefault(x => x.Id == product.ColorId);
                var result = new ProductDto()
                {
                    Id = product.Id,
                    BrandId = product.BrandId,
                    CodeProduct = product.CodeProduct,
                    DateCreated = product.DateCreated,
                    Description = productDetailRepo.Description,
                    SeoAlias = productDetailRepo.SeoAlias,
                    OnBanner = product.OnBanner,
                    OnTopHot = product.OnTopHot,
                    DefaultImage = productImages.Count > 0 ? productImages.FirstOrDefault(x => x.IsDefault).ImageLink : SystemConstants.DefaultImage,
                    IsActive = product.IsActive,
                    Name = product.Name,
                    Price = product.Price,
                    Title = productDetailRepo.Title,
                    TotalInStock = product.TotalInStock,
                    ProductImages = productImages ?? null,
                    CategoryId = product.CategoryId,
                    BrandName = brandRepo.FirstOrDefault(x => x.Id == product.BrandId).BrandName,
                    CategoryName = categoryRepo.FirstOrDefault(x => x.Id == product.CategoryId).Name,
                    DiscountPrice = product.DiscountPrice,
                    OrderCount = product.OrderCount,
                    RatingStar = ratingRepo.Any() ? ratingRepo.Average(x => x.RatingStar) : 0,
                    RatingCount = ratingRepo.Any() ? ratingRepo.Count() : 0,
                    ColorId = product.ColorId,
                    ColorName = color != null ? color.NameOption : string.Empty,
                    OriginalPrice = product.OriginalPrice
                };
                if (!isAdmin)
                {
                    product.ViewCount++;
                    productRepo.Update(product);
                    _uow.SaveChanges();
                }
                return new ApiResult<ProductDto>(true, data: result);
            }
            return new ApiResult<ProductDto>(false, errorCode: ProductMessage.NotFound);
        }

        public PageResult<List<ProductDto>> GetPaging(SitePagingDto paging)
        {
            var categoryRepo = _uow.GetRepository<Category>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var brandRepo = _uow.GetRepository<Brand>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var productImageRepo = _uow.GetRepository<ProductImage>().QueryConditionReadOnly(x => x.IsDefault);
            var productDetailRepo = _uow.GetRepository<ProductDetail>().QueryAllReadOnly();
            var ratingRepo = _uow.GetRepository<Rating>().QueryAllReadOnly();

            var query = (from a in productRepo
                         join b in brandRepo on a.BrandId equals b.Id
                         join c in categoryRepo on a.CategoryId equals c.Id
                         join d in productDetailRepo on a.Id equals d.ProductId
                         let rating = ratingRepo.Where(x => x.ProductId == a.Id).AsEnumerable()
                         select new
                         {
                             rating,
                             b.BrandName,
                             a.CodeProduct,
                             a.DateCreated,
                             d.Description,
                             a.IsActive,
                             a.Price,
                             a.DiscountPrice,
                             d.Title,
                             d.SeoAlias,
                             a.OrderCount,
                             a.TotalInStock,
                             ProductId = a.Id,
                             BrandId = b.Id,
                             CategoryId = c.Id,
                             CategoryName = c.Name,
                             ProductName = a.Name,
                             a.ColorId
                         }).AsEnumerable();

            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                paging.Keyword = paging.Keyword.Trim().ToLower();
                query = query.Where(x => x.ProductName.ToLower().Contains(paging.Keyword)
                                  || x.CategoryName.ToLower().Contains(paging.Keyword)
                                  || x.BrandName.ToLower().Contains(paging.Keyword));
            }
            if (paging.CategoryId != null && paging.CategoryId != 0)
            {
                query = query.Where(x => x.CategoryId == paging.CategoryId.Value);
            }
            if (paging.TagId != null && paging.TagId != 0)
            {
                var tagRepo = _uow.GetRepository<Tag>().QueryConditionReadOnly(x => x.IsActive);
                var tagInProductRepo = _uow.GetRepository<TagInProduct>().QueryAllReadOnly();
                var tagInProduct = (from a in tagRepo
                                    join b in tagInProductRepo on a.Id equals b.TagId
                                    where a.Id == paging.TagId
                                    select b.ProductId).AsEnumerable();

                query = query.Where(x => tagInProduct.Contains(x.ProductId));
            }
            switch (paging.SortProduct)
            {
                case SortProduct.Default:
                    query = query.OrderByDescending(x => x.ProductId);
                    break;
                case SortProduct.Name:
                    query = query.OrderBy(x => x.ProductName);
                    break;
                case SortProduct.OnSale:
                    query = query.Where(x => x.DiscountPrice > 0).OrderByDescending(x => x.DiscountPrice);
                    break;
                case SortProduct.NewArrivals:
                    query = query.OrderByDescending(x => x.ProductId);
                    break;
                case SortProduct.IncrementPrice:
                    query = query.OrderBy(x => x.Price - x.DiscountPrice);
                    break;
                case SortProduct.DecrementPrice:
                    query = query.OrderByDescending(x => x.Price - x.DiscountPrice);
                    break;
                default:
                    break;
            }

            if (paging.FromPrice <= paging.ToPrice && paging.ToPrice > 0)
            {
                query = query.Where(x => (x.Price - x.DiscountPrice) >= paging.FromPrice && (x.Price - x.DiscountPrice) <= paging.ToPrice);
            }

            if (paging.Options != null && paging.Options.Length > 0)
            {
                var optionRepo = _uow.GetRepository<Option>().QueryConditionReadOnly(x => !x.IsDelete);
                var productOptionRepo = _uow.GetRepository<ProductOption>().QueryAllReadOnly();
                var productOption = (from a in optionRepo
                                     join b in productOptionRepo on a.Id equals b.OptionId
                                     select b).AsEnumerable();

                query = query.Where(x => productOption.Where(y => y.ProductId == x.ProductId)
                            .Any(y => paging.Options.Contains(y.OptionId) || paging.Options.Contains(x.ColorId)));
            }

            if (paging.Brands != null && paging.Brands.Length > 0)
            {
                query = query.Where(x => paging.Brands.Contains(x.BrandId));
            }

            int totalRow = query.Count();
            var result = query.Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .Select(x =>
                {
                    var defaultImage = productImageRepo.FirstOrDefault(y => y.ProductId == x.ProductId);
                    return new ProductDto
                    {
                        Id = x.ProductId,
                        BrandName = x.BrandName,
                        BrandId = x.BrandId,
                        CategoryId = x.CategoryId,
                        CategoryName = x.CategoryName,
                        Name = x.ProductName,
                        CodeProduct = x.CodeProduct,
                        DateCreated = x.DateCreated,
                        Description = x.Description,
                        SeoAlias = x.SeoAlias,
                        IsActive = x.IsActive,
                        Price = x.Price,
                        Title = x.Title,
                        TotalInStock = x.TotalInStock,
                        DefaultImage = defaultImage != null ? defaultImage.ImageLink : SystemConstants.DefaultImage,
                        DiscountPrice = x.DiscountPrice,
                        OrderCount = x.OrderCount,
                        RatingStar = x.rating.Count() > 0 ? x.rating.Average(y => y.RatingStar) : 0,
                        RatingCount = x.rating.Count()
                    };
                }).ToList();

            var pageResult = new PageResult<List<ProductDto>>()
            {
                Items = result,
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize,
                TotalRecords = totalRow
            };
            return pageResult;
        }

        // change option: remove old list option and add new list in dto
        public ApiResult<int> Update(int id, ProductUpdateDto dto)
        {
            var productRepo = _uow.GetRepository<Product>();
            var productDetailRepo = _uow.GetRepository<ProductDetail>();
            var productOptionRepo = _uow.GetRepository<ProductOption>();
            var tagInProductRepo = _uow.GetRepository<TagInProduct>();

            var product = productRepo.Single(x => x.Id == id && !x.IsDelete);
            if (product != null)
            {
                product.BrandId = dto.BrandId;
                product.CategoryId = dto.CategoryId;
                product.CodeProduct = dto.CodeProduct;
                product.DateModified = DateTime.Now;
                product.IsActive = dto.IsActive;
                product.Name = dto.Name;
                product.Price = dto.Price;
                product.DiscountPrice = dto.DiscountPrice;
                product.OnBanner = dto.OnBanner;
                product.OnTopHot = dto.OnTopHot;
                product.ColorId = dto.ColorId;
                product.OriginalPrice = dto.OriginalPrice;

                var productDetail = productDetailRepo.Single(x => x.ProductId == id);
                productDetail.Description = dto.Description;
                productDetail.Title = dto.Title;
                productDetail.SeoAlias = FriendlyStringHelper.GetFriendlyString(dto.SeoAlias);

                var productOptions = productOptionRepo.QueryConditionReadOnly(x => x.ProductId == id).AsEnumerable();
                var options = new List<ProductOption>();
                foreach (var item in dto.Options ?? Enumerable.Empty<int>())
                {
                    options.Add(new ProductOption()
                    {
                        IsDefault = false,
                        ProductId = id,
                        OptionId = item
                    });
                }

                var tagInProduct = tagInProductRepo.QueryConditionReadOnly(x => x.ProductId == id).AsEnumerable();
                var tags = new List<TagInProduct>();
                foreach (var item in dto.Tags ?? Enumerable.Empty<int>())
                {
                    tags.Add(new TagInProduct()
                    {
                        ProductId = id,
                        TagId = item
                    });
                }

                productRepo.Update(product);
                productOptionRepo.DeleteRange(productOptions);
                productOptionRepo.InsertRange(options);
                productDetailRepo.Update(productDetail);
                tagInProductRepo.DeleteRange(tagInProduct);
                tagInProductRepo.InsertRange(tags);
                _uow.SaveChanges();
                return new ApiResult<int>(true, data: product.Id);
            }
            return new ApiResult<int>(false, errorCode: ProductMessage.NotFound);
        }

        public ApiResult<bool> UploadImages(int productId, List<IFormFile> images)
        {
            if (images == null || images.Count < 1)
            {
                return new ApiResult<bool>(false, errorCode: "NoFileToUpload");
            }

            var productRepo = _uow.GetRepository<Product>();
            var productImageRepo = _uow.GetRepository<ProductImage>();
            var product = productRepo.Single(x => x.Id == productId && !x.IsDelete);

            if (product != null)
            {
                var productImages = new List<ProductImage>();
                foreach (var image in images)
                {
                    string path = _utilityService.SaveFile(image, "images/products/");
                    productImages.Add(new ProductImage()
                    {
                        ImageLink = path,
                        IsDefault = false,
                        ProductId = productId,
                        DateCreated = DateTime.Now,
                    });
                }
                var checkDefault = productImageRepo.Single(x => x.ProductId == productId && x.IsDefault);
                if (checkDefault == null)
                {
                    productImages.FirstOrDefault().IsDefault = true;
                }

                productImageRepo.InsertRange(productImages);
                _uow.SaveChanges();
                return new ApiResult<bool>(true);
            }
            return new ApiResult<bool>(false, errorCode: ProductMessage.NotFound);
        }

        public ApiResult<List<ProductImageDto>> LoadProductImages(int productId)
        {
            var productRepo = _uow.GetRepository<Product>();
            var productImageRepo = _uow.GetRepository<ProductImage>(); ;
            var product = productRepo.FindById(productId);
            if (product != null)
            {
                var result = productImageRepo.QueryConditionReadOnly(x => x.ProductId == productId)
                    .Select(x => new ProductImageDto()
                    {
                        Id = x.Id,
                        DateCreated = x.DateCreated,
                        ImageLink = x.ImageLink,
                        ProductId = x.ProductId,
                        IsDefault = x.IsDefault
                    }).ToList();

                return new ApiResult<List<ProductImageDto>>(true, data: result);
            }
            return new ApiResult<List<ProductImageDto>>(false, errorCode: ProductMessage.NotFound);
        }

        public ApiResult<List<ProductDto>> GetBanner()
        {
            try
            {
                var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
                var productImageRepo = _uow.GetRepository<ProductImage>().QueryConditionReadOnly(x => x.IsDefault);
                var productDetailRepo = _uow.GetRepository<ProductDetail>().QueryAllReadOnly();

                var result = (from a in productRepo
                              join b in productDetailRepo on a.Id equals b.ProductId
                              where a.OnBanner == true
                              orderby a.Id descending
                              select new ProductDto()
                              {
                                  Id = a.Id,
                                  Name = a.Name,
                                  CodeProduct = a.CodeProduct,
                                  DateCreated = a.DateCreated,
                                  Description = b.Description,
                                  IsActive = a.IsActive,
                                  Price = a.Price,
                                  Title = b.Title,
                                  SeoAlias = b.SeoAlias,
                                  DefaultImage = productImageRepo.FirstOrDefault(x => x.ProductId == a.Id).ImageLink ?? SystemConstants.DefaultImage
                              }).Take(SystemConstants.Banner)
                              .ToList();

                return new ApiResult<List<ProductDto>>(true, data: result);
            }
            catch (Exception)
            {
                return new ApiResult<List<ProductDto>>(false, errorCode: ProductMessage.NotFound);
            }
        }

        public ApiResult<List<ProductDto>> GetTabProducts(string tabname)
        {
            try
            {
                var productDetailRepo = _uow.GetRepository<ProductDetail>().QueryAllReadOnly();
                var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
                var productImageRepo = _uow.GetRepository<ProductImage>().QueryConditionReadOnly(x => x.IsDefault);

                var query = (from a in productRepo
                             join b in productDetailRepo on a.Id equals b.ProductId
                             select new
                             {
                                 a.Id,
                                 BrandId = b.Id,
                                 a.Name,
                                 a.CodeProduct,
                                 a.DateCreated,
                                 b.Description,
                                 a.IsActive,
                                 a.Price,
                                 a.DiscountPrice,
                                 b.SeoAlias,
                                 b.Title,
                                 a.OrderCount,
                                 a.OnTopHot
                             }).AsEnumerable();

                query = tabname.Trim().ToLower() switch
                {
                    SystemConstants.Tab.BestSellers => query.OrderByDescending(x => x.OrderCount).ThenBy(x => x.Name),
                    SystemConstants.Tab.NewArrivals => query.OrderByDescending(x => x.Id).ThenBy(x => x.Name),
                    SystemConstants.Tab.Trending => query.OrderByDescending(x => x.OnTopHot).ThenBy(x => x.Name),
                    SystemConstants.Tab.TopSales => query.OrderByDescending(x => x.DiscountPrice).ThenBy(x => x.Name),
                    _ => query.OrderByDescending(x => x.Id).ThenBy(x => x.Name),
                };

                var result = query.Take(SystemConstants.TabProductQuantity)
                    .Select(x =>
                    {
                        var image = productImageRepo.FirstOrDefault(y => y.ProductId == x.Id);
                        return new ProductDto
                        {
                            Id = x.Id,
                            BrandId = x.BrandId,
                            Name = x.Name,
                            CodeProduct = x.CodeProduct,
                            DateCreated = x.DateCreated,
                            Description = x.Description,
                            SeoAlias = x.SeoAlias,
                            IsActive = x.IsActive,
                            Price = x.Price,
                            Title = x.Title,
                            DiscountPrice = x.DiscountPrice,
                            DefaultImage = image != null ? image.ImageLink : SystemConstants.DefaultImage
                        };
                    }).ToList();

                return new ApiResult<List<ProductDto>>(true, data: result);
            }
            catch (Exception)
            {
                return new ApiResult<List<ProductDto>>(false, errorCode: ProductMessage.NotFound);
            }
        }

        public ApiResult<List<ProductDto>> GetRelated(int productId)
        {
            var categoryRepo = _uow.GetRepository<Category>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var brandRepo = _uow.GetRepository<Brand>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var productImageRepo = _uow.GetRepository<ProductImage>().QueryConditionReadOnly(x => x.IsDefault);
            var productDetailRepo = _uow.GetRepository<ProductDetail>().QueryAllReadOnly();
            var ratingRepo = _uow.GetRepository<Rating>().QueryAllReadOnly();

            var product = productRepo.FirstOrDefault(x => x.Id == productId);
            if (product == null)
            {
                return new ApiResult<List<ProductDto>>(false, errorCode: ProductMessage.NotFound);
            }

            var result = (from a in productRepo
                          join b in productImageRepo on a.Id equals b.ProductId into pi
                          from b in pi.DefaultIfEmpty()
                          join c in productDetailRepo on a.Id equals c.ProductId
                          where a.CategoryId == product.CategoryId && a.Id != productId
                          orderby a.Id descending
                          let rating = ratingRepo.Where(x => x.ProductId == a.Id).Select(x => x.RatingStar).AsEnumerable()
                          select new ProductDto()
                          {
                              Id = a.Id,
                              Name = a.Name,
                              CodeProduct = a.CodeProduct,
                              DateCreated = a.DateCreated,
                              Description = c.Description,
                              SeoAlias = c.SeoAlias,
                              IsActive = a.IsActive,
                              Price = a.Price,
                              Title = c.Title,
                              TotalInStock = a.TotalInStock,
                              DefaultImage = b.ImageLink,
                              DiscountPrice = a.DiscountPrice,
                              RatingStar = rating.Count() > 0 ? rating.Average() : 0,
                              RatingCount = rating.Count() > 0 ? rating.Count() : 0
                          }).Take(SystemConstants.ProductRelated)
                          .ToList();

            return new ApiResult<List<ProductDto>>(true, data: result);
        }

        public ApiResult<decimal> GetMaxPrice()
        {
            var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            if (productRepo == null)
            {
                return new ApiResult<decimal>(false);
            }
            var result = productRepo.Max(x => x.Price);
            return new ApiResult<decimal>(true, result);
        }

        public ApiResult<List<ProductAutocompleteSearchDto>> Search(string keyword)
        {
            var categoryRepo = _uow.GetRepository<Category>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var brandRepo = _uow.GetRepository<Brand>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var productImageRepo = _uow.GetRepository<ProductImage>().QueryConditionReadOnly(x => x.IsDefault);
            var productDetailRepo = _uow.GetRepository<ProductDetail>().QueryAllReadOnly();
            var ratingRepo = _uow.GetRepository<Rating>().QueryAllReadOnly();

            var query = (from a in productRepo
                         join b in brandRepo on a.BrandId equals b.Id
                         join c in categoryRepo on a.CategoryId equals c.Id
                         join d in productDetailRepo on a.Id equals d.ProductId
                         select new
                         {
                             b.BrandName,
                             CategoryName = c.Name,
                             ProductName = a.Name,
                             ProductTitile = d.Title,
                             ProductId = a.Id,
                             d.SeoAlias
                         }).AsEnumerable();

            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.Trim().ToLower();
                query = query.Where(x => x.ProductName.ToLower().Contains(keyword)
                                  || x.BrandName.ToLower().Contains(keyword)
                                  || x.CategoryName.ToLower().Contains(keyword));
            }

            var result = query.Take(SystemConstants.AutocompleteSearch)
                .Select(x =>
                {
                    var image = productImageRepo.FirstOrDefault(y => y.ProductId == x.ProductId);
                    return new ProductAutocompleteSearchDto()
                    {
                        Name = x.ProductName,
                        DefaultImage = image != null ? image.ImageLink : SystemConstants.DefaultImage,
                        Id = x.ProductId,
                        SeoAlias = x.SeoAlias
                    };
                }).ToList();
            return new ApiResult<List<ProductAutocompleteSearchDto>>(true, data: result);
        }

        public PageResult<List<ProductDto>> GetAdminPaging(ProductAdminPagingDto paging)
        {
            var categoryRepo = _uow.GetRepository<Category>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var brandRepo = _uow.GetRepository<Brand>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => !x.IsDelete);
            var productImageRepo = _uow.GetRepository<ProductImage>().QueryConditionReadOnly(x => x.IsDefault);
            var productDetailRepo = _uow.GetRepository<ProductDetail>().QueryAllReadOnly();
            var ratingRepo = _uow.GetRepository<Rating>().QueryAllReadOnly();
            var productOptionRepo = _uow.GetRepository<ProductOption>().QueryAllReadOnly();

            var query = (from a in productRepo
                         join b in brandRepo on a.BrandId equals b.Id
                         join c in categoryRepo on a.CategoryId equals c.Id
                         join d in productDetailRepo on a.Id equals d.ProductId
                         let rating = ratingRepo.Where(x => x.ProductId == a.Id).AsEnumerable()
                         select new
                         {
                             rating,
                             b.BrandName,
                             a.CodeProduct,
                             a.DateCreated,
                             d.Description,
                             a.IsActive,
                             a.Price,
                             a.DiscountPrice,
                             d.Title,
                             a.OrderCount,
                             a.TotalInStock,
                             ProductId = a.Id,
                             BrandId = b.Id,
                             CategoryId = c.Id,
                             CategoryName = c.Name,
                             ProductName = a.Name,
                             d.SeoAlias
                         }).AsEnumerable();

            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                paging.Keyword = paging.Keyword.Trim().ToLower();
                query = query.Where(x => x.ProductName.ToLower().Contains(paging.Keyword)
                                  || x.CategoryName.ToLower().Contains(paging.Keyword)
                                  || x.BrandName.ToLower().Contains(paging.Keyword));
            }
            if (paging.CategoryId != null && paging.CategoryId != 0)
            {
                query = query.Where(x => x.CategoryId == paging.CategoryId);
            }
            if (paging.BrandId != null && paging.BrandId != 0)
            {
                query = query.Where(x => x.BrandId == paging.BrandId);
            }

            int totalRow = query.Count();
            var result = query.OrderByDescending(x => x.ProductId)
                .Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .Select(x =>
                {
                    var defaultImage = productImageRepo.FirstOrDefault(y => y.ProductId == x.ProductId);
                    return new ProductDto
                    {
                        Id = x.ProductId,
                        BrandName = x.BrandName,
                        BrandId = x.BrandId,
                        CategoryId = x.CategoryId,
                        CategoryName = x.CategoryName,
                        Name = x.ProductName,
                        CodeProduct = x.CodeProduct,
                        DateCreated = x.DateCreated,
                        Description = x.Description,
                        SeoAlias = x.SeoAlias,
                        IsActive = x.IsActive,
                        Price = x.Price,
                        Title = x.Title,
                        TotalInStock = x.TotalInStock,
                        DefaultImage = defaultImage != null ? defaultImage.ImageLink : SystemConstants.DefaultImage,
                        DiscountPrice = x.DiscountPrice,
                        OrderCount = x.OrderCount,
                        RatingStar = x.rating.Count() > 0 ? x.rating.Average(y => y.RatingStar) : 0,
                        RatingCount = x.rating.Count()
                    };
                }).ToList();

            var pageResult = new PageResult<List<ProductDto>>()
            {
                Items = result,
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize,
                TotalRecords = totalRow
            };
            return pageResult;
        }

        public ApiResult<bool> RemoveAllImages(int productId)
        {
            var productImageRepo = _uow.GetRepository<ProductImage>();
            var product = _uow.GetRepository<Product>().Single(x => x.Id == productId && !x.IsDelete);
            if (product == null)
            {
                return new ApiResult<bool>(false, errorCode: ProductMessage.NotFound);
            }
            try
            {
                var images = productImageRepo.QueryConditionReadOnly(x => x.ProductId == productId).AsEnumerable();
                string[] imageLinks = images.Select(x => x.ImageLink).ToArray();
                productImageRepo.DeleteRange(images);
                _uow.SaveChanges();

                foreach (var link in imageLinks ?? Enumerable.Empty<string>())
                {
                    _utilityService.RemoveFile(link);
                }
                return new ApiResult<bool>(true);
            }
            catch (Exception)
            {
                return new ApiResult<bool>(false);
            }
        }

        public ApiResult<int> TotalActives()
        {
            var products = _uow.GetRepository<Product>().QueryConditionReadOnly(x => !x.IsDelete && x.IsActive).Count();
            return new ApiResult<int>(true, data: products);
        }

        public ApiResult<int> TotalSolds()
        {
            var productsold = _uow.GetRepository<Product>().QueryConditionReadOnly(x => !x.IsDelete).Sum(x => x.OrderCount);
            return new ApiResult<int>(true, data: productsold);
        }

        public ApiResult<List<ProductRatingDto>> GetProductRatings(int productId, bool adminRole = false)
        {
            var product = _uow.GetRepository<Product>().Single(x => x.Id == productId && !x.IsDelete);

            if (product == null || (!adminRole && !product.IsActive))
            {
                return new ApiResult<List<ProductRatingDto>>(false, errorCode: ProductMessage.NotFound);
            }

            var ratingRepo = _uow.GetRepository<Rating>().QueryConditionReadOnly(x => x.ProductId == productId && !x.IsDelete);
            if (!adminRole)
            {
                ratingRepo = ratingRepo.Where(x => x.IsActive);
            }
            var result = ratingRepo.OrderByDescending(x => x.Id)
                .Take(SystemConstants.TopRatings)
                .Select(x => new ProductRatingDto()
                {
                    Id = x.Id,
                    DateCreated = x.DateCreated,
                    Name = x.Name,
                    ProductId = x.ProductId,
                    RatingContent = x.RatingContent,
                    RatingStar = x.RatingStar,
                    UserId = x.UserId
                }).ToList();
            return new ApiResult<List<ProductRatingDto>>(true, data: result);
        }

        public ApiResult<int> CreateNewRating(ProductRatingDto dto)
        {
            var ratingRepo = _uow.GetRepository<Rating>();
            var product = _uow.GetRepository<Product>().Single(x => x.Id == dto.ProductId && !x.IsDelete && x.IsActive);
            if (product == null)
            {
                return new ApiResult<int>(false, errorCode: ProductMessage.NotFound);
            }

            var entity = new Rating()
            {
                DateCreated = DateTime.Now,
                Email = dto.Email,
                IsActive = true,
                Name = dto.Name,
                ProductId = dto.ProductId,
                RatingContent = dto.RatingContent,
                RatingStar = dto.RatingStar,
                UserId = dto.UserId,
                IsDelete = false
            };
            ratingRepo.Insert(entity);
            _uow.SaveChanges();
            return new ApiResult<int>(true, data: entity.Id);
        }

    }
}
