using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Pages
{
    public class EshopNewLogOutPage : BasePage
    {
        private const string PageAddress = "https://medexy.lt/paskyra";
        private IWebElement LoginButton => Driver.FindElement(By.CssSelector("button > span:nth-child(1)"));
        private IWebElement LogOutButton => Driver.FindElement(By.LinkText("Atsijungti"));
        public EshopNewLogOutPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }
        public EshopNewLogOutPage ClickButton()
        {
            LoginButton.Click();
            return this;
        }
        public EshopNewLogOutPage ClickLogOut()
        {
            LogOutButton.Click();
            return this;
        }

    }
}
