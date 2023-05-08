using Curs07_CENTRIC.Shared;
using OpenQA.Selenium;

namespace Curs07_CENTRIC.PageObjects
{
    public class RegisterPage
    {
        private IWebDriver driver;
        public MenuItemControlRegister menuItemControlRegister => new MenuItemControlRegister(driver);
        public RegisterPage(IWebDriver browser)
        {
            driver = browser;
        }
        private IWebElement FirstName => driver.FindElement(By.Name("customer.firstName"));
        private IWebElement LastName => driver.FindElement(By.Name("customer.lastName"));
        private IWebElement Address => driver.FindElement(By.Name("customer.address.street"));

        private IWebElement City => driver.FindElement(By.Name("customer.address.city"));
        private IWebElement State => driver.FindElement(By.Name("customer.address.state"));
        private IWebElement ZipCode => driver.FindElement(By.Name("customer.address.zipCode"));
        private IWebElement Phone => driver.FindElement(By.Name("customer.phoneNumber"));
        private IWebElement SSN_input => driver.FindElement(By.Name("customer.ssn"));
        private IWebElement Username => driver.FindElement(By.Name("customer.username"));
        private IWebElement Password => driver.FindElement(By.Name("customer.password"));
        private IWebElement Confirm => driver.FindElement(By.Name("repeatedPassword"));
        private IWebElement RegisterButton => driver.FindElement(By.XPath("//input[@value='Register']"));

        private IWebElement LogOutButton => driver.FindElement(By.XPath("//div[@id='bodyPanel']//div[@id='leftPanel']//ul//a[text()='Log Out']"));

        public void RegisterTheApplication(string firstName, string lastName,string address,string city,string state,string zipCode,string phone,string SSN,string username,string password,string confirm)
        {
           FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
            Address.SendKeys(address);
            City.SendKeys(city);
            State.SendKeys(state);
            ZipCode.SendKeys(zipCode);
            Phone.SendKeys(phone);
            SSN_input.SendKeys(SSN);
            Username.SendKeys(username);
            Password.SendKeys(password);
            Confirm.SendKeys(confirm);

            RegisterButton.Click();
            
        }
        public void LogOut()
        {

            LogOutButton.Click();
        }
    }
    
}