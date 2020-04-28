using Abp.Application.Services;
using App.SharedKernel.Application;

namespace Amazon.Order
{
    public abstract class OrderAppServiceBase : BaseAppService
    {
        protected OrderAppServiceBase(IApplicationInjector injector) : base(injector)
        {
            LocalizationSourceName = OrderConsts.LocalizationSourceName;
        }
    }
}