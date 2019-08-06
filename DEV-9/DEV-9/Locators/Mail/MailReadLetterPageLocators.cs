namespace DEV_9.Locators.Mail
{
    /// <summary>
    /// Class with locators for mail.ru read letter page.
    /// </summary>
    public class MailReadLetterPageLocators
    {
        public string ReplyTextLocator { get; } = "//div[@class = 'js-helper js-readmsg-msg']/div/div/div/div";
        public string ProfileInfoButtonLocator { get; } = "//i[@id = 'PH_user-email']";
        public string PersonalDataButtonLocator { get; } = "//span[text() = 'Личные данные']";
    }
}
