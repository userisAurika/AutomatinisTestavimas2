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
{   
    public class EshopTest
    {
        private static EshopPage _page;


        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new EshopPage(driver);
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
            //Console.WriteLine("Testing...");
            _page.ClickLanguageChoose("На русском")
                 .VerifyResult("На русском");
                 //.CklickVidausSviestuvai("Daugiafunkciniai šviestuvai")
                // .VerifyChoiceResult("Daugiafunkciniai šviestuvai");
        }
    }
}


