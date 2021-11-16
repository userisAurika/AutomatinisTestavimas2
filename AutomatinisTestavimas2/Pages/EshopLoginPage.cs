using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Pages
{
    class EshopLoginPage : BasePage
    {
        private const string PageAddress = "https://www.dermabalt.lt/account/login";
        private const string TextToCheck = "Norėdami tęsti įtikinkite, kad nesate robotas.";//"Pakoreguokite toliau pateiktą informaciją.";
        private IWebElement UserEmailInput => Driver.FindElement(By.Id("CustomerEmail"));
        private IWebElement UserPasswordInput => Driver.FindElement(By.Id("CustomerPassword"));
        private IWebElement LoginButton => Driver.FindElement(By.CssSelector("#customer_login > button"));
        private IWebElement LoginMessage => Driver.FindElement(By.CssSelector("#customer_login > h2"));
        public EshopLoginPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }
        public EshopLoginPage InputEmailText(string text)
        {
            UserEmailInput.Clear();
            UserEmailInput.SendKeys(text);
            Thread.Sleep(8000);
            return this;
        }
        public EshopLoginPage InputPasswordText(string text)
        {
            UserPasswordInput.Clear();
            UserPasswordInput.SendKeys(text);
            Thread.Sleep(6000);
            return this;
        }

        public EshopLoginPage ClickButton()
        {
            LoginButton.Click();
            Thread.Sleep(9000);
            return this;
        }
        private void WaitForResult() 
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => LoginMessage.Displayed); 
        }

        public EshopLoginPage CheckResult()
        {
            WaitForResult();
            Assert.IsTrue(LoginMessage.Text.Equals(TextToCheck));
            return this;
        }
    }
}
