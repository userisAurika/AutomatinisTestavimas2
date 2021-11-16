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
    public class EshopPage : BasePage
    {
        private const string PageAddress = "https://www.sviestuvai.lt/";
        private const string ResultText = "На русском";
        private const string ChoiceText = "Daugiafunkciniai šviestuvai";
        private IWebElement CookiesApprove => Driver.FindElement(By.CssSelector("body > div.cms_cookies.visible > div > div"));
        private SelectElement ChooseLanguage
        {
            get
            {
                IWebElement el = Driver.FindElement(By.CssSelector("form#language > li:nth-child(2) > a"));
                el.Click();
                //IWebElement e = Driver.FindElement(By.Id("language"));
                return new SelectElement(el);
            }
        }

        private IWebElement ResultTextElement => Driver.FindElement(By.XPath("/html/body/header[2]/div/div/div[2]/ul/li[5]/text()"));
        private SelectElement  ButtonVidausSviestuvai => new SelectElement(Driver.FindElement(By.CssSelector("body > nav > div > div > ul > li:nth-child(2) > a")));
        private IWebElement ResultTextelement => Driver.FindElement(By.CssSelector("body > nav > div > div > ul > li:nth-child(2) > ul > li:nth-child(3)"));
        public EshopPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }
        
        public EshopPage PrivatePolicy() 
        {
            CookiesApprove.Click();
            return this;
        }
        public EshopPage ClickLanguageChoose(string text)
        {
            ChooseLanguage.SelectByText(text);
            return this;
        }
        public EshopPage VerifyResult(string selectedLanguage) //patikrinu ar pasirinkta diena ta kurios tikejausi(noriu palyginti,)
        {
            Assert.IsTrue(ResultTextElement.Text.Equals(ResultText + selectedLanguage), $"Result is wrong, not {selectedLanguage}");
            return this;
        }/*
        public EshopPage CklickVidausSviestuvai(string text) 
        {
            ButtonVidausSviestuvai.SelectByText(text);
            return this;
        }
        public EshopPage VerifyChoiceResult(string selectedLine) //patikrinu ar pasirinkta diena ta kurios tikejausi(noriu palyginti,)
        {
           // Assert.IsTrue(ResultTextelement.Text.Contains(selectedLine), $"Result is not the same, expected {ResultTextelement}, but was{_resultBox.Text}");
            //return this;
            Assert.IsTrue(ResultTextelement.Text.Equals(ChoiceText + selectedLine), $"Result is wrong, not {selectedLine}");
            return this;
            // Assert.IsTrue(!element.Selected, "Checkbox is still checked");
            //Assert.That(!element.Selected, "Checkbox is still checked");
        }
        */
    }
}
