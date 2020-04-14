using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Amazon.Items.Configuration;
using Amazon.Items.EntityFrameworkCore;
using Amazon.Items.Web.Startup.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Amazon.Items.Web.Startup
{
    [DependsOn(
        typeof(ItemsApplicationModule), 
        typeof(ItemsEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class ItemsWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ItemsWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(ItemsConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<ItemsNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(ItemsApplicationModule).GetAssembly()
                );
            Configuration.Modules.AbpAutoMapper().RegisterAutomapper();
        }

        public override void Initialize()
        {
            IocManager.RegisterIoc();
        }
    }
}