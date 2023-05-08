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

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            billPayment = new BillPaymentPage(driver);
            login = new LoginPage(driver); 
            //maximize browser window 
            driver.Manage().Window.Maximize();
            //open the navigatation URL
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            login.SignInTheApplication("testare", "testare");
            billPayment.menuItemControlBillPayment.NavigateToBillPaymentPage();
        }
        [TestMethod]
        public void Should_SendPaymentAndPayBill_When_UserIsLoggedIn()
        {

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
