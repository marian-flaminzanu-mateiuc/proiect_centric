using Curs07_CENTRIC.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs07_CENTRIC.Shared
{
    public class MenuItemControlBillPayment
    {
            private IWebDriver driver;
            public MenuItemControlBillPayment(IWebDriver browser)
            {
                driver = browser;
            }
            public IWebElement BtnBillPayment => driver.FindElement(By.XPath("//div[@id=\"leftPanel\"]//a[contains(text(),'Bill Pay')]"));
            public BillPaymentPage NavigateToBillPaymentPage()
            {
                BtnBillPayment.Click();
                return new BillPaymentPage(driver);
            }
    }
}
