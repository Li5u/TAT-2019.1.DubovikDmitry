namespace DEV_9.Locators.Mail
{
    /// <summary>
    /// Class with locators for mail.ru peronal data page.
    /// </summary>
    public class MailPersonalDataPageLocators
    {
        public string NickNameFieldLocator { get; } = "//input[@id='NickName']";
        public string SaveButtonLocator { get; } = "//span[text() = 'Сохранить']";
    }
}
