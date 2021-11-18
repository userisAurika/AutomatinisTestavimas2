﻿using NUnit.Framework;
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
   public class EshopNewPage : BasePage
    {
        private const string PageAddress = "https://medexy.lt/";
        private const string TextToCheck = "Įspėjimas: El. paštas ir/arba slaptažodis nerasti sistemoje.";
        private const string TextToCheckValue = "Mano paskyra";
         
        //alert alert-danger alert-dismissible
        private IWebElement AccountButton => Driver.FindElement(By.CssSelector("button > span:nth-child(1)"));
        private IWebElement UserEmailInput => Driver.FindElement(By.Name("email"));
        private IWebElement UserPasswordInput => Driver.FindElement(By.Name("password"));
        private IWebElement PrivatePolicyButton => Driver.FindElement(By.CssSelector(".agree_button"));
        private IWebElement LoginButton => Driver.FindElement(By.CssSelector(".button"));
        //private IWebElement LoginMessage => Driver.FindElement(By.XPath("//html/body/main/div[1]/div[3]"));// deti du // xpath jei rasau ispejimo elementai
        private IWebElement MyLogin => Driver.FindElement(By.XPath("//html/body/main/div[1]/div[1]/h1"));
        private IWebElement LoginMessage => Driver.FindElement(By.XPath("//html/body/main/div[1]/div[3]"));
        private IWebElement SkinCare => Driver.FindElement(By.CssSelector("#menu > ul > li:nth-child(2) > a"));

        public EshopNewPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
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
        private void WaitForResult() 
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => LoginMessage.Displayed); 
        }

        public EshopNewPage CheckIfLoginFailed()
        {
            //WaitForResult();
            Thread.Sleep(1000 * 2);
            //Assert.IsFalse(LoginMessage.Text.Equals(TextToCheck));
            var statusMsg = LoginMessage.Text;
            //var expectedAlertValue = "Įspėjimas: Jūs viršijote leistiną bandymų prisijungti kiekį. Prašome pamėginti dar kartą už 1 valandos.";
            var expectedAlertValue = "Įspėjimas: El. paštas ir/arba slaptažodis nerasti sistemoje.";
            Assert.IsTrue(statusMsg.Equals(expectedAlertValue));
            
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

    }
}
