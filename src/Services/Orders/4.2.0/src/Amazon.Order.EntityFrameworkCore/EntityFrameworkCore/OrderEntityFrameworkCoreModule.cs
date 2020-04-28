using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Amazon.Order.EntityFrameworkCore
{
    [DependsOn(
        typeof(OrderCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class OrderEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OrderEntityFrameworkCoreModule).GetAssembly());
        }
    }
}