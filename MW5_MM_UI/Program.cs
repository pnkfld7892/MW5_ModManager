using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nexus_Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace MW5_MM_UI
{
    static class Program
    {
        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddLogging()
                .AddScoped<Form1>();
            services.AddSingleton<INexusApi, NexusAPI>();
            //services.AddSingleton<>();
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var hostBuilder = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) => 
                {
                    ConfigureServices(services);
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
                    var form = services.GetRequiredService<Form1>();
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
