using Curs07_CENTRIC.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs07_CENTRIC.Shared
{
   public class MenuItemSiteMap                     //Axana-Marinela
    {
        private IWebDriver driver;
        public MenuItemSiteMap(IWebDriver browser)
        {
            driver = browser;
        }
        public IWebElement BtnSiteMap => driver.FindElement(By.XPath("//div[@id='footermainPanel']//div[@id='footerPanel']//li//a[text()='Site Map']"));
        public SiteMapPage NavigateToSiteMapPage()
        {
            BtnSiteMap.Click();
            return new SiteMapPage(driver);
        }
    }
}
