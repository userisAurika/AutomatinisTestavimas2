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
    class EshopJuodrastisPage : BasePage
    {
        //private const string actualURL= "https://www.dermabalt.lt/account/login";
       // private const string expectedURL = "https://www.dermabalt.lt/account";

        private const string PageAddress = "https://www.dermabalt.lt/";
        private const string TextToCheck = "Norėdami tęsti įtikinkite, kad nesate robotas"; //"Pakoreguokite toliau pateiktą informaciją.";
        //private const string TextToCheck = "Norėdami tęsti įtikinkite, kad nesate robotas.";// pradeda mesti po daugkartinio testavimo puslapio
        private IWebElement AccountButton => Driver.FindElement(By.CssSelector("#shopify-section-header > sticky-header > header > div > a.header__icon.header__icon--account.link.focus-inset.small-hide > svg"));
        private IWebElement UserEmailInput => Driver.FindElement(By.Id("CustomerEmail"));
        private IWebElement UserPasswordInput => Driver.FindElement(By.Id("CustomerPassword"));
        private IWebElement LoginButton => Driver.FindElement(By.CssSelector("#customer_login > button"));
        private IWebElement LoginMessage => Driver.FindElement(By.CssSelector(".shopify-challenge__message"));////(By.CssSelector("#customer_login > h2"));
        private IWebElement ClickBunner => Driver.FindElement(By.Id("shopify-privacy-banner-accept-button"));

        public EshopJuodrastisPage(IWebDriver webdriver) : base(webdriver)//konstruktorius
        {
            Driver.Url = PageAddress;
        }
        public EshopJuodrastisPage PrivatePolicy()
        {
            ClickBunner.Click();
            return this;
        }
        public EshopJuodrastisPage ClickAccountButton()
        {
            AccountButton.Click();
            return this;
        }
        public EshopJuodrastisPage InputEmailText(string text)
        {
            UserEmailInput.Clear();
            UserEmailInput.SendKeys(text);
            return this;
        }
        public EshopJuodrastisPage InputPasswordText(string text)
        {
            UserPasswordInput.Clear();
            UserPasswordInput.SendKeys(text);
            return this;
        }

        public EshopJuodrastisPage ClickButton()
        {
            LoginButton.Click();
            return this;
        }
        private void WaitForResult() 
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));// kodo stabilizavimui
            wait.Until(d => LoginMessage.Displayed);// kai reikia palaukti 
        }

        public EshopJuodrastisPage CheckResult()
        {
            WaitForResult();
            
            Assert.IsFalse(LoginMessage.Text.Equals(TextToCheck));
            //Assert.IsTrue(LoginMessage.Text.Equals(TextToCheck));
            //Assert.AreEqual(expectedURL, actualURL);
            return this;
        }
       
    }
}
