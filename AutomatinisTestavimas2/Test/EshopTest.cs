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
{   [TestFixture]//=====>>> ??nesu tikra
    public class EshopTest
    {
        private static EshopPage _page;
        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);// testo stabilimui
            driver.Manage().Window.Maximize();
            _page = new EshopPage(driver);
        }
        [OneTimeTearDown]

        public static void TearDown()
        {
            _page.CloseBrowser();
        }
        /*[Test]
        public void BunnerAcceptAndAccountClick() //gal nereikia
        {
            _page.PrivatePolicy()
                .ClickAccountButton();
        }*/
        [Test]
        public void VerifyInvalidLogin() 
        {
            string myText = "test";
            _page.PrivatePolicy()
                .ClickAccountButton()
                .InputEmailText(myText)
                .InputPasswordText(myText)
                .ClickButton()
                .CheckResult();
        }
        [Test]
        public void VerifyValidLogin() 
        {
            string myMail = "aurikaa@gmail.com";
            string myPassword = "test321";
            _page.PrivatePolicy()
               .ClickAccountButton()
                .InputEmailText(myMail)
                .InputPasswordText(myPassword)
                .ClickButton()
                .CheckResult();

        }

    }
}
