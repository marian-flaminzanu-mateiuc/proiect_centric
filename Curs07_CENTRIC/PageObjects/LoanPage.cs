using Curs07_CENTRIC.Shared;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Surdu Tony

namespace Curs07_CENTRIC.PageObjects
{
    public class LoanPage
    {
        private IWebDriver driver;
        public MenuItemControlLoan menuItemControlLoan => new MenuItemControlLoan(driver);

        public LoanPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement LoanAmountInput => driver.FindElement(By.Id("amount"));
        private IWebElement DownPaymentInput => driver.FindElement(By.Id("downPayment"));
        private IWebElement ApplyButton => driver.FindElement(By.XPath("//input[@type='submit']"));

        public void GetLoan(string loanAmount, string downPayment)
        {
            LoanAmountInput.SendKeys(loanAmount);
            DownPaymentInput.SendKeys(downPayment);
            ApplyButton.Click();
        }
    }
}
