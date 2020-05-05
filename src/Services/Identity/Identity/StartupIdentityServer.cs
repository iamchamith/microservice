using Identity.Model.Infastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Identity.Controllers;
using Microsoft.OpenApi.Models;

namespace Identity
{
    public class StartupIdentityServer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>(config =>
            {
                config.UseSqlServer(IdentityGlobalConfig.ConnectionString);
            });
            services.AddIdentity<IdentityUser, IdentityRole>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 2;
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<IdentityContext>();


            services.AddIdentityServer()
                     .AddDeveloperSigningCredential(filename: "tempkey.rsa")
                     .AddInMemoryApiResources(IdentityConfig.GetApiResources())
                     .AddInMemoryIdentityResources(IdentityConfig.GetIdentityResources())
                     .AddInMemoryClients(IdentityConfig.GetClients())
                     .AddTestUsers(IdentityConfig.GetUsers());

            services.AddMvc().AddMvcOptions(options => options.EnableEndpointRouting = false);
         
            services.Configure<DataProtectionTokenProviderOptions>(o =>
                 o.TokenLifespan = TimeSpan.FromHours(3));

            services.AddTransient<IdentityContext, IdentityContext>()
                .AddTransient<IdentityService, IdentityApiController>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Identity.Amazon", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseIdentityServer(); 
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=identity}/{action=login}/{id?}");
            });
        }
    }
}
