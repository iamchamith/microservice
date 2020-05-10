using System;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.EntityFrameworkCore;
using Amazon.Items.EntityFrameworkCore;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using StackExchange.Redis;
using Amazon.Items.Web.Startup.Config;
using Microsoft.Extensions.Configuration;

namespace Amazon.Items.Web.Startup
{
    public class Startup
    {
        IConfiguration _configuration { get; set; }
        readonly string _default = "_default";
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            new ItemGlobalConfig(_configuration);
        }
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddAbpDbContext<ItemsDbContext>(options =>
            {
                DbContextOptionsConfigurer.Configure(options.DbContextOptions, "Data Source=DESKTOP-LE44UH9;Initial Catalog=Amazon;Integrated Security=True");
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Item Api", Version = "v1" });
            });
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddCors(options =>
            {
                options.AddPolicy(_default,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:5001",
                                                          "http://localhost:8000")
                                                          .AllowAnyHeader()
                                                          .AllowAnyMethod();
                                  });
            });
            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("127.0.0.1:6379,allowAdmin=true"));
            return services.AddAbp<ItemsWebModule>(options =>
            {
                options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                );
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(); //Initializes ABP framework.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Item Api");
            });
            app.UseStaticFiles();
            app.UseCors(_default);
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
