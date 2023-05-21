using Curs07_CENTRIC.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Threading;

// Surdu Tony

namespace Curs07_CENTRIC
{
    [TestClass]
    public class TransferFundsTest
    {
        [TestClass]
        public class GetLoanTest
        {
            private IWebDriver driver;
            private LoginPage login;
            private RegisterPage register;
            private TransferFundsPage transferPage;

            [TestInitialize]
            public void TestInitialize()
            {
                driver = new ChromeDriver();
                login = new LoginPage(driver);
                register = new RegisterPage(driver);
                transferPage = new TransferFundsPage(driver);
                //maximize browser window 
                driver.Manage().Window.Maximize();
            }

            [TestMethod]
            public void Should_Not_Accept_Loan_If_DownPayment_Is_Bigger_Than_LoanAmount()
            {
                //navigate to the registration page because  the bill payment action requires login
                driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
                register.RegisterTheApplication("firstname", "lastname", "address", "city", "state", "123456", "0777777778", "123456", "user", "password", "password");
                //after register press log out
                register.LogOut();
                //navigate to home page for log in 
                driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
                //log in with your registration dates
                login.SignInTheApplication("user", "password");

                transferPage.menuItemControlTransferFunds.NavigateToLoanPage();

                Thread.Sleep(1000);

                transferPage.Transfer("200");

                Thread.Sleep(3000);

                //assert
                var result = driver.FindElement(By.XPath("//h1[contains(text(),'Transfer Complete!')]"));
                Assert.IsNotNull(result);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                driver.Quit();
                //driver.Close();
            }
        }
    }
}