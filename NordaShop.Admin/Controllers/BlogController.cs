using AutoMapper;
using Common.Constants;
using DataTransferObjects.DTOs.Posts;
using DataTransferObjects.DTOs.Tags;
using DataTransferObjects.DTOs.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NordaShop.Admin.Models.Post;
using NordaShop.Admin.Models.Tag;
using NordaShop.IntegrationApi.Interfaces;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogApiClient _blogApi;
        private readonly IMapper _mapper;
        private readonly ITagApiClient _tagApi;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IWebHostEnvironment _env;

        public BlogController(IBlogApiClient blogApi,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            ITagApiClient tagApi,
            IWebHostEnvironment env)
        {
            _blogApi = blogApi;
            _mapper = mapper;
            _httpContext = httpContext;
            _tagApi = tagApi;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            string keyword = _httpContext.HttpContext.Request.Query["keyword"].ToString();
            int.TryParse(_httpContext.HttpContext.Request.Query["pageindex"], out int pageIndex);

            var paging = new BlogPagingDto()
            {
                Keyword = keyword,
                PageIndex = pageIndex
            };
            var posts = await _blogApi.GetAdminPosts(paging);
            var model = new PageResult<List<PostViewModel>>()
            {
                PageIndex = posts.PageIndex,
                PageSize = posts.PageSize,
                TotalRecords = posts.TotalRecords,
                Items = _mapper.Map<List<PostDto>, List<PostViewModel>>(posts.Items)
            };

            ViewBag.Keyword = keyword;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var tags = await _tagApi.GetAll();
            var model = new CEPostViewModel()
            {
                Tags = _mapper.Map<List<TagDto>, List<TagViewModel>>(tags.Data)
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CEPostViewModel model)
        {
            var listTags = await _tagApi.GetAll();

            if (!ModelState.IsValid)
            {
                model.Tags = _mapper.Map<List<TagDto>, List<TagViewModel>>(listTags.Data);
                return View(model);
            }

            int[] tags = Array.ConvertAll(Request.Form["tag"].ToArray(), int.Parse);
            var dto = new CEPostDto()
            {
                ImageFile = model.ImageFile,
                ReviewContent = model.ReviewContent,
                Tags = tags,
                Title = model.Title,
                IsActive = model.IsActive,
                SeoAlias = model.SeoAlias
            };
            var response = await _blogApi.Create(dto);
            if (response)
            {
                SetAlert(NotificationConstants.CreateSuccess, "success");
                return RedirectToAction(nameof(BlogController.Index));
            }
            SetAlert(NotificationConstants.CreateFailed, "error");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _blogApi.GetById(id, true);
            if (post != null && post.Success)
            {
                var tags = await _tagApi.GetAll();
                var tagInPosts = await _tagApi.GetTagOfPost(id);
                var model = new CEPostViewModel()
                {
                    Title = post.Data.Title,
                    ReviewContent = post.Data.ReviewContent,
                    IsActive = post.Data.IsActive,
                    SeoAlias = post.Data.SeoAlias,
                    Tags = _mapper.Map<List<TagDto>, List<TagViewModel>>(tags.Data)
                };
                foreach (var item in model.Tags ?? Enumerable.Empty<TagViewModel>())
                {
                    if (tagInPosts != null && tagInPosts.Success)
                    {
                        if (tagInPosts.Data.Any(x => x.Id == item.Id))
                        {
                            item.Checked = true;
                        }
                    }
                }
                return View(model);
            }
            SetAlert(NotificationConstants.PostNotFound, "error");
            return RedirectToAction(nameof(BlogController.Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CEPostViewModel model)
        {
            var listTags = await _tagApi.GetAll();
            var tagInPosts = await _tagApi.GetTagOfPost(model.Id);
            model.Tags = _mapper.Map<List<TagDto>, List<TagViewModel>>(listTags.Data);
            foreach (var item in model.Tags ?? Enumerable.Empty<TagViewModel>())
            {
                if (tagInPosts != null && tagInPosts.Success)
                {
                    if (tagInPosts.Data.Any(x => x.Id == item.Id))
                    {
                        item.Checked = true;
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int[] tags = Array.ConvertAll(Request.Form["tag"].ToArray(), int.Parse);
            var dto = new CEPostDto()
            {
                ImageFile = model.ImageFile,
                ReviewContent = model.ReviewContent,
                Tags = tags,
                Title = model.Title,
                IsActive = model.IsActive,
                SeoAlias = model.SeoAlias
            };
            var response = await _blogApi.Update(model.Id, dto);
            if (response)
            {
                SetAlert(NotificationConstants.UpDateSuccess, "success");
                return RedirectToAction(nameof(BlogController.Index));
            }
            SetAlert(NotificationConstants.UpdateFailed, "error");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _blogApi.Delete(id);
            if (response)
            {
                SetAlert(NotificationConstants.DeleteSuccess, "success");
            }
            else
            {
                SetAlert(NotificationConstants.DeleteFailed, "error");
            }
            return RedirectToAction(nameof(BlogController.Index));
        }

        public async Task<IActionResult> PostComments()
        {
            string keyword = _httpContext.HttpContext.Request.Query["keyword"].ToString();
            int.TryParse(_httpContext.HttpContext.Request.Query["pageindex"], out int pageIndex);
            int.TryParse(_httpContext.HttpContext.Request.Query["postid"], out int postId);

            var paging = new BlogPagingDto()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = 3
            };
            var comments = await _blogApi.GetPostComment(postId, paging);
            var model = new PageResult<List<PostCommentViewModel>>()
            {
                PageIndex = comments.PageIndex,
                PageSize = comments.PageSize,
                TotalRecords = comments.TotalRecords,
                Items = _mapper.Map<List<PostCommentDto>, List<PostCommentViewModel>>(comments.Items)
            };

            ViewBag.Keyword = keyword;
            ViewBag.PostId = postId;
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteComment(int id)
        {
            var response = await _blogApi.DeleteComment(id);
            if (response)
            {
                SetAlert(NotificationConstants.DeleteSuccess, "success");
            }
            else
            {
                SetAlert(NotificationConstants.DeleteFailed, "error");
            }
            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> UploadCkEditor()
        {
            var file = _httpContext.HttpContext.Request.Form.Files[0];
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss_") + file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), _env.WebRootPath, "file-uploads", fileName);
            var stream = new FileStream(path, FileMode.Create);
             await file.CopyToAsync(stream);
            return Json("/file-uploads/" + fileName);
        }

        [HttpGet]
        public  IActionResult BrowseCkEditor()
        {
            var dir = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), _env.WebRootPath, "file-uploads"));
            ViewBag.FileInfo = dir.GetFiles();
            return View("BrowseCkEditor");
        }


    }
}
