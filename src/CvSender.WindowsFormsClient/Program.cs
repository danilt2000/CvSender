using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Forms.Design;
using CvSender.Core;

namespace CvSender.WindowsFormsClient
{
        internal static class Program
        {
                /// <summary>
                ///  The main entry point for the application.
                /// </summary>
                ///
                [STAThread]
                static void Main()
                {
                        //Application.SetHighDpiMode(HighDpiMode.SystemAware);
                        //Application.EnableVisualStyles();
                        //Application.SetCompatibleTextRenderingDefault(false);

                        //var host = CreateHostBuilder().Build();
                        //ServiceProvider = host.Services;

                        //Application.Run(ServiceProvider.GetRequiredService<Form1>());
                        //////////////ApplicationConfiguration.Initialize();

                        //////////////Application.SetCompatibleTextRenderingDefault(false);

                        //////////////var host = CreateHostBuilder().Build();

                        //////////////var fromStartService = host.Services.GetRequiredService<Form1>();

                        //////////////Application.Run(fromStartService);

                        //// To customize application configuration such as set high DPI settings or default font,
                        //// see https://aka.ms/applicationconfiguration.
                        //ApplicationConfiguration.Initialize();
                        //Application.Run(new Form1());

                        //var host = CreateHostBuilder().Build();
                        //ServiceProvider = host.Services;

                        //Application.Run(ServiceProvider.GetRequiredService<Form1>());

                        Application.SetHighDpiMode(HighDpiMode.SystemAware);
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);

                        var serviceCollection = new ServiceCollection();
                        ConfigureServices(serviceCollection);

                        IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

                        Application.Run(serviceProvider.GetRequiredService<Form1>());
                }

                //static IHostBuilder CreateHostBuilder()
                //{
                //        return Host.CreateDefaultBuilder()
                //                .ConfigureServices((context, services) => {
                //                        services.AddSingleton<Form1>();
                //                });
                //}
                private static void ConfigureServices(ServiceCollection services)
                {
                        services.AddCore();

                        // Register your services here
                        // Register your forms
                        services.AddTransient<Form1>();
                }


        }
}