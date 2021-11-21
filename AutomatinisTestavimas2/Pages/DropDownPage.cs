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
    public class DropDownPage : BasePage
    {
        private const string PageAddress = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
        private const string ResultText = "Day selected :- ";//po bruksniuko yra tarpelis nepamirsti
        private SelectElement DropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private IWebElement ResultTextElement => Driver.FindElement(By.CssSelector(".selected-value"));//pries lyginant gauta reiksme reikia apsirasyti ka lyginsiu
        //Css galiu pakeisti i reiksme prie6 tai padejus taska ir nepalikus tarpu
        private IWebElement FirstSelectedButton => Driver.FindElement(By.Id("printMe"));//kintamieji is didesnio valstiju kiekio pasirinkimo
        private IWebElement GetAllSelectedButton => Driver.FindElement(By.Id("printAll"));
        private SelectElement MultiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));//antra dalis su valstiju pasirinkimais


        public DropDownPage(IWebDriver webdriver) : base(webdriver)//konstruktorius
        {
            Driver.Url = PageAddress;
        }
        public DropDownPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public DropDownPage SelectFromDropdownByText(string text) // apsirasau metoda, geriau nenaudoti teksto, geriau naudoti value rei
        {
            DropDown.SelectByText(text);
            return this;
        }
        public DropDownPage SelectFromDropDownByValue(string text) // apsirasau metoda, taisyklingai su value reiksme
        {
            DropDown.SelectByValue(text);
            return this;
        }
        //-------antra dalis ---valstijos---
        public DropDownPage SelectFromMultiDropDownByValue(string firstValue, string secondValue) //pasirenku reiksmes(valstijos)
        {
            Actions action = new Actions(Driver);//====>>objektas butinai su Driver struktura
            MultiDropDown.SelectByValue(firstValue);//=======>>pirma renkames pirma reiksme
            action.KeyDown(Keys.Control);//========>>spaudziam mygtuka (siuo atveju laikau pasirinkima) action pagalba
            MultiDropDown.SelectByValue(secondValue);
            action.KeyUp(Keys.Control);//==============>>>noriu kad atsispaustu mygtukas
            action.Build().Perform();//=======>>noriu veiksma ivykdyti
            return this;
        }
        public DropDownPage ClickFirstSelectedButton() //pasirinktu valstiju paspaudimas
        {
            FirstSelectedButton.Click();
            return this;
        }
        public DropDownPage ClickAllSelectedButton()
        {
            GetAllSelectedButton.Click();
            return this;
        }

        public DropDownPage SelectFromMultipleDropDownByValue(List<string> listOfStates) //cia reiketu issikviesti kaip masyva tuomet kartu eina foreach
        {
            MultiDropDown.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);//nusiselektinam, uzpausdziam
            foreach(string state in listOfStates) //renkames valstija si valstiju saraso
            {
                foreach (IWebElement option in MultiDropDown.Options) //susirandam elementa
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

        public DropDownPage VerifyResult(string selectedDay) //patikrinu ar pasirinkta diena ta kurios tikejausi(noriu palyginti,)
        {
            Assert.IsTrue(ResultTextElement.Text.Equals(ResultText + selectedDay),$"Result is wrong, not {selectedDay}");
            return this;
        }
        


    }
}
