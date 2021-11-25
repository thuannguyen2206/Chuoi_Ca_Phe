using Common.Messages;
using DataAccess.Entities;
using DataTransferObjects.DTOs.Contacts;
using DataTransferObjects.DTOs.Utilities;
using Repositories;
using Service.ApiResponse;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _uow;

        public ContactService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ApiResult<int> Create(ContactDto dto)
        {
            try
            {
                var contactRepo = _uow.GetRepository<Contact>();
                var entity = new Contact()
                {
                    DateCreated = DateTime.Now,
                    Email = dto.Email,
                    IsRead = false,
                    Message = dto.Message,
                    Name = dto.Name,
                    Subject = dto.Subject
                };

                contactRepo.Insert(entity);
                _uow.SaveChanges();
                return new ApiResult<int>(true, data: entity.Id);
            }
            catch (Exception)
            {
                return new ApiResult<int>(false);
            }
        }

        public ApiResult<bool> Delete(int id)
        {
            var contactRepo = _uow.GetRepository<Contact>();
            var contact = contactRepo.FindById(id);
            if (contact != null)
            {
                contact.IsDelete = true;
                contactRepo.Update(contact);
                _uow.SaveChanges();
                return new ApiResult<bool>(true);
            }
            return new ApiResult<bool>(false);
        }

        public ApiResult<ContactDto> GetById(int id)
        {
            var contactRepo = _uow.GetRepository<Contact>();
            var contact = contactRepo.FindById(id);
            if (contact == null)
            {
                return new ApiResult<ContactDto>(false, errorCode: UserMessage.ContactNotFound);
            }
            var result = new ContactDto()
            {
                DateCreated = contact.DateCreated,
                Email = contact.Email,
                Id = contact.Id,
                IsRead = contact.IsRead,
                Message = contact.Message,
                Subject = contact.Subject,
                Name = contact.Name,
            };
            contact.IsRead = true;
            contactRepo.Update(contact);
            _uow.SaveChanges();
            return new ApiResult<ContactDto>(true, data: result);
        }

        public PageResult<List<ContactDto>> GetPagings(PagingDto paging)
        {
            var contacts = _uow.GetRepository<Contact>().QueryAllReadOnly();
            if (!string.IsNullOrEmpty(paging.Keyword))
            {
                paging.Keyword = paging.Keyword.Trim().ToLower();
                contacts = contacts.Where(x => x.Name.ToLower().Contains(paging.Keyword)
                  || x.Subject.ToLower().Contains(paging.Keyword)
                  || x.Email.ToLower().Contains(paging.Keyword)
                  || x.Message.ToLower().Contains(paging.Keyword));
            }

            int totalRecords = contacts.Count();
            var data = contacts.OrderByDescending(x => x.DateCreated)
                .Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .Select(x => new ContactDto()
                {
                    DateCreated = x.DateCreated,
                    Email = x.Email,
                    Id = x.Id,
                    IsRead = x.IsRead,
                    Message = x.Message,
                    Subject = x.Subject,
                    Name = x.Name,
                }).ToList();

            var pageResult = new PageResult<List<ContactDto>>()
            {
                Items = data,
                PageIndex = paging.PageIndex,
                PageSize = paging.PageSize,
                TotalRecords = totalRecords
            };
            return pageResult;
        }



    }
}
