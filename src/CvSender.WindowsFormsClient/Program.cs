using CvSender.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CvSender.WindowsFormsClient
{
        internal static class Program
        {
                [STAThread]
                static void Main()
                {
                        Application.SetHighDpiMode(HighDpiMode.SystemAware);
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);

                        var host = CreateHostBuilder().Build();

                        Application.Run(host.Services.GetRequiredService<MainForm>());
                }

                private static IHostBuilder CreateHostBuilder()
                {
                        return Host.CreateDefaultBuilder()
                                .ConfigureAppConfiguration((context, config) =>
                                {
                                        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                                })
                                .ConfigureServices((context, services) =>
                                {
                                        services.AddCore();

                                        IConfiguration configuration = context.Configuration;
                                        services.AddSingleton(configuration);

                                        services.AddTransient<MainForm>();
                                });
                }
        }
}