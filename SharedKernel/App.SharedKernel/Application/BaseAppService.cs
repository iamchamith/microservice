using Abp.Application.Services;
using Abp.ObjectMapping;
using Abp.Runtime.Caching;
using App.SharedKernel.Model;
using System.Collections.Generic;

namespace App.SharedKernel.Application
{
    public class BaseAppService : ApplicationService
    {
        protected IObjectMapper Mapper;
        protected ICache Cache;
        public BaseAppService(IApplicationInjector injector)
        {
            Mapper = injector.Mapper;
            Cache = injector.Cache;
        }
        protected Response<T> Response<T>(T item)
        {
            return new Response<T>(item);
        }
        protected Response<List<T>, PageList> PageResponse<T>(List<T> item, int recordCount = 0, Search search = null)
        {
            return new Response<List<T>, PageList>(item, new PageList().SetPageResult(recordCount, search));
        }

       
    }
}
