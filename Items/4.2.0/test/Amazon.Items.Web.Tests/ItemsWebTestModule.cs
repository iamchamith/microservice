using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Amazon.Items.Web.Startup;
namespace Amazon.Items.Web.Tests
{
    [DependsOn(
        typeof(ItemsWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class ItemsWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ItemsWebTestModule).GetAssembly());
        }
    }
}