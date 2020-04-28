using Abp.Dependency;
using Abp.Reflection.Extensions;
using Amazon.Items.Interface;
using Amazon.Items.Service;
using Amazon.Items.Service.Amazon.Items.Service;
using App.SharedKernel.Application;

namespace Amazon.Items.Web.Startup.Config
{
    public static class IocConfig
    {
        public static void RegisterIoc(this IIocManager iocManager) {
            iocManager.RegisterAssemblyByConvention(typeof(ItemsWebModule).GetAssembly());
            iocManager.RegisterIfNot<IBrandAppService, BrandAppService>(DependencyLifeStyle.Transient);
            iocManager.RegisterIfNot<IItemAppService, ItemAppService>(DependencyLifeStyle.Transient);
            iocManager.RegisterIfNot<IApplicationInjector, ApplicationInjector>(DependencyLifeStyle.Transient);
        }
    }
}
