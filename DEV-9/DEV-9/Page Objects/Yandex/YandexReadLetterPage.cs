using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Page_Objects.Yandex
{
    /// <summary>
    /// Class for yandex read letter page.
    /// </summary>
    class YandexReadLetterPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement LatterText { get; set; }
        IWebElement ReplyButton { get; set; }
        Locators.Yandex.YandexReadLetterPageLocators Locator { get; }

        /// <summary>
        /// Class constuctor initializes fields.
        /// </summary>
        /// <param name="driver"></param>
        public YandexReadLetterPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new Locators.Yandex.YandexReadLetterPageLocators();
        }

        /// <summary>
        /// Clicks on reply button.
        /// </summary>
        /// <returns></returns>
        public YandexReadLetterPage ClickReplyButton()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.ReplyButtonLocator)).Any());
            ReplyButton = Driver.FindElement(By.XPath(Locator.ReplyButtonLocator));
            ReplyButton.Click();

            return this;
        }

        /// <summary>
        /// Fills text field.
        /// </summary>
        /// <param name="answer">text of the message to answer</param>
        /// <returns></returns>
        public YandexReadLetterPage TypeReplyText(string answer)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.TextFieldLocator)).Any());
            Driver.FindElement(By.XPath(Locator.TextFieldLocator)).SendKeys(answer);

            return this;
        }

        /// <summary>
        /// Clicks on send reply button.
        /// </summary>
        /// <returns></returns>
        public YandexReadLetterPage SendReply()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SendReplyButtonLocator)).Any());
            Driver.FindElement(By.XPath(Locator.SendReplyButtonLocator)).Click();

            return this;
        }

        /// <summary>
        /// Sends reply to the letter.
        /// </summary>
        /// <param name="answer">Text of the answer</param>
        /// <returns></returns>
        public YandexReadLetterPage ReplyToTheLetter(string answer)
        {
            ClickReplyButton();
            TypeReplyText(answer);
            SendReply();

            return this;
        }
    }
}
