using AutoMapper;
using DataTransferObjects.DTOs.Brands;
using DataTransferObjects.DTOs.Carts;
using DataTransferObjects.DTOs.Categories;
using DataTransferObjects.DTOs.Delivery;
using DataTransferObjects.DTOs.Menus;
using DataTransferObjects.DTOs.Options;
using DataTransferObjects.DTOs.Orders;
using DataTransferObjects.DTOs.Posts;
using DataTransferObjects.DTOs.Products;
using DataTransferObjects.DTOs.Promotions;
using DataTransferObjects.DTOs.Sliders;
using DataTransferObjects.DTOs.Tags;
using DataTransferObjects.DTOs.Users;
using DataTransferObjects.DTOs.WishLists;
using NordaShop.WebApp.Models.Brand;
using NordaShop.WebApp.Models.Cart;
using NordaShop.WebApp.Models.Category;
using NordaShop.WebApp.Models.Delivery;
using NordaShop.WebApp.Models.Menu;
using NordaShop.WebApp.Models.Option;
using NordaShop.WebApp.Models.Order;
using NordaShop.WebApp.Models.Post;
using NordaShop.WebApp.Models.Product;
using NordaShop.WebApp.Models.Promotion;
using NordaShop.WebApp.Models.Slide;
using NordaShop.WebApp.Models.Tag;
using NordaShop.WebApp.Models.User;

namespace NordaShop.WebApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, ProductViewModel>();
            CreateMap<CategoryDto, CategoryViewModel>();
            CreateMap<OptionDto, OptionViewModel>();
            CreateMap<ProductImageDto, ProductImageViewModel>();
            CreateMap<CartItemDto, MiniCartItemViewModel>();
            CreateMap<MenuDto, MenuViewModel>();
            CreateMap<WishListDto, WishListViewModel>();
            CreateMap<UserDto, UserViewModel>();
            CreateMap<UserOrderDto, OrderViewModel>();
            CreateMap<BrandDto, BrandViewModel>();
            CreateMap<OrderDetailDto, OrderItemViewModel>();
            CreateMap<DetailDto, DetailViewModel>();
            CreateMap<PromotionDto, PromotionViewModel>();
            CreateMap<TagDto, TagViewModel>();
            CreateMap<UserDashboardDto, DashboardViewModel>();
            CreateMap<RelatedColorDto, RelatedColorViewModel>();
            CreateMap<SliderDto, SlideViewModel>();
            CreateMap<ProductRatingDto, ProductRatingViewModel>();
            CreateMap<ProvinceDto, ProvinceViewModel>();
            CreateMap<DistrictDto, DistrictViewModel>();
            CreateMap<WardDto, WardViewModel>();
            CreateMap<PostDto, PostViewModel>();
            CreateMap<PostCommentDto, PostCommentViewModel>();
        }
    }
}
