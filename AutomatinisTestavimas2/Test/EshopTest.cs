using AutomatinisTestavimas2.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Test
{   //[TestFixture]//=====>>> ??nesu tikra
    public class EshopTest
    {
        private static EshopPage _page;
        //private static EshopLoginPage _page2;
        //private static EshopMenuPage _page3;


        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new EshopPage(driver);
            //_page2 = new EshopLoginPage(driver);
           // _page3 = new EshopMenuPage(driver);
        }
        [OneTimeTearDown]

        public static void TearDown()
        {
            _page.CloseBrowser();
        }
        /*[Test]
        public void AcceptPrivatepolicytClick()
        {
            _page.PrivatePolicy();
        }*/
        [Test]
        public void ChangeLanguage() 
        {
            _page.PrivatePolicy();
            Console.WriteLine("Testing...");
            _page.ClickLanguageChoose("На русском")
                 .VerifyResult("На русском");
                 //.CklickVidausSviestuvai("Daugiafunkciniai šviestuvai")
                // .VerifyChoiceResult("Daugiafunkciniai šviestuvai");
        }
    }
}


