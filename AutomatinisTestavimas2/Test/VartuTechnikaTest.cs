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
    public class VartuTechnikaTest : BaseTest
    {
        [TestCase("2000", "2000", true, false, "665.98€", TestName = "2000 x 2000 + Vartų automatika = 665.98€")]
        [TestCase("4000", "2000", true, true, "1006.43€", TestName = "4000 + 2000 + Vartu automatika + Vartu montavimo darbai = 1006.43€")]
        [TestCase("4000", "2000", false, false, "692.35€", TestName = "4000 + 2000 = 692.35€")]
        [TestCase("5000", "2000", false, true, "989.21€", TestName = "5000 + 2000 + Vartu montavimo darbai = 989.21€")]
        public void TestVartuTechnika(string width, string height, bool automatika, bool montavimoDarbai, string result) //tokiu budu parinks reiksmes is testcase
        {

           _vartuTechnikaPage.NavigateToDefaultPage ()
            .InsertWidthAndHeight(width, height)
            .CheckAutomatikaCheckbox(automatika)//testcase bus true arba false, tad rasyti siu reiksmiu nebereikia
            .CheckAutomatikaCheckbox(montavimoDarbai)
            .ClickCalculateButton()
            .CheckResult(result);
            //surasyti skaitmenys harkodina testa, reikia keisti struktura
            // pakeitus Void i VartuTechnikaPage nebereikia kaskart rasyti zodzio page, ir nebedeti kabliataskiu
            // tokiu buu mums nereikia sakyti ei i vartutechnika page pasiimk metoda, nes nukreipia iskart

        }
    }
}
