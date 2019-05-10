using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Page_Objects.Yandex
{
    /// <summary>
    /// Class for yandex main page.
    /// </summary>
    class YandexMainPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement LatestLetter { get; set; }
        Locators.Yandex.YandexMainPageLocators Locator { get; }

        /// <summary>
        /// Class constuctor initializes fields.
        /// </summary>
        /// <param name="driver"></param>
        public YandexMainPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new Locators.Yandex.YandexMainPageLocators();
        }

        /// <summary>
        /// Opens latest letter;
        /// </summary>
        /// <param name="senderName"></param>
        /// <returns></returns>
        public YandexReadLetterPage SelectLatestLetter(string senderName)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.LatestMaleLocator)).Any());
            LatestLetter = Driver.FindElement(By.XPath(Locator.LatestMaleLocator));
            LatestLetter.Click();

            return new YandexReadLetterPage(Driver);
        }
    }
}
