using Curs07_CENTRIC.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Curs07_CENTRIC
{
    [TestClass]                             //test case  Axana-Marinela
    public class OpenNewAccountTest   
    {
        private IWebDriver driver;
        private NewAccountPage openNewAccount;
        private RegisterPage register;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            openNewAccount = new NewAccountPage(driver);
            register = new RegisterPage(driver);
            //maximize browser window 
            driver.Manage().Window.Maximize();


        }
        [TestMethod]
        public void Should_OpenNewAccount_When_User_is_register()//test de verificare creare cont nou bancar dupa inregistrare
        {
            //navigate to register Page to create account
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
            register.RegisterTheApplication("testare1", "testare1", "Address", "Mexico", "Mexico", "13234", "455321112345", "23345567", "testare47", "testare3", "testare3");
            // navigate to Open new account page
            openNewAccount.menuItemControlNewAccount.NavigateToNewAccountPage();

            openNewAccount.OpenAccount();

            //sleep
            Thread.Sleep(2000);
            
            //assert
            var actualResult = driver.FindElement(By.XPath("//div[@id='mainPanel']//div[@id='rightPanel']//p[contains(text(),'Congratulations, your account is now open.')]"));
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
