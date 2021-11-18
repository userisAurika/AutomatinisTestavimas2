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
   public class EshopMenuPage : BasePage
    {
        private const string PageAddress = "https://medexy.lt/odos-prieziura";
        private IWebElement ConsentButton => Driver.FindElement(By.XPath("//html/body/div[2]/div/button[2]"));
        private IWebElement BathAndShowerGel => Driver.FindElement(By.XPath("/html/body/main/div[1]/div[3]/div[3]/div[1]/a[2]"));
        //html/body/main/div[1]/aside/div/div[2]/div[2]/label[4]/span[2]
        private IWebElement OpenFullList => Driver.FindElement(By.XPath("/html/body/main/div[1]/aside/div/div[2]/button[1]"));
       private IWebElement SelectedCheckbox => Driver.FindElement(By.XPath("//html/body/main/div[1]/aside/div/div[2]/div[2]/label[4]/span[2]"));
        public EshopMenuPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }
        public EshopMenuPage ConcentButton() 
        {
            ConsentButton.Click();
            return this;
        }
        public EshopMenuPage OpenList() 
        {
            OpenFullList.Click();
            return this;
        }
        public EshopMenuPage SkinTipeBox() 
        {
            SelectedCheckbox.Click();
            return this;
        }

        public EshopMenuPage ChooseFirstItem() 
        {
            BathAndShowerGel.Click();
            return this;    
        }
    }
}
