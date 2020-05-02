using Identity.Model.Infastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using System;
using Identity.Controllers;
using Microsoft.OpenApi.Models;

namespace Identity
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>(config =>
            {
                config.UseSqlServer(GlobalConfig.ConnectionString);
            });
            services.AddIdentity<IdentityUser, IdentityRole>(config=> {
                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 2;
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "Identity.Cookie";
                config.LoginPath = "/identity/login";
                config.AccessDeniedPath = "/identity/login1";
            });


            services.AddMvc()
        .AddMvcOptions(options => options.EnableEndpointRouting = false);
            services.AddMailKit(optionBuilder =>
            {
                optionBuilder.UseMailKit(new MailKitOptions()
                {
       
                    //Server = Configuration["Server"],
                    //Port = Convert.ToInt32(Configuration["Port"]),
                    //SenderName = Configuration["SenderName"],
                    //SenderEmail = Configuration["SenderEmail"],
                    
                    //// can be optional with no authentication 
                    //Account = Configuration["Account"],
                    //Password = Configuration["Password"],
                    // enable ssl or tls
                    Security = true
                });
            });
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
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=identity}/{action=login}/{id?}");
            });
        }
    }
}
