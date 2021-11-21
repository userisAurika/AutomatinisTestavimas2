using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Pages
{
    public class VartuTechnikaPage : BasePage
    {
        private const string PageAddress= "http://vartutechnika.lt/";

        private IWebElement _widthInput => Driver.FindElement(By.Id("doors_width"));
        private IWebElement _heightInput => Driver.FindElement(By.Id("doors_height"));
        private IWebElement _autoCheckBox => Driver.FindElement(By.Id("automatika"));
        private IWebElement _montavimoCheckBox => Driver.FindElement(By.Id("darbai"));
        private IWebElement _calculateButton => Driver.FindElement(By.Id("calc_submit"));
        private IWebElement _resultBox => Driver.FindElement(By.CssSelector("#calc_result > div"));

        public VartuTechnikaPage(IWebDriver webdriver): base(webdriver)// konstruktorius, panaikinamas nes paveldesiu is base klases
        {
            Driver.Url = PageAddress;
        }
        public VartuTechnikaPage NavigateToDefaultPage() 
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        /*metodai aprasyti nieko negrazina, atlieka kazkokius zingsnius ir nieko daugiau
         * galima apsirasyti kad visada kazka grazintu
         * pavadinkim metoda kuris garzins vartu technika puslapi
         * vietoj void rasome => VartuTechnikaPage, prirasant return this;
         */
        public VartuTechnikaPage InsertWidth(string width)
        {
            _widthInput.Clear();
            _widthInput.SendKeys(width);
            return this;// ----------> visada prirasom tokia sintakse
        }
        public VartuTechnikaPage InsertHeight(string height)
        {
            _heightInput.Clear();
            _heightInput.SendKeys(height);
            return this;
        }
        public VartuTechnikaPage InsertWidthAndHeight(string widht, string height)
        {
            InsertWidth(widht);
            InsertHeight(height);
            return this;
        }
        //jei paduosime true checkbox bus pazymetas jei false, tai nepazymetas
        public VartuTechnikaPage CheckAutomatikaCheckbox(bool shouldBeChecked) 
        {
            if (shouldBeChecked != _autoCheckBox.Selected)
                _autoCheckBox.Click();
            return this;
        }
        public VartuTechnikaPage CheckMontavimoCheckbox(bool shouldBeChecked)
        {
            if (shouldBeChecked != _montavimoCheckBox.Selected)
                _autoCheckBox.Click();
            return this;
        }
        public VartuTechnikaPage ClickCalculateButton() 
        {
            _calculateButton.Click();
            return this;
        }
        private void WaitForResult() // prie privataus nesiraso => VartuTechnikaPage, prirasant return this;
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));// kodo stabilizavimui
            wait.Until(d => _resultBox.Displayed);// kai reikia palaukti 
        }
        public VartuTechnikaPage CheckResult (string expectedResult) 
        {
            WaitForResult();//kad palauktu
            Assert.IsTrue(_resultBox.Text.Contains(expectedResult), $"Result is not the same, expected {expectedResult}, but was{_resultBox.Text}");
            return this;
            //-------kintamasis su underskoru------rezultatas kurio tikimes---

        }
    }
}
