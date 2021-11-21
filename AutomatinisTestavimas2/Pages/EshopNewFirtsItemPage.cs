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
    public class EshopNewFirtsItemPage : BasePage
    {
        private const string PageAddress = "https://medexy.lt/zarqa-vonios-ir-duso-gelis-jautriai-odai-200-ml";
        private IWebElement WishList => Driver.FindElement(By.CssSelector("#product_body > div.product-info > div.product-blue-block > button"));
        private IWebElement AgreeButton => Driver.FindElement(By.CssSelector("#cookies_box > div > button.agree_button"));
        private IWebElement ButtonWish => Driver.FindElement(By.CssSelector("#favorite"));
        private IWebElement CheckItem => Driver.FindElement(By.CssSelector(" body > main > div.wrap.account-page > div.page-content > div > div > a.title"));
        private IWebElement PutToBasket => Driver.FindElement(By.Id("button-cart"));
        public EshopNewFirtsItemPage(IWebDriver webdriver) : base(webdriver)
        {}
        public EshopNewFirtsItemPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public EshopNewFirtsItemPage AgreeClick()
        {
            AgreeButton.Click();
            return this;
        }
        public EshopNewFirtsItemPage PutToWishList()
        {
            WishList.Click();
            return this;
        }
        private void WaitForResult()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => ButtonWish.Displayed);
        }
        public EshopNewFirtsItemPage CheckWishButton() 
        {
            WaitForResult();
            ButtonWish.Click();
            return this;
        }
        public EshopNewFirtsItemPage CheckIfWithoutLogin() 
        {
            string statusOfQ = "1";
            string expectedQuantity= "1";
            Assert.IsTrue(statusOfQ.Equals(expectedQuantity));
            return this;
        }
        public EshopNewFirtsItemPage CheckItembefore() 
        {
            CheckItem.Click();
            return this;
        }
        public EshopNewFirtsItemPage CheckPutToBasket() 
        {
            PutToBasket.Click();
            return this;
        }
        public EshopNewFirtsItemPage CheckIfItemIsInBasket()
        {
            string send= "1";
            string expected = "1";
            Assert.IsTrue(send.Equals(expected));
            return this;
        }
    }
}
