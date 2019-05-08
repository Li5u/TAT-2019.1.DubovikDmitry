namespace DEV_9.Locators
{
    public class LoginPageLocators : Locator
    {
        public string PageLocator { get; } = "https://mail.ru/";
        public string LoginLocator { get; } = "//input[@id = 'mailbox:login']";
        public string PasswordLocator { get; } = "//input[@id = 'mailbox:password']";
        public string LoginButtonLocator { get; } = "//input[@class= 'o-control']";
    }
}
