using Abp.Domain.Repositories;
using Amazon.Items.Dto;
using Amazon.Items.Entities;
using Amazon.Items.Interface;
using App.SharedKernel.Application;
using App.SharedKernel.Extension;
using App.SharedKernel.Model;
using Microsoft.EntityFrameworkCore;
using RedisRepo;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Items.Service
{
    namespace Amazon.Items.Service
    {
        public class ItemAppService : ItemsAppServiceBase, IItemAppService
        {
            IRepository<Item> _itemRepository;
            RedisContext<Item> _itemCache;
            public ItemAppService(IRepository<Item> itemRepository,
                RedisContext<Item> itemCache,
                IApplicationInjector applicationInjector) : base(applicationInjector)
            {
                _itemRepository = itemRepository;
                _itemCache = itemCache.SetDatabase(nameof(Item));
            }

            public async Task<Response<List<ItemDto>, PageList>> GetItems(Request<Search> request)
            {
                try
                {
                    var cacheResult = await _itemCache.Get();
                    var result = (cacheResult.Item1) ? cacheResult.Item2 : await _itemCache.RefillIfNot(await _itemRepository.GetAllAsNoTraking().ToListAsync());

                    var orderByRequest = request.Item.OrderByQuery.ToObject<ItemOrderByRequest>(returnDefault: true) ?? new ItemOrderByRequest();
                    var searchByRequest = request.Item.SearchTerm.ToObject<ItemSearchByRequest>(returnDefault: true) ?? new ItemSearchByRequest();
                    if (!string.IsNullOrEmpty(searchByRequest?.Name))
                        result = result.Where(p => p.Name.StartsWith(request.Item.SearchTerm, System.StringComparison.InvariantCultureIgnoreCase)).ToList();
                    if (searchByRequest.MinPrice.HasValue)
                        result = result.Where(p => p.Price >= searchByRequest.MinPrice.Value).ToList();
                    if (searchByRequest.MaxPrice.HasValue)
                        result = result.Where(p => p.Price <= searchByRequest.MaxPrice.Value).ToList();
                    if (searchByRequest.Brand.HasValue)
                        result = result.Where(p => p.BrandId == searchByRequest.Brand.Value).ToList();

                    var count = result.Count();
                    result = orderByRequest.Name ? result.OrderBy(p => p.Name).ToList() : result.OrderByDescending(p => p.Name).ToList();
                    result = orderByRequest.Price ? result.OrderBy(p => p.Price).ToList() : result.OrderByDescending(p => p.Price).ToList();
                    result = orderByRequest.Review ? result.OrderBy(p => p.Price).ToList() : result.OrderByDescending(p => p.Price).ToList();
                    if (!request.Item.Take.IsZero())
                        result = result.Skip(request.Item.Skip).Take(request.Item.Take).ToList();

                    var dtos = Mapper.Map<List<ItemDto>>(result);
                    dtos.ForEach(item =>
                    {
                        item.SetImageWithPath();
                    });
                    return PageResponse(dtos, count, request.Item);
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
            public async Task<Response<ItemDto>> GetItemById(Request<int> request)
            {
                try
                {
                    var item = (await _itemRepository.GetAsync(request.Item))
                        .ThrowExceptionIfNull();
                    return Response(Mapper.Map<ItemDto>(item).SetImageWithPath());
                }
                catch (System.Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
