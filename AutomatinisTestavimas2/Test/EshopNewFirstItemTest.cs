﻿using AutomatinisTestavimas2.Pages;
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
    public class EshopNewFirstItemTest
    {
        private static EshopNewFirtsItemPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new EshopNewFirtsItemPage(driver);
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }
        [Test]
        public void CheckWishList() 
        {
            _page.AgreeClick()
                 .PutToWishList()
                 .CheckWishButton()
                 .CheckIfWithoutLogin()
                 .CheckItembefore()
                 .CheckPutToBasket();
        }
    }
}
