using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using Curs07_CENTRIC.PageObjects;

namespace Curs07_CENTRIC
{
    [TestClass]
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
            //open the navigatation URL
           
        }
        [TestMethod]
        public void Should_LoginUser_When_ValidCredentialsAreUsed()//test de verificare logare cu un set de credentiale corecte
        {

            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
            register.RegisterTheApplication("testare", "testare", "Address", "Mexico", "Mexico", "13234", "455321112345", "2334556", "testare19", "test", "test");
            register.LogOut();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            login.menuItemControlLoggedOut.NavigateToLoginPage();
            login.SignInTheApplication("testare19", "test");

            // sleep
            Thread.Sleep(2000);

            //assert
            //var expectedResult = "Welcome Test Customer FirstName Test Customer LastName";
            var actualResult = driver.FindElement(By.ClassName("smallText"));

            Assert.IsNotNull(actualResult);

        }
        [TestMethod]
        public void Should_NotLoginUser_When_WrongEmailUsed()   //set de valori pentru testare cu credentiale gresite
        {
           
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            login.menuItemControlLoggedOut.NavigateToLoginPage();
            login.SignInTheApplication("hasjj@outlook.ro", "Test!123");

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
