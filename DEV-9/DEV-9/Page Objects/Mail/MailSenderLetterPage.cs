using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Page_Objects.Mail
{
    public class MailSenderLetterPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement Recepient { get; set; }
        IWebElement SentButton { get; set; }
        IWebElement Text { get; set; }
        Locators.Mail.MailSenderLetterPageLocators Locator { get; }

        public MailSenderLetterPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new Locators.Mail.MailSenderLetterPageLocators();
        }

        public void SendLetter(string recepient, string content)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.RecepientLocator)).Any());
            Recepient = Driver.FindElement(By.XPath(Locator.RecepientLocator));
            Recepient.SendKeys(recepient);

            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SwitcherToFrameLocator)).Any());
            Driver.SwitchTo().Frame(Driver.FindElement(By.XPath(Locator.SwitcherToFrameLocator)));

            Wait.Until(t => Driver.FindElements(By.XPath(Locator.TextLocator)).Any());
            Text = Driver.FindElement(By.XPath(Locator.TextLocator));
            Text.Clear();
            Text.SendKeys(content);

            Driver.SwitchTo().ParentFrame();

            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SendButtonLocator)).Any());
            SentButton = Driver.FindElement(By.XPath(Locator.SendButtonLocator));
            SentButton.Click();
        }
    }
}
