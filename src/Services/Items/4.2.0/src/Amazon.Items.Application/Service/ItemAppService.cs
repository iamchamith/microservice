using Abp.Domain.Repositories;
using Amazon.Items.Dto;
using Amazon.Items.Entities;
using Amazon.Items.Interface;
using App.SharedKernel.Application;
using App.SharedKernel.Extension;
using App.SharedKernel.Model;
using Microsoft.EntityFrameworkCore;
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
            public ItemAppService(IRepository<Item> itemRepository, IApplicationInjector applicationInjector) : base(applicationInjector)
            {
                _itemRepository = itemRepository;
            }

            public async Task<Response<List<ItemDto>, PageList>> GetItems(Request<Search> request)
            {
                try
                {
                    var orderByRequest = request.Item.OrderByQuery.ToObject<ItemOrderByRequest>();
                    var searchByRequest = request.Item.SearchTerm.ToObject<ItemSearchByRequest>();

                    var query = _itemRepository.GetAllAsNoTraking();
                    if (!string.IsNullOrEmpty(searchByRequest.Name))
                        query = query.Where(p => p.Name.StartsWith(request.Item.SearchTerm, System.StringComparison.InvariantCultureIgnoreCase));
                    if (searchByRequest.MinPrice.HasValue)
                        query = query.Where(p => p.Price >= searchByRequest.MinPrice.Value);
                    if (searchByRequest.MaxPrice.HasValue)
                        query = query.Where(p => p.Price <= searchByRequest.MaxPrice.Value);
                    if (searchByRequest.Brand.HasValue)
                        query = query.Where(p => p.BrandId == searchByRequest.Brand.Value);

                    var count = await query.CountAsync();
                    query = orderByRequest.Name ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name);
                    query = orderByRequest.Price ? query.OrderBy(p => p.Price) : query.OrderByDescending(p => p.Price);
                    query = orderByRequest.Review ? query.OrderBy(p => p.Price) : query.OrderByDescending(p => p.Price);
                    if (!request.Item.Take.IsZero())
                        query = query.Skip(request.Item.Skip).Take(request.Item.Take);
                    var result = await query.ToListAsync();
                    return PageResponse(Mapper.Map<List<ItemDto>>(result), count, request.Item);
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            public async Task<Response<ItemDto>> GetItemById(Request<int> request)
            {
                try
                {
                    var item = (await _itemRepository.GetAsync(request.Item))
                        .ThrowExceptionIfNull();
                    return Response(Mapper.Map<ItemDto>(request.Item));   
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }
    }
}
