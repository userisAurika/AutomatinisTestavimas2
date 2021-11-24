using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2
{
    class papildoma_uzduotis
    {
        //---------------------1 uzduotis--------------
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.active.com/fitness/calculators/pace");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);// waita paliekam stabilumui
            _driver.Manage().Window.Maximize();// isdidinam langa
            _driver.FindElement(By.CssSelector("body > div.optanon-alert-box-wrapper > div.optanon-alert-box-bg > div.optanon-alert-box-button-container > div.optanon-alert-box-button.optanon-button-allow > div > button"));
            IWebElement cookie = _driver.FindElement(By.CssSelector("body > div.optanon-alert-box-wrapper > div.optanon-alert-box-bg > div.optanon-alert-box-button-container > div.optanon-alert-box-button.optanon-button-allow > div > button"));
            Thread.Sleep(5000);
            cookie.Click();
            IWebElement popupX = _driver.FindElement(By.XPath("/html/body/div[11]/div[2]/div[3]"));
            Thread.Sleep(5000);
            popupX.Click();
        }

       [OneTimeTearDown]
        public static void TearDown()
        {
            //_driver.Quit();
        }
        [TestCase("13", "1", "5", "5", TestName = "kilometro greitis yra 5min/km")]
        public static void TestCalculate(string km, string hour, string min)//, string result)
        {
            IWebElement firstInput = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(2) > div > label:nth-child(1) > input[type=number]"));
            firstInput.SendKeys(hour);
            IWebElement secondInput = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(2) > div > label:nth-child(2) > input[type=number]"));
            secondInput.SendKeys(min);
            IWebElement lastInput = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > label > input[type=number]"));
            lastInput.SendKeys(km);
            //_driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > span")).Click();
           // _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > span > span")).Click();
           // _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > span > span")).Click();
            //IWebElement resultFromPage = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > label:nth-child(2) > input[type=number]"));
           // Assert.AreEqual(result, resultFromPage.Text, "Result is NOK");

        }
    }
}
