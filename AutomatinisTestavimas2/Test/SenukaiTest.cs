using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Test
{
    public class SenukaiTest : BaseTest
    {
        [Test]
        public void TestSenukaiCookies() 
        {
            _senukaiPage.NavigateToDefaultPage().
                AcceptCookie();
        }
    }
}
