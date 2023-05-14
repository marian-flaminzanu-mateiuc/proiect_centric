using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Curs07_CENTRIC.PageObjects;
using System.Threading;

namespace Curs07_CENTRIC
{
    [TestClass]                             //test case Ioana
    public class DatabaseInitializationTest
    {
        private IWebDriver driver;
        private AdminPage admin;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            admin = new AdminPage(driver);
            //maximize browser window 
            driver.Manage().Window.Maximize();
            //open the navigatation URL
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/admin.htm");
            admin.menuItemControlAdmin.NavigateToAdminPage();
        }

        [TestMethod]
        public void Should_Initialize_Database()
        {
            admin.InitializeDatabase(0,"456", "http://localhost:9080/proxy/parabank/services/bank", "456p", "30000", "30.00","Local","combined", "50");

            // sleep
            Thread.Sleep(3000);

            //assert
            var actualResult = driver.FindElement(By.XPath("//b[contains(text(),'Database Initialized')]"));
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
