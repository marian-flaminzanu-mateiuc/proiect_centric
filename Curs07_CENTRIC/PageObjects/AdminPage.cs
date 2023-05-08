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
    public class AdminPage
    {
        private IWebDriver driver;
        public MenuItemControlAdmin menuItemControlAdmin => new MenuItemControlAdmin(driver);

        public AdminPage(IWebDriver browser)
        {
            driver = browser;
        }
        private IWebElement InitializeButton => driver.FindElement(By.XPath("//button[@value='INIT']"));

        private IWebElement DataAccesModeInput => driver.FindElement(By.XPath("//form[@id='adminForm']/table[@class='form']//input[@id='accessMode3']"));

        private IWebElement SOAPEndpointInput => driver.FindElement(By.XPath("//form[@id='adminForm']/table[@class='form2']//input[@id='soapEndpoint']"));

        private IWebElement RESTEndpointInput => driver.FindElement(By.XPath("//form[@id='adminForm']/table[@class='form2']//input[@id='restEndpoint']"));
       
        private IWebElement EndpointInput => driver.FindElement(By.XPath("//input[@id = 'endpoint']"));
        
        private IWebElement InitialBalanceInput => driver.FindElement(By.Name("initialBalance"));

        private IWebElement MinimumBalanceInput => driver.FindElement(By.Name("minimumBalance"));

        private IWebElement LoanProviderSelect => driver.FindElement(By.CssSelector("#loanProvider"));
        
        private IWebElement LoanProcessorSelect => driver.FindElement(By.CssSelector("#loanProcessor"));
        
        private IWebElement ThresholdInput => driver.FindElement(By.XPath("//table[@class='form2']//input[@id='loanProcessorThreshold']"));
        
        private SelectElement LoanProviderSelectElement => new SelectElement(LoanProviderSelect);
        private SelectElement LoanProcessorSelectElement => new SelectElement(LoanProcessorSelect);
        public void InitializeDatabase( string SOAPEndpoint, string RESTEndpoint,string endpoint, string initialBalance, string minimumBalance,string loanProvider,string loanProcessor, string threshold)
        {
            DataAccesModeInput.Click();
            SOAPEndpointInput.SendKeys(SOAPEndpoint);
            RESTEndpointInput.SendKeys(RESTEndpoint);
            EndpointInput.SendKeys(endpoint);
            InitialBalanceInput.SendKeys(initialBalance);
            MinimumBalanceInput.SendKeys(minimumBalance);      
            LoanProviderSelectElement.SelectByText(loanProvider);
            LoanProcessorSelectElement.SelectByValue(loanProcessor);
            ThresholdInput.SendKeys(threshold);
            InitializeButton.Click();
        }
    }
}
