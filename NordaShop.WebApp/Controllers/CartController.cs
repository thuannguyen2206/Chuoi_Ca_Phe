using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Common.Constants;
using Common.Messages;
using DataTransferObjects.DTOs.Carts;
using DataTransferObjects.DTOs.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NordaShop.IntegrationApi.Interfaces;
using NordaShop.WebApp.Filters;
using NordaShop.WebApp.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Helper;
using DataTransferObjects.DTOs.Options;
using DataAccess.Enums;
using DataTransferObjects.DTOs.Delivery;
using NordaShop.WebApp.Models.Delivery;
using Microsoft.Extensions.Configuration;
using NordaShop.WebApp.Models.Payment.Paypal;
using Newtonsoft.Json.Linq;
//using PayPal.v1.Payments;
//using PayPal.Core;
//using BraintreeHttp;

namespace NordaShop.WebApp.Controllers
{
    //[ServiceFilter(typeof(AuthorizationFilter))]
    public class CartController : Controller
    {
        private readonly ICartApiClient _cartApi;
        private readonly IHttpContextAccessor _httpContext;
        private readonly INotyfService _notyf;
        private readonly IMapper _mapper;
        private readonly IOrderApiClient _orderApi;
        private readonly IProductApiClient _productApi;
        private readonly IOptionApiClient _optionApi;
        private readonly ISession _session;
        private readonly IDeliveryApiClient _deliveryApi;
        private readonly IConfiguration _config;
        private readonly IUserApiClient _userApi;
        private readonly IPaymentApiClient _paymentApi;

