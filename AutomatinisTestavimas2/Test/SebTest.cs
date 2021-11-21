using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Test
{
    public class SebTest : BaseTest
    { 
        [Test]
        public void TestLoan() 
        {
                _sebPage.NavigateToDefaultPage()
                .FocusOnFrame()
                .InsertIncome("1000")
                .SelectCityFromDropDownByValue("Klaipeda")
                .CalculateLoan()
                .CheckResult(75000);
        }
    }
}
