using Amazon.Order.Dto;
using App.SharedKernel.Application;
using App.SharedKernel.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.SharedKernel.Extension;
using System.Linq;
using Amazon.Order.Interface;

namespace Amazon.Order.Service
{
    public class BasketAppService : OrderAppServiceBase, IBasketAppService
    {
        public string CacheKey { get; set; } = "basket_{0}";
        public BasketAppService(IApplicationInjector coreInjector) : base(coreInjector)
        {

        }

        private string GetCacheKey(int userid)
        {
            return string.Format(CacheKey, userid);
        }

        public async Task AddToBasket(Request<BasketModel> request)
        {
            var requestItem = request.Item;
            requestItem.SetUser(request.User).CalculateTotalPrice();

            var result = (await ReadItemsByUserId(new Request<int>(request.UserId))).Item;
            var item = result.SingleOrDefault(p => p.ItemId == requestItem.ItemId);
            if (item.IsNull())
                result.Add(requestItem);
            else
                item.AddMoreItems(requestItem).CalculateTotalPrice();

            await ClearBusketByUserId(new Request<int>(request.UserId));
            await Cache.SetAsync(GetCacheKey(request.UserId), result);

        }
        public async Task RemoveBasket(Request<int> request)
        {
            var result = (await ReadItemsByUserId(new Request<int>(request.UserId))).Item;
            result.RemoveAll(p => p.ItemId == request.Item);

            await ClearBusketByUserId(new Request<int>(request.UserId));
            await Cache.SetAsync(GetCacheKey(request.UserId), result);

        }
        public async Task UpdateBasket(Request<BasketModel> request)
        {
            var result = (await ReadItemsByUserId(new Request<int>(request.UserId))).Item;
            var item = result.SingleOrDefault(p => p.ItemId == request.Item.ItemId);
            if (!item.IsNull())
                item.Update(request.Item.Quantity);

            await ClearBusketByUserId(new Request<int>(request.UserId));
            await Cache.SetAsync(GetCacheKey(request.UserId), result);
        }
        public async Task ClearBusketByUserId(Request<int> request)
        {
            await Cache.RemoveAsync(GetCacheKey(request.UserId));
        }
        public async Task<Response<List<BasketModel>>> ReadItemsByUserId(Request<int> request)
        {
            var result = await base.Cache.GetOrDefaultAsync(GetCacheKey(request.UserId))
                as List<BasketModel>;
            return Response(result.IsNullOrZero() ? new List<BasketModel>() : result);
        }

    }
}
