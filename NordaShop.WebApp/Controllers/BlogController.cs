using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Common.Constants;
using DataTransferObjects.DTOs.Posts;
using DataTransferObjects.DTOs.Tags;
using DataTransferObjects.DTOs.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NordaShop.IntegrationApi.Interfaces;
using NordaShop.WebApp.Models.Post;
using NordaShop.WebApp.Models.Tag;
using Service.ApiResponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogApiClient _blogApi;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly ITagApiClient _tagApi;
        private readonly INotyfService _notyf;

        public BlogController(IBlogApiClient blogApi, 
            IHttpContextAccessor httpContext, 
            IMapper mapper, 
            ITagApiClient tagApi,
            INotyfService notyf)
        {
            _blogApi = blogApi;
            _httpContext = httpContext;
            _mapper = mapper;
            _tagApi = tagApi;
            _notyf = notyf;
        }

        public async Task<IActionResult> Index()
        {
            string keyword = _httpContext.HttpContext.Request.Query["keyword"].ToString();
            int.TryParse(_httpContext.HttpContext.Request.Query["pageindex"], out int pageIndex);
            int.TryParse(_httpContext.HttpContext.Request.Query["tagid"], out int tagid);

            var paging = new BlogPagingDto()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = SystemConstants.PostInPage,
                TagId = tagid
            };

            var posts = await _blogApi.GetPosts(paging);
            var tags = await _tagApi.GetTopPostTags();
            var lastestPost = await _blogApi.GetLastestPost();
            var model = new PostIndexViewModel()
            {
                Posts = new PageResult<List<PostViewModel>>()
                {
                    PageIndex = posts.PageIndex,
                    PageSize = posts.PageSize,
                    TotalRecords = posts.TotalRecords,
                    Items = _mapper.Map<List<PostDto>, List<PostViewModel>>(posts.Items)
                },
                Tags = _mapper.Map<List<TagDto>, List<TagViewModel>>(tags?.Data),
                LastestPosts = _mapper.Map<List<PostDto>, List<PostViewModel>>(lastestPost.Data)
            };
            
            ViewBag.Keyword = keyword;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var post = await _blogApi.GetById(id);
            if (post != null && post.Success)
            {
                var tagInPost = await _tagApi.GetTagOfPost(id);
                var relatedPosts = await _blogApi.GetRelatedPost(id);
                var comments = await _blogApi.GetLastestPostComment(id);
                var model = new PostDetailViewModel()
                {
                    Post = _mapper.Map<PostViewModel>(post.Data),
                    Tags = _mapper.Map<List<TagDto>, List<TagViewModel>>(tagInPost?.Data),
                    RelatedPost = _mapper.Map<List<PostDto>, List<PostViewModel>>(relatedPosts?.Data),
                    PostComments = _mapper.Map<List<PostCommentDto>, List<PostCommentViewModel>>(comments?.Data),
                };
                return View(model);
            }
            return RedirectToAction("Index", "Blog");
        }

        public async Task<JsonResult> CreateComment(NewPostCommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _notyf.Error(NotificationConstants.InvalidForm);
                return Json(new { status = false });
            }

            var dto = new PostCommentDto()
            {
                Name = model.Name,
                Comment = model.Message,
                PostId = model.PostId,
                Email = model.Email,
                ImageLink = SystemConstants.UserDefault
            };
            var response = await _blogApi.AddPostComment(model.PostId, dto);
            if (response != null && response.Success)
            {
                _notyf.Success(NotificationConstants.CreatePostCommentSusscess);
                return Json(new { status = true, data = dto });
            }
            _notyf.Error(NotificationConstants.Error);
            return Json(new { status = false });
        }


    }
}
