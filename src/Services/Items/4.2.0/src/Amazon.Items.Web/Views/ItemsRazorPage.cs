using Abp.AspNetCore.Mvc.Views;

namespace Amazon.Items.Web.Views
{
    public abstract class ItemsRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected ItemsRazorPage()
        {
            LocalizationSourceName = ItemsConsts.LocalizationSourceName;
        }
    }
}
