using CvSender.Core.Interfaces;
using CvSender.Core.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CvSender.Core.ApplicationServices
{
        public class JobsCzCvSender : ICVManager
        {
                public const string ServiceKey = "JobsCzCvSender";

                private readonly IWebDriver _driver;

                public JobsCzCvSender(IWebDriver driver)
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

                public void SendCvToUnappliedPositions(string link, UserInfo userInfo)
                {
                        _driver.Navigate().GoToUrl(link);

                        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

                        wait.Until(d => d.FindElements(By.CssSelector(".SearchResultCard__titleLink")).Count > 0);

                        var jobLinks = _driver.FindElements(By.CssSelector(".SearchResultCard__titleLink"));

                        foreach (var jobLink in jobLinks)
                        {
                                try
                                {
                                        var jobCard = jobLink.FindElement(By.XPath("ancestor::article"));

                                        var companyNameElement = jobCard.FindElement(By.CssSelector(".SearchResultCard__footerItem span"));

                                        string companyName = companyNameElement.Text;
                                        
                                        var position = jobLink.Text;

                                        jobLink.Click();

                                        var applyButton = _driver.FindElement(By.CssSelector(".Button.Button--primary.Button--large.d-none.d-tablet-inline-flex.mr-tablet-700"));

                                        applyButton.Click();

                                        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DanilTkachenkoCv.pdf");

                                        IWebElement fileInput = _driver.FindElement(By.Id("customCvs"));

                                        fileInput.SendKeys(filePath);

                                        IWebElement firstNameField = _driver.FindElement(By.Id("jobad_application_firstName"));

                                        firstNameField.Clear();

                                        firstNameField.SendKeys(userInfo.Name);

                                        IWebElement surnameField = _driver.FindElement(By.Id("jobad_application_surname"));

                                        surnameField.Clear();

                                        surnameField.SendKeys(userInfo.Surname);

                                        IWebElement emailField = _driver.FindElement(By.Id("jobad_application_email"));

                                        emailField.Clear();

                                        emailField.SendKeys(userInfo.Email);

                                        IWebElement phoneField = _driver.FindElement(By.Id("jobad_application_phone"));

                                        phoneField.Clear();

                                        phoneField.SendKeys(userInfo.Telephone);

                                        IWebElement checkbox = _driver.FindElement(By.Id("jobad_application_acceptTerms"));

                                        if (!checkbox.Selected)
                                                checkbox.Click();

                                        var submitButton = _driver.FindElement(By.CssSelector("Button.Button--primary.Button--large"));

                                        submitButton.Click();
                                }
                                catch (Exception ex)
                                {
                                        Console.WriteLine($"Произошла ошибка при обработке позиции: {ex.Message}");
                                }
                        }
                }
        }
}
