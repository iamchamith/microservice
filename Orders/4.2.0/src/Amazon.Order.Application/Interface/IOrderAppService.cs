using Abp.Application.Services;
using Amazon.Order.Dto;
using App.SharedKernel.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amazon.Order.Interface
{
    public interface IOrderAppService:IApplicationService
    {
        Task<Response<OrderDto>> CreateOrder(Request<OrderDto> request);
        Task<Response<OrderDto>> ReadOrderByOrderId(Request<int> request);
        Task<Response<List<OrderDto>>> ReadOrdersByCustomer(Request<int> request);
    }
}
