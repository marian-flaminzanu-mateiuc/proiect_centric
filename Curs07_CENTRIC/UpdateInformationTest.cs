using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Curs07_CENTRIC.PageObjects;
using System.Threading;

namespace Curs07_CENTRIC
{
    [TestClass]                             //test case Marian 
    public class UpdateInformationTest
    {
        private IWebDriver driver;
        private UpdateInformationPage updateInformation;
        private RegisterPage register;
        private LoginPage login;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            updateInformation = new UpdateInformationPage(driver);
            register = new RegisterPage(driver);
            login = new LoginPage(driver);
            //maximize browser window 
            driver.Manage().Window.Maximize();
            
                   
        }
        [TestMethod]

        public void Should_UpdateInformation_When_IsRegisteredForTheFirstTime() 
        {
            //navigate to register Page to create account
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
            register.RegisterTheApplication("testare1", "testare1", "Address", "Mexico", "Mexico", "13234", "455321112345", "23345567", "testare201", "testare3", "testare3");
            //after register press log out
            register.LogOut();
            //navigate to home page for log in 
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            //log in with your registration dates
            login.SignInTheApplication("testare201", "testare3");

            //navigate to Update Contact Info page
            updateInformation.menuItemControlUpdateInformation.NavigateToUpdateInformation();

            updateInformation.UpdateInformation("John", "Kenneth", "Wool Street", "San Francisco", "California", "94110", "123456789");

            //sleep
            Thread.Sleep(3000);

            //assert
            IWebElement actualResult = driver.FindElement(By.XPath("//*[@id='rightPanel']/div/div/p"));
            Assert.IsNotNull(actualResult);
            
        }
        [TestMethod]
        public void Should_UpdateInformation_When_UserExists()
        {
            //navigate to home page for log in 
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            //log in with your registration dates
            login.SignInTheApplication("testare201", "testare3");
            //navigate to Update Contact Info page
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/overview.htm");
            updateInformation.menuItemControlUpdateInformation.NavigateToUpdateInformation();

            updateInformation.UpdateInformation("John","Kenneth","Wool Street","San Francisco","California","94110","123456789");

            //sleep
            Thread.Sleep(3000);

            //assert
            IWebElement actualResult = driver.FindElement(By.XPath("//*[@id='rightPanel']/div/div/p"));
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
