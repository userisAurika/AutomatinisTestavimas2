using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2
{
    class Demo03
    {
        //---------2021-11-05----
        [Test]
        public static void TestChromeDriver()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //IWebElement element = chrome.FindElement(By.Id("id_user_agent"));//nebutinas
            //chrome.Quit();
        }
        [Test]
        public static void TestFirefoxDriver()
        {
            IWebDriver firefox = new FirefoxDriver();
            firefox.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            firefox.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //firefox.Quit();
        }
        //-------------------------------------------------------------------

        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            //_driver.Quit();
        }
        //---------------------------------
        private static IWebDriver _firefox;

        [OneTimeSetUp]
        public static void SetUpas()
        {
            _firefox = new FirefoxDriver();
            _firefox.Navigate().GoToUrl("https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent");
            _firefox.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _firefox.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public static void TearDownas()
        {
            //_driver.Quit();
        }
    }
}
