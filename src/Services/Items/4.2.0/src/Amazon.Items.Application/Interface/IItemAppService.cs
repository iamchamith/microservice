using Abp.Application.Services;
using Amazon.Items.Dto;
using App.SharedKernel.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amazon.Items.Interface
{
    public interface IItemAppService:IApplicationService
    {
        Task<Response<List<ItemDto>, PageList>> GetItems(Request<Search> request);
        Task<Response<ItemDto>> GetItemById(Request<int> request);
    }
}
