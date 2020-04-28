using Abp.Application.Services;
using Amazon.Items.Dto;
using App.SharedKernel.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amazon.Items.Interface
{
    public interface IBrandAppService : IApplicationService
    {
        string BrandOrderByTerm { get; set; }
        Task<Response<List<BrandDto>, PageList>> GetBrands(Request<Search> request);
        Task<Response<List<KeyValuePair<int, string>>>> GetBrandsKeyValuePair(Request<int> request);
    }
}