        public CartController(ICartApiClient cartApi,
            IHttpContextAccessor httpContext,
            INotyfService notyf,
            IMapper mapper,
            IOrderApiClient orderApi,
            IProductApiClient productApi,
            IOptionApiClient optionApi,
            IDeliveryApiClient deliveryApi,
            IConfiguration config,
            IUserApiClient userApi,
            IPaymentApiClient paymentApi)
        {
            _cartApi = cartApi;
            _httpContext = httpContext;
            _notyf = notyf;
            _mapper = mapper;
            _orderApi = orderApi;
            _productApi = productApi;
            _optionApi = optionApi;
            _session = _httpContext.HttpContext.Session;
            _deliveryApi = deliveryApi;
            _config = config;
            _userApi = userApi;
            _paymentApi = paymentApi;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            var model = new List<CartViewModel>();
            if (string.IsNullOrEmpty(userId))
            {
                var cart = _session.GetObject<List<CartViewModel>>(SystemConstants.CartSession);
                if (cart != null)
                {
                    model = cart;
                }
                return View(model);
            }
            var userIdConvert = Guid.Parse(!string.IsNullOrEmpty(userId) ? userId : Guid.Empty.ToString());
            var response = await _cartApi.GetCart(userIdConvert);
            if (response.Success)
            {

                foreach (var item in response.Data.CartItems ?? Enumerable.Empty<CartItemDto>())
                {
                    model.Add(new CartViewModel()
                    {
                        ItemId = item.Id,
                        CartId = item.CartId,
                        DefaultImage = item.ImageLink,
                        Name = item.ProductName,
                        Price = item.Price,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        SizeName = !string.IsNullOrEmpty(item.SizeName) ? item.SizeName : string.Empty,
                    });
                }
                return View(model);
            }
            _notyf.Error(NotificationConstants.Error);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateCart(IDictionary<int, int> dic)
        {
            var dtos = new List<CartItemUpdateDto>();
            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            if (string.IsNullOrEmpty(userId))
            {
                var update = this.UpdateCartSession(dic);
                if (update)
                {
                    _notyf.Success(NotificationConstants.UpDateSuccess);
                }
                else
                {
                    _notyf.Error(NotificationConstants.UpdateFailed);
                }
            }
            else
            {
                foreach (KeyValuePair<int, int> item in dic)
                {
                    dtos.Add(new CartItemUpdateDto()
                    {
                        ItemId = item.Key,
                        Quantity = item.Value
                    });
                }
                var response = await _cartApi.UpdateQuantity(Guid.Parse(userId), dtos);
                if (response != null && response.Success)
                {
                    _notyf.Success(NotificationConstants.UpDateSuccess);
                }
                else
                {
                    _notyf.Error(NotificationConstants.Error);
                }
            }
            return Json(new { url = Url.Action("Index", "Cart") });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(int id, int quantity = 1, int sizeid = 0)
        {
            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            if (string.IsNullOrEmpty(userId))
            {
                var result = await this.AddToCartSession(id, quantity, sizeid);
                if (result == 2)
                {
                    _notyf.Success(NotificationConstants.AddToCartSussess);
                    return Json(true);
                }
                else if (result == 1)
                {
                    _notyf.Information(NotificationConstants.ExistInCart);
                }
                else
                {
                    _notyf.Error(NotificationConstants.AddToCartFailed);
                }
                return Json(false);
            }
            else
            {
                var dto = new AddCartItemDto()
                {
                    UserId = Guid.Parse(userId),
                    ProductId = id,
                    Quantity = quantity,
                    SizeId = sizeid
                };
                var response = await _cartApi.AddToCart(dto);
                if (response != null && response.Success && response.ErrorCode == CartMessage.ExistProduct)
                {
                    _notyf.Information(NotificationConstants.ExistInCart);
                    return Json(false);
                }
                else if (response != null && response.Success)
                {
                    _notyf.Success(NotificationConstants.AddToCartSussess);
                    return Json(true);
                }
                else
                {
                    _notyf.Error(NotificationConstants.AddToCartFailed);
                    return Json(false);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetDiscountPercent(string code)
        {
            var result = await _orderApi.GetDiscountPercent(code);
            int percent = 0;
            if (result != null && result.Success)
            {
                percent = result.Data;
                _notyf.Success(NotificationConstants.CouponSuccess);
            }
            else
            {
                _notyf.Error(NotificationConstants.CouponNotFound);
            }
            return Json(percent);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveMiniCartItem(int itemId)
        {
            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            if (string.IsNullOrEmpty(userId))
            {
                this.RemoveItemSession(itemId);
                return Json(true);
            }
            else
            {
                var result = await _cartApi.RemoveCartItem(itemId);
                if (result)
                {
                    _notyf.Success(NotificationConstants.RemoveCartItemSuccess);
                    return Json(true);
                }
                _notyf.Error(NotificationConstants.RemoveCartItemFailed);
                return Json(false);
            }
        }

        public async Task<IActionResult> RemoveProduct(int itemid)
        {
            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            if (string.IsNullOrEmpty(userId))
            {
                this.RemoveItemSession(itemid);
            }
            else
            {
                var result = await _cartApi.RemoveCartItem(itemid);
                if (!result)
                {
                    _notyf.Error(NotificationConstants.RemoveCartItemFailed);
                }
            }
            return RedirectToAction("Index", "Cart");
        }

        public async Task<IActionResult> ClearCart()
        {
            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            if (string.IsNullOrEmpty(userId))
            {
                this.ClearCartSession();
            }
            else
            {
                var result = await _cartApi.ClearCart(Guid.Parse(userId));
                if (!result)
                {
                    _notyf.Error(NotificationConstants.ClearCartFailed);
                }
            }
            return RedirectToAction("Index", "Cart");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult LoadMiniCart()
        {
            return ViewComponent("MiniCart");
        }

        public async Task<JsonResult> LoadProvince()
        {
            var data = await _deliveryApi.LoadProvince();
            var provinces = _mapper.Map<List<ProvinceDto>, List<ProvinceViewModel>>(data);
            return Json(provinces);
        }

        public async Task<JsonResult> LoadDistrict(int provinceId)
        {
            var data = await _deliveryApi.LoadDistrict(provinceId);
            var districts = _mapper.Map<List<DistrictDto>, List<DistrictViewModel>>(data);
            return Json(districts);
        }

        public async Task<JsonResult> LoadWard(int districtId)
        {
            var data = await _deliveryApi.LoadWard(districtId);
            var wards = _mapper.Map<List<WardDto>, List<WardViewModel>>(data);
            return Json(wards);
        }

        public async Task<JsonResult> CalShippingFee(int districtId, string wardCode, int deliveryType, decimal subtotal, int productCount)
        {
            if (subtotal >= DeliveryConstants.DefaultPriceFreeShip)
            {
                return Json(0);
            }
            else
            {
                var shippingFee = await _deliveryApi.CalShippingFee(districtId, wardCode, deliveryType, subtotal, productCount);
                return Json(shippingFee);
            }
        }


        #region Payment

        [HttpGet]
        public async Task<IActionResult> Checkout(int deliveryType = DeliveryConstants.ServiceTypeId)
        {
            var model = new CheckoutViewModel
            {
                DeliveryServiceType = deliveryType
            };
            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            if (string.IsNullOrEmpty(userId))
            {
                var cart = _session.GetObject<List<CartViewModel>>(SystemConstants.CartSession);
                foreach (var item in cart ?? Enumerable.Empty<CartViewModel>())
                {
                    model.CheckoutDetails.Add(new CheckoutDetailViewModel()
                    {
                        Price = item.Price,
                        ProductName = item.Name,
                        Quantity = item.Quantity
                    });
                }
            }
            else
            {
                var userInfo = await _userApi.GetById(Guid.Parse(userId));
                if (userInfo != null && userInfo.Success && userInfo.Data != null)
                {
                    model.CustomerAddress = userInfo.Data.Address;
                    model.CustomerEmail = userInfo.Data.Email;
                    model.CustomerName = userInfo.Data.Username;
                    model.CustomerPhoneNumber = userInfo.Data.PhoneNumber;
                }

                var cart = await _cartApi.GetMiniCart(Guid.Parse(userId));
                if (cart != null && cart.Success)
                {
                    foreach (var item in cart.Data)
                    {
                        model.CheckoutDetails.Add(new CheckoutDetailViewModel()
                        {
                            Price = item.Price,
                            ProductName = item.ProductName,
                            Quantity = item.Quantity
                        });
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            // if failed, get cart and return view
            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            if (string.IsNullOrEmpty(userId))
            {
                var cart = _session.GetObject<List<CartViewModel>>(SystemConstants.CartSession);
                foreach (var item in cart ?? Enumerable.Empty<CartViewModel>())
                {
                    model.CheckoutDetails.Add(new CheckoutDetailViewModel()
                    {
                        Price = item.Price,
                        ProductName = item.Name,
                        Quantity = item.Quantity
                    });
                }
            }
            else
            {
                var cart = await _cartApi.GetMiniCart(Guid.Parse(userId));
                if (cart != null && cart.Success)
                {
                    foreach (var item in cart.Data)
                    {
                        model.CheckoutDetails.Add(new CheckoutDetailViewModel()
                        {
                            Price = item.Price,
                            ProductName = item.ProductName,
                            Quantity = item.Quantity
                        });
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                _notyf.Error(NotificationConstants.InvalidForm);
                return View(model);
            }

            // if payment online => required login
            if (model.PaymentMethod != PaymentMethod.CashOnDelivery && string.IsNullOrEmpty(userId))
            {
                _notyf.Error(NotificationConstants.PaymentNotLogin);
                return View(model);
            }

            _session.SetObject(SystemConstants.CheckoutSession, model);

            // choosse payment
            if (model.PaymentMethod == PaymentMethod.NganLuong)
            {
                return await CreateNewOrder();
            }
            else if (model.PaymentMethod == PaymentMethod.Paypal)
            {
                return await PaypalCheckout();
            }
            else if (model.PaymentMethod == PaymentMethod.Momo)
            {
                return await MomoCheckout();
            }
            else // cash on delivery
            {
                return await CreateNewOrder();
            }
        }

        public async Task<IActionResult> CreateNewOrder()
        {
            var model = _session.GetObject<CheckoutViewModel>(SystemConstants.CheckoutSession);
            if (model == null)
            {
                _notyf.Error(NotificationConstants.PaymentInfoNotFound);
                return RedirectToAction("Checkout", "Cart");
            }

            var cart = _session.GetObject<List<CartViewModel>>(SystemConstants.CartSession);
            var orderItems = new List<NewOrderItemDto>();
            foreach (var item in cart ?? Enumerable.Empty<CartViewModel>())
            {
                model.CheckoutDetails.Add(new CheckoutDetailViewModel()
                {
                    Price = item.Price,
                    ProductName = item.Name,
                    Quantity = item.Quantity
                });

                orderItems.Add(new NewOrderItemDto()
                {
                    ItemId = item.ItemId,
                    SizeOptionId = item.SizeId,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ProductId = item.ProductId
                });
            }

            var userId = _httpContext.HttpContext.Session.GetString(SystemConstants.UserId);
            var dto = new NewOrderDto()
            {
                DeliveryServiceType = model.DeliveryServiceType,
                ShippingFee = model.ShippingFee,
                DistrictId = model.DistrictId,
                ProvinceId = model.ProvinceId,
                WardCode = model.WardCode,
                CustomerAddress = model.CustomerAddress,
                CustomerAddressOption = model.CustomerAddressOption,
                CustomerName = model.CustomerName,
                CustomerEmail = model.CustomerEmail,
                CustomerPhoneNumber = model.CustomerPhoneNumber,
                OrderNote = model.OrderNote,
                DiscountCode = model.DiscountCode,
                NewOrderItems = orderItems,
                IsPaid = model.IsPaid,
                PaymentMethod = model.PaymentMethod,
                OrderStatus = model.OrderStatus
            };
            var result = await _orderApi.Checkout(string.IsNullOrEmpty(userId) ? Guid.Empty : Guid.Parse(userId), dto);
            
            if (result != null && result.Success)
            {
                _notyf.Success(NotificationConstants.CheckoutSuccess);
                this.ClearCartSession();
                this.ClearPaypalChekoutSession();
                return RedirectToAction("OrderResult", "Order", new { success = true, orderid = result.Data });
            }
            else if (result != null && result.ErrorCode == OrderMessage.PromotionInvalid)
            {
                _notyf.Information(NotificationConstants.CouponInvalid);
            }
            else
            {
                _notyf.Success(NotificationConstants.CheckoutFailed);
            }

            switch (model.PaymentMethod) // Refurn money if customer using payment online
            {
                case PaymentMethod.CashOnDelivery:
                    break;
                case PaymentMethod.Paypal:
                    string accessToken = this._session.GetString(SystemConstants.PaypalAccessToken);
                    string saleId = this._session.GetString(SystemConstants.PaypalSaleId);
                    var refund = await _paymentApi.PaypalRefundSale(accessToken, saleId);
                    break;
                case PaymentMethod.NganLuong:
                    break;
                case PaymentMethod.Momo:
                    break;
                default:
                    break;
            }

            return RedirectToAction("Checkout", "Cart", new { model });
        }

        public async Task<IActionResult> PaypalCheckout()
        {
            var model = _session.GetObject<CheckoutViewModel>(SystemConstants.CheckoutSession);
            if (model == null)
            {
                _notyf.Error(NotificationConstants.PaymentInfoNotFound);
                return RedirectToAction("Checkout", "Cart");
            }

            string accessToken = await _paymentApi.PaypalGetAccessToken();
            if (!string.IsNullOrEmpty(accessToken))
            {
                _session.SetString(SystemConstants.PaypalAccessToken, accessToken);
            }
            else
            {
                _notyf.Error(NotificationConstants.PaypalGetAccessTokenFailed);
                return RedirectToAction("Checkout", "Cart");
            }

            //string clientId = _config.GetValue<string>("Paypal:ClientId");
            //string secretKey = _config.GetValue<string>("Paypal:SecretKey");

            decimal exchangeRateUSD = Math.Round(await _paymentApi.GetExchangeRate(PaymentConstants.CurrencyConvert.USD_VND), 0);
            var paypalOrderId = DateTime.Now.Ticks;


            var itemList = new ItemList()
            {
                items = new List<Item>()
            };

            foreach (var item in model.CheckoutDetails)
            {
                itemList.items.Add(new Item
                {
                    name = item.ProductName,
                    currency = "USD",
                    price = Math.Round(item.Price / exchangeRateUSD, 2).ToString(),
                    quantity = item.Quantity.ToString(),
                });
            }

            var subtotal = Math.Round(itemList.items.Sum(x => decimal.Parse(x.price) * int.Parse(x.quantity)), 2);
            var discountPrice = Math.Round(subtotal * model.DiscountPercent / 100, 2);
            var shippingFee = Math.Round(model.ShippingFee / exchangeRateUSD, 2);
            var total = subtotal - discountPrice + shippingFee;

            if (model.DiscountPercent > 0)
            {
                itemList.items.Add(new Item
                {
                    name = "Discount",
                    currency = "USD",
                    price = (-discountPrice).ToString(),
                    quantity = "1"
                });
                subtotal -= discountPrice;
            }

            string uri = $"{_httpContext.HttpContext.Request.Scheme}://{_httpContext.HttpContext.Request.Host}";

            var payment = new PaypalCreatePaymentRequestModel()
            {
                intent = "sale",
                payer = new Payer()
                {
                    payment_method = "paypal"
                },
                transactions = new List<Transaction>()
                {
                    new Transaction()
                    {
                        amount = new Amount()
                        {
                            currency = "USD",
                            total = total.ToString(),
                            details = new AmountDetail()
                            {
                                shipping = shippingFee.ToString(),
                                subtotal = subtotal.ToString()
                            }
                        },
                        description = $"Invoice #{paypalOrderId}",
                        invoice_number = paypalOrderId.ToString(),
                        item_list = itemList
                    }
                },
                redirect_urls = new RedirectUrl()
                {
                    cancel_url = $"{uri}/Cart/PaypalCheckoutFailed",
                    return_url = $"{uri}/Cart/PaypalCheckoutSuccess"
                },
            };

            var response = await _paymentApi.PaypalCraetePayment(accessToken, payment);
            string paypalRedirectUrl = null;
            if (response != null)
            {
                foreach (var lnk in response.links)
                {
                    if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                    {
                        paypalRedirectUrl = lnk.href;
                        break;
                    }
                }
                return Redirect(paypalRedirectUrl);
            }

            return RedirectToAction("PayPalCheckoutFailed", "Cart");

            #region Paypal checkout using paypal package
            /*var environment = new SandboxEnvironment(clientId, secretKey);
            var client = new PayPalHttpClient(environment);
            client.SetConnectTimeout(TimeSpan.FromMinutes(10));

            //item of cart
            var itemList = new ItemList()
            {
                Items = new List<Item>()
            };

            foreach (var item in model.CheckoutDetails)
            {
                itemList.Items.Add(new Item()
                {
                    Name = item.ProductName,
                    Currency = "USD",
                    Price = Math.Round(item.Price / exchangeRateUSD, 2).ToString(),
                    Quantity = item.Quantity.ToString(),
                    Sku = "sku",
                    Tax = "0"
                });
            }

            var subtotal = Math.Round(itemList.items.Sum(x => decimal.Parse(x.price) * int.Parse(x.quantity)), 2);
            var discountPrice = Math.Round(subtotal * model.DiscountPercent / 100, 2);
            var shippingFee = Math.Round(model.ShippingFee / exchangeRateUSD, 2);
            var total = Math.Round(subtotal - discountPrice + shippingFee, 2);

            if (discountPrice > 0)
            {
                itemList.Items.Add(new Item()
                {
                    Name = "Discount",
                    Currency = "USD",
                    Price = (-discountPrice).ToString(),
                    Quantity = "1"
                });
            }

            var payment = new Payment()
            {
                Intent = "sale",
                Transactions = new List<Transaction>()
                {
                    new Transaction()
                    {
                        Amount = new Amount()
                        {
                            Total = Math.Round(total, 2).ToString(),
                            Currency = "USD",
                            Details = new AmountDetails()
                            {
                                Subtotal = subTotal.ToString(),
                                Tax = "0",
                                Shipping = shippingFee.ToString(),
                                //ShippingDiscount = (-discountPrice).ToString() // giảm giá đơn hàng
                            }
                        },
                        ItemList = itemList,
                        Description = $"ShippingDiscount is the discounted price of this order. Invoice #{paypalOrderId}",
                        InvoiceNumber = paypalOrderId.ToString(),
                        NoteToPayee=""
                    }
                },
                RedirectUrls = new RedirectUrls()
                {
                    CancelUrl = $"{_config.GetValue<string>("SiteUri")}/Cart/PaypalCheckoutFailed",
                    ReturnUrl = $"{_config.GetValue<string>("SiteUri")}/Cart/PaypalCheckoutSuccess"
                },
                Payer = new Payer()
                {
                    PaymentMethod = "paypal"
                }
            };

            PaymentCreateRequest request = new PaymentCreateRequest();
            request.RequestBody(payment);

            try
            {
                var response = await client.Execute(request);
                var statusCode = response.StatusCode;
                Payment result = response.Result<Payment>();

                var links = result.Links.GetEnumerator();
                string paypalRedirectUrl = null;
                while (links.MoveNext())
                {
                    LinkDescriptionObject lnk = links.Current;
                    if (lnk.Rel.ToLower().Trim().Equals("approval_url"))
                    {
                        paypalRedirectUrl = lnk.Href;
                        break;
                    }
                }

                return Redirect(paypalRedirectUrl);
            }
            catch (HttpException httpException)
            {
                var statusCode = httpException.StatusCode;
                var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();

                return RedirectToAction("PayPalCheckoutFailed", "Cart");
            }*/
            #endregion
        }

        public async Task<IActionResult> PaypalCheckoutSuccess(string paymentId, string token, string payerId)
        {
            string accessToken = this._session.GetString(SystemConstants.PaypalAccessToken);
            var response = await _paymentApi.PaypalExcutePayment(accessToken, paymentId, payerId);
            if (response != null)
            {
                var payment = await _paymentApi.GetPaypalPayment(accessToken, response.id);
                if (payment != null)
                {
                    var checkoutSession = this._session.GetObject<CheckoutViewModel>(SystemConstants.CheckoutSession);
                    if (checkoutSession != null)
                    {
                        checkoutSession.OrderStatus = OrderStatus.Confirmed;
                        checkoutSession.IsPaid = true;
                        this._session.SetObject(SystemConstants.CheckoutSession, checkoutSession);
                        string saleId = payment.transactions.FirstOrDefault().related_resources.FirstOrDefault().sale.id;
                        this._session.SetString(SystemConstants.PaypalSaleId, saleId);
                    }
                    return await CreateNewOrder();
                }
            }
            return RedirectToAction("PayPalCheckoutFailed", "Cart");
        }

        public IActionResult PaypalCheckoutFailed()
        {
            _notyf.Error(NotificationConstants.Error);
            return RedirectToAction("Checkout", "Cart");
        }

        public void ClearPaypalChekoutSession()
        {
            try
            {
                this._session.Remove(SystemConstants.CheckoutSession);
                this._session.Remove(SystemConstants.PaypalAccessToken);
                this._session.Remove(SystemConstants.PaypalSaleId);
            }
            catch { }
        }


        public async Task<IActionResult> MomoCheckout()
        {
            var model = _session.GetObject<CheckoutViewModel>(SystemConstants.CheckoutSession);
            if (model == null)
            {
                _notyf.Error(NotificationConstants.PaymentInfoNotFound);
                return RedirectToAction("Checkout", "Cart");
            }

            var subtotal = model.CheckoutDetails.Sum(x => x.Price * x.Quantity);
            var discountPrice = subtotal * model.DiscountPercent / 100;
            var total = Math.Round(subtotal - discountPrice + model.ShippingFee, 0);

            //string endpoint = PaymentConstants.MomoApiEndPoint;
            string partnerCode = _config.GetValue<string>("Momo:PartnerCode");
            string accessKey = _config.GetValue<string>("Momo:AccessKey");
            string serectkey = _config.GetValue<string>("Momo:SecretKey");

            string uri = $"{_httpContext.HttpContext.Request.Scheme}://{_httpContext.HttpContext.Request.Host}";
            string ticks = DateTime.Now.Ticks.ToString();
            string orderInfo = $"Thanh toán cho #{ticks}";
            string redirectUrl = $"{uri}/Cart/MonoRedirectUrl";
            string ipnUrl = $"{uri}/Cart/MonoNotifyUrl";
            string requestType = "captureWallet";

            long amount = long.Parse(total.ToString()); // số tiền thanh toán
            string orderId = ticks;
            string requestId = ticks;
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "accessKey=" + accessKey +
                "&amount=" + amount +
                "&extraData=" + extraData +
                "&ipnUrl=" + ipnUrl +
                "&orderId=" + orderId +
                "&orderInfo=" + orderInfo +
                "&partnerCode=" + partnerCode +
                "&redirectUrl=" + redirectUrl +
                "&requestId=" + requestId +
                "&requestType=" + requestType;

            //sign signature SHA256
            string signature = MomoSecurity.HmacSha256Hash(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "partnerName", "NordaShop" },
                { "storeId", "MomoTestStore" },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderId },
                { "orderInfo", orderInfo },
                { "redirectUrl", redirectUrl },
                { "ipnUrl", ipnUrl },
                { "lang", "vi" },
                { "extraData", extraData },
                { "requestType", requestType },
                { "signature", signature }
            };

            var response = await _paymentApi.MomoCreatePayment(message);
            if (response != null)
            {
                return Redirect(response.payUrl);
            }

            _notyf.Error(NotificationConstants.Error);
            return RedirectToAction("Checkout", "Cart");

            //JObject jmessage = JObject.Parse(responseFromMomo);
            //System.Diagnostics.Process.Start(jmessage.GetValue("payUrl").ToString());
        }

        public IActionResult MonoRedirectUrl()
        {
            string query= _httpContext.HttpContext.Request.Query.ToString();
            string paramSignature = Request.QueryString.ToString().Substring(0, Request.QueryString.ToString().IndexOf("signature") - 1);
            string x = query.Substring(0, _httpContext.HttpContext.Request.QueryString.ToString().IndexOf("signature") - 1);
            string y = query.Substring(0, _httpContext.HttpContext.Request.QueryString.ToString().IndexOf("signature"));
            string querySignature = _httpContext.HttpContext.Request.Query["signature"].ToString();
            string errorCode = _httpContext.HttpContext.Request.Query["resultCode"].ToString();
            string serectkey = _config.GetValue<string>("Momo:SecretKey");
            string signature = MomoSecurity.HmacSha256Hash(paramSignature, serectkey);

            if (querySignature != signature)
            {
                _notyf.Error(NotificationConstants.MomoSignatureNotEqual);
            }
            else if(int.Parse(errorCode) != 0)
            {
                _notyf.Error(NotificationConstants.Error);
            }
            else
            {
                _notyf.Error(NotificationConstants.MomoCreatePaymentSuccess);
            }

            return NoContent();//RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> MonoNotifyUrl()
        {
            string query = _httpContext.HttpContext.Request.Query.ToString();
            string paramSignature = Request.QueryString.ToString().Substring(0, Request.QueryString.ToString().IndexOf("signature") - 1);
            string x = query.Substring(0, _httpContext.HttpContext.Request.QueryString.ToString().IndexOf("signature") - 1);
            string y = query.Substring(0, _httpContext.HttpContext.Request.QueryString.ToString().IndexOf("signature"));
            string querySignature = _httpContext.HttpContext.Request.Query["signature"].ToString();
            string errorCode = _httpContext.HttpContext.Request.Query["resultCode"].ToString();
            string serectkey = _config.GetValue<string>("Momo:SecretKey");
            string signature = MomoSecurity.HmacSha256Hash(paramSignature, serectkey);

            if (querySignature == signature && int.Parse(errorCode) == 0)
            {
                return await this.CreateNewOrder();
            }

            _notyf.Error(NotificationConstants.Error);
            return RedirectToAction("Checkout", "Cart");
        }



        #endregion

        #region Session

        public async Task<int> AddToCartSession(int id, int quantity = 1, int sizeid = 0)
        {
            var product = await _productApi.GetById(id);
            if (product == null || !product.Success)
            {
                return 0; // product not found
            }
            OptionDto sizeOption = null;

            if (sizeid == 0)
            {
                var size = await _optionApi.GetDefaultOptionOfProduct(id, ProductOptionGroup.Size);
                sizeOption = size != null && size.Success ? size.Data : null;
            }
            else
            {
                var size = await _optionApi.GetById(sizeid);
                sizeOption = size != null && size.Success ? size.Data : null;
            }

            var cartSession = _session.GetObject<List<CartViewModel>>(SystemConstants.CartSession);
            if (cartSession != null) // if cart exist => add to cart
            {
                if (cartSession.Exists(x => x.ProductId == id && x.SizeId == (sizeOption != null ? sizeOption.Id : sizeid)))
                {
                    return 1; // if this product already in cart return is exist
                }
                else // if this product isn't in cart =>  add to cart
                {
                    cartSession.Add(new CartViewModel()
                    {
                        Quantity = quantity,
                        SizeId = sizeOption != null ? sizeOption.Id : sizeid,
                        SizeName = sizeOption != null ? sizeOption.NameOption : string.Empty,
                        DefaultImage = product.Data.DefaultImage ?? SystemConstants.DefaultImage,
                        Name = product.Data.Name ?? string.Empty,
                        Price = product.Data.Price - product.Data.DiscountPrice,
                        ProductId = product.Data.Id,
                        ItemId = cartSession.Count > 0 ? cartSession.Max(x => x.ItemId) + 1 : 1,
                        SeoAlias = product.Data.SeoAlias
                    });
                    _session.SetObject(SystemConstants.CartSession, cartSession);
                }
            }
            else // if cart not exist, create new cart
            {
                var cart = new List<CartViewModel>
                {
                    new CartViewModel()
                    {
                        Quantity = quantity,
                        SizeId = sizeOption != null ? sizeOption.Id : sizeid,
                        SizeName = sizeOption != null ? sizeOption.NameOption : string.Empty,
                        DefaultImage = product.Data.DefaultImage ?? SystemConstants.DefaultImage,
                        Name = product.Data.Name ?? string.Empty,
                        Price = product.Data.Price - product.Data.DiscountPrice,
                        ProductId = product.Data.Id,
                        ItemId = 1,
                        SeoAlias = product.Data.SeoAlias
                    }
                };
                _session.SetObject(SystemConstants.CartSession, cart);
            }
            return 2; // Add successed
        }

        public bool UpdateCartSession(IDictionary<int, int> dic)
        {
            var cart = _session.GetObject<List<CartViewModel>>(SystemConstants.CartSession);
            if (cart != null)
            {
                foreach (var item in cart ?? Enumerable.Empty<CartViewModel>())
                {
                    item.Quantity = dic.FirstOrDefault(x => x.Key == item.ItemId).Value;
                }
                _session.SetObject(SystemConstants.CartSession, cart);
                return true;
            }
            return false;
        }

        public void RemoveItemSession(int itemId)
        {
            var cart = _session.GetObject<List<CartViewModel>>(SystemConstants.CartSession);
            foreach (var item in cart ?? Enumerable.Empty<CartViewModel>())
            {
                if (item.ItemId == itemId)
                {
                    cart.Remove(item);
                    break;
                }
            }
            _session.SetObject(SystemConstants.CartSession, cart);
        }

        public void ClearCartSession()
        {
            this._session.Remove(SystemConstants.CartSession);
        }

        #endregion

    }
}
