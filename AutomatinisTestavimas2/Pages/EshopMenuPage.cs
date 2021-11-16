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
   public class EshopMenuPage : BasePage
    {
        private const string PageAddress = "https://www.dermabalt.lt/";
        /*private const string ResultText = "Šampūnai";
        private IWebElement _shopButton => Driver.FindElement(By.CssSelector("li:nth-child(1) > details-disclosure > details > .header__menu-item path"));
        private IWebElement _listMenutButton => Driver.FindElement(By.CssSelector(".header__menu-item > .icon:nth-child(1)"));

        private SelectElement _menuDropDown => new SelectElement(Driver.FindElement(By.CssSelector("#shopify-section-header > sticky-header > header > nav > ul > li:nth-child(1) > details-disclosure > details > ul > li:nth-child(2) > details > ul > li:nth-child(1) > a")));
        private IWebElement _productFormButton => Driver.FindElement(By.CssSelector("#product-form-template--15194966818984__main > div > button > span"));
        private IWebElement _resultTextElement => Driver.FindElement(By.LinkText("Šampūnai"));
        private IWebElement _continueButton => Driver.FindElement(By.CssSelector(".link.button-label"));
       */

        public EshopMenuPage(IWebDriver webdriver) : base(webdriver)//konstruktorius
        {
            Driver.Url = PageAddress;
        }
        /*public EshopLoginPage ShopButton()
        {
            _shopButton.Click();
            return this;
        }
        public EshopLoginPage MenuList()
        {
            _listMenutButton.Click();
            return this;
        }
   
        */
    }
}
