using Curs07_CENTRIC.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs07_CENTRIC.Shared
{
    public class MenuItemRecoverUser
    {
        private IWebDriver driver;
        public MenuItemRecoverUser(IWebDriver browser)
        {
            driver = browser;
        }
        public IWebElement BtnRecover => driver.FindElement(By.XPath("//form[@id='customerForm']//input[@value='Forgot login info?']"));
        public RecoverUserPage NavigateToRecoveryPage()
        {
            BtnRecover.Click();
            return new RecoverUserPage(driver);
        }
    }
}
