using Curs07_CENTRIC.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs07_CENTRIC.Shared
{
   public  class MenuItemControlNewAccount                  //Axana-Marinela
    {
        private IWebDriver driver;
        public MenuItemControlNewAccount(IWebDriver browser)
        {
            driver = browser;
        }
        public IWebElement BtnOpenNewAccount => driver.FindElement(By.XPath("//div[@id='mainPanel']//div[@id='leftPanel']//li//a[contains(text(),'Open New Account')]"));
        public NewAccountPage NavigateToNewAccountPage()
        {
            BtnOpenNewAccount.Click();
            return new NewAccountPage(driver);
        }

    }
}
