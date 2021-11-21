using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Pages
{
    public class SenukaiPage : BasePage
    {
        private const string PageAddress = "https://www.senukai.lt/";

        public SenukaiPage(IWebDriver webdriver) : base(webdriver)//konstruktorius
        { }
        public SenukaiPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public SenukaiPage AcceptCookie() 
        {
            Cookie myCookie = new Cookie("CookieConsent","c");
            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();
            return this;
        
        }
    }
}
