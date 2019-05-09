namespace DEV_9.Locators.Yandex
{
    class YandexLoginPageLocators
    {
        public string PageLocator { get; } = "https://yandex.by/";
        public string LoginIntoButtonLocator { get; } = "//a[contains(@class,'button desk-notif-card__login-enter-expanded')]";
        public string LoginLocator { get; } = "//input[@id = 'passp-field-login']";
        public string PasswordLocator { get; } = "//input[@id = 'passp-field-passwd']";
        public string SubmitButtonLocator { get; } = "//button[@type = 'submit']";
    }
}
