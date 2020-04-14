using Abp.Modules;
using Abp.Reflection.Extensions;
using Amazon.Items.Localization;

namespace Amazon.Items
{
    public class ItemsCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            ItemsLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ItemsCoreModule).GetAssembly());
        }
    }
}