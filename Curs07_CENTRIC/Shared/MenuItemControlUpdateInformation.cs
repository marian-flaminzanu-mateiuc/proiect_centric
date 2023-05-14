using Curs07_CENTRIC.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs07_CENTRIC.Shared
{
    public class MenuItemControlUpdateInformation                   //Marian
    {
        private IWebDriver driver;
        public MenuItemControlUpdateInformation(IWebDriver browser)
        {
            driver = browser;
        }
        public IWebElement BtnUpdateInformation => driver.FindElement(By.XPath("//div[@id=\"leftPanel\"]//a[contains(text(),'Update Contact Info')]"));
        
        public UpdateInformationPage NavigateToUpdateInformation()
        {
            BtnUpdateInformation.Click();
            return new UpdateInformationPage(driver);
        }
    }
}
