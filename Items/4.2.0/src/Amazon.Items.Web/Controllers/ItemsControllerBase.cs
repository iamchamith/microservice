using Abp.AspNetCore.Mvc.Controllers;

namespace Amazon.Items.Web.Controllers
{
    public abstract class ItemsControllerBase: AbpController
    {
        protected ItemsControllerBase()
        {
            LocalizationSourceName = ItemsConsts.LocalizationSourceName;
        }
    }
}