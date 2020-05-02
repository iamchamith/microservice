using Abp.Application.Services;
using Abp.ObjectMapping;
using App.SharedKernel.Model;
using System.Collections.Generic;

namespace App.SharedKernel.Application
{
    public class BaseAppService : ApplicationService
    {
        protected IObjectMapper Mapper; 
        public BaseAppService(IApplicationInjector injector)
        {
            Mapper = injector.Mapper; 
        }
        protected Response<T> Response<T>(T item)
        {
            return new Response<T>(item);
        }
        protected Response<List<T>, PageList> PageResponse<T>(List<T> item, int recordCount = 0, Search search = null)
        {
            return new Response<List<T>, PageList>(item, new PageList().SetPageResult(recordCount, search));
        }

        protected Request<TOut> Request<TIn, TOut>(Request<TIn> requestIn, TOut requestOut) {

            return new Request<TOut>(requestOut, requestIn.UserId);
        }
       
    }
}
