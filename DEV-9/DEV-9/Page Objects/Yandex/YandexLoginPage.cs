using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Page_Objects.Yandex
{
    class YandexLoginPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement Login { get; set; }
        IWebElement Password { get; set; }
        IWebElement LoginButton { get; set; }
        Locators.Yandex.YandexLoginPageLocators Locator { get; }

        public YandexLoginPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new Locators.Yandex.YandexLoginPageLocators();
        }

        public void GoToPage()
        {
            Driver.Navigate().GoToUrl(Locator.PageLocator);
        }

        public YandexLoginPage TypeUsername(String username)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.LoginLocator)).Any());
            Driver.FindElement(By.XPath(Locator.LoginLocator)).SendKeys(username);
            return this;
        }

        public YandexLoginPage TypePassword(String password)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.PasswordLocator)).Any());
            Driver.FindElement(By.XPath(Locator.PasswordLocator)).SendKeys(password);
            return this;
        }

        public YandexMainPage SubmitLogin()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SubmitButtonLocator)).Any());
            Driver.FindElement(By.XPath(Locator.SubmitButtonLocator)).Click();
            return new YandexMainPage(Driver);
        }

        public YandexLoginPage StartLogin()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.LoginIntoButtonLocator)).Any());
            Driver.FindElement(By.XPath(Locator.LoginIntoButtonLocator)).Click();
            return this;
        }

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
