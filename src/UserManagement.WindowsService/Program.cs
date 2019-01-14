using Amara.UserManagement;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace UserManagement.WindowsService
{
    public class Program
    {
        public const string IsWindowsServiceConfig = "IsService";

        public static void Main(string[] args)
        {
            var hostBuilder = new WebHostBuilder();

            var pathToContentRoot = GetContentRoot(hostBuilder);

            var config = BuildConfiguration(hostBuilder, args);

            var host = hostBuilder
                   .UseKestrel(options =>
                   {
                       //options.Listen(IPAddress.Any, 8812, listenOptions => listenOptions.UseHttps(cert));
                       options.Listen(IPAddress.Any, 1601);
                   })
                   .UseConfiguration(config)
                   //.ConfigureServices(
                   //services => services
                   //    .AddSingleton<IServiceStateManager>(new ServiceStateManager(ServiceState.Active))
                   //    .AddSingleton<ILoggerFactory>(loggerFactory)
                   //)
                   .ConfigureAppConfiguration((appConfig) =>
                   {
                       appConfig
                        .SetBasePath(pathToContentRoot)
                        .AddJsonFile(Path.Combine(pathToContentRoot, "appSettings.json"))
                        .AddEnvironmentVariables();
                   })
                   .UseContentRoot(pathToContentRoot)
                   .UseIISIntegration()
                   .UseStartup<Startup>()
                   .Build();

            if (Debugger.IsAttached
                || string.Equals(config.GetSection(IsWindowsServiceConfig)?.Value, "false", StringComparison.OrdinalIgnoreCase))
                host.Run();
            else
                host.RunAsService();
        }

        #region Private Method(s)
        private static string GetContentRoot(IWebHostBuilder hostBuilder)
        {
            var environment = hostBuilder.GetSetting(WebHostDefaults.EnvironmentKey);
            string contentRoot;
            if (string.Equals(environment, EnvironmentName.Development, StringComparison.OrdinalIgnoreCase))
            {
                contentRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;// @"..\..\..\..\..\UserManagement";
            }
            else
            {
                // But if we're published out, then we need to grab from the exe location.
                contentRoot = GetExePath();
            }

            return contentRoot;
        }

        private static string GetExePath()
        {
            var pathToExe =  Process.GetCurrentProcess().MainModule.FileName;
            var contentRoot = Path.GetDirectoryName(pathToExe);
            return contentRoot;
        }

        private static IConfiguration BuildConfiguration(IWebHostBuilder hostBuilder, string[] args)
        {
            var configBuilder = new ConfigurationBuilder();

            var environment = hostBuilder.GetSetting(WebHostDefaults.EnvironmentKey);

            // Normally I'd love to use ConfigureAppConfiguration.  But, we set the
            // content root to be the IdentityServer folder. However, the appsettings.json
            // files are stashed with the website project.  So we set up the config
            // outside the normal startup stuff to make sure we're finding our intended settings
            // file.
            string baseFolder;
            if (string.Equals(environment, EnvironmentName.Development, StringComparison.OrdinalIgnoreCase))
            {
                baseFolder = Directory.GetCurrentDirectory();
            }
            else
            {
                baseFolder = GetExePath();
            }


            return configBuilder
                //.AddJsonFile(Path.Combine(baseFolder, "appSettings.json"))
                //.AddJsonFile(Path.Combine(baseFolder, $"appSettings.{environment}.json"), optional: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
        }
        #endregion
    }
}
