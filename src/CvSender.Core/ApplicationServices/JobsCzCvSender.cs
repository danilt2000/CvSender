using System.Reflection.Metadata.Ecma335;
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

                private readonly IRepository<IAppliedPosition> _repositoryAppliedPosition;

                public JobsCzCvSender(IWebDriver driver, IRepository<IAppliedPosition> repositoryAppliedPosition)
                {
                        _driver = driver;

                        _repositoryAppliedPosition = repositoryAppliedPosition;
                }

                public async void SendCvToUnappliedPositions(string link, UserInfo userInfo)
                {
                        _driver.Navigate().GoToUrl(link);

                        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

                        wait.Until(d => d.FindElements(By.CssSelector(".SearchResultCard__titleLink")).Count > 0);

                        var jobLinks = _driver.FindElements(By.CssSelector(".SearchResultCard__titleLink")).ToList();

                        var firstLink = link;

                        var webHost = new Uri(link).Host;

                        var alreadyAppliedJobs = new List<IWebElement>();

                        for (int i = 0; i < jobLinks.Count - 1; i++)
                        {
                                try
                                {
                                        if (alreadyAppliedJobs.Contains(jobLinks[i]))
                                                continue;

                                        var jobCard = jobLinks[i].FindElement(By.XPath("ancestor::article"));

                                        var companyNameElement = jobCard.FindElement(By.CssSelector(".SearchResultCard__footerItem span"));

                                        string companyName = companyNameElement.Text;

                                        var position = jobLinks[i].Text;

                                        if (await IsPositionAlreadyApplied(companyName, position))
                                        {
                                                alreadyAppliedJobs.Add(jobLinks[i]);

                                                jobLinks = _driver
                                                        .FindElements(By.CssSelector(".SearchResultCard__titleLink"))
                                                        .ToList();

                                                continue;
                                        }

                                        jobLinks[i].Click();

                                        string currentHost = new Uri(_driver.Url).Host;

                                        if (webHost != currentHost)
                                        {
                                                _driver.Navigate().GoToUrl(link);

                                                alreadyAppliedJobs.Add(jobLinks[i]);

                                                jobLinks = _driver
                                                        .FindElements(By.CssSelector(".SearchResultCard__titleLink"))
                                                        .ToList();

                                                continue;
                                        }

                                        var applyButton = _driver.FindElement(By.CssSelector(".Button.Button--primary.Button--large.d-none.d-tablet-inline-flex.mr-tablet-700"));

                                        applyButton.Click();

                                        var currentUrl = new Uri(_driver.Url).AbsoluteUri;

                                        if (currentUrl.StartsWith("https://www.jobs.cz/asmt"))
                                        {
                                                _driver.Navigate().GoToUrl(link);

                                                alreadyAppliedJobs.Add(jobLinks[i]);

                                                jobLinks = _driver
                                                        .FindElements(By.CssSelector(".SearchResultCard__titleLink"))
                                                        .ToList();

                                                continue;
                                        }

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

                                        AddAppliedPositionToRepository(companyName, position);

                                        _driver.Navigate().GoToUrl(link);

                                        alreadyAppliedJobs.Add(jobLinks[i]);

                                        jobLinks = _driver
                                                .FindElements(By.CssSelector(".SearchResultCard__titleLink"))
                                                .ToList();
                                }
                                catch (Exception ex)
                                {
                                        Console.WriteLine($"Произошла ошибка при обработке позиции: {ex.Message}");
                                }
                        }
                }

                private async void AddAppliedPositionToRepository(string companyName, string position)
                {
                        //await _repositoryAppliedPosition.AddAsync(new CoreAppliedPosition() { Company = companyName, Position = position, CreatedUtc = DateTime.UtcNow });
                }

                private async Task<bool> IsPositionAlreadyApplied(string companyName, string position)
                {
                        return false;

                        //var positions = await _repositoryAppliedPosition.GetAllAsync();

                        //var tempPosition = positions.FirstOrDefault(x => x.Company == companyName && x.Position == position);

                        //if (tempPosition == null)
                        //        return false;

                        //return true;
                }
        }
}
