using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Amazon.Items.Dto;
using Amazon.Items.Entities;
using Amazon.Items.Interface;
using App.SharedKernel.Extension;
using App.SharedKernel.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using App.SharedKernel.Application;
using RedisRepo;
using System;

namespace Amazon.Items.Service
{
    public class BrandAppService : ItemsAppServiceBase, IBrandAppService
    {
        IRepository<Brand> _brandRepository;
        RedisContext<Brand> _brandCache { get; }
        public BrandAppService(IRepository<Brand> brandRepository,
            RedisContext<Brand> brandCache,
            IApplicationInjector applicationInjector) : base(applicationInjector)
        {
            _brandRepository = brandRepository;
            _brandCache = brandCache.SetDatabase(nameof(Brand));
        }

        public string BrandOrderByTerm { get; set; } = "name";


        public async Task<Response<List<BrandDto>, PageList>> GetBrands(Request<Search> request)
        {
            try
            {
                var cacheResult = await _brandCache.Get();
                var result = new List<Brand>();
                if (cacheResult.Item1)
                    result = cacheResult.Item2;
                else
                {
                    var dbResult = await _brandRepository.GetAll().AsNoTracking().ToListAsync();
                    await _brandCache.RefillIfNot(dbResult);
                }
                if (!string.IsNullOrEmpty(request.Item.SearchTerm))
                    result = result.Where(p => p.Name.StartsWith(request.Item.SearchTerm, System.StringComparison.InvariantCultureIgnoreCase))
                        .ToList();
                if (request.Item.OrderBy.Equals(BrandOrderByTerm, System.StringComparison.InvariantCultureIgnoreCase))
                    result = (request.Item.IsAsc ? result.OrderBy(p => p.Name) : result.OrderByDescending(p => p.Name))
                        .ToList();
                var count = result.Count;

                if (!request.Item.Take.IsZero())
                    result = result.Skip(request.Item.Skip).Take(request.Item.Take).ToList();
                return PageResponse(Mapper.Map<List<BrandDto>>(result), count, request.Item);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<Response<List<KeyValuePair<int, string>>>> GetBrandsKeyValuePair(Request<int> request)
        {
            try
            {
                var cacheResult = await _brandCache.Get();
                var result = new List<KeyValuePair<int, string>>();
                if (cacheResult.Item1)
                {
                    return Response(cacheResult.Item2.Select(p => new KeyValuePair<int, string>(p.Id, p.Name)).ToList());
                }
                else
                {
                    var dbResult = (await GetBrands(base.Request(request, new Search().SetOrderBy(BrandOrderByTerm)))).Item1;
                    return Response(cacheResult.Item2.Select(p => new KeyValuePair<int, string>(p.Id, p.Name)).ToList());
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
