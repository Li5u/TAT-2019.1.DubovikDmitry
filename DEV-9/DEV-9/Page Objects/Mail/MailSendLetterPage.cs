using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Page_Objects.Mail
{
    /// <summary>
    /// Class for mail.ru read letter page.
    /// </summary>
    public class MailSendLetterPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement Text { get; set; }
        IWebElement SentButton { get; set; }
        Locators.Mail.MailSendLetterPageLocators Locator { get; }

        /// <summary>
        /// Class constuctor initializes fields.
        /// </summary>
        /// <param name="driver"></param>
        public MailSendLetterPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new Locators.Mail.MailSendLetterPageLocators();
        }

        /// <summary>
        /// Fills recepient field.
        /// </summary>
        /// <param name="recepient">Recepient</param>
        /// <returns></returns>
        public MailSendLetterPage TypeRecepient(string recepient)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.RecepientLocator)).Any());
            Driver.FindElement(By.XPath(Locator.RecepientLocator)).SendKeys(recepient);

            return this;
        }

        /// <summary>
        /// Fills text field.
        /// </summary>
        /// <param name="text">Text of the message</param>
        /// <returns></returns>
        public MailSendLetterPage TypeText(string text)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.TextLocator)).Any());
            Text = Driver.FindElement(By.XPath(Locator.TextLocator));
            Text.Clear();
            Text.SendKeys(text);

            return this;
        }

        /// <summary>
        /// Clicks on send letter button.
        /// </summary>
        /// <returns></returns>
        public MailSendLetterPage ClickOnSendButton()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SendButtonLocator)).Any());
            SentButton = Driver.FindElement(By.XPath(Locator.SendButtonLocator));
            SentButton.Click();

            return this;
        }

        /// <summary>
        /// Sends letter.
        /// </summary>
        /// <param name="recepient">Recepient email</param>
        /// <param name="text">Text of the message</param>
        /// <returns></returns>
        public MailSendLetterPage SendLetter(string recepient, string text)
        {
            TypeRecepient(recepient);

            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SwitcherToFrameLocator)).Any());
            Driver.SwitchTo().Frame(Driver.FindElement(By.XPath(Locator.SwitcherToFrameLocator)));

            TypeText(text);

            Driver.SwitchTo().ParentFrame();

            ClickOnSendButton();

            return new MailSendLetterPage(Driver);
        }
    }
}
