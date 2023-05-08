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
    public class BillPaymentTest
    {
        private IWebDriver driver;
        private BillPaymentPage billPayment;
        private LoginPage login;
        private RegisterPage register;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            billPayment = new BillPaymentPage(driver);
            login = new LoginPage(driver);
            register = new RegisterPage(driver);
            //maximize browser window 
            driver.Manage().Window.Maximize();
            
            
        }
        [TestMethod]
        public void Should_SendPaymentAndPayBill_When_UserIsLoggedIn()
        {

            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
            register.RegisterTheApplication("testare1", "testare1", "Address", "Mexico", "Mexico", "13234", "455321112345", "23345567", "testare301", "testare3", "testare3");
            register.LogOut();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            login.SignInTheApplication("testare301", "testare3");
            billPayment.menuItemControlBillPayment.NavigateToBillPaymentPage();

            billPayment.SendPayment("Mike Anderson", "Avenue 23", "Juneau", "Alaska", "400230", "907-555-1212", "12000", "12000", "750");
            
            Thread.Sleep(3000);

            var actualResult = driver.FindElement(By.XPath("//h1[contains(text(),'Bill Payment Complete')]"));
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
