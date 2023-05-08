using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
        [TestInitialize]
        public void TestInitialize()
        {
            driver = new FirefoxDriver();
            login = new LoginPage(driver);
            //maximize browser window 
            driver.Manage().Window.Maximize();
            //open the navigatation URL
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            login.menuItemControlLoggedOut.NavigateToLoginPage();
        }
        [TestMethod]
        public void Should_LoginUser_When_ValidCredentialsAreUsed()//test de verificare logare cu un set de credentiale corecte
        {

            //click sign in button from header
            //driver.FindElement(By.XPath("//div[@class='panel header']//a[contains(text(), 'Sign In')]")).Click();
            //fill in valid user email
            //driver.FindElement(By.Id("email")).SendKeys("test@email.ro");
            //fill in user password
            //driver.FindElement(By.Name("login[password]")).SendKeys("Test!123");
            //click sign in button 
            //driver.FindElement(By.CssSelector("button[name='send']")).Click();
            //assert
            login.SignInTheApplication("testare", "testare");

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
            //click sign in button from header
            // driver.FindElement(By.XPath("//div[@class='panel header']//a[contains(text(), 'Sign In')]")).Click();
            //fill in wrong  user email
            //driver.FindElement(By.Id("email")).SendKeys("testulet@yahoo.com");
            //fill in user password
            // driver.FindElement(By.Name("login[password]")).SendKeys("Test!123");
            //click sign in button 
            //driver.FindElement(By.CssSelector("button[name='send']")).Click();
            //assert
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
