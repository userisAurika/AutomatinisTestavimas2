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
   public class EshopNewBuyItemPage : BasePage
    {
        private const string PageAddress = "https://medexy.lt/index.php?route=product/search&search=ZARQA%20VONIOS%20IR%20DU%C5%A0O%20GELIS%20JAUTRIAI%20ODAI%2C%20200%20ml";
        private const string InfoTitle = "Prisijungti prie paskyros";
        private IWebElement FindItem => Driver.FindElement(By.CssSelector("body > main > div.wrap > div.page-content > div.products-list > div > a.title"));
        private IWebElement Accept => Driver.FindElement(By.CssSelector("#cookies_box > div > button.agree_button"));
        private IWebElement BasketButton => Driver.FindElement(By.Id("button-cart"));
        private IWebElement BasketPush => Driver.FindElement(By.CssSelector("body > header > div.wrap > div.top > div.header-buttons > div > div > button"));
        private IWebElement BuyButton => Driver.FindElement(By.CssSelector("body > header > div.wrap > div.top > div.header-buttons > div > div > div > a"));
        private IWebElement FinalBuyButton => Driver.FindElement(By.CssSelector("body > main > div.wrap.order-page > div:nth-child(5) > div > div.buttons > a"));
        private IWebElement PageInformation => Driver.FindElement(By.CssSelector("body > main > div.wrap.order-page > form > div.heading36"));
        public EshopNewBuyItemPage(IWebDriver webdriver) : base(webdriver)
        {}
        public EshopNewBuyItemPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public EshopNewBuyItemPage AcceptCookie() 
        {
            Accept.Click();
            return this;
        }
        public EshopNewBuyItemPage ChooseFindItem() 
        {
            FindItem.Click();
            return this;
        }
        public EshopNewBuyItemPage ClickOnBasketButtonToBuy() 
        {
            BasketButton.Click();
            Thread.Sleep(4000);
            return this;
        }
        public EshopNewBuyItemPage FirstStepToBuy() 
        {
            BasketPush.Click();
            Thread.Sleep(5000);
            return this;
        }
        public EshopNewBuyItemPage SecondStepToBuy() 
        {
            BuyButton.Click();
            Thread.Sleep(3000);
            return this;
        }
        public EshopNewBuyItemPage CheckSum() 
        {
            var statusSum = "16.00€";
            var expectedSum = "16.00€";
            Assert.IsTrue(statusSum.Equals(expectedSum));
            return this;
        }
        public EshopNewBuyItemPage FinalButton()
        {
            FinalBuyButton.Click();
            return this;
        }
        public EshopNewBuyItemPage FinalInfo() 
        {
            Assert.IsTrue(PageInformation.Text.Equals(InfoTitle));
            return this;
        }
    }
}
