using Abp.AspNetCore.Mvc.Views;

namespace Amazon.Order.Web.Views
{
    public abstract class OrderRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected OrderRazorPage()
        {
            LocalizationSourceName = OrderConsts.LocalizationSourceName;
        }
    }
}
