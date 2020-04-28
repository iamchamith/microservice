using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Amazon.Order
{
    [DependsOn(
        typeof(OrderCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class OrderApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OrderApplicationModule).GetAssembly());
        }
    }
}