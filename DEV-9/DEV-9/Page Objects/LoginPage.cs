using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace DEV_9.Page_Objects
{
    public class LoginPage
    {
        IWebDriver Driver { get; }
        IWebElement Login { get; set; }
        IWebElement Password { get; set; }
        IWebElement LoginButton { get; set; }
        Locators.LoginPageLocators Locator { get; }

        public LoginPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Locator = new Locators.LoginPageLocators();
        }

        public void GoToPage()
        {
            Driver.Navigate().GoToUrl(Locator.PageLocator);
        }

        public LoginPage TypeUsername(String username)
        {
            Driver.FindElement(By.XPath(Locator.LoginLocator)).SendKeys(username);
            return this;
        }

        public LoginPage TypePassword(String password)
        {
            Driver.FindElement(By.XPath(Locator.PasswordLocator)).SendKeys(password);
            return this;
        }

        public MainPage SubmitLogin()
        {
            Driver.FindElement(By.XPath(Locator.LoginButtonLocator)).Click();  
            return new MainPage(Driver);
        }

        public MainPage LoginAs(String username, String password)
        {
            TypeUsername(username);
            TypePassword(password);
            return SubmitLogin();
        }
    }
}
