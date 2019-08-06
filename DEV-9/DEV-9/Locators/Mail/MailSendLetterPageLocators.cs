namespace DEV_9.Locators.Mail
{
    /// <summary>
    /// Class with locators for mail.ru send letter page.
    /// </summary>
    public class MailSendLetterPageLocators 
    {
        public string RecepientLocator { get; } = "//textarea[@tabindex = '4']";
        public string SwitcherToFrameLocator { get; } = "//tr[@class = 'mceFirst mceLast']//iframe";
        public string TextLocator { get; } = "//*[@id='tinymce']";
        public string SendButtonLocator { get; } = "//div[@data-name = 'send']";
    }
}
