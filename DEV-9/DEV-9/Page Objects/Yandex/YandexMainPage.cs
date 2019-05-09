using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Page_Objects.Yandex
{
    class YandexMainPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement LatestLetter { get; set; }
        Locators.Yandex.YandexMainPageLocators Locator { get; }

        public YandexMainPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new Locators.Yandex.YandexMainPageLocators();
        }

        public YandexReadLetterPage SelectLatestLetter(string senderName)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.LatestMaleLocator)).Any());
            LatestLetter = Driver.FindElement(By.XPath(Locator.LatestMaleLocator));
            string name = LatestLetter.FindElement(By.XPath("//span[@class = 'mail-MessageSnippet-FromText']")).Text;
            Console.WriteLine(name);
            LatestLetter.Click();

            return new YandexReadLetterPage(Driver);
        }
    }
}
