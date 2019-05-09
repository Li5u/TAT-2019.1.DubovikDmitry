using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Page_Objects.Yandex
{
    class YandexReadLetterPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement LatterText { get; set; }
        IWebElement ReplyButton { get; set; }
        Locators.Yandex.YandexReadLetterPageLocators Locator { get; }

        public YandexReadLetterPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new Locators.Yandex.YandexReadLetterPageLocators();
        }

        public YandexReadLetterPage ClickReplyButton()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.ReplyButtonLocator)).Any());
            ReplyButton = Driver.FindElement(By.XPath(Locator.ReplyButtonLocator));
            ReplyButton.Click();
            return this;
        }

        public YandexReadLetterPage TypeReplyText(string answer)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.TextFieldLocator)).Any());
            Driver.FindElement(By.XPath(Locator.TextFieldLocator)).SendKeys(answer);
            return this;
        }

        public YandexReadLetterPage SendReply()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SendReplyButtonLocator)).Any());
            Driver.FindElement(By.XPath(Locator.SendReplyButtonLocator)).Click();
            return this;
        }

        public YandexReadLetterPage ReplyToTheLetter(string answer)
        {
            ClickReplyButton();
            TypeReplyText(answer);
            SendReply();
            return this;
        }
    }
}
