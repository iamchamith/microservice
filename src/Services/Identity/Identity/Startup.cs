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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using App.SharedKernel.Messaging.Email;

namespace Identity
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            new IdentityGlobalConfig(configuration);
        }
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
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
            };
        });

            services.AddMvc()
            .AddMvcOptions(options => options.EnableEndpointRouting = false);

            services.Configure<DataProtectionTokenProviderOptions>(o =>
                 o.TokenLifespan = TimeSpan.FromHours(3));

            services.AddTransient<IdentityContext, IdentityContext>()
                .AddTransient<IdentityService, IdentityApiController>()
                          .AddTransient<IEmailService, EmailService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Identity.Amazon", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
            {
                app.UseExceptionHandler("/Error/_500");
            }

            //app.Use(async (ctx, next) =>
            //{
            //    if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
            //        ctx.Request.Path = "/error/_404";
            //    else if (ctx.Response.StatusCode == 500 && !ctx.Response.HasStarted)
            //        if (env.IsDevelopment())
            //            app.UseDeveloperExceptionPage();
            //        else
            //            ctx.Request.Path = "/error/_500";
            //    else if (ctx.Response.StatusCode == 403 && !ctx.Response.HasStarted)
            //        ctx.Request.Path = "/error/_403";
            //    await next();
            //});

            app.UseStaticFiles();
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
