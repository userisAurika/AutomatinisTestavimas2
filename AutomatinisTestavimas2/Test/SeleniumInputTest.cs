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
    public class SeleniumInputTest//butina nurodyti public nes page ir test tarpusavyje bendradarbiaus
    {
        private static IWebDriver _driver; //sioje vietoje jau bus testai [OneTimeSetUp]
        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            IWebElement popUp = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));// laukiam pupup'o
            wait.Until(d => popUp.Displayed);//tiesiog tokia sintakse
            popUp.Click();
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            // _driver.Quit();
        }
        [Test]
        public void TestSeleniumInputFirstBlock() 
        {
            SeleniumInputPage page = new SeleniumInputPage(_driver);// siuod du pusplapius reikia susisieti susikurus konstruktoriu
            string myText = "Labas";// kaip ir page dalyje turejo resultate tam tikra stringa tai susikuriam ji ir cia

            page.InsertText(myText);
            page.ClickShowMesageButton();
            page.CheckResult(myText);

            //testo zingsniai, kuriu pagalba kivieciu kintamaji ir tada testas praeina
            // tarp page ir test galime naviguoti paspaudus control mygtuku
        }
        //------------------------2uzdavinys--
        //
        [TestCase("2", "2", "4", TestName = "2 plius 2 = 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 plius 3 = -2")]
        [TestCase("a", "b", "NaN", TestName = "a plius b = NaN")]
        public void TestSeleniumInputSecondBlock(string firstInput, string secondInput, string result) 
        {
            SeleniumInputPage page = new SeleniumInputPage(_driver);
            //susikuriu testo objekta be jo neatliks zingsniu nurodau draiveri
            page.InsertBothsInput(firstInput, secondInput);
            page.ClickGetTotalButton();
            page.CheckSumResult(result);
        }
    }
}
