using Curs07_CENTRIC.Shared;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Curs07_CENTRIC.PageObjects
{
    public class SiteMapPage        //Axana-Marinela
    {
        private IWebDriver driver;
        public MenuItemSiteMap menuItemSiteMap => new MenuItemSiteMap(driver);
        public SiteMapPage(IWebDriver browser)
        {
            driver = browser;
        }
        private IWebElement SiteMap => driver.FindElement(By.XPath("//div[@id='footermainPanel']//div[@id='footerPanel']//li//a[text()='Site Map']"));

        public ServicesPage SiteMapRedirect()
        {
            SiteMap.Click();
            return new ServicesPage(driver);
        }
    }
}
