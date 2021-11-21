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
    public class SebPage: BasePage
    {
        private const string PageAddress = "https://www.seb.lt/privatiems/kreditai-ir-lizingas/kreditai/busto-kreditas-0#1";

        private IWebElement _IncomeInsertField => Driver.FindElement(By.Id("income"));
        private IWebElement _CalculateButton => Driver.FindElement(By.CssSelector("#calculate > span"));
        private IWebElement _Result => Driver.FindElement(By.CssSelector("#mortgageCalculatorStep2 > div.row > div > div:nth-child(5) > div > span > strong"));
        private SelectElement _CityDropdown => new SelectElement(Driver.FindElement(By.Id("city")));
        public SebPage(IWebDriver webdriver) : base(webdriver)
        { }

        public SebPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public SebPage InsertIncome(string income)
        {
            _IncomeInsertField.Clear();
            _IncomeInsertField.SendKeys(income);

            return this;
        }

        public SebPage FocusOnFrame()
        {
            Driver.SwitchTo().Frame(0);
            return this;
        }

        public SebPage SelectCityFromDropDownByValue(string city)
        {
            _CityDropdown.SelectByValue(city);
            return this;
        }
        public SebPage CalculateLoan()
        {
            _CalculateButton.Click();
            return this;
        }

        public SebPage CheckResult(int myWish) //79 105
        {
            string preparedSum = _Result.Text.Replace(" ", "");
            int calculateLoan = Int32.Parse(preparedSum);
            Assert.IsTrue(calculateLoan > myWish, "Nope, paskolos nebus");
            return this;
        }

    }
}
