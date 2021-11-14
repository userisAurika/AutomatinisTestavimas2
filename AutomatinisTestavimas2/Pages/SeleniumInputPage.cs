using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Pages
{
    public class SeleniumInputPage
    {
        private static IWebDriver _driver;

        private IWebElement _inputField => _driver.FindElement(By.Id("user-message"));// visada private ir visada globalus kintamasis su underskoru
        private IWebElement _button => _driver.FindElement(By.CssSelector("#get-input > button"));//=> priskiriam reiksme kintamajam tuomet kai kviesim metoda prima karta
        private IWebElement _result => _driver.FindElement(By.Id("display"));//=> liamda 
        private IWebElement _firstInput => _driver.FindElement(By.Id("sum1"));
        private IWebElement _secondInput => _driver.FindElement(By.Id("sum2"));
        private IWebElement _getTotalButton => _driver.FindElement(By.CssSelector("#gettotal > button"));// button kitamasis is sumos kodo
        private IWebElement _resultFromPage  => _driver.FindElement(By.Id("displayvalue"));
        public SeleniumInputPage(IWebDriver webdriver)
        {
            _driver = webdriver;// kontruktorius paduosim kintamaji su webdriver ir tures reiksme kuria paduosim i testa
        }

        //susikuriu metoda kuris pades dirbti su vrsuje esanciais elementais


        public void InsertText(string text) //----------->priims string tipa ir dirbs su inputField elementu(privatus
        {
            _inputField.Clear();
            _inputField.SendKeys(text);

            //issivalau eilute
            // su sendkeys metodu irasau tekstine zinute
            //sita metoda kviesime is Test klases
        }
        public void ClickShowMesageButton()//--------------->kvieciam mygtuka paspaudimui
        {
            _button.Click();
        }
        public void CheckResult(string expectedResult) 
        {
            Assert.AreEqual(expectedResult, _result.Text, "Tekstas neatsirado");//result yra globalus kintamasis underskora uzdeti reikia
        }
        //---------------------------2uzduotis-------metodai---
        public void InsertFirstInput(string text) 
        {
            _firstInput.Clear();
            _firstInput.SendKeys(text);
        }
        public void InsertSecondInput(string text)
        {
            _secondInput.Clear();
            _secondInput.SendKeys(text);
        }
        public void InsertBothsInput(string first, string second) 
        {
            InsertFirstInput(first);
            InsertSecondInput(second);

            //siuo atveju as sukeliu auksciau esancius metodus ir issikviesti tik si, tuomet esancius virsuje galiu padaryti private
            //virsuje esantys metodai slepiasi sio metodo viduje
        }
        public void ClickGetTotalButton() 
        {
            _getTotalButton.Click();
        }
        public void CheckSumResult(string expectedResultSum) 
        {
            Assert.AreEqual(expectedResultSum, _resultFromPage.Text, "Result is NOK");
        }
    }
}

