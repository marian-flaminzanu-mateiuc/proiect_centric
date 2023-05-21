using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Curs07_CENTRIC.PageObjects;
using System.Threading;
using System;
using System.Collections.Specialized;

// Surdu Tony

namespace Curs07_CENTRIC
{
    [TestClass]
    public class GetLoanTest
    {
        private IWebDriver driver;
        private LoginPage login;
        private RegisterPage register;
        private LoanPage loan;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            login = new LoginPage(driver);
            register = new RegisterPage(driver);
            loan = new LoanPage(driver);
            //maximize browser window 
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void Should_Not_Accept_Loan_If_DownPayment_Is_Bigger_Than_LoanAmount()
        {
            //navigate to the registration page because  the bill payment action requires login
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
            register.RegisterTheApplication("Andrei", "Patrascu", "str. Florida", "Galati", "Romania", "12345", "0777777777", "12345", "Tony", "parola", "parola");
            //after register press log out
            register.LogOut();
            //navigate to home page for log in 
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            //log in with your registration dates
            login.SignInTheApplication("Tony", "parola");

            loan.menuItemControlLoan.NavigateToLoanPage();

            loan.GetLoan("1000", "2000");

            Thread.Sleep(3000);

            //assert
            var result = driver.FindElement(By.XPath("//td[contains(text(),'Denied')]"));
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
