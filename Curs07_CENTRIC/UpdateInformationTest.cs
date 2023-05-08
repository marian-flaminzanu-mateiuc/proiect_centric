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
    [TestClass]
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
            //open the navigatation URL
                   
        }
        [TestMethod]

        public void Should_UpdateInformation_When_IsRegisteredForTheFirstTime()
        {

            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
            register.RegisterTheApplication("testare1", "testare1", "Address", "Mexico", "Mexico", "13234", "455321112345", "23345567", "testare201", "testare3", "testare3");
            register.LogOut();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            login.SignInTheApplication("testare201", "testare3");

            updateInformation.menuItemControlUpdateInformation.NavigateToUpdateInformation();

            updateInformation.UpdateInformation("John", "Kenneth", "Wool Street", "San Francisco", "California", "94110", "123456789");

            Thread.Sleep(3000);

            IWebElement actualResult = driver.FindElement(By.XPath("//*[@id='rightPanel']/div/div/p"));
            Assert.IsNotNull(actualResult);
            
        }
        [TestMethod]
        public void Should_UpdateInformation_When_UserExists()
        {
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            login.SignInTheApplication("testare201", "testare3");
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/overview.htm");
            updateInformation.menuItemControlUpdateInformation.NavigateToUpdateInformation();

            updateInformation.UpdateInformation("John","Kenneth","Wool Street","San Francisco","California","94110","123456789");

            Thread.Sleep(3000);

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
