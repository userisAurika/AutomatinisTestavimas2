﻿using NUnit.Framework;
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
    class PapUzduotisPagalLektore
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.active.com/fitness/calculators/pace?avad=160597_b22851ed9");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
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
            _driver.Quit();
        }

        [Test]
        public static void TestPace()

        {
            //Actions builder = new Actions(_driver);
            //builder.MoveToElement(_driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(6) > div > a")));
            //builder.Build().Perform();
            IWebElement hours = _driver.FindElement(By.Name("time_hours"));
            hours.SendKeys("1");
            IWebElement minutes = _driver.FindElement(By.Name("time_minutes"));
            minutes.SendKeys("5");
            IWebElement distance = _driver.FindElement(By.Name("distance"));
            distance.SendKeys("13");
            _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > span > span.selectboxit-arrow-container")).Click();
            _driver.FindElement(By.XPath("//*[@id='calculator-pace']/form/div[3]/div/span/span/span[2]")).Click();

            _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > span > span > span.selectboxit-arrow-container > i")).Click();
            _driver.FindElement(By.XPath("//*[@id='calculator-pace']/form/div[4]/div/span/span/span[2]")).Click();

            _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(6) > div > a")).Click();
            Assert.IsTrue(_driver.FindElement(By.Name("pace_hours")).GetAttribute("value").Equals("00"), "Hours are wrong");
            Assert.IsTrue(_driver.FindElement(By.Name("pace_minutes")).GetAttribute("value").Equals("05"), "Minutes are wrong");
            Assert.IsTrue(_driver.FindElement(By.Name("pace_seconds")).GetAttribute("value").Equals("00"), "Seconds are wrong");
        }
    }
}
