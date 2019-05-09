using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_9.Locators.Mail
{
    public class MailSenderLetterPageLocators : Locator
    {
        public string RecepientLocator { get; } = "//textarea[@tabindex = '4']";
        public string SwitcherToFrameLocator { get; } = "//tr[@class = 'mceFirst mceLast']//iframe";
        public string TextLocator { get; } = "//*[@id='tinymce']";
        public string SendButtonLocator { get; } = "//div[@data-name = 'send']";
    }
}
