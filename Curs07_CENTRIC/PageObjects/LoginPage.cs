using Curs07_CENTRIC.Shared;
using OpenQA.Selenium;

namespace Curs07_CENTRIC.PageObjects
{
    public class LoginPage          //Axana-Marinela
    {
        private IWebDriver driver;
        public MenuItemControlLogIn menuItemControlLogIn => new MenuItemControlLogIn(driver);
        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }
        private IWebElement EmailInput => driver.FindElement(By.Name("username"));

        private IWebElement PasswordInput => driver.FindElement(By.Name("password"));
        private IWebElement SignInButton => driver.FindElement(By.XPath("//input[@type='submit']"));

        public void SignInTheApplication(string email, string password)
        {
            EmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);
            SignInButton.Click();
            
        }
    }
}