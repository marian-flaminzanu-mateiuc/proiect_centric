using Curs07_CENTRIC.Shared;
using OpenQA.Selenium;

namespace Curs07_CENTRIC.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public MenuItemControlLoggedOut menuItemControlLoggedOut => new MenuItemControlLoggedOut(driver);
        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        /* private IWebElement EmailInput()
         {
             return driver.FindElement(By.Id("email"));
         }

         private IWebElement PasswordInput()
         {
             return driver.FindElement(By.Name("login[password]"));
         }

         private IWebElement SignInButton()
         {
             return driver.FindElement(By.CssSelector("button[name='send']"));
         }*/
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