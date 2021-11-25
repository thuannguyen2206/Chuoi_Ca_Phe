using Common.Constants;
using Common.Messages;
using DataAccess.Entities;
using DataAccess.Enums;
using DataTransferObjects.DTOs.Orders;
using DataTransferObjects.DTOs.Utilities;
using Repositories;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Helper;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IO;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;
        private readonly ICartService _cartService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _config;

        public OrderService(IUnitOfWork uow, ICartService cartService,
            IEmailService emailService, IConfiguration config)
        {
            _uow = uow;
            _cartService = cartService;
            _emailService = emailService;
            _config = config;
        }

        public  string BuildOrderDownloadTemplate(int orderId)
        {
            var order = this.GetOrderById(orderId);
            if (order != null && order.Success)
            {
                decimal subPrice = 0;
                var format = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
                int i = 0;
                var orderItems = new StringBuilder();

                // add item to email body
                foreach (var item in order.Data.OrderDetails)
                {
                    i++;
                    subPrice += item.Quantity * item.Price;
                    orderItems.Append(@$"<tr>
                            <td>{i}</td>
                            <td>{item.ProductName} {(!string.IsNullOrEmpty(item.SizeName) ? "(" + item.SizeName + ")" : string.Empty)}</td>
                            <td>{item.Quantity}</td>
                            <td>{string.Format(format, "{0:c0}", item.Price)}</td>
                            <td>{string.Format(format, "{0:c0}", item.Price * item.Quantity)}</td>
                        </tr>");
                }

                string shopAddress = _config.GetValue<string>("WebInfo:Address");
                string shopPhoneNumber = _config.GetValue<string>("WebInfo:PhoneNumber");
                string website = _config.GetValue<string>("WebInfo:Website");
                string shopEmail = _config.GetValue<string>("WebInfo:Email");

                string qrcode = BitmapExtensions.CreateQRCodeBitMapAsUrl(order.Data.QRCodeContent);
                var dicContent = new Dictionary<string, string>
                {

                    { OrderConstants.ShopAddress, shopAddress },
                    { OrderConstants.ShopPhoneNumber, shopPhoneNumber },
                    { OrderConstants.Website, website },
                    { OrderConstants.ShopEmail, shopEmail },
                    { OrderConstants.QrCode, qrcode },
                    { OrderConstants.OrderCode, order.Data.OrderCode.ToString() },
                    { OrderConstants.DateCreated, order.Data.DateCreated.ToString("dd/MM/yyyy HH:mm:ss") },
                    { OrderConstants.OrderStatus, order.Data.OrderStatus.GetDisplayName() },
                    { OrderConstants.IsPaid, order.Data.IsPaid ? "Đã thanh toán" : "Chưa thanh toán" },
                    { OrderConstants.UserName, order.Data.CustomerName },
                    { OrderConstants.PhoneNumber, order.Data.CustomerPhoneNumber },
                    { OrderConstants.Email, order.Data.CustomerEmail },
                    { OrderConstants.Address, order.Data.CustomerAddress },
                    { OrderConstants.AddressOption, order.Data.CustomerAddressOption },
                    { OrderConstants.OrderNote, order.Data.OrderNote },
                    { OrderConstants.SubPrice, string.Format(format, "{0:c0}", subPrice) },
                    { OrderConstants.ShippingFee, string.Format(format, "{0:c0}", order.Data.ShippingFee) },
                    { OrderConstants.DiscountPrice, string.Format(format, "{0:c0}", order.Data.DiscountPrice) },
                    { OrderConstants.TotalPrice, string.Format(format, "{0:c0}", order.Data.TotalPrice) },
                    { OrderConstants.OrderItems, orderItems.ToString() },
                };

                string content = this.BuildOrderTemplate(OrderConstants.OrderDownloadPath, dicContent);
                return content;
            }
            return string.Empty;
        }

        public ApiResult<bool> ChangeOrderStatus(int orderId, OrderStatus status)
        {
            var orderRepo = _uow.GetRepository<Order>();
            var order = orderRepo.FindById(orderId);
            if (order == null)
            {
                return new ApiResult<bool>(false, errorCode: OrderMessage.NotFound);
            }

            order.OrderStatus = status;
            order.DateModified = DateTime.Now;
            if (status == OrderStatus.Successed)
            {
                order.IsPaid = true;
            }
            else if (status == OrderStatus.Canceled)
            {
                order.IsPaid = false;
            }

            orderRepo.Update(order);
            _uow.SaveChanges();
            return new ApiResult<bool>(true);
        }

        // Create order and order detail
        // After that, clear cart
        // Update order count of product
        // Add accumulated point for user
        // Send order detail to email
        public async Task<ApiResult<Guid>> Checkout(Guid userId, NewOrderDto dto)
        {
            var orderRepo = _uow.GetRepository<Order>();
            var productRepo = _uow.GetRepository<Product>();
            var productFilter = productRepo.QueryConditionReadOnly(x => x.IsActive && !x.IsDelete);
            var userRepo = _uow.GetRepository<User>();
            var user = userRepo.Single(x => x.Id == userId && x.IsActive && x.EmailConfirmed && !x.IsDelete);

            var orderDetails = new List<OrderDetail>();
            if (userId == Guid.Empty)
            {
                var products = productFilter.Where(x => dto.NewOrderItems.Select(y => y.ProductId).Contains(x.Id))
                    .Select(x => new { x.Id, x.OriginalPrice, x.Price }).ToList();
                foreach (var item in dto.NewOrderItems)
                {
                    var product = products.FirstOrDefault(x => x.Id == item.ProductId);
                    orderDetails.Add(new OrderDetail()
                    {
                        DateCreated = DateTime.Now,
                        SizeOptionId = item.SizeOptionId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = product.Price,
                        OriginalPrice = product.OriginalPrice
                    });
                }
            }
            else
            {
                if (user == null)
                {
                    return new ApiResult<Guid>(false, errorCode: OrderMessage.UserNotFound);
                }

                var cart = _uow.GetRepository<Cart>().Single(x => x.UserId == userId);
                if (cart == null)
                {
                    return new ApiResult<Guid>(false, errorCode: OrderMessage.CartNotFound);
                }
                var cartItemRepo = _uow.GetRepository<CartItem>().QueryConditionReadOnly(x => x.CartId == cart.Id);
                orderDetails = (from a in cartItemRepo
                                join b in productFilter on a.ProductId equals b.Id
                                select new OrderDetail()
                                {
                                    SizeOptionId = a.SizeOptionId,
                                    ProductId = a.ProductId,
                                    Quantity = a.Quantity,
                                    DateCreated = DateTime.Now,
                                    Price = b.Price - b.DiscountPrice,
                                    OriginalPrice = b.OriginalPrice
                                }).ToList();
            }

            var order = new Order()
            {
                CustomerName = dto.CustomerName,
                CustomerAddress = dto.CustomerAddress,
                CustomerAddressOption = dto.CustomerAddressOption,
                CustomerPhoneNumber = dto.CustomerPhoneNumber,
                UserId = userId,
                DateCreated = DateTime.Now,
                OrderStatus = dto.OrderStatus,
                CustomerEmail = dto.CustomerEmail,
                OrderNote = dto.OrderNote,
                OrderCode = Guid.NewGuid(),
                ShippingFee = dto.ShippingFee,
                IsPaid = dto.IsPaid,
                PaymentMethod = dto.PaymentMethod,
                DistrictId = dto.DistrictId,
                DeliveryServiceType = dto.DeliveryServiceType,
                ProvinceId = dto.ProvinceId,
                WardCode = dto.WardCode
            };
            order.OrderDetails = new List<OrderDetail>();
            order.OrderDetails.AddRange(orderDetails);
            decimal totalPrice = orderDetails.Sum(x => x.Price * x.Quantity);
            var promotion = _uow.GetRepository<Promotion>().Single(x => x.IsValid && x.DiscountCode == dto.DiscountCode);
            if (promotion != null)
            {
                var now = DateTime.Now;
                if (DateTime.Compare(promotion.StartTime, now) <= 0 && DateTime.Compare(promotion.ExpireTime, now) >= 0)
                {
                    var discountPrice = totalPrice * promotion.DiscountPercent / 100;
                    if (promotion.MaxValueDiscount != null && promotion.MaxValueDiscount > 0)
                    {
                        discountPrice = discountPrice <= promotion.MaxValueDiscount.Value ? discountPrice : promotion.MaxValueDiscount.Value;
                    }
                    order.TotalPrice = totalPrice - discountPrice + dto.ShippingFee;
                    order.DiscountPrice = discountPrice;
                }
                else
                {
                    return new ApiResult<Guid>(false, errorCode: OrderMessage.PromotionInvalid);
                }
            }
            else
            {
                order.TotalPrice = totalPrice + dto.ShippingFee;
            }

            orderRepo.Insert(order);
            if (user != null)
            {
                //clear cart
                _cartService.ClearCart(user.Id);

                // Add accumulated point
                user.AccumulatedPoint += totalPrice >= DeliveryConstants.DefaultPriceFreeShip ? SystemConstants.VipPoint : SystemConstants.StandarPoint; // Increment accumulated point
                userRepo.Update(user);
            }

            // update order count of product
            string orderItems = string.Empty;
            var format = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            foreach (var item in orderDetails)
            {
                var product = productFilter.FirstOrDefault(x => x.Id == item.ProductId);
                if (product != null)
                {
                    product.OrderCount += item.Quantity;
                    productRepo.Update(product);

                    // add item to email body
                    orderItems += "<li  class=\"order-item\">" +
                                 $"<div class=\"col\">" +
                                 $"<p class=\"name\">{product.Name} x {item.Quantity}</p>" +
                                 $"<p>Giá: {string.Format(format, "{0:c0}", item.Price * item.Quantity)}</p>" +
                                 "</div></li>";
                }
            }

            // Send Email
            var dicContent = new Dictionary<string, string>
            {
                { EmailConstants.UserName, dto.CustomerName },
                { EmailConstants.OrderCode, order.OrderCode.ToString() },
                { EmailConstants.DateCreated, order.DateCreated.ToString("dd/MM/yyyy HH:mm:ss") },
                { EmailConstants.SubPrice, string.Format(format, "{0:c0}", totalPrice) },
                { EmailConstants.ShippingFee, string.Format(format, "{0:c0}", order.ShippingFee) },
                { EmailConstants.DiscountPrice, string.Format(format, "{0:c0}", order.DiscountPrice) },
                { EmailConstants.TotalPrice, string.Format(format, "{0:c0}", order.TotalPrice) },
                { EmailConstants.OrderItems, orderItems },
            };

            string content = _emailService.BuildBodyEmail(EmailConstants.OrderContentPath, dicContent);
            try
            {
                await _emailService.SendEmailSendgridAsync(dto.CustomerEmail, content, AuthMessage.SubjectNewOrder);
            }
            catch (Exception) { }

            _uow.SaveChanges();
            return new ApiResult<Guid>(true, data: order.OrderCode);
        }

        public PageResult<List<OrderDto>> GetAllOrderPaging(OrderAdminPagingDto paging)
        {
            var orderRepo = _uow.GetRepository<Order>().QueryAllReadOnly();

            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                paging.Keyword = paging.Keyword.Trim().ToLower();
                orderRepo = orderRepo.Where(x => x.CustomerName.ToLower().Contains(paging.Keyword)
                  || x.CustomerAddress.ToLower().Contains(paging.Keyword));
            }
            if (paging.FromDate != null && paging.ToDate != null && paging.FromDate != DateTime.MinValue && paging.FromDate <= paging.ToDate)
            {
                orderRepo = orderRepo.Where(x => x.DateCreated >= paging.FromDate && x.DateCreated <= paging.ToDate);
            }
            switch (paging.OrderStatus)
            {
                case OrderStatus.InProgress:
                    orderRepo = orderRepo.Where(x => x.OrderStatus == OrderStatus.InProgress);
                    break;
                case OrderStatus.Confirmed:
                    orderRepo = orderRepo.Where(x => x.OrderStatus == OrderStatus.Confirmed);
                    break;
                case OrderStatus.Shipping:
                    orderRepo = orderRepo.Where(x => x.OrderStatus == OrderStatus.Shipping);
                    break;
                case OrderStatus.Successed:
                    orderRepo = orderRepo.Where(x => x.OrderStatus == OrderStatus.Successed);
                    break;
                case OrderStatus.Canceled:
                    orderRepo = orderRepo.Where(x => x.OrderStatus == OrderStatus.Canceled);
                    break;
                default:
                    break;
            }

            int totalRecord = orderRepo.Count();
            var result = orderRepo.OrderByDescending(x => x.Id)
                .Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .Select(x => new OrderDto()
                {
                    Id = x.Id,
                    CustomerAddress = x.CustomerAddress,
                    CustomerName = x.CustomerName,
                    CustomerPhoneNumber = x.CustomerPhoneNumber,
                    DateCreated = x.DateCreated,
                    TotalPrice = x.TotalPrice,
                    TotalProducts = x.OrderDetails.Count,
                    OrderStatus = x.OrderStatus,
                    IsPaid = x.IsPaid
                }).ToList();

            var pageResult = new PageResult<List<OrderDto>>()
            {
                Items = result,
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize,
                TotalRecords = totalRecord
            };
            return pageResult;
        }

        public ApiResult<int> GetDiscountPercent(string code)
        {
            var promotion = _uow.GetRepository<Promotion>().Single(x => x.IsValid && x.DiscountCode == code);
            if (promotion != null)
            {
                if (DateTime.Compare(promotion.StartTime, DateTime.Now) <= 0 && DateTime.Compare(promotion.ExpireTime, DateTime.Now) >= 0)
                {
                    return new ApiResult<int>(true, data: promotion.DiscountPercent);
                }
                return new ApiResult<int>(false, errorCode: "NotValid");
            }
            return new ApiResult<int>(false, errorCode: "NotFound");
        }

        public ApiResult<DetailDto> GetOrderByCode(Guid orderCode)
        {
            var promotionRepo = _uow.GetRepository<Promotion>();
            var productRepo = _uow.GetRepository<Product>().QueryAllReadOnly();
            var productImageRepo = _uow.GetRepository<ProductImage>().QueryConditionReadOnly(x => x.IsDefault);
            var orderDetailRepo = _uow.GetRepository<OrderDetail>().QueryAllReadOnly();
            var optionRepo = _uow.GetRepository<Option>().QueryConditionReadOnly(x => x.IsActive);
            var order = _uow.GetRepository<Order>().Single(x => x.OrderCode == orderCode);

            if (order == null)
            {
                return new ApiResult<DetailDto>(false, errorCode: "NotFound");
            }

            string webAppUri = _config.GetValue<string>("WebAppUri");

            var result = new DetailDto()
            {
                Id = order.Id,
                CustomerAddress = order.CustomerAddress,
                CustomerAddressOption = order.CustomerAddressOption,
                CustomerName = order.CustomerName,
                CustomerPhoneNumber = order.CustomerPhoneNumber,
                DateCreated = order.DateCreated,
                TotalPrice = order.TotalPrice,
                DiscountPrice = order.DiscountPrice,
                ShippingFee = order.ShippingFee,
                OrderCode = order.OrderCode,
                OrderStatus = order.OrderStatus,
                IsPaid = order.IsPaid,
                PaymentMethod = order.PaymentMethod,
                OrderNote = order.OrderNote,
                CustomerEmail = order.CustomerEmail,
                QRCodeContent = $"{webAppUri}/Order/GetByCode/{order.OrderCode}"
            };

            var details = (from a in orderDetailRepo
                           join b in productRepo on a.ProductId equals b.Id
                           where a.OrderId == order.Id
                           select new OrderDetailDto()
                           {
                               Id = a.Id,
                               OrderId = a.OrderId,
                               Price = a.Price,
                               Quantity = a.Quantity,
                               ProductId = a.ProductId,
                               ProductName = a.Product.Name,
                               ProductDefaultLink = productImageRepo.FirstOrDefault(x => x.ProductId == a.ProductId).ImageLink,
                               SizeName = optionRepo.FirstOrDefault(x => x.Id == a.SizeOptionId).NameOption
                           }).ToList();

            result.OrderDetails = details;
            return new ApiResult<DetailDto>(true, data: result);
        }

        public ApiResult<DetailDto> GetOrderById(int orderId)
        {
            //var promotionRepo = _uow.GetRepository<Promotion>();
            var productRepo = _uow.GetRepository<Product>().QueryAllReadOnly();
            var productImageRepo = _uow.GetRepository<ProductImage>().QueryConditionReadOnly(x => x.IsDefault);
            var orderDetailRepo = _uow.GetRepository<OrderDetail>().QueryAllReadOnly();
            var optionRepo = _uow.GetRepository<Option>().QueryConditionReadOnly(x => x.IsActive);
            var order = _uow.GetRepository<Order>().FindById(orderId);

            if (order == null)
            {
                return new ApiResult<DetailDto>(false, errorCode: "NotFound");
            }

            string webAppUri = _config.GetValue<string>("WebAppUri");

            var result = new DetailDto()
            {
                Id = order.Id,
                CustomerAddress = order.CustomerAddress,
                CustomerAddressOption = order.CustomerAddressOption,
                CustomerName = order.CustomerName,
                CustomerPhoneNumber = order.CustomerPhoneNumber,
                DateCreated = order.DateCreated,
                TotalPrice = order.TotalPrice,
                DiscountPrice = order.DiscountPrice,
                ShippingFee = order.ShippingFee,
                OrderCode = order.OrderCode,
                OrderStatus = order.OrderStatus,
                IsPaid = order.IsPaid,
                PaymentMethod = order.PaymentMethod,
                OrderNote = order.OrderNote,
                CustomerEmail = order.CustomerEmail,
                QRCodeContent = $"{webAppUri}/Order/GetByCode/{order.OrderCode}"
            };

            //var details = new List<OrderDetailDto>();
            var details = (from a in orderDetailRepo
                           join b in productRepo on a.ProductId equals b.Id
                           where a.OrderId == orderId
                           select new OrderDetailDto()
                           {
                               Id = a.Id,
                               OrderId = a.OrderId,
                               Price = a.Price,
                               Quantity = a.Quantity,
                               ProductId = a.ProductId,
                               ProductName = a.Product.Name,
                               ProductDefaultLink = productImageRepo.FirstOrDefault(x => x.ProductId == a.ProductId).ImageLink,
                               SizeName = optionRepo.FirstOrDefault(x => x.Id == a.SizeOptionId).NameOption
                           }).ToList();

            result.OrderDetails = details;
            return new ApiResult<DetailDto>(true, data: result);
        }

        public ApiResult<List<OrderDetailDto>> GetOrderItemByOrderId(int orderId)
        {
            var promotionRepo = _uow.GetRepository<Promotion>();
            var productRepo = _uow.GetRepository<Product>().QueryAllReadOnly();
            var productImageRepo = _uow.GetRepository<ProductImage>().QueryConditionReadOnly(x => x.IsDefault);
            var orderDetailRepo = _uow.GetRepository<OrderDetail>().QueryAllReadOnly();
            var optionRepo = _uow.GetRepository<Option>().QueryConditionReadOnly(x => x.IsActive);

            var order = _uow.GetRepository<Order>().FindById(orderId);
            if (order == null)
            {
                return new ApiResult<List<OrderDetailDto>>(false, errorCode: "NotFound");
            }

            var details = (from a in orderDetailRepo
                           join b in productRepo on a.ProductId equals b.Id
                           where a.OrderId == orderId
                           select new OrderDetailDto()
                           {
                               Id = a.Id,
                               OrderId = a.OrderId,
                               Price = a.Price,
                               Quantity = a.Quantity,
                               ProductId = a.ProductId,
                               ProductName = a.Product.Name,
                               ProductDefaultLink = productImageRepo.FirstOrDefault(x => x.ProductId == a.ProductId).ImageLink,
                               SizeName = optionRepo.FirstOrDefault(x => x.Id == a.SizeOptionId).NameOption ?? "No"
                           }).ToList();

            return new ApiResult<List<OrderDetailDto>>(true, data: details);
        }

        public ApiResult<List<UserOrderDto>> GetUserOrders(Guid userId)
        {
            var user = _uow.GetRepository<User>().Single(x => x.Id == userId && x.EmailConfirmed && x.IsActive && !x.IsDelete);
            if (user == null)
            {
                return new ApiResult<List<UserOrderDto>>(false, errorCode: OrderMessage.UserNotFound);
            }
            var orderRepo = _uow.GetRepository<Order>().QueryConditionReadOnly(x => x.UserId == userId);
            var orderDetailRepo = _uow.GetRepository<OrderDetail>().QueryAllReadOnly();

            var result = orderRepo.OrderByDescending(x => x.Id)
                .Take(SystemConstants.UserOrderCount)
                .Select(x => new UserOrderDto()
                {
                    Id = x.Id,
                    CustomerName = x.CustomerName,
                    Datecreated = x.DateCreated,
                    OrderStatus = x.OrderStatus,
                    TotalPrice = x.TotalPrice,
                    IsPaid = x.IsPaid,
                    TotalProducts = orderDetailRepo.Count(y => y.OrderId == x.Id)
                }).ToList();
            return new ApiResult<List<UserOrderDto>>(true, data: result);
        }

        public ApiResult<decimal> MonthlyIncome()
        {
            var now = DateTime.Now;
            var total = _uow.GetRepository<Order>()
                .QueryConditionReadOnly(x => x.DateCreated.Year == now.Year && x.DateCreated.Month == now.Month
                    && x.IsPaid && x.OrderStatus == OrderStatus.Successed)
                .Sum(x => x.TotalPrice - x.ShippingFee);
            return new ApiResult<decimal>(true, data: total);
        }

        public ApiResult<decimal> TotalIncome()
        {
            var total = _uow.GetRepository<Order>().QueryConditionReadOnly(x => x.IsPaid && x.OrderStatus == OrderStatus.Successed)
                .Sum(x => x.TotalPrice - x.ShippingFee);
            return new ApiResult<decimal>(true, data: total);
        }

        public ApiResult<int> TotalOrders()
        {
            var orders = _uow.GetRepository<Order>().QueryConditionReadOnly(x => x.OrderStatus != OrderStatus.Canceled).Count();
            return new ApiResult<int>(true, data: orders);
        }

        private string BuildOrderTemplate(string path, Dictionary<string,string> contentReplace)
        {
            string directory = Directory.GetCurrentDirectory();

            var templatePath = string.Format("{0}{1}", directory, path);

            string layoutContent = File.ReadAllText(templatePath);

            foreach (var item in contentReplace)
            {
                layoutContent = layoutContent.Replace(item.Key, item.Value);
            }

            return layoutContent;
        }

    }
}
