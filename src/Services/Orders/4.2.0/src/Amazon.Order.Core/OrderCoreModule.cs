using Abp.Modules;
using Abp.Reflection.Extensions;
using Amazon.Order.Localization;

namespace Amazon.Order
{
    public class OrderCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            OrderLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OrderCoreModule).GetAssembly());
        }
    }
}