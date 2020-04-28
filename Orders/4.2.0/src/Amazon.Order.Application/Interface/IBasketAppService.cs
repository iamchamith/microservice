using Amazon.Order.Dto;
using App.SharedKernel.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amazon.Order.Interface
{
    public interface IBasketAppService
    {
        string CacheKey { get; set; }
        Task AddToBasket(Request<BasketModel> request);
        Task RemoveBasket(Request<int> request);
        Task UpdateBasket(Request<BasketModel> request);
        Task ClearBusketByUserId(Request<int> request);
        Task<Response<List<BasketModel>>> ReadItemsByUserId(Request<int> request);
    }
}
