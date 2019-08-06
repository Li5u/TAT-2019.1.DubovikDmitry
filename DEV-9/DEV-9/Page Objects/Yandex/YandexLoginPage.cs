using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Page_Objects.Yandex
{
    /// <summary>
    /// Class for yandex login page.
    /// </summary>
    class YandexLoginPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement Login { get; set; }
        IWebElement Password { get; set; }
        IWebElement LoginButton { get; set; }
        Locators.Yandex.YandexLoginPageLocators Locator { get; }

        /// <summary>
        /// Class constuctor initializes fields.
        /// </summary>
        /// <param name="driver"></param>
        public YandexLoginPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new Locators.Yandex.YandexLoginPageLocators();
        }

        /// <summary>
        /// Goes to yandex login page.
        /// </summary>
        public void GoToPage()
        {
            Driver.Navigate().GoToUrl(Locator.PageLocator);
        }

        /// <summary>
        /// Fills username field on login page.
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns></returns>
        public YandexLoginPage TypeUsername(String username)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.LoginLocator)).Any());
            Driver.FindElement(By.XPath(Locator.LoginLocator)).SendKeys(username);

            return this;
        }

        /// <summary>
        /// Fills password field on login page.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public YandexLoginPage TypePassword(String password)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.PasswordLocator)).Any());
            Driver.FindElement(By.XPath(Locator.PasswordLocator)).SendKeys(password);

            return this;
        }

        /// <summary>
        /// Clicks on login button.
        /// </summary>
        /// <returns></returns>
        public YandexMainPage SubmitLogin()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SubmitButtonLocator)).Any());
            Driver.FindElement(By.XPath(Locator.SubmitButtonLocator)).Click();

            return new YandexMainPage(Driver);
        }

        /// <summary>
        /// Clicks on start login button.
        /// </summary>
        /// <returns></returns>
        public YandexLoginPage StartLogin()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.LoginIntoButtonLocator)).Any());
            Driver.FindElement(By.XPath(Locator.LoginIntoButtonLocator)).Click();

            return this;
        }

        /// <summary>
        /// Logins into yandex account.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public YandexMainPage LoginAs(String username, String password)
        {
            StartLogin();
            TypeUsername(username);
            SubmitLogin();
            TypePassword(password);

            return SubmitLogin();
        }
    }
}
