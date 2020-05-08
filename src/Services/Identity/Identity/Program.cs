using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog.Extensions.Logging;

namespace Identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, loggin) =>
            {
                loggin.AddNLog();
            }).UseStartup<Startup>();
    }
}
