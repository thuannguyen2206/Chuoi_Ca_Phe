using Common.Constants;
using Common.Messages;
using DataAccess.Entities;
using DataAccess.Enums;
using DataTransferObjects.DTOs.Carts;
using Repositories;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _uow;
        private readonly IOptionService _optionService;

        public CartService(IUnitOfWork uow, IOptionService optionService)
        {
            _uow = uow;
            _optionService = optionService;
        }

        // if have value of cartid then find cart by id
        // else if have value of userid  then find cart by userid
        // if cart equal null => create new cart
        public ApiResult<int> AddToCart(AddCartItemDto dto)
        {
            var cartRepo = _uow.GetRepository<Cart>();
            var cartItemRepo = _uow.GetRepository<CartItem>();
            var userRepo = _uow.GetRepository<User>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete && x.EmailConfirmed);
            var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var optionRepo = _uow.GetRepository<Option>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);

            var product = productRepo.FirstOrDefault(x => x.Id == dto.ProductId);
            if (product == null)
            {
                return new ApiResult<int>(false, errorCode: CartMessage.CartItemNotFound);
            }
            
            int sizeId = 0;
            if (dto.SizeId == 0)
            {
                var defaultOption = _optionService.GetProductDefaultOption(dto.ProductId, ProductOptionGroup.Size);
                if (defaultOption != null && defaultOption.Success)
                {
                    sizeId = defaultOption.Data != null ? defaultOption.Data.Id : 0;
                }
            }
            else
            {
                var size = optionRepo.FirstOrDefault(x => x.Id == dto.SizeId);
                sizeId = size != null ? size.Id : 0;
            }

            Cart checkCart = null;
            if (dto.UserId != null && dto.UserId != Guid.Empty)
            {
                var user = userRepo.FirstOrDefault(x => x.Id == dto.UserId);
                if (user != null)
                {
                    checkCart = cartRepo.Single(x => x.UserId == dto.UserId);
                }
                else
                {
                    return new ApiResult<int>(false, errorCode: CartMessage.UserNotFound);
                }
            }

            // if cart == null => create new cart
            if (checkCart == null)
            {
                checkCart = new Cart
                {
                    UserId = dto.UserId,
                    DateCreated = DateTime.Now,
                    CartItems = new List<CartItem>
                    {
                        new CartItem()
                        {
                            ProductId = dto.ProductId,
                            Quantity = dto.Quantity,
                            DateCreated = DateTime.Now,
                            SizeOptionId = sizeId
                        }
                    }
                };
                cartRepo.Insert(checkCart);
            }
            else
            {
                // If cart is exist this product, return true and error code product is exist
                if (cartItemRepo.Single(x => x.CartId == checkCart.Id && x.ProductId == dto.ProductId && x.SizeOptionId == sizeId) != null)
                {
                    return new ApiResult<int>(true, errorCode: CartMessage.ExistProduct);
                }
                else
                {
                    cartItemRepo.Insert(new CartItem()
                    {
                        ProductId = dto.ProductId,
                        Quantity = dto.Quantity,
                        DateCreated = DateTime.Now,
                        CartId = checkCart.Id,
                        SizeOptionId = sizeId
                    });
                }
            }
            _uow.SaveChanges();
            return new ApiResult<int>(true, data: checkCart.Id);
        }

        public ApiResult<bool> Delete(int cartId)
        {
            var cartRepo = _uow.GetRepository<Cart>();
            var cartItemRepo = _uow.GetRepository<CartItem>();
            var cart = cartRepo.FindById(cartId);
            if (cart != null)
            {
                var cartItems = cartItemRepo.QueryConditionReadOnly(x => x.CartId == cartId).AsEnumerable();
                cartItemRepo.DeleteRange(cartItems);
                cartRepo.Delete(cart);
                _uow.SaveChanges();
                return new ApiResult<bool>(true);
            }
            return new ApiResult<bool>(false, errorCode: CartMessage.NotFound);
        }

        public ApiResult<CartDto> GetCart(int cartId)
        {
            var cart = _uow.GetRepository<Cart>().FindById(cartId);
            if (cart == null)
            {
                return new ApiResult<CartDto>(false, errorCode: CartMessage.NotFound);
            }
            var optionRepo = _uow.GetRepository<Option>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var cartItemRepo = _uow.GetRepository<CartItem>().QueryConditionReadOnly(x => x.CartId == cartId);
            var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var productImageRepo = _uow.GetRepository<ProductImage>().QueryConditionReadOnly(x => x.IsDefault);

            var cartItems = (from a in cartItemRepo
                             join b in productRepo on a.ProductId equals b.Id
                             join c in productImageRepo on b.Id equals c.ProductId into pi
                             from c in pi.DefaultIfEmpty()
                             where a.CartId == cartId
                             select new CartItemDto()
                             {
                                 CartId = cartId,
                                 DateCreated = a.DateCreated,
                                 Id = a.Id,
                                 Price = (b.Price - b.DiscountPrice),
                                 Quantity = a.Quantity,
                                 ProductId = a.ProductId,
                                 ProductName = b.Name,
                                 ImageLink = c.ImageLink,
                                 SizeName = optionRepo.FirstOrDefault(x => x.Id == a.SizeOptionId).NameOption
                             }).ToList();

            var result = new CartDto()
            {
                DateCreated = cart.DateCreated,
                Id = cart.Id,
                TotalProducts = cartItems.Count(),
                UserId = cart.UserId,
                CartItems = cartItems
            };
            return new ApiResult<CartDto>(true, data: result);
        }

        // if cart not exist, create new cart
        // ortherwise get cart info
        public ApiResult<CartDto> GetCart(Guid userId)
        {
            var cartItemRepo = _uow.GetRepository<CartItem>().QueryAllReadOnly();
            var cartRepo = _uow.GetRepository<Cart>();
            var optionRepo = _uow.GetRepository<Option>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var productImageRepo = _uow.GetRepository<ProductImage>().QueryConditionReadOnly(x => x.IsDefault);

            var user = _uow.GetRepository<User>().Single(x => x.IsActive && !x.IsDelete && x.Id == userId);

            if (user == null)
            {
                return new ApiResult<CartDto>(false, CartMessage.UserNotFound);
            }

            var checkCart = cartRepo.Single(x => x.UserId == userId);
            if (checkCart == null)
            {
                var cart = new Cart()
                {
                    UserId = userId,
                    DateCreated = DateTime.Now
                };
                cartRepo.Insert(cart);
                _uow.SaveChanges();

                var dto = new CartDto()
                {
                    CartItems = new List<CartItemDto>(),
                    DateCreated = cart.DateCreated,
                    Id = cart.Id,
                    TotalProducts = 0,
                    UserId = userId
                };
                return new ApiResult<CartDto>(true, data: dto);
            }

            var cartItems = (from a in cartItemRepo
                             join b in productRepo on a.ProductId equals b.Id
                             join c in productImageRepo on b.Id equals c.ProductId into pi
                             from c in pi.DefaultIfEmpty()
                             where a.CartId == checkCart.Id
                             select new CartItemDto()
                             {
                                 CartId = checkCart.Id,
                                 DateCreated = a.DateCreated,
                                 Id = a.Id,
                                 Price = (b.Price - b.DiscountPrice),
                                 Quantity = a.Quantity,
                                 ProductId = a.ProductId,
                                 ProductName = b.Name,
                                 ImageLink = c.ImageLink,
                                 SizeName = optionRepo.FirstOrDefault(x => x.Id == a.SizeOptionId).NameOption
                             }).ToList();

            // get cart info
            var result = new CartDto()
            {
                Id = checkCart.Id,
                DateCreated = checkCart.DateCreated,
                TotalProducts = cartItems.Count(),
                UserId = checkCart.UserId,
                CartItems = cartItems
            };
            return new ApiResult<CartDto>(true, data: result);
        }

        public ApiResult<int> ClearCart(Guid userId)
        {
            var cartItemRepo = _uow.GetRepository<CartItem>();
            var user = _uow.GetRepository<User>().Single(x => x.Id == userId && x.IsActive && !x.IsDelete && x.EmailConfirmed);
            if (user == null)
            {
                return new ApiResult<int>(false, errorCode: CartMessage.UserNotFound);
            }

            var cart = _uow.GetRepository<Cart>().Single(x => x.UserId == userId);
            if (cart != null)
            {
                var productInCarts = cartItemRepo.QueryCondition(x => x.CartId == cart.Id).AsEnumerable();
                cartItemRepo.DeleteRange(productInCarts);
                //_uow.SaveChanges();
                return new ApiResult<int>(true, cart.Id);
            }
            return new ApiResult<int>(false, errorCode: CartMessage.NotFound);
        }

        public ApiResult<int> RemoveProduct(int itemId)
        {
            var cartItemRepo = _uow.GetRepository<CartItem>();
            var cartItem = cartItemRepo.FindById(itemId);
            if (cartItem != null)
            {
                cartItemRepo.Delete(cartItem);
                _uow.SaveChanges();
                return new ApiResult<int>(true, data: cartItem.Id);
            }
            return new ApiResult<int>(false, errorCode: CartMessage.CartItemNotFound);
        }

        public ApiResult<bool> UpdateQuantity(Guid userId, List<CartItemUpdateDto> dtos)
        {
            var cartItemRepo = _uow.GetRepository<CartItem>();
            var user = _uow.GetRepository<User>().Single(x => x.Id == userId && x.IsActive && !x.IsDelete && x.EmailConfirmed);
            if (user == null)
            {
                return new ApiResult<bool>(false, errorCode: CartMessage.UserNotFound);
            }

            foreach (var item in dtos)
            {
                var product = cartItemRepo.FindById(item.ItemId);
                if (product != null)
                {
                    product.Quantity = item.Quantity;
                    product.DateModified = DateTime.Now;

                    cartItemRepo.Update(product);
                }
            }
            _uow.SaveChanges();
            return new ApiResult<bool>(true);
        }

        public ApiResult<int> TotalProductInCart(Guid userId)
        {
            var cartItemRepo = _uow.GetRepository<CartItem>().QueryAllReadOnly();
            var cart = _uow.GetRepository<Cart>().Single(x => x.UserId == userId);
            var user = _uow.GetRepository<User>().Single(x => x.IsActive && !x.IsDelete && x.Id == userId);
            if (user == null)
            {
                return new ApiResult<int>(false, errorCode: CartMessage.UserNotFound);
            }

            if (cart != null)
            {
                int result = 0;
                result = cartItemRepo.Count(x => x.CartId == cart.Id);
                return new ApiResult<int>(true, data: result);
            }
            return new ApiResult<int>(true, errorCode: CartMessage.NotFound);
        }

        public ApiResult<List<CartItemDto>> GetMiniCart(Guid userId)
        {
            var cartItemRepo = _uow.GetRepository<CartItem>().QueryAllReadOnly();
            var productRepo = _uow.GetRepository<Product>().QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var productDetailRepo = _uow.GetRepository<ProductDetail>().QueryAllReadOnly();
            var productImageRepo = _uow.GetRepository<ProductImage>().QueryConditionReadOnly(x => x.IsDefault);
            var user = _uow.GetRepository<User>().Single(x => x.IsActive && !x.IsDelete && x.Id == userId);
            var cart = _uow.GetRepository<Cart>().Single(x => x.UserId == userId);

            if (user == null)
            {
                return new ApiResult<List<CartItemDto>>(false, CartMessage.UserNotFound);
            }

            if (cart == null)
            {
                return new ApiResult<List<CartItemDto>>(false, errorCode: CartMessage.NotFound);
            }

            var result = (from a in cartItemRepo
                          join b in productRepo on a.ProductId equals b.Id
                          join c in productImageRepo on a.ProductId equals c.ProductId into pi
                          from c in pi.DefaultIfEmpty()
                          join d in productDetailRepo on b.Id equals d.ProductId
                          where a.CartId == cart.Id
                          select new CartItemDto()
                          {
                              Id = a.Id,
                              CartId = a.CartId,
                              DateCreated = a.DateCreated,
                              Quantity = a.Quantity,
                              ProductId = a.ProductId,
                              Price = b.Price - b.DiscountPrice,
                              ImageLink = c.ImageLink,
                              ProductName = b.Name,
                              SeoAlias = d.SeoAlias
                          }).ToList();

            return new ApiResult<List<CartItemDto>>(true, data: result);
        }

        public ApiResult<bool> SyncCart(Guid userId, List<AddCartItemDto> dto)
        {
            var cartRepo = _uow.GetRepository<Cart>();
            var cartItemRepo = _uow.GetRepository<CartItem>();

            var user = _uow.GetRepository<User>().Single(x => x.Id == userId && x.IsActive && !x.IsDelete && x.EmailConfirmed);
            if (user == null)
            {
                return new ApiResult<bool>(false, errorCode: CartMessage.UserNotFound);
            }

            var cart = cartRepo.Single(x => x.UserId == userId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    DateCreated = DateTime.Now,
                    CartItems = new List<CartItem>()
                };
                foreach (var item in dto)
                {
                    cart.CartItems.Add(new CartItem()
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        DateCreated = DateTime.Now,
                        SizeOptionId = item.SizeId
                    });
                }
                cartRepo.Insert(cart);
            }
            else
            {
                CartItem cartItem = null;
                foreach (var item in dto)
                {
                     cartItem = cartItemRepo.Single(x => x.CartId == cart.Id && x.ProductId == item.ProductId && x.SizeOptionId == item.SizeId);
                    if (cartItem != null) //already in cart => update quantity
                    {
                        cartItem.Quantity += item.Quantity;
                        cartItemRepo.Update(cartItem);
                    }
                    else // not exist in cart => add to cart
                    {
                        cartItem = new CartItem()
                        {
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            DateCreated = DateTime.Now,
                            CartId = cart.Id,
                            SizeOptionId = item.SizeId
                        };
                        cartItemRepo.Insert(cartItem);
                    }
                    cartItem = null;
                }
            }
            _uow.SaveChanges();
            return new ApiResult<bool>(true);
        }


    }
}
