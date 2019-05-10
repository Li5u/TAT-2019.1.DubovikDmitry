namespace DEV_9.Locators
{
    /// <summary>
    /// Class with locators for mail.ru login page.
    /// </summary>
    public class MailLoginPageLocators
    {
        public string PageLocator { get; } = "https://mail.ru/";
        public string LoginLocator { get; } = "//input[@id = 'mailbox:login']";
        public string PasswordLocator { get; } = "//input[@id = 'mailbox:password']";
        public string LoginButtonLocator { get; } = "//input[@class= 'o-control']";
    }
}
