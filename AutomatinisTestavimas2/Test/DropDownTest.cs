using AutomatinisTestavimas2.Driver;
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
    public class DropDownTest : BaseTest
    {
        [Test]
        public void TestDropDown() 
        {
            _dropDownPage.NavigateToDefaultPage()
                .SelectFromDropDownByValue("Friday")
                .VerifyResult("Friday");
        }
        [Test]
        public void TestMultiDropDown()//valstiju paieska
        {
            _dropDownPage.NavigateToDefaultPage()
                .SelectFromMultiDropDownByValue("Ohio", "Florida")
                .ClickFirstSelectedButton();
                
        }
    }
    
}
