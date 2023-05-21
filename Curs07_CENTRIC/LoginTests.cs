using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using Curs07_CENTRIC.PageObjects;

namespace Curs07_CENTRIC
{
    [TestClass]                 //test case Axana-Marinela
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage login;
        private RegisterPage register;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            login = new LoginPage(driver);
            register = new RegisterPage(driver);

            //maximize browser window 
            driver.Manage().Window.Maximize();

        }
        [TestMethod]
        public void Should_LoginUser_When_ValidCredentialsAreUsed() //test de verificare logare cu un set de credentiale corecte
        {
            //navigate to register Page to create account
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
            register.RegisterTheApplication("testare", "testare", "Address", "Mexico", "Mexico", "13234", "455321112345", "2334556", "testare19", "test", "test");
            //press log out button to verify log in action
            register.LogOut();
            //navigate to home page
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            login.menuItemControlLogIn.NavigateToLoginPage();
            //log in with your registration dates
            login.SignInTheApplication("testare19", "test");

            // sleep
            Thread.Sleep(2000);

            //assert
            var actualResult = driver.FindElement(By.ClassName("smallText"));

            Assert.IsNotNull(actualResult);

        }
        [TestMethod]
        public void Should_NotLoginUser_When_WrongEmailUsed()   //set de valori pentru testare cu credentiale gresite
        {

            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            login.menuItemControlLogIn.NavigateToLoginPage();
            login.SignInTheApplication("email@out.com", "Test!123");

            // sleep
            Thread.Sleep(2000);

            //assert
            var actualResult = driver.FindElement(By.ClassName("error"));

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