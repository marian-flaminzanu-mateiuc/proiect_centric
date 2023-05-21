using Curs07_CENTRIC.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs07_CENTRIC.Shared
{
    public class MenuItemControlTransferFunds
    {
        private IWebDriver driver;
        public MenuItemControlTransferFunds(IWebDriver browser)
        {
            driver = browser;
        }
        public IWebElement ButtonTransferPage => driver.FindElement(By.XPath("//div[@id=\"leftPanel\"]//a[contains(text(),'Transfer Funds')]"));
        public TransferFundsPage NavigateToLoanPage()
        {
            ButtonTransferPage.Click();
            return new TransferFundsPage(driver);
        }
    }
}
