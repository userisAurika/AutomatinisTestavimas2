using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Pages
{
   public class EshopSecondStepPage : BasePage
    {
        private const string PageAddress = "https://www.dermabalt.lt/";


        public EshopSecondStepPage(IWebDriver webdriver) : base(webdriver)//konstruktorius
        {
            Driver.Url = PageAddress;
        }
    }
}
