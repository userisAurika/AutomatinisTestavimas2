using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Pages
{
    public class NDDropDownPage : BasePage
    {
        private const string PageAddress = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
        private IWebElement FirstSelectedButton => Driver.FindElement(By.Id("printMe"));//kintamieji is didesnio valstiju kiekio pasirinkimo
        private IWebElement GetAllSelectedButton => Driver.FindElement(By.Id("printAll"));
        private SelectElement MultiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));//antra dalis su valstiju pasirinkimais
        private IWebElement ResultTextOptionsSelectedAreElement => Driver.FindElement(By.CssSelector(".getall-selected"));//Class reiksme su tasku be tarpu
        public NDDropDownPage(IWebDriver webdriver) : base(webdriver)//konstruktorius
        {
            Driver.Url = PageAddress;
        }
        public NDDropDownPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        /*public NDDropDownPage SelectFromMultiDropDownByValue(string firstValue, string secondValue) //pasirenku reiksmes(valstijos)
        {
            Actions action = new Actions(Driver);
            MultiDropDown.SelectByValue(firstValue);
            action.KeyDown(Keys.Control);
            MultiDropDown.SelectByValue(secondValue);
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            return this;
        }*/
        public NDDropDownPage ClickFirstSelectedButton() //pasirinktu valstiju paspaudimas
        {
            FirstSelectedButton.Click();
            return this;
        }
        public NDDropDownPage ClickAllSelectedButton()
        {
            GetAllSelectedButton.Click();
            return this;
        }
        public NDDropDownPage SelectFromMultipleDropDownByValue(List<string> listOfStates)
        {
            MultiDropDown.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);
            foreach (string state in listOfStates)
            {
                foreach (IWebElement option in MultiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        action.Click(option);
                        break;
                    }
                }
            }
            action.KeyUp(Keys.LeftControl);
            action.Build().Perform();
            action.Click(FirstSelectedButton);
            action.Build().Perform();
            return this;
        }

        public NDDropDownPage CheckListedStates(List<string> selectedElements)
        {
            string result = ResultTextOptionsSelectedAreElement.Text;
            foreach (string selectedElement in selectedElements)//ieskau vieno elemento is saraso
            {
                Assert.True(result.Contains(selectedElement),
                    $"galimas {selectedElement}, gautas {result}");
            }
            return this;
        }
        public NDDropDownPage CheckFirstState(string selectedElement)
        {
            string result = ResultTextOptionsSelectedAreElement.Text;//tikrinu pasirinkta elementa
            Assert.True(result.Contains(selectedElement),
                $"{selectedElement} is uncheck. {result}");
            return this;
        }

        public NDDropDownPage SelectFromMultipleDropDownByValueCheck(List<string> listOfStates)
        {
            MultiDropDown.DeselectAll();
            foreach (IWebElement option in MultiDropDown.Options)
                if (listOfStates.Contains(option.GetAttribute("value")))
                {
                    ClickMultipleBox(option);
                }
            return this;
        }
        private void ClickMultipleBox(IWebElement element)
        {
            Actions actions = new Actions(Driver);
            actions.KeyDown(Keys.Control);
            actions.Click(element);
            actions.KeyUp(Keys.Control);
            actions.Build().Perform();
        }

    }
}