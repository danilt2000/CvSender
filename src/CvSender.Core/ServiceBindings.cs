using CvSender.Core.ApplicationServices;
using CvSender.Core.Interfaces;
using CvSender.Core.Repository;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace CvSender.Core
{
        public static class ServiceBindings
        {
                //private static readonly IWebDriver _driver;

                static ServiceBindings()
                {

                }

                public static IServiceCollection AddCore(this IServiceCollection serviceCollection/*, IConfiguration configuration*/)
                {
                        //var options = new ChromeOptions();

                        var options = new ChromeOptions();
                        //options.AddArgument("user-data-dir=C:\\Users\\Danil\\AppData\\Local\\Google\\Chrome\\User Data");

                        options.AddArgument("--no-sandbox");

                        options.AddArgument("--disable-dev-shm-usage");

                        options.AddArgument("--start-maximized");

                        string userProfilePath = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            "pure_automation_profile"
                        );

                        Directory.CreateDirectory(userProfilePath);

                        options.AddArgument($"--user-data-dir={userProfilePath}");
                        options.AddArgument("--profile-directory=Default");
            
                        serviceCollection.AddSingleton<IWebDriver>(_ => new ChromeDriver(options));

                        serviceCollection.AddSingleton<IMongoDbService, MongoDBService>();

                        serviceCollection.AddKeyedSingleton<ICVManager, JobsCzCvSender>(JobsCzCvSender.ServiceKey);

                        return serviceCollection;
                }
        }
}
