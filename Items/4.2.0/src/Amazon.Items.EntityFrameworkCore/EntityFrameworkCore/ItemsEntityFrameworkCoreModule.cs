using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Amazon.Items.EntityFrameworkCore
{
    [DependsOn(
        typeof(ItemsCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class ItemsEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ItemsEntityFrameworkCoreModule).GetAssembly());
        }
    }
}