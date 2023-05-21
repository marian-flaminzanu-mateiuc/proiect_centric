using Curs07_CENTRIC.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Surdu Tony

namespace Curs07_CENTRIC.Shared
{
    public class MenuItemControlLoan
    {
        private IWebDriver driver;
        public MenuItemControlLoan(IWebDriver browser)
        {
            driver = browser;
        }
        public IWebElement ButtonLoan => driver.FindElement(By.XPath("//div[@id=\"leftPanel\"]//a[contains(text(),'Request Loan')]"));
        public LoanPage NavigateToLoanPage()
        {
            ButtonLoan.Click();
            return new LoanPage(driver);
        }
    }
}
