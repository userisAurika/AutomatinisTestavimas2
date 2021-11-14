using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2
{
    class NDpvz
    {
        [Test]
        public static void TestTwoPlusTwo()
        {
            int i = 2 + 2;
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            IWebElement inputField1 = chrome.FindElement(By.Id("sum1"));
            inputField1.SendKeys("2");
            IWebElement inputField2 = chrome.FindElement(By.Id("sum2"));
            inputField2.SendKeys("2");
            IWebElement button = chrome.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(i, int.Parse(result.Text), "Nelygu 2");
            //chrome.Quit();
        }
    }
}
