using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Amazon.Order.Configuration;
using Amazon.Order.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Amazon.Order.Web.Startup
{
    [DependsOn(
        typeof(OrderApplicationModule), 
        typeof(OrderEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class OrderWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public OrderWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(OrderConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<OrderNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(OrderApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OrderWebModule).GetAssembly());
        }
    }
}