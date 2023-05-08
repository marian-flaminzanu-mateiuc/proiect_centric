using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs07_CENTRIC.PageObjects
{
   public  class ServicesPage
    {
        private IWebDriver driver;
        public ServicesPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement ServicesButton => driver.FindElement(By.XPath("//div[@id='bodyPanel']//div[@id='rightPanel']//li//a[text()='Services']"));

        private IWebElement linkInvalid => driver.FindElement(By.XPath("//div[@id='bodyPanel']//div[@id='rightPanel']//table//td//a[text()='{http://store.parabank.parasoft.com/}Bookstore']"));

        public void ServicesRedirect()
        {
            ServicesButton.Click();
            linkInvalid.Click();
        }
      
    }
}
