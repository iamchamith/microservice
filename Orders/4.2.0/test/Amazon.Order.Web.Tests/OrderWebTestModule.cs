using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Amazon.Order.Web.Startup;
namespace Amazon.Order.Web.Tests
{
    [DependsOn(
        typeof(OrderWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class OrderWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OrderWebTestModule).GetAssembly());
        }
    }
}