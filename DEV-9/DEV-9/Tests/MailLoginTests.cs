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

        /// <summary>
        /// Negative test for logging in:
        /// empty input, results in error message.
        /// </summary>
        [Test]
        public void Login_EmptyInput_ErrorMessage()
        {
            var loginPage = new Page_Objects.MailLoginPage(Driver);
            loginPage.LoginAs(string.Empty, string.Empty); 
            //Wait.Until(t => Driver.FindElements(By.XPath("//input[contains(@class, 'is-error']")).Any());
            var log = Driver.FindElements(By.XPath("//input[contains(@class, 'is-error']"));
            Assert.IsTrue(log.Count == 2);
        }

        /// <summary>
        /// Negative test for logging in:
        /// empty username, results in error message.
        /// </summary>
        [Test]
        public void Login_EmptyUsername_ErrorMessage()
        {
            var loginPage = new Page_Objects.MailLoginPage(Driver);
            loginPage.LoginAs(string.Empty, "test");
            //Wait.Until(t => Driver.FindElements(By.XPath("//input[contains(@class, 'is-error']")).Any());
            var log = Driver.FindElements(By.XPath("//input[contains(@class, 'is-error']"));
            Assert.IsTrue(log.Count == 1);
        }
    

        /// <summary>
        /// Negative test for logging in:
        /// empty password, results in error message.
        /// </summary>
        [Test]
        public void Login_EmptyPassword_ErrorMessage()
        {
            var loginPage = new Page_Objects.MailLoginPage(Driver);
            loginPage.LoginAs("test", string.Empty);
            //Wait.Until(t => Driver.FindElements(By.XPath("//input[contains(@class, 'is-error']")).Any());
            var log = Driver.FindElements(By.XPath("//input[contains(@class, 'is-error']"));
            Assert.IsTrue(log.Count == 1);
        }

        /*/// <summary>
        /// Negative test for logging in:
        /// wrong id or password, results in error message.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        [TestCase("niksaff34", "testing")]
        [TestCase("niksavi84", "testing")]
        public void Login_WrongIdOrPassword_ErrorMessage(string username, string password)
        {
            var homePage = new Page_Objects.MailLoginPage(this.driver);
            homePage.Login_ExpectingError(username, password);
            Assert.AreEqual("Неверное имя или пароль", homePage.ErrorMessage.Text);
        }*/

        /// <summary>
        /// Tear down: close the driver.
        /// </summary>
        [TearDown]
        public void CloseBrowser()
        {
            this.Driver.Quit();
        }
    }
}