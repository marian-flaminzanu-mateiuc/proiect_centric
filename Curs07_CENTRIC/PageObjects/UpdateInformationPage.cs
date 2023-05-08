using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Curs07_CENTRIC.PageObjects;
using System.Threading;
using Curs07_CENTRIC.Shared;
using OpenQA.Selenium.Support.UI;

namespace Curs07_CENTRIC.PageObjects
{
    public class UpdateInformationPage
    {
        private IWebDriver driver;
        public MenuItemControlUpdateInformation menuItemControlUpdateInformation => new MenuItemControlUpdateInformation(driver);
        public UpdateInformationPage(IWebDriver browser)
        {
            driver = browser;
        }
        private IWebElement FirstNameInput => driver.FindElement(By.Name("customer.firstName"));
        private IWebElement LastNameInput => driver.FindElement(By.Name("customer.lastName"));
        private IWebElement AddressInput => driver.FindElement(By.Name("customer.address.street"));
        private IWebElement CityInput => driver.FindElement(By.Name("customer.address.city"));
        private IWebElement StateInput => driver.FindElement(By.Name("customer.address.state"));
        private IWebElement ZipCodeInput => driver.FindElement(By.Name("customer.address.zipCode"));
        private IWebElement PhoneInput => driver.FindElement(By.Name("customer.phoneNumber"));

        private IWebElement UpdateProfileInput => driver.FindElement(By.CssSelector("input[value='Update Profile']"));
        
        
        public void UpdateInformation(string firstName, string lastName, string address,string city, string state, string zipCode, string phone)
        {
            FirstNameInput.SendKeys(firstName);
            LastNameInput.SendKeys(lastName);
            AddressInput.SendKeys(address);
            CityInput.SendKeys(city);
            StateInput.SendKeys(state);
            ZipCodeInput.SendKeys(zipCode);
            PhoneInput.SendKeys(phone);

            UpdateProfileInput.Click();
        }
    }
}
