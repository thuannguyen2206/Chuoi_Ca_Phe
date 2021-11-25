using AutoMapper;
using DataTransferObjects.DTOs.Brands;
using DataTransferObjects.DTOs.Categories;
using DataTransferObjects.DTOs.Contacts;
using DataTransferObjects.DTOs.Menus;
using DataTransferObjects.DTOs.Options;
using DataTransferObjects.DTOs.Orders;
using DataTransferObjects.DTOs.Posts;
using DataTransferObjects.DTOs.Products;
using DataTransferObjects.DTOs.Promotions;
using DataTransferObjects.DTOs.Sliders;
using DataTransferObjects.DTOs.Tags;
using DataTransferObjects.DTOs.Users;
using NordaShop.Admin.Models.Brand;
using NordaShop.Admin.Models.Category;
using NordaShop.Admin.Models.Menu;
using NordaShop.Admin.Models.Option;
using NordaShop.Admin.Models.Order;
using NordaShop.Admin.Models.Post;
using NordaShop.Admin.Models.Product;
using NordaShop.Admin.Models.Promotion;
using NordaShop.Admin.Models.Slide;
using NordaShop.Admin.Models.Tag;
using NordaShop.Admin.Models.User;

namespace NordaShop.Admin.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, UserEditViewModel>();
            CreateMap<UserDto, UserViewModel>();
            CreateMap<ProductCreateDto, ProductCreateViewModel>();
            CreateMap<ProductDto, ProductViewModel>();
            CreateMap<OptionDto, OptionViewModel>();
            CreateMap<ProductImageDto, ProductImageViewModel>();
            CreateMap<CategoryDto, CategoryViewModel>();
            CreateMap<CategoryDto, CategoryCEViewModel>();// category create edit model
            CreateMap<MenuDto, MenuViewModel>();
            CreateMap<BrandDto, BrandViewModel>();
            CreateMap<OrderDto, OrderInfoViewModel>();
            CreateMap<OrderDetailDto, OrderDetailViewModel>();
            CreateMap<DetailDto, OrderViewModel>();
            CreateMap<ContactDto, ContactViewModel>();
            CreateMap<PromotionDto, PromotionViewModel>();
            CreateMap<TagDto, TagViewModel>();
            CreateMap<SliderDto, SlideViewModel>();
            CreateMap<PostDto, PostViewModel>();
            CreateMap<PostCommentDto, PostCommentViewModel>();
        }
    }
}
