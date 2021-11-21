using AutomatinisTestavimas2.Driver;
using AutomatinisTestavimas2.Pages;
using AutomatinisTestavimas2.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static DropDownPage _dropDownPage;
        public static VartuTechnikaPage _vartuTechnikaPage;
        public static NDDropDownPage _ndDrobDownPage;
        public static SenukaiPage _senukaiPage;
        public static SebPage _sebPage;
        public static AlertPage _alertPage;

        public static EshopNewPage _eshopNewPage;
        public static EshopNewFirtsItemPage _eshopNewFirtsItemPage;
        public static EshopNewBuyItemPage _eshopNewBuyItemPage;

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomeDriver.GetChromeDriver();
            //driver = CustomeDriver.GetIncognitoChrome();
            _dropDownPage = new DropDownPage(driver);
            _vartuTechnikaPage = new VartuTechnikaPage(driver);
            _ndDrobDownPage = new NDDropDownPage(driver);
            _senukaiPage = new SenukaiPage(driver);
            _sebPage = new SebPage(driver);
            _alertPage = new AlertPage(driver);

            _eshopNewPage = new EshopNewPage(driver);
            _eshopNewFirtsItemPage = new EshopNewFirtsItemPage(driver);
            _eshopNewBuyItemPage = new EshopNewBuyItemPage(driver);



    }
    [TearDown]
        public static void TakeScreenshot() 
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreenshot(driver);
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            driver.Quit();
        }
    }
}
