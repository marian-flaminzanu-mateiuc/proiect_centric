using Curs07_CENTRIC.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs07_CENTRIC.Shared
{
    public class MenuItemControlRegister                     //Axana-Marinela
    {
        private IWebDriver driver;
        public MenuItemControlRegister(IWebDriver browser)
        {
            driver = browser;
        }
        public IWebElement BtnRegister => driver.FindElement(By.XPath("//form[@id='customerForm']//input[@value='Register']"));
        public RegisterPage NavigateToRegisterPage()
        {
            BtnRegister.Click();
            return new RegisterPage(driver);
        }

    }
}
