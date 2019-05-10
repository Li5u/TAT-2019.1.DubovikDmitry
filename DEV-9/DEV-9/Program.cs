using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DEV_9
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver("C:/Users/User/Downloads");
            var lpl = new Locators.MailLoginPageLocators();
            var lp = new Page_Objects.MailLoginPage(driver);
            lp.GoToPage();
            var mp = lp.LoginAs("demitrodub", "qwaqwaqwa11");
            var l = mp.SelectUnseenLetter();
            var nick = l.GetReplyText();
            var pd = l.GoToPersonalDataPage();
            pd.ChangeNickName(nick);

            /*var sendletter = mp.ClickToWriteLetterButton();
            sendletter.SendLetter("dubovikdmitro@yandex.by", "give me new name");
            var lpp = new Page_Objects.Yandex.YandexLoginPage(driver);
            lpp.GoToPage();
            var mpp = lpp.LoginAs("dubovikdmitro", "qwaqwa11");
            var a = mpp.SelectLatestLetter("d");
            a.ReplyToTheLetter("Plevok");
            lp.GoToPage();
            var mppp = lp.LoginAs("demitrodub", "qwaqwaqwa11");
            var l = mppp.SelectUnseenLetter();
            Console.WriteLine(l.GetReplyText());*/
        }
    }
}
