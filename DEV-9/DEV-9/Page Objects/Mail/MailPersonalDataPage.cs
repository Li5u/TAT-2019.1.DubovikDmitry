using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DEV_9.Page_Objects.Mail
{
    /// <summary>
    /// Class for mail.ru personal data page.
    /// </summary>
    public class MailPersonalDataPage
    {
        IWebDriver Driver { get; }
        WebDriverWait Wait { get; }
        IWebElement SaveButton { get; set; }
        Locators.Mail.MailPersonalDataPageLocators Locator { get; }

        /// <summary>
        /// Class constuctor initializes fields.
        /// </summary>
        /// <param name="driver"></param>
        public MailPersonalDataPage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
            this.Locator = new Locators.Mail.MailPersonalDataPageLocators();
        }

        /// <summary>
        /// Writes new nickname into nickname field.
        /// </summary>
        /// <param name="newNickName">new nickname</param>
        /// <returns></returns>
        public MailPersonalDataPage WriteNewNickName(string newNickName)
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.NickNameFieldLocator)).Any());
            var nickNameField = Driver.FindElement(By.XPath(Locator.NickNameFieldLocator));
            nickNameField.Clear();
            nickNameField.SendKeys(newNickName);

            return this;
        }

        /// <summary>
        /// Clicks on save button.
        /// </summary>
        /// <returns></returns>
        public MailPersonalDataPage SaveChanges()
        {
            Wait.Until(t => Driver.FindElements(By.XPath(Locator.SaveButtonLocator)).Any());
            SaveButton = Driver.FindElement(By.XPath(Locator.SaveButtonLocator));
            SaveButton.Click();

            return this;
        }

        /// <summary>
        /// Changes nickname.
        /// </summary>
        /// <param name="newNickName">new nickname</param>
        /// <returns></returns>
        public MailPersonalDataPage ChangeNickName(string newNickName)
        {
            WriteNewNickName(newNickName);
            SaveChanges();

            return this;
        }
    }
}
