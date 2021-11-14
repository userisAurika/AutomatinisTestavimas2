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
     public class CheckBoxDemoTest
    {
        private static CheckBoxDemoPage _page;//==> vietoj driverio _page

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new CheckBoxDemoPage(driver);// susiejimas kai keistas driveris, siejasi klases
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            _page.CloseBrowser();
        }

        //[Order(3)]//===> leidzia paleisti viena testa po kito savo nustatyta eiles tvarka, taciau jei luzta vienas luzta visi, nera butinas
        [Test]
        public void TestSingleCheckBox()
        {
            _page.CheckSingleCheckbox()
                .CheckResult();
        }
        //[Order(1)]
        [Test]
        public void TestCheckAllCheckboxes()
        {
            _page.CheckAllCheckboxes()
                .CheckButtonValue("Uncheck All");
        }
        //[Order(2)]
        [Test]
        public void TestUncheckAllCheckboxes()
        {
            _page.CheckAllCheckboxes()
                .ClickButton()
                .VerifyThatAllCheckboxesAreUnchecked();
        }
    }
}
