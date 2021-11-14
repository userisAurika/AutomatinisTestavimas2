using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Pages
{
    public class EshopPage : BasePage
    {
        private const string PageAddress = "https://www.dermabalt.lt/";
        private const string TextToCheck = "Pakoreguokite toliau pateiktą informaciją.";
        //private const string TextToCheck = "Norėdami tęsti įtikinkite, kad nesate robotas.";// pradeda mesti po daugkartinio testavimo puslapio
        private IWebElement _accountButton => Driver.FindElement(By.CssSelector("#shopify-section-header > sticky-header > header > div > a.header__icon.header__icon--account.link.focus-inset.small-hide > svg"));
        private IWebElement _userEmailInput => Driver.FindElement(By.Id("CustomerEmail"));
        private IWebElement _userPasswordInput => Driver.FindElement(By.Id("CustomerPassword"));
        private IWebElement _loginButton => Driver.FindElement(By.CssSelector("#customer_login > button"));
        private IWebElement _loginMessage => Driver.FindElement(By.CssSelector("#customer_login > h2"));
        private IWebElement _clickBunner => Driver.FindElement(By.Id("shopify-privacy-banner-accept-button"));

        public EshopPage(IWebDriver webdriver) : base(webdriver)//konstruktorius
        {
            Driver.Url = PageAddress;
        }
        public EshopPage PrivatePolicy() 
        {
            _clickBunner.Click();
            return this;
        }
        public EshopPage ClickAccountButton()
        {
            _accountButton.Click();
            return this;
        }
        public EshopPage InputEmailText(string text) 
        {
            _userEmailInput.Clear();
            _userEmailInput.SendKeys(text);
            return this;
        }
        public EshopPage InputPasswordText(string text)
        {
            _userPasswordInput.Clear();
            _userPasswordInput.SendKeys(text);
            return this;
        }

        public EshopPage ClickButton()
        {
            _loginButton.Click();
            return this;
        }
        private void WaitForResult() // prie privataus nesiraso => VartuTechnikaPage, prirasant return this;
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));// kodo stabilizavimui
            wait.Until(d => _loginMessage.Displayed);// kai reikia palaukti 
        }

        public EshopPage CheckResult() 
        {
            WaitForResult();
            Assert.IsTrue(_loginMessage.Text.Equals(TextToCheck));
            return this;
        }
    }
}
