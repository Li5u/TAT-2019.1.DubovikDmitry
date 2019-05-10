namespace DEV_9.Locators
{
    /// <summary>
    /// Class with locators for mail.ru main page.
    /// </summary>
    public class MailMainPageLocators
    {
        public string WriteLetterButtonLocator { get; } = "//span[text() = 'Написать письмо']";
        public string SelecterUnreadLetterLocator { get; } = "//div[@class='b-datalist__body']/div[1]";
    }
}
