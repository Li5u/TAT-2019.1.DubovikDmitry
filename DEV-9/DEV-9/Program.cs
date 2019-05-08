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
            var lpl = new Locators.LoginPageLocators();
            var lp = new Page_Objects.LoginPage(driver);
            lp.GoToPage();
            var mp = lp.LoginAs("dimkadubovik99", "24514125dds99");
            mp.SelectUnseenLetter("Дмитрий");
        }
    }
}
