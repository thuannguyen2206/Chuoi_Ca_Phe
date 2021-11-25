using Common.Constants;
using DataAccess.Entities;
using DataTransferObjects.DTOs.Posts;
using DataTransferObjects.DTOs.Utilities;
using Repositories;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Helper;
using Common.Messages;
using Microsoft.AspNetCore.Http;

namespace Service.Services
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUtilityService _utilityService;

        public BlogService(IUnitOfWork uow, IUtilityService utilityService)
        {
            _uow = uow;
            _utilityService = utilityService;
        }

        public ApiResult<int> AddPostComment(int postId, PostCommentDto dto)
        {
            var postCommentRepo = _uow.GetRepository<PostComment>();
            var post = _uow.GetRepository<PostReview>().Single(x => x.Id == postId && x.IsActive);
            if (post != null)
            {
                var entity = new PostComment()
                {
                    Comment = dto.Comment,
                    DateCreated = DateTime.Now,
                    Name = dto.Name,
                    Email = dto.Email,
                    PostId = postId,
                    ReplyFor = dto.ReplyFor
                };

                postCommentRepo.Insert(entity);
                _uow.SaveChanges();
                return new ApiResult<int>(true, entity.Id);
            }
            return new ApiResult<int>(false, errorCode: BlogMessage.NotFound);
        }

        public ApiResult<int> Create(CEPostDto dto)
        {
            try
            {
                var postRepo = _uow.GetRepository<PostReview>();

                var tagInPost = new List<TagInPost>();
                if (dto.Tags != null && dto.Tags.Length > 0)
                {
                    foreach (var item in dto.Tags)
                    {
                        tagInPost.Add(new TagInPost()
                        {
                            TagId = item
                        });
                    }
                }

                var entity = new PostReview()
                {
                    Title = dto.Title,
                    LinkImage = SystemConstants.DefaultImage,
                    SeoAlias = FriendlyStringHelper.GetFriendlyString(dto.SeoAlias ?? dto.Title),
                    ReviewContent = dto.ReviewContent,
                    DateCreated = DateTime.Now,
                    IsActive = dto.IsActive,
                    TagInPosts = tagInPost,
                    ViewCount = 0
                };

                if (dto.ImageFile != null)
                {
                    string path = _utilityService.SaveFile(dto.ImageFile, "images/posts/");
                    entity.LinkImage = path;
                }

                postRepo.Insert(entity);
                _uow.SaveChanges();
                return new ApiResult<int>(true, entity.Id);
            }
            catch
            {
                return new ApiResult<int>(false, errorCode: BlogMessage.CreatePostFailed);
            }
        }

        public ApiResult<bool> Delete(int id)
        {
            var postRepo = _uow.GetRepository<PostReview>();
            var tagInPostRepo = _uow.GetRepository<TagInPost>();
            var postCommentRepo = _uow.GetRepository<PostComment>();
            var post = postRepo.FindById(id);
            if (post != null)
            {
                var listComments = postCommentRepo.QueryConditionReadOnly(x => x.PostId == id).AsEnumerable();
                var tagInPost = tagInPostRepo.QueryConditionReadOnly(x => x.PostId == id).AsEnumerable();

                tagInPostRepo.DeleteRange(tagInPost);
                postCommentRepo.DeleteRange(listComments);
                postRepo.Delete(post);

                _uow.SaveChanges();
                return new ApiResult<bool>(true);
            }
            return new ApiResult<bool>(false, BlogMessage.NotFound);
        }

        public ApiResult<bool> DeleteComment(int commentId)
        {
            var postCommentRepo = _uow.GetRepository<PostComment>();
            var comment = postCommentRepo.FindById(commentId);
            if (comment != null)
            {
                postCommentRepo.Delete(comment);
                _uow.SaveChanges();
                return new ApiResult<bool>(true);
            }
            return new ApiResult<bool>(false, errorCode: BlogMessage.CommentNotFound);
        }

        public ApiResult<string> FileUploadCkEditor(IFormFile file)
        {
            if (file != null)
            {
                string path = _utilityService.SaveFile(file, "images/posts/");
                return new ApiResult<string>(true, data: path);
            }
            return new ApiResult<string>(false, data: string.Empty);
        }

        public ApiResult<PostDto> GetById(int id, bool adminRole = false)
        {
            var postRepo = _uow.GetRepository<PostReview>();
            var postFilter = postRepo.QueryAllReadOnly().AsEnumerable();
            var post = postFilter.FirstOrDefault(x => x.Id == id);
            if (post != null)
            {
                if (!adminRole && !post.IsActive)
                {
                    return new ApiResult<PostDto>(false, errorCode:BlogMessage.NotFound);
                }
                else
                {
                    var totalComments = _uow.GetRepository<PostComment>().QueryConditionReadOnly(x => x.PostId == post.Id).Count();
                    var next = postFilter.SkipWhile(x => x.Id != id).Skip(1).FirstOrDefault();
                    var previous = postFilter.TakeWhile(x => x.Id != id).LastOrDefault();
                    var result = new PostDto()
                    {
                        Id = post.Id,
                        DateCreated = post.DateCreated,
                        IsActive = post.IsActive,
                        LinkImage = post.LinkImage,
                        ReviewContent = post.ReviewContent,
                        Title = post.Title,
                        SeoAlias = post.SeoAlias,
                        TotalComment = totalComments,
                        NextId = next?.Id,
                        NextSeoAlias = next?.SeoAlias,
                        PreviousId = previous?.Id,
                        PreviousSeoAlias = previous?.SeoAlias,
                        ViewCount = post.ViewCount
                    };

                    if (!adminRole)
                    {
                        post.ViewCount++;
                        postRepo.Update(post);
                        _uow.SaveChanges();
                    }

                    return new ApiResult<PostDto>(true, data: result);
                }
            }
            return new ApiResult<PostDto>(false, BlogMessage.NotFound);
        }

        public ApiResult<List<PostDto>> GetLastestPost()
        {
            var result = _uow.GetRepository<PostReview>()
                .QueryConditionReadOnly(x => x.IsActive)
                .OrderByDescending(x=>x.Id)
                .Take(SystemConstants.LastestPost)
                .Select(x => new PostDto()
                {
                    Id = x.Id,
                    LinkImage = x.LinkImage,
                    SeoAlias = x.SeoAlias,
                    Title = x.Title,
                    DateCreated = x.DateModified ?? x.DateCreated
                }).ToList();

            return new ApiResult<List<PostDto>>(true, data: result);
        }

        public ApiResult<List<PostCommentDto>> GetLastestPostComment(int postId)
        {
            var post = _uow.GetRepository<PostReview>().FindById(postId);
            if (post == null)
            {
                return new ApiResult<List<PostCommentDto>>(false, errorCode: BlogMessage.NotFound);
            }

            var result = _uow.GetRepository<PostComment>()
                .QueryConditionReadOnly(x => x.PostId == postId)
                .OrderByDescending(x => x.Id)
                .Take(SystemConstants.LastestPostComment)
                .Select(x => new PostCommentDto()
                {
                    Id = x.Id,
                    Comment = x.Comment,
                    DateCreated = x.DateCreated,
                    Name = x.Name,
                    PostId = x.PostId,
                    ReplyFor = x.ReplyFor,
                    ImageLink = SystemConstants.UserDefault
                }).ToList();

            return new ApiResult<List<PostCommentDto>>(true, data: result);
        }

        public PageResult<List<PostDto>> GetPagings(BlogPagingDto paging, bool adminRole = false)
        {
            var postRepo = _uow.GetRepository<PostReview>().QueryAllReadOnly();
            if (!adminRole)
            {
                postRepo = postRepo.Where(x => x.IsActive);
            }

            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                paging.Keyword = paging.Keyword.Trim().ToLower();
                postRepo = postRepo.Where(x => x.Title.ToLower().Contains(paging.Keyword)
                                  || x.ReviewContent.ToLower().Contains(paging.Keyword));
            }

            if (paging.TagId != null && paging.TagId != 0)
            {
                var tagRepo = _uow.GetRepository<Tag>().QueryConditionReadOnly(x => x.IsActive);
                var tagInPostRepo = _uow.GetRepository<TagInPost>().QueryAllReadOnly();
                var tagInPost = (from a in tagRepo
                                 join b in tagInPostRepo on a.Id equals b.TagId
                                 where a.Id == paging.TagId
                                 select b.PostId).AsEnumerable();

                postRepo = postRepo.Where(x => tagInPost.Contains(x.Id));
            }

            var postCommentRepo = _uow.GetRepository<PostComment>().QueryAllReadOnly();
            int totalRow = postRepo.Count();
            var result = postRepo.OrderByDescending(x => x.Id)
                .Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .Select(x => new PostDto()
                {
                    Id = x.Id,
                    DateCreated = x.DateCreated,
                    IsActive = x.IsActive,
                    LinkImage = x.LinkImage,
                    OwnerId = x.OwnerId,
                    ViewCount = x.ViewCount,
                    //ReviewContent = x.ReviewContent,
                    SeoAlias = x.SeoAlias,
                    Title = x.Title,
                    TotalComment = postCommentRepo.Count(y => y.PostId == x.Id)
                }).ToList();

            var pageResult = new PageResult<List<PostDto>>()
            {
                Items = result,
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize,
                TotalRecords = totalRow
            };
            return pageResult;
        }

        public PageResult<List<PostCommentDto>> GetPostComment(int postId, BlogPagingDto paging)
        {
            var query = _uow.GetRepository<PostComment>().QueryConditionReadOnly(x => x.PostId == postId);

            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                paging.Keyword = paging.Keyword.Trim().ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(paging.Keyword)
                                  || x.Email.ToLower().Contains(paging.Keyword)
                                  || x.Comment.ToLower().Contains(paging.Keyword));
            }

            int totalRow = query.Count();
            var result = query.OrderByDescending(x => x.Id)
                .Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .Select(x => new PostCommentDto()
                {
                    Id = x.Id,
                    Comment = x.Comment,
                    DateCreated = x.DateCreated,
                    Name = x.Name,
                    PostId = x.PostId,
                    ReplyFor = x.ReplyFor,
                    ImageLink = SystemConstants.UserDefault,
                    Email = x.Email
                }).ToList();

            var pageResult = new PageResult<List<PostCommentDto>>()
            {
                Items = result,
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize,
                TotalRecords = totalRow
            };
            return pageResult;
        }

        // get all tag of this post, then select from list tag join with PostReview entity to find some related
        public ApiResult<List<PostDto>> GetRelatedPost(int postId)
        {
            var postRepo = _uow.GetRepository<PostReview>().QueryConditionReadOnly(x => x.IsActive);

            var post = postRepo.FirstOrDefault(x => x.Id == postId);
            if (post != null)
            {
                var tagRepo = _uow.GetRepository<Tag>().QueryConditionReadOnly(x => x.IsActive);
                var tagInPostRepo = _uow.GetRepository<TagInPost>().QueryAllReadOnly();

                //var listPostIds = (from a in tagRepo
                //                   join b in tagInPostRepo on a.Id equals b.TagId
                //                   where b.PostId == postId
                //                   select b.TagId into tag
                //                   from c in tagInPostRepo
                //                   where c.PostId != postId && c.TagId == tag
                //                   select c.PostId).AsEnumerable().Distinct();

                //var result = postRepo.Where(x => listPostIds.Contains(x.Id))
                //    .Select(x => new PostDto()
                //    {
                //        Id = x.Id,
                //        DateCreated = x.DateCreated,
                //        LinkImage = x.LinkImage,
                //        SeoAlias = x.SeoAlias,
                //        Title = x.Title
                //    }).ToList();

                var result = (from a in tagRepo
                              join b in tagInPostRepo on a.Id equals b.TagId
                              where b.PostId == postId
                              select b.TagId into tag
                              from c in postRepo
                              join d in tagInPostRepo on c.Id equals d.PostId
                              where c.Id != postId && tag == d.TagId
                              select new PostDto()
                              {
                                  Id = c.Id,
                                  DateCreated = c.DateCreated,
                                  LinkImage = c.LinkImage,
                                  SeoAlias = c.SeoAlias,
                                  Title = c.Title
                              }).Distinct()
                              .Take(SystemConstants.RelatedPost)
                              .ToList();

                return new ApiResult<List<PostDto>>(true, data: result);
            }

            return new ApiResult<List<PostDto>>(false, errorCode: BlogMessage.NotFound);
        }

        public ApiResult<int> Update(int id, CEPostDto dto)
        {
            var postRepo = _uow.GetRepository<PostReview>();
            var tagInPostRepo = _uow.GetRepository<TagInPost>();

            var post = postRepo.Single(x => x.Id == id);
            if (post != null)
            {
                if (dto.ImageFile != null)
                {
                    string path = _utilityService.SaveFile(dto.ImageFile, "images/posts/");
                    post.LinkImage = path;
                }

                post.Title = dto.Title;
                post.SeoAlias = FriendlyStringHelper.GetFriendlyString(dto.SeoAlias ?? dto.Title);
                post.ReviewContent = dto.ReviewContent;
                post.DateModified = DateTime.Now;
                post.IsActive = dto.IsActive;

                var tagInPost = tagInPostRepo.QueryConditionReadOnly(x => x.PostId == id).AsEnumerable();
                var tags = new List<TagInPost>();
                foreach (var item in dto.Tags ?? Enumerable.Empty<int>())
                {
                    tags.Add(new TagInPost()
                    {
                        PostId = id,
                        TagId = item
                    });
                }

                postRepo.Update(post);
                tagInPostRepo.DeleteRange(tagInPost);
                tagInPostRepo.InsertRange(tags);
                _uow.SaveChanges();
                return new ApiResult<int>(true, post.Id);
            }
            return new ApiResult<int>(false, errorCode: BlogMessage.NotFound);
        }

    }
}
