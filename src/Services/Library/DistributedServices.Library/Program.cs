using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Configuration;

namespace DistributedServices.Library
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = AppConfigurations.Get(Directory.GetCurrentDirectory(), enviroment?.ToLower());
            var host = BuildWebHost(configuration, args);
            host.RunAsync().Wait();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        private static IWebHost BuildWebHost(IConfiguration configuration, string[] args) =>
         WebHost.CreateDefaultBuilder(args)
             .CaptureStartupErrors(false)
             .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
             .UseStartup<Startup>().UseKestrel(options => options.AddServerHeader = false)
             .UseContentRoot(Directory.GetCurrentDirectory())
             .Build();
    }

}
