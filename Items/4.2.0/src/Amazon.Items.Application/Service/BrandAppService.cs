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

namespace Amazon.Items.Service
{
    public class BrandAppService : ItemsAppServiceBase, IBrandAppService
    {
        IRepository<Brand> _brandRepository;
        public BrandAppService(IRepository<Brand> brandRepository, IApplicationInjector applicationInjector):base(applicationInjector)
        {
            _brandRepository = brandRepository;
        }

        public string BrandOrderByTerm { get; set; } = "name";

        public async Task<Response<List<BrandDto>,PageList>> GetBrands(Request<Search> request)
        {
            try
            {              
                var query = _brandRepository.GetAllAsNoTraking();
                if (!string.IsNullOrEmpty(request.Item.SearchTerm))
                    query = query.Where(p => p.Name.StartsWith(request.Item.SearchTerm, System.StringComparison.InvariantCultureIgnoreCase));

                if (request.Item.OrderBy.Equals(BrandOrderByTerm, System.StringComparison.InvariantCultureIgnoreCase))
                    query = request.Item.IsAsc ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name);

                var count = await query.CountAsync();

                if (!request.Item.Take.IsZero())
                    query = query.Skip(request.Item.Skip).Take(request.Item.Take);
                var result = await query.ToListAsync();
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
                var result = await _brandRepository.GetAllAsNoTraking()
                    .Select(p => new KeyValuePair<int, string>(p.Id, p.Name))
                    .ToListAsync();

                return Response(result);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
