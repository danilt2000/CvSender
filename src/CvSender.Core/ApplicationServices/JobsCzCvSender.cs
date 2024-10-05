using CvSender.Core.Interfaces;
using CvSender.Core.Models;
using OpenQA.Selenium;

namespace CvSender.Core.ApplicationServices
{
        public class JobsCzCvSender : ICVManager
        {
                public const string ServiceKey = "JobsCzCvSender";

                private readonly IWebDriver _driver;

                public JobsCzCvSender(IWebDriver driver)
                //JobsCzCvSender(/*string userChromeDataLocalPath*/)
                {
                        //ChromeOptions options = new ChromeOptions();

                        ////options.AddArgument(@"user-data-dir=C:\Users\PUTYOURWINDOWSUSERNAME\AppData\Local\Google\Chrome\User Data");
                        //options.AddArgument("userChromeDataLocalPath");
                        ////options.AddArgument(@"user-data-dir=C:\Users\Danil\AppData\Local\Google\Chrome\User Data");

                        //options.AddArgument("--no-sandbox");

                        //options.AddArgument("--disable-dev-shm-usage");
                        _driver = driver;
                        //_driver = new ChromeDriver(options);
                }

                public void SendCv(string link, UserInfo userInfo)
                {
                        _driver.Navigate().GoToUrl(link);
                }
        }
}
