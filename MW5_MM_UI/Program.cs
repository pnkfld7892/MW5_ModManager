using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nexus_Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http;
using System.IO;
using Newtonsoft.Json;
using MW5_MM_Core.Services;

namespace MW5_MM_UI
{
    static class Program
    {
        private static void ConfigureServices(IServiceCollection services,IConfiguration config)
        {
            services
                .AddLogging()
                .AddScoped<MainForm>();
            services.AddHttpClient("nexusApi",c => c.BaseAddress = new Uri($"{config.GetValue<string>("nexusBaseUrl")}/{config.GetValue<string>("gameDomain")}"));
            services.AddScoped<INexusApi, NexusAPI>();
            services.AddScoped<IMw5ModService, Mw5ModService>();
            services.AddScoped<IBaseClass, BaseClass>();
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var hostBuilder = Host.CreateDefaultBuilder()
            //    .ConfigureServices((hostContext, services) =>
            //    {
            //        ConfigureServices(services, hostContext.Configuration);
            //    });
            var hostBuilder = new Microsoft.Extensions.Hosting.HostBuilder()
                .ConfigureAppConfiguration(config => config
                    .SetBasePath(Application.StartupPath)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables())
                .ConfigureServices((hostContext, services) =>
                {
                    ConfigureServices(services, hostContext.Configuration);
                });




            var builderDefault = hostBuilder.Build();
            using (var serviceScope = builderDefault.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    Application.SetHighDpiMode(HighDpiMode.SystemAware);
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    var form = services.GetRequiredService<MainForm>();
                    Application.Run(form);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("it broke",ex);
                }
            }
        }

      
    }
}
