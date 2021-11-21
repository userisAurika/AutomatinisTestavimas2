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
            Cookie myCookie = new Cookie("CookieConsent",
                "c{stamp:%27ZLLs4oML86bTnexxB9UH1LyvRs9qhIKuX+GYqX47QY1gpGUC/aK6wg==%27%2Cnecessary:true%2Cpreferences:false%2Cstatistics:false%2Cmarketing:false%2Cver:1%2Cutc:1637482379170%2Cregion:%27lt%27}",
                "www.senukai.lt", "/",
                DateTime.Now.AddDays(2));
            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();
            return this;
        
        }
    }
}
