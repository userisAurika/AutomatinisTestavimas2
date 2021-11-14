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
    public class CheckBoxDemoPage : BasePage //paveldi tam tikra struktura is kitos klases pvz: private static IWebDriver _driver ir nezymim, jie iskelti i bacepage;
    {
        //private static IWebDriver _driver istryne keiciam _driver i Driver( toks aprasytas basepage), desiniu peles klavisu pasirinkti spausti rename ir pervadinti

        private const string PageAddress = "https://demo.seleniumeasy.com/basic-checkbox-demo.html";// privati konstanta 
        private const string TextToCheck = "Success - Check box is checked";
        //virusje privacios konstantos kurios leidzia isventi kazkokio hardkodinimo rasant ne reiksme, prisidengti ja kaip reiksme

        private IWebElement _singleCheckbox => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _Text => Driver.FindElement(By.Id("txtAge"));
        private IReadOnlyCollection<IWebElement> MultipleCheckboxList => Driver.FindElements(By.CssSelector(".cb1-element"));
        private IWebElement _Button => Driver.FindElement(By.Id("check1"));

        public CheckBoxDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;// cia vietoj adreso rasau konstanta, ir esant pasikeitimams adrese nereiketu ieskoti kode kur taisyti
        }
        public CheckBoxDemoPage CheckSingleCheckbox()
        {
            if (!_singleCheckbox.Selected)// patikrinu ar mano pirmas checkboxas nepazymetas, jei viskas gerai klikinu
                _singleCheckbox.Click();
            return this;
        }

        public CheckBoxDemoPage CheckResult()
        {
            Assert.IsTrue(_Text.Text.Equals(TextToCheck));// cia taip pat dedam konstanta kad nerasyti konkretaus teksto ir butu lengva ji pakeisti
            return this;
        }


        private void UncheckFirstBlockCheckbox()
        {
            if (_singleCheckbox.Selected)
                _singleCheckbox.Click();
        }

        public CheckBoxDemoPage CheckAllCheckboxes()
        {
            UncheckFirstBlockCheckbox();
            foreach (IWebElement element in MultipleCheckboxList)
            {
                if (!element.Selected)
                    element.Click();
            }
            return this;
        }

        public CheckBoxDemoPage CheckButtonValue(string value)
        {
           //GetWait().Until(ExpectedConditions.TextToBePresentInElement(_Button, "Uncheck All"));// mano C# neveikia
            //DefaultWait.Until(ExpectedConditions.TextToBePresentInElementValue(_Button, "Uncheck All"));// su situ metodu turetu testas suktis greiciau
           //Assert.IsTrue(_Button.GetAttribute("value").Equals(value), "Second is wrong");
            return this;
        }

        public CheckBoxDemoPage ClickButton()
        {
            _Button.Click();
            return this;
        }

        public CheckBoxDemoPage VerifyThatAllCheckboxesAreUnchecked()
        {
            foreach (IWebElement element in MultipleCheckboxList)
            {
                Assert.False(element.Selected, "Checkbox is still checked");//tikrinu ar visi checkboxai yra atzymeti

                //Assert.IsTrue(!element.Selected, "Checkbox is still checked");
                //Assert.That(!element.Selected, "Checkbox is still checked");
            }
            return this;
        }
    }
}
