using Curs07_CENTRIC.Shared;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs07_CENTRIC.PageObjects
{
    public class BillPaymentPage
    {
        private IWebDriver driver;
        public MenuItemControlBillPayment menuItemControlBillPayment => new MenuItemControlBillPayment(driver);
        public BillPaymentPage(IWebDriver browser)
        {
            driver = browser;
        }
        private IWebElement PayeeNameInput => driver.FindElement(By.XPath("//table[@class='form2']//input[@name='payee.name']"));
        private IWebElement AddressInput => driver.FindElement(By.Name("payee.address.street"));
        private IWebElement CityInput => driver.FindElement(By.CssSelector("td input[name=\"payee.address.city\"]"));
        private IWebElement StateInput => driver.FindElement(By.CssSelector("td input[name=\"payee.address.state\"]"));
        private IWebElement ZipCodeInput => driver.FindElement(By.Name("payee.address.zipCode"));

        private IWebElement PhoneInput => driver.FindElement(By.CssSelector("input[name=\"payee.phoneNumber\"]"));
        private IWebElement AccountInput => driver.FindElement(By.XPath("//table[@class='form2']//input[@name='payee.accountNumber']"));
        private IWebElement VerifyAccountInput => driver.FindElement(By.XPath("//table[@class='form2']//input[@name='verifyAccount']"));
        private IWebElement AmountInput => driver.FindElement(By.CssSelector("input[name='amount']"));
        private IWebElement FromAccountSelect => driver.FindElement(By.XPath("//select[@name='fromAccountId']"));
        private SelectElement FromAccountSelectElement => new SelectElement(FromAccountSelect);
        private IWebElement SendPaymentInput => driver.FindElement(By.CssSelector("input[value='Send Payment']"));
        public void SendPayment(string payeeName, string address, string city, string state, string zipCode, string phone, string account, string verifyAccount, string amount)
        {
            PayeeNameInput.SendKeys(payeeName);
            AddressInput.SendKeys(address);
            CityInput.SendKeys(city);
            StateInput.SendKeys(state);
            ZipCodeInput.SendKeys(zipCode);
            PhoneInput.SendKeys(phone);
            AccountInput.SendKeys(account);
            VerifyAccountInput.SendKeys(verifyAccount);
            AmountInput.SendKeys(amount);
            FromAccountSelectElement.SelectByIndex(0);
            SendPaymentInput.Click();
        }
    }
}
