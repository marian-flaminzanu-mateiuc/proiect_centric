using Curs07_CENTRIC.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs07_CENTRIC.Shared
{
    public class MenuItemControlAdmin           //Ioana
    {
        private IWebDriver driver;
        public MenuItemControlAdmin(IWebDriver browser)
        {
            driver = browser;
        }
        public IWebElement BtnAdmin => driver.FindElement(By.XPath("//a[contains(text(),'Admin Page')]"));
        public AdminPage NavigateToAdminPage()
        {
            BtnAdmin.Click();
            return new AdminPage(driver);
        }
    }
}
