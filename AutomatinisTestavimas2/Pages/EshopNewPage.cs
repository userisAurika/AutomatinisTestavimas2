using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Pages
{
   public class EshopNewPage : BasePage
    {
        private const string PageAddress = "https://medexy.lt/";
        private IWebElement AccountButton => Driver.FindElement(By.CssSelector("button > span:nth-child(1)"));
        private IWebElement UserEmailInput => Driver.FindElement(By.Name("email"));
        private IWebElement UserPasswordInput => Driver.FindElement(By.Name("password"));
        private IWebElement PrivatePolicyButton => Driver.FindElement(By.CssSelector(".agree_button"));
        private IWebElement LoginButton => Driver.FindElement(By.CssSelector(".button"));
        //private IWebElement LoginMessage => Driver.FindElement(By.XPath("//html/body/main/div[1]/div[3]"));// deti du // xpath jei rasau ispejimo elementai
        private IWebElement MyLogin => Driver.FindElement(By.XPath("//html/body/main/div[1]/div[1]/h1"));
        private IWebElement LoginMessage => Driver.FindElement(By.XPath("//html/body/main/div[1]/div[3]"));
        private IWebElement SkinCare => Driver.FindElement(By.CssSelector("#menu > ul > li:nth-child(2) > a"));
        private IWebElement SearchFieldButton => Driver.FindElement(By.CssSelector("#search > form > input[type=text]:nth-child(1)"));
        private IWebElement Search => Driver.FindElement(By.CssSelector("#search > form > input[type=submit]:nth-child(2)"));
        private IWebElement AgreeCookie => Driver.FindElement(By.CssSelector("#cookies_box > div > button.agree_button"));

        private IWebElement LogOutFirst => Driver.FindElement(By.CssSelector("body > header > div.wrap > div.top > div.header-buttons > div > div.account-button.red > button"));
        private IWebElement LogOut => Driver.FindElement(By.CssSelector("body > header > div.wrap > div.top > div.header-buttons > div > div.account-button.red > div > a"));

        public EshopNewPage(IWebDriver webdriver) : base(webdriver)
        {}
        public EshopNewPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public EshopNewPage ClickAccountButton()
        {
            AccountButton.Click();
            return this;
        }
        public EshopNewPage ClickPrivatePolicy()
        {
            PrivatePolicyButton.Click();
            return this;
        }
        public EshopNewPage InputEmailText(string text)
        {
            UserEmailInput.Clear();
            UserEmailInput.SendKeys(text);
            return this;
        }
        public EshopNewPage InputPasswordText(string text)
        {
            UserPasswordInput.Clear();
            UserPasswordInput.SendKeys(text);
            return this;
        }

        public EshopNewPage ClickButton()
        {
            LoginButton.Click();
            return this;
        }

        public EshopNewPage CheckIfLoginFailed()
        {
            Thread.Sleep(2000 );
            string statusMsg = LoginMessage.Text;
            //string expectedAlertValue = "Įspėjimas: Jūs viršijote leistiną bandymų prisijungti kiekį. Prašome pamėginti dar kartą už 1 valandos.";
            string expectedAlertValue = "Įspėjimas: El. paštas ir/arba slaptažodis nerasti sistemoje.";
            Assert.IsTrue(statusMsg.Equals(expectedAlertValue));   
            return this;
        }
        public EshopNewPage ClickLogOut() 
        {
            LogOutFirst.Click();
            return this;
        }
        public EshopNewPage Out() 
        {
            LogOut.Click();
            return this;
        }

        public EshopNewPage CheckIfLoginWasSuccessful() 
        {
            Thread.Sleep(2000);
            var statusMyL = MyLogin.Text;
            var expectedAlertValueR = "Mano paskyra";
            Assert.IsTrue(statusMyL.Equals(expectedAlertValueR));
            return this;
        }
        public EshopNewPage ClickSinCare()
        {
            SkinCare.Click();
            return this;
        }
        public EshopNewPage CheckSearchField(string text) 
        {
            Actions action = new Actions(Driver);
            action.Click(AgreeCookie).Perform();
            Thread.Sleep(4000);
            SearchFieldButton.Click();
            //action.MoveToElement(SearchFieldButton).Perform();
            SearchFieldButton.SendKeys(text);
            Search.Click();
            //action.Click(Search).Perform();
            return this;
        }

    }
}
