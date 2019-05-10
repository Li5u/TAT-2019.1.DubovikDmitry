using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Page_Objects.Mail
{
    /// <summary>
    /// Class for mail.ru read letter page.
    /// </summary>
    public class MailReadLetterPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement ProfileInfoButton { get; set; }
        IWebElement PersonalDataButton { get; set; }
        Locators.Mail.MailReadLetterPageLocators Locator { get; }

        /// <summary>
        /// Class constuctor initializes fields.
        /// </summary>
        /// <param name="driver"></param>
        public MailReadLetterPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new Locators.Mail.MailReadLetterPageLocators();
        }

        /// <summary>
        /// Returns text of reply.
        /// </summary>
        /// <returns>Text of reply</returns>
        public string GetReplyText()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.ReplyTextLocator)).Any());

            return Driver.FindElement(By.XPath(Locator.ReplyTextLocator)).Text;
        }

        /// <summary>
        /// Clicks on profile info button.
        /// </summary>
        /// <returns></returns>
        public MailReadLetterPage ClickProfileInfoButton()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.ProfileInfoButtonLocator)).Any());
            ProfileInfoButton = Driver.FindElement(By.XPath(Locator.ProfileInfoButtonLocator));
            ProfileInfoButton.Click();

            return this;
        }

        /// <summary>
        /// Clicks on personal data button.
        /// </summary>
        /// <returns></returns>
        public MailReadLetterPage ClickPersonalDataButton()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.PersonalDataButtonLocator)).Any());
            PersonalDataButton = Driver.FindElement(By.XPath(Locator.PersonalDataButtonLocator));
            PersonalDataButton.Click();

            return this;
        }

        /// <summary>
        /// Goes to personal data page.
        /// </summary>
        /// <returns></returns>
        public MailPersonalDataPage GoToPersonalDataPage()
        {
            ClickProfileInfoButton();
            ClickPersonalDataButton();

            return new MailPersonalDataPage(Driver);
        }
    }
}
