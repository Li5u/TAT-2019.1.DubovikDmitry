namespace DEV_9.Locators.Yandex
{
    /// <summary>
    /// Class with locators for yandex.by read letter page.
    /// </summary>
    public class YandexReadLetterPageLocators
    {
        public string RecievedTextLocator { get; } = "//div[@class='mail-Message-Body-Content']";
        public string ReplyButtonLocator { get; } = "//div[@class='mail-QuickReply-Placeholder_text']";
        public string TextFieldLocator { get; } = "//div[@role='textbox']";
        public string SendReplyButtonLocator { get; } = "//button[contains(@title, 'Отправить')]";
    }
}
