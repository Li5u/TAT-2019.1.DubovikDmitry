using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Page_Objects
{
    public class MainPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement LetterButton { get; set; }
        IWebElement SelecterLetter { get; set; }
        Locators.MainPageLocators Locator { get; }

        public MainPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new Locators.MainPageLocators();
        }

        public void ClickToWriteLetter()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.WriteLetterButtonLocator)).Any());
            LetterButton = Driver.FindElement(By.XPath(Locator.WriteLetterButtonLocator));
            LetterButton.Click();

            //return new SenderLetterMailPage(Driver);
        }

        public void SelectUnseenLetter(string senderName)
        {
            //public string SelectUnseenLetterLocator(string name)
            //{
            //    return $"//a[contains(@data-title, '{name}')]//div//span[@class= 'b-datalist__item__status-unread']/following::div[3]/div[3]/div";
            //}
            //Wait.Until(t => Driver.FindElements(By.XPath(Locator.SelectUnseenLetterLocator(senderName))).Any());
            //SelecterLetter = Driver.FindElement(By.XPath(Locator.SelectUnseenLetterLocator(senderName)));

            // Wait unread letter.
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SelecterUnreadLetterLocator)).Any());
            SelecterLetter = Driver.FindElement(By.XPath(Locator.SelecterUnreadLetterLocator)).FindElement(By.XPath($"//a"));
            SelecterLetter.Click();

            //return new LetterMailPage(Driver);
        }

    }
}
