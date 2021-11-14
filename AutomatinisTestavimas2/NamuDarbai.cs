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
    class NamuDarbai
    {
        //------------namu darbai--23 SKAIDRE----2 uzduotis
        //---2021-11-03
        [Test]
        public static void TestSeleniumPage()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            IWebElement InputFieldFirst = chrome.FindElement(By.Id("sum1"));
            string myNumberFirst = "2";
            InputFieldFirst.SendKeys(myNumberFirst);
            Thread.Sleep(5000);
            IWebElement popUp = chrome.FindElement(By.Id("at-cv-lightbox-close"));//kad "uzsnustu popUp'as
            popUp.Click();
            IWebElement InputFieldSecond = chrome.FindElement(By.Id("sum2"));
            string myNumberSecond = "2";
            InputFieldSecond.SendKeys(myNumberSecond);
            IWebElement button = chrome.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("4", result.Text, "2+2 is not equal 4");
            //chrome.Quit();
        }
        [Test]
        public static void TestSeleniumPageNumber()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            Thread.Sleep(5000);
            IWebElement popUp = chrome.FindElement(By.Id("at-cv-lightbox-close"));//kad "uzsnustu popUp'as
            popUp.Click();
            IWebElement InputFieldFirst = chrome.FindElement(By.Id("sum1"));
            string myNumberFirst = "-5";
            InputFieldFirst.SendKeys(myNumberFirst);
            IWebElement InputFieldSecond = chrome.FindElement(By.Id("sum2"));
            string myNumberSecond = "3";
            InputFieldSecond.SendKeys(myNumberSecond);    
            IWebElement button = chrome.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("-2", result.Text, "-5+2 is not equal -2");
            //chrome.Quit();
        }
        [Test]
        public static void TestSeleniumPageLetters()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            Thread.Sleep(5000);
            IWebElement popUp = chrome.FindElement(By.Id("at-cv-lightbox-close"));//kad "uzsnustu popUp'as
            popUp.Click();
            IWebElement InputFieldFirst = chrome.FindElement(By.Id("sum1"));
            string myNumberFirst = "a";
            InputFieldFirst.SendKeys(myNumberFirst);
            IWebElement InputFieldSecond = chrome.FindElement(By.Id("sum2"));
            string myNumberSecond = "b";
            InputFieldSecond.SendKeys(myNumberSecond);
            IWebElement button = chrome.FindElement(By.CssSelector("#gettotal > button"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("NaN", result.Text, "a+b is not equal NaN");
            //chrome.Quit();
        }
    }
}
