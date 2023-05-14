using Curs07_CENTRIC.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs07_CENTRIC.Shared
{
    public class MenuItemControlLogIn                   //Axana-Marinela
    {
        private IWebDriver driver;
        public MenuItemControlLogIn(IWebDriver browser)
        {
            driver = browser;
        }
        public IWebElement BtnSignIn => driver.FindElement(By.XPath("//div[@class='login']/input[@value='Log In']"));
        public LoginPage NavigateToLoginPage()
        {
            BtnSignIn.Click();
            return new LoginPage(driver);
        }
    }
}
