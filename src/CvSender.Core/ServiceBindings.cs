using CvSender.Core.ApplicationServices;
using CvSender.Core.Interfaces;
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
                        var options = new ChromeOptions();

                        options.AddArgument("user-data-dir=C:\\Users\\Danil\\AppData\\Local\\Google\\Chrome\\User Data");

                        options.AddArgument("--no-sandbox");
                        
                        options.AddArgument("--disable-dev-shm-usage");

                        serviceCollection.AddSingleton<IWebDriver>(_ => new ChromeDriver(options));

                        serviceCollection.AddKeyedSingleton<ICVManager, JobsCzCvSender>(JobsCzCvSender.ServiceKey);

                        return serviceCollection;
                }
        }
}
