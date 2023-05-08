using Curs07_CENTRIC.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Curs07_CENTRIC
{
    [TestClass]
    public class ViewServicesTest
    {
        private IWebDriver driver;
        private SiteMapPage SiteMap;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            SiteMap = new SiteMapPage(driver);
            //maximize browser window 
            driver.Manage().Window.Maximize();
            //open the navigatation URL
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
            SiteMap.menuItemSiteMap.NavigateToSiteMapPage();
        }

        [TestMethod]
        public void Should_Access_SiteMapPage()   //set de valori pentru testare cu credentiale gresite
        {

            SiteMap.SiteMapRedirect().ServicesRedirect();

            // sleep
            Thread.Sleep(2000);

            //assert
            //var actualResult = driver.FindElement(By.XPath("//div[@id='bodyPanel']//div[@id='rightPanel']//li[@class='Solutions']"));
            //var actualResult = driver.FindElement(By.XPath("//div[@id='bodyPanel']//div[@id='rightPanel']//span[@class='heading']"));
            var actualResult = driver.FindElement(By.CssSelector("body div.header > span"));
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
