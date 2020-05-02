using Abp.ObjectMapping;
using Abp.Runtime.Caching;

namespace App.SharedKernel.Application
{
    public class ApplicationInjector : IApplicationInjector
    {
        public IObjectMapper Mapper { get; set; } 
        public ApplicationInjector(IObjectMapper mapper, ICacheManager cacheManager)
        {
            Mapper = mapper; 
        }
    }
}
