using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace DEV_9.Tests
{
 
    public class LoginTestsMailRu
    {

        IWebDriver Driver { get; set; }
        WebDriverWait Wait { get; set; }


        [SetUp]
        public void StartBrowser()
        {
            this.Driver = new ChromeDriver("C:/Users/User/Downloads");
            this.Wait = new WebDriverWait(Driver, TimeSpan.FromMinutes(1));
        }


        [Test]
        public void Login_With_Correct_Data()
        {
            var loginPage = new Page_Objects.MailLoginPage (Driver);
            var mainPage = loginPage.LoginAs("demitrodub", "qwaqwaqwa11");
            Assert.True(mainPage.FindWriteLetterButton().Displayed);
        }

        [Test]
        public void Login_EmptyInput_ErrorMessage()
        {
            var loginPage = new Page_Objects.MailLoginPage(Driver);
            loginPage.LoginAs(string.Empty, string.Empty); 
            //Wait.Until(t => Driver.FindElements(By.XPath("//input[contains(@class, 'is-error']")).Any());
            var log = Driver.FindElements(By.XPath("//input[contains(@class, 'is-error']"));
            Assert.IsTrue(log.Count == 2);
        }

        [Test]
        public void Login_EmptyUsername_ErrorMessage()
        {
            var loginPage = new Page_Objects.MailLoginPage(Driver);
            loginPage.LoginAs(string.Empty, "test");
            //Wait.Until(t => Driver.FindElements(By.XPath("//input[contains(@class, 'is-error']")).Any());
            var log = Driver.FindElements(By.XPath("//input[contains(@class, 'is-error']"));
            Assert.IsTrue(log.Count == 1);
        }
    
        [Test]
        public void Login_EmptyPassword_ErrorMessage()
        {
            var loginPage = new Page_Objects.MailLoginPage(Driver);
            loginPage.LoginAs("test", string.Empty);
            //Wait.Until(t => Driver.FindElements(By.XPath("//input[contains(@class, 'is-error']")).Any());
            var log = Driver.FindElements(By.XPath("//input[contains(@class, 'is-error']"));
            Assert.IsTrue(log.Count == 1);
        }


        [TestCase("demitrodub", "test")]
        [TestCase("test", "qwaqwaqwa11")]
        public void Login_WrongIdOrPassword_ErrorMessage(string username, string password)
        {
            var loginPage = new Page_Objects.MailLoginPage(Driver);
            loginPage.LoginAs(username, password);
            //Wait.Until(t => Driver.FindElements(By.XPath("//div[text() = 'Неверное имя или пароль'")).Any());
            var log = Driver.FindElements(By.XPath("//div[text() = 'Неверное имя или пароль'"));
            Assert.IsTrue(log.Count == 1);
        }

        [TearDown]
        public void CloseBrowser()
        {
            this.Driver.Quit();
        }
    }
}