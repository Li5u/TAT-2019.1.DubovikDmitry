using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Page_Objects
{
    public class MailLoginPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement Login { get; set; }
        IWebElement Password { get; set; }
        IWebElement LoginButton { get; set; }
        Locators.MailLoginPageLocators Locator { get; }

        public MailLoginPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new Locators.MailLoginPageLocators();
        }

        public void GoToPage()
        {
            Driver.Navigate().GoToUrl(Locator.PageLocator);
        }

        public MailLoginPage TypeUsername(String username)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.LoginLocator)).Any());
            Driver.FindElement(By.XPath(Locator.LoginLocator)).SendKeys(username);
            return this;
        }

        public MailLoginPage TypePassword(String password)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.PasswordLocator)).Any());
            Driver.FindElement(By.XPath(Locator.PasswordLocator)).SendKeys(password);
            return this;
        }

        public MailMainPage SubmitLogin()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.LoginButtonLocator)).Any());
            Driver.FindElement(By.XPath(Locator.LoginButtonLocator)).Click();  
            return new MailMainPage(Driver);
        }

        public MailMainPage LoginAs(String username, String password)
        {
            TypeUsername(username);
            TypePassword(password);
            return SubmitLogin();
        }
    }
}
