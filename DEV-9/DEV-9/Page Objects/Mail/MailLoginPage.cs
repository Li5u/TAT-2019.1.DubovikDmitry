using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Page_Objects
{
    /// <summary>
    /// Class for mail.ru login page.
    /// </summary>
    public class MailLoginPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement LoginButton { get; set; }
        Locators.MailLoginPageLocators Locator { get; }

        /// <summary>
        /// Class constuctor initializes fields.
        /// </summary>
        /// <param name="driver"></param>
        public MailLoginPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new Locators.MailLoginPageLocators();
        }

        /// <summary>
        /// Goes to mail.ru login page
        /// </summary>
        public void GoToPage()
        {
            Driver.Navigate().GoToUrl(Locator.PageLocator);
        }

        /// <summary>
        /// Fills username field on login page.
        /// </summary>
        /// <param name="username">username to type</param>
        /// <returns></returns>
        public MailLoginPage TypeUsername(String username)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.LoginLocator)).Any());
            Driver.FindElement(By.XPath(Locator.LoginLocator)).SendKeys(username);
            return this;
        }

        /// <summary>
        /// Fills password field on login page.
        /// </summary>
        /// <param name="password">password ro type</param>
        /// <returns></returns>
        public MailLoginPage TypePassword(String password)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.PasswordLocator)).Any());
            Driver.FindElement(By.XPath(Locator.PasswordLocator)).SendKeys(password);

            return this;
        }

        /// <summary>
        /// Clicks on submit button.
        /// </summary>
        /// <returns></returns>
        public MailMainPage SubmitLogin()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.LoginButtonLocator)).Any());
            LoginButton = Driver.FindElement(By.XPath(Locator.LoginButtonLocator));
            LoginButton.Click();

            return new MailMainPage(Driver);
        }

        /// <summary>
        /// Logins into mail.ru account.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public MailMainPage LoginAs(String username, String password)
        {
            TypeUsername(username);
            TypePassword(password);

            return SubmitLogin();
        }
    }
}
