using DataTransferObjects.DTOs.Contacts;
using DataTransferObjects.DTOs.Utilities;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NordaShop.IntegrationApi.Interfaces
{
    public interface IContactApiClient
    {
        Task<PageResult<List<ContactDto>>> GetListContactPaging(PagingDto paging);

        Task<ApiResult<int>> AddContact(ContactDto dto);

        Task<ApiResult<ContactDto>> GetById(int id);

        Task<bool> Delete(int id); 
    }
}
