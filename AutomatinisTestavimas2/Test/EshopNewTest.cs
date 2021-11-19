using AutomatinisTestavimas2.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Test
{
    public class EshopNewTest
    {
        private static EshopNewPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new EshopNewPage(driver);
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }
        [Test]
        public void VerifyValidLogin()
        {
            string myMail = "aurikaa@gmail.com";
            string myPassword = "Testavicius321";
            _page.ClickAccountButton()
                 .ClickPrivatePolicy()
                 .InputEmailText(myMail)
                 .InputPasswordText(myPassword)
                 .ClickButton()
                 .CheckIfLoginWasSuccessful()
                 .ClickLogOut()
                 .Out();
        }
        [Test]
        public void VerifyInvalidLogin()
        {
            string myText = "test@321";
            _page.ClickAccountButton()
                  .ClickPrivatePolicy()
                  .InputEmailText(myText)
                  .InputPasswordText(myText)
                  .ClickButton()
                  .CheckIfLoginFailed();
        }
        [Test]
        public void OpenNewbutton()
        {
            _page.ClickSinCare();
        }
        [Test]
        public void SearchField() 
        {
            string myItem = "ZARQA VONIOS IR DUŠO GELIS JAUTRIAI ODAI, 200 ml";
               _page.CheckSearchField(myItem);
                
        }
    }
}
