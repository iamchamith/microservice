using Abp.Application.Services;

namespace Amazon.Order
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class OrderAppServiceBase : ApplicationService
    {
        protected OrderAppServiceBase()
        {
            LocalizationSourceName = OrderConsts.LocalizationSourceName;
        }
    }
}