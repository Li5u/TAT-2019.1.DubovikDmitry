using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Page_Objects
{
    /// <summary>
    /// Class for mail.ru main page.
    /// </summary>
    public class MailMainPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement LetterButton { get; set; }
        IWebElement LatestLetter { get; set; }
        Locators.MailMainPageLocators Locator { get; }

        /// <summary>
        /// Class constuctor initializes fields.
        /// </summary>
        /// <param name="driver"></param>
        public MailMainPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new Locators.MailMainPageLocators();
        }

        /// <summary>
        /// Class for tests tries to find write massege button element on page.
        /// </summary>
        /// <returns></returns>
        public IWebElement FindWriteLetterButton()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.WriteLetterButtonLocator)).Any());

            return Driver.FindElement(By.XPath(Locator.WriteLetterButtonLocator));
        }

        /// <summary>
        /// Clicks write new message button.
        /// </summary>
        /// <returns></returns>
        public Mail.MailSendLetterPage ClickToWriteLetterButton()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.WriteLetterButtonLocator)).Any());
            LetterButton = Driver.FindElement(By.XPath(Locator.WriteLetterButtonLocator));
            LetterButton.Click();

            return new Mail.MailSendLetterPage(Driver);
        }

        /// <summary>
        /// Opens latest mail.
        /// </summary>
        /// <returns></returns>
        public Mail.MailReadLetterPage SelectUnseenLetter()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SelecterUnreadLetterLocator)).Any());
            LatestLetter = Driver.FindElement(By.XPath(Locator.SelecterUnreadLetterLocator));
            LatestLetter.Click();

            return new Mail.MailReadLetterPage(Driver);
        }
    }
}
