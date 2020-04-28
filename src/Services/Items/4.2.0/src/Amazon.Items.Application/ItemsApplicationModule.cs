using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Amazon.Items
{
    [DependsOn(
        typeof(ItemsCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ItemsApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ItemsApplicationModule).GetAssembly());
        }
    }
}