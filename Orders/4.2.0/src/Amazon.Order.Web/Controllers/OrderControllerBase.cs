using Abp.AspNetCore.Mvc.Controllers;

namespace Amazon.Order.Web.Controllers
{
    public abstract class OrderControllerBase: AbpController
    {
        protected OrderControllerBase()
        {
            LocalizationSourceName = OrderConsts.LocalizationSourceName;
        }
    }
}