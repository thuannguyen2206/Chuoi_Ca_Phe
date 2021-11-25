using DataTransferObjects.DTOs.Contacts;
using DataTransferObjects.DTOs.Utilities;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IServices
{
    public interface IContactService
    {
        /// <summary>
        /// Create new contact (feedback)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        ApiResult<int> Create(ContactDto dto);

        /// <summary>
        /// Get list contacts paging
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        PageResult<List<ContactDto>> GetPagings(PagingDto paging);

        /// <summary>
        /// Get contact by id and change status is read equal true
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        ApiResult<ContactDto> GetById(int id);

        ApiResult<bool> Delete(int id);
    }
}
