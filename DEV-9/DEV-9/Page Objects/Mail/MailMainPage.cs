using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Page_Objects
{
    public class MailMainPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement LetterButton { get; set; }
        IWebElement LatestLetter { get; set; }
        Locators.MailMainPageLocators Locator { get; }

        public MailMainPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new Locators.MailMainPageLocators();
        }

        public IWebElement FindWriteLetterButton()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.WriteLetterButtonLocator)).Any());
            return Driver.FindElement(By.XPath(Locator.WriteLetterButtonLocator));
        }

        public Mail.MailSenderLetterPage ClickToWriteLetterButton()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.WriteLetterButtonLocator)).Any());
            LetterButton = Driver.FindElement(By.XPath(Locator.WriteLetterButtonLocator));
            LetterButton.Click();

            return new Mail.MailSenderLetterPage(Driver);
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
            LatestLetter = Driver.FindElement(By.XPath(Locator.SelecterUnreadLetterLocator));
            LatestLetter.Click();

            //return new LetterMailPage(Driver);
        }
    }
}
