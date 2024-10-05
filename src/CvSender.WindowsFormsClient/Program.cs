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
                        //Application.SetHighDpiMode(HighDpiMode.SystemAware);
                        //Application.EnableVisualStyles();
                        //Application.SetCompatibleTextRenderingDefault(false);

                        //var serviceCollection = new ServiceCollection();
                        //ConfigureServices(serviceCollection);

                        //IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

                        //Application.Run(serviceProvider.GetRequiredService<MainForm>());
                        Application.SetHighDpiMode(HighDpiMode.SystemAware);
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);

                        // Create the host builder
                        var host = CreateHostBuilder().Build();

                        // Run the main form with dependency injection
                        Application.Run(host.Services.GetRequiredService<MainForm>());
                }

                //private static void ConfigureServices(ServiceCollection services)
                //{
                //        services.AddCore();

                //        services.AddTransient<MainForm>();
                //}
                private static IHostBuilder CreateHostBuilder()
                {
                        return Host.CreateDefaultBuilder()
                                .ConfigureAppConfiguration((context, config) =>
                                {
                                        // Add appsettings.json configuration
                                        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                                })
                                .ConfigureServices((context, services) =>
                                {
                                        // Configure services here
                                        services.AddCore(); // Assuming this is your custom DI setup

                                        // Inject configuration settings if needed
                                        IConfiguration configuration = context.Configuration;
                                        services.AddSingleton(configuration);

                                        // Register the MainForm
                                        services.AddTransient<MainForm>();
                                });
                }
        }
}