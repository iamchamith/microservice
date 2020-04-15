using Abp.Dependency;
using Abp.Reflection.Extensions;
using Amazon.Order.Interface;
using Amazon.Order.Service;
using App.SharedKernel.Application;

namespace Amazon.Order.Web.Startup.Config
{
    public static class IocConfig
    {
        public static void RegisterIoc(this IIocManager iocManager)
        {
            iocManager.RegisterAssemblyByConvention(typeof(OrderWebModule).GetAssembly());
            iocManager.RegisterIfNot<IOrderAppService, OrderAppService>(DependencyLifeStyle.Transient);
            iocManager.RegisterIfNot<IApplicationInjector, ApplicationInjector>(DependencyLifeStyle.Transient);
        }
    }
}
