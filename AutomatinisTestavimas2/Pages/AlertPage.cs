using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Pages
{
    public class AlertPage : BasePage
    {
        private const string PageAddress = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";
        private IWebElement AlertButton => Driver.FindElement(By.XPath("//button[@onclick='myAlertFunction()']"));
        private IWebElement ConfirmationAlertButton => Driver.FindElement(By.XPath("//button[@onclick='myConfirmFunction()']"));
        private IWebElement PromptAlertButton => Driver.FindElement(By.XPath("//button[@onclick='myPromptFunction()']"));


        public AlertPage(IWebDriver webdriver) : base(webdriver)
        { }

        public AlertPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public AlertPage ClickAlertButton()
        {
            AlertButton.Click();
            return this;
        }

        public AlertPage AcceptAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
            return this;
        }
        public AlertPage ClickConfirmationAlertButton()
        {
            ConfirmationAlertButton.Click();
            return this;
        }

        public AlertPage DismissConfirmationAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Dismiss();
            return this;
        }
        public AlertPage ClickPromptAlertButton()
        {
            PromptAlertButton.Click();
            return this;
        }
        public AlertPage InsertTextAndAcceptPromptAlert(string text)
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.SendKeys(text);
            alert.Accept();
            return this;
        }
    }
}
