using Curs07_CENTRIC.Shared;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Surdu Tony

namespace Curs07_CENTRIC.PageObjects
{
    public class TransferFundsPage
    {
        private IWebDriver driver;
        public MenuItemControlTransferFunds menuItemControlTransferFunds => new MenuItemControlTransferFunds(driver);

        public TransferFundsPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement AmountInput => driver.FindElement(By.Id("amount"));
        private IWebElement ApplyButton => driver.FindElement(By.XPath("//input[@type='submit']"));

        public void Transfer(string amount)
        {
            AmountInput.SendKeys(amount);
            ApplyButton.Click();
        }
    }
}
