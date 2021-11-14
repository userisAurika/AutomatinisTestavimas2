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
    public class NDDropDownTest
    {
        private static NDDropDownPage _page;//aprasom dropdown page

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new NDDropDownPage(driver);
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            _page.CloseBrowser();
        }
        /*[Test]
        public void TestMultiDropDown()//pirmos pasirinktos valstijos paieska
        {
            _page.SelectFromMultiDropDownByValue("Ohio", "Florida")
                .ClickFirstSelectedButton();
        }*/

        [TestCase("New York", "Ohio", TestName = "Pasirenkame 2 reiksmes ir patikriname pirma pasirinkima")]
        [TestCase("Washington", "New York", "New Jersey", TestName = "Pasirenkame 3 reiksmes ir patikriname pirma pasirinkima")]
        public void TestMultipleDropdownGetOne(params string[] selectedElement) //imam kaip masyva string tipo reiksme skliaustuose
        {
            _page.SelectFromMultipleDropDownByValue(selectedElement.ToList())
                .CheckFirstState(selectedElement[0]);
        }
        [TestCase("New Jersey", "California", TestName = "Pasirenkame 2 reiksmes ir patikriname visus pasirinkimus")]
        [TestCase("Washington", "Ohio", "Texas", "Florida", TestName = "Pasirenkame 4 reiksmes ir patikriname visus pasirinkimus")]
        public void TestMultipleDropdownGetAll(params string[] selectedElement)
        {
            _page.SelectFromMultipleDropDownByValueCheck(selectedElement.ToList())
                .ClickAllSelectedButton();
        }
    }
}

