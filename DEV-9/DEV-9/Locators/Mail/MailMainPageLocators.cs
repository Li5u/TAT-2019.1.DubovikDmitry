namespace DEV_9.Locators
{
    public class MailMainPageLocators : Locator
    {
        public string WriteLetterButtonLocator { get; } = "//span[text() = 'Написать письмо']";
        public string SelecterUnreadLetterLocator { get; } = "//div//span[@class= 'b-datalist__item__status-unread']";
    }
}
