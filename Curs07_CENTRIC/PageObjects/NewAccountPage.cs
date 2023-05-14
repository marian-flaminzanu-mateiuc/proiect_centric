using Curs07_CENTRIC.Shared;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Curs07_CENTRIC.PageObjects
{
    public class NewAccountPage     //Axana-Marinela
    {
        private IWebDriver driver;
        public MenuItemControlNewAccount menuItemControlNewAccount => new MenuItemControlNewAccount(driver);
        public NewAccountPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement FromTypeAccountSelect => driver.FindElement(By.XPath("//select[@id='type']"));
        private SelectElement FromTypeAccountSelectElement => new SelectElement(FromTypeAccountSelect);
        private IWebElement FromIdAccountSelect => driver.FindElement(By.XPath("//select[@id='fromAccountId']"));
        private IWebElement OpenNewAccountButton => driver.FindElement(By.XPath("//form[@ng-submit='submit()']//input[@value='Open New Account']"));
        public void OpenAccount()
        {
            FromTypeAccountSelectElement.SelectByValue("1");
            FromIdAccountSelect.Click();
            Thread.Sleep(1000);
            OpenNewAccountButton.Click();
            
        }
    }

}
