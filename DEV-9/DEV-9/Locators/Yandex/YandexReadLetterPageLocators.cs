using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_9.Locators.Yandex
{
    class YandexReadLetterPageLocators
    {
        public string RecievedTextLocator { get; } = "//div[@class='mail-Message-Body-Content']";
        public string ReplyButtonLocator { get; } = "//div[@class='mail-QuickReply-Placeholder_text']";
        public string TextFieldLocator { get; } = "//div[@role='textbox']";
        public string SendReplyButtonLocator { get; } = "//button[contains(@title, 'Отправить')]";
    }
}
