using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using Curs07_CENTRIC.PageObjects;

namespace Curs07_CENTRIC
{
    [TestClass]
    public class RegisterTests
    {
        private IWebDriver driver;
        private RegisterPage register;
        [TestInitialize]
        public void TestRegister()
        {
            driver = new ChromeDriver();
            register = new RegisterPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
            register.menuItemControlRegister.NavigateToRegisterPage();
        }

        [TestMethod]
        public void Should_RegisterUser()//test de verificare logare cu un set de credentiale corecte
        {

            register.RegisterTheApplication("testare", "testare", "Address", "Mexico", "Mexico", "13234", "455321112345", "2334556", "testare16", "testare2", "testare2");

            // sleep
            Thread.Sleep(3000);

            //assert
            //var expectedResult = "Welcome Test Customer FirstName Test Customer LastName";
            var actualResult = driver.FindElement(By.XPath("//p[contains(text(), 'Your account was created successfully. You are now logged in.')]"));

            Assert.IsNotNull(actualResult);

        }

        [TestCleanup]
        public void TestCleanup()
        {
            //clean-up
            driver.Quit();
            //driver.Close();

        }
    }
}
