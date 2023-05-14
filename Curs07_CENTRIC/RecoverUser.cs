using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using Curs07_CENTRIC.PageObjects;

namespace Curs07_CENTRIC
{


    //Flaminzanu-Mateiuc Marian


    [TestClass]
    public class RecoverUserTests
    {
        private IWebDriver driver;
        private RecoverUserPage recover;
        private RegisterPage register;
        private LoginPage login;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            recover = new RecoverUserPage(driver);
            register = new RegisterPage(driver);
            login = new LoginPage(driver);
            //maximize browser window 
            driver.Manage().Window.Maximize();
            //open the navigatation URL

        }
        [TestMethod]

        public void Should_RecoverInformation_When_IsRegisteredForTheFirstTime()
        {

            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
            register.RegisterTheApplication("testare9", "testare9", "Address", "Mexico", "Mexico", "132345", "455321112345", "2334556789", "testare2092", "testare8", "testare8");
            register.LogOut();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/lookup.htm");

            recover.RecoverInformation("testare9", "testare9", "Address", "Mexico", "Mexico", "132345", "2334556789");
            Thread.Sleep(3000);

            var actualResult = driver.FindElement(By.XPath("//p[contains(text(), 'Your login information was located successfully. You are now logged in.')]"));
            //
            Assert.IsNotNull(actualResult);

        }

        [TestMethod]
        public void Should_RecoverInformation_When_UserExists()
        {
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            login.SignInTheApplication("testare2091", "testare8");
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/lookup.htm");

            recover.RecoverInformation("testare9", "testare9", "Address", "Mexico", "Mexico", "132345", "2334556789");
            Thread.Sleep(3000);

            var actualResult = driver.FindElement(By.XPath("//p[contains(text(), 'Your login information was located successfully. You are now logged in.')]"));
            //
            Assert.IsNotNull(actualResult);

        }

        [TestCleanup]
        public void TestCleanup()
        {
            //clean-up

            driver.Quit();

        }
    }
}