using Curs07_CENTRIC.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace Curs07_CENTRIC.PageObjects
{
    public class RecoverUserPage
    {
        private IWebDriver driver;
        public MenuItemRecoverUser menuItemRecoverUser => new MenuItemRecoverUser(driver);
        public RecoverUserPage(IWebDriver browser)
        {
            driver = browser;
        }
        private IWebElement FirstNameInput => driver.FindElement(By.Name("firstName"));
        private IWebElement LastNameInput => driver.FindElement(By.Name("lastName"));
        private IWebElement AddressInput => driver.FindElement(By.Name("address.street"));
        private IWebElement CityInput => driver.FindElement(By.Name("address.city"));
        private IWebElement StateInput => driver.FindElement(By.Name("address.state"));
        private IWebElement ZipCodeInput => driver.FindElement(By.Name("address.zipCode"));
        private IWebElement SSNInput => driver.FindElement(By.Name("ssn"));

        private IWebElement RecoveProfileInput => driver.FindElement(By.CssSelector("input[value='Find My Login Info']"));


        public void RecoverInformation(string firstName, string lastName, string address, string city, string state, string zipCode, string ssn)
        {
            FirstNameInput.SendKeys(firstName);
            LastNameInput.SendKeys(lastName);
            AddressInput.SendKeys(address);
            CityInput.SendKeys(city);
            StateInput.SendKeys(state);
            ZipCodeInput.SendKeys(zipCode);
            SSNInput.SendKeys(ssn);

            RecoveProfileInput.Click();
        }
    }
}
