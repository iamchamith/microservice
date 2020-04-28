using Abp.Application.Services;
using App.SharedKernel.Application;

namespace Amazon.Items
{
    public abstract class ItemsAppServiceBase : BaseAppService
    {
        protected ItemsAppServiceBase(IApplicationInjector injector):base(injector)
        {
            LocalizationSourceName = ItemsConsts.LocalizationSourceName;
        }
    }
}