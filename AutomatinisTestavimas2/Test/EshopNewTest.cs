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
    public class EshopNewTest : BaseTest
    {
        [Test]
        public void VerifyValidLogin()
        {
            string myMail = "aurikaa@gmail.com";
            string myPassword = "Testavicius321";
            _eshopNewPage.NavigateToDefaultPage()
                 .ClickAccountButton()
                 .ClickPrivatePolicy()
                 .InputEmailText(myMail)
                 .InputPasswordText(myPassword)
                 .ClickButton()
                 .CheckIfLoginWasSuccessful()
                 .ClickLogOut()
                 .Out();
        }
        [Test]
        public void VerifyInvalidLogin()
        {
            string myText = "test@321";
            _eshopNewPage.NavigateToDefaultPage()
                         .ClickAccountButton()
                         .ClickPrivatePolicy()
                         .InputEmailText(myText)
                         .InputPasswordText(myText)
                         .ClickButton()
                         .CheckIfLoginFailed();
        }
        [Test]
        public void OpenNewbutton()
        {
            _eshopNewPage.NavigateToDefaultPage()
                         .ClickPrivatePolicy()
                         .ClickSinCare();
        }
        [Test]
        public void CheckWishList()
        {
            _eshopNewFirtsItemPage.NavigateToDefaultPage()
                                  .AgreeClick()
                                  .PutToWishList()
                                  .CheckWishButton()
                                  .CheckIfWithoutLogin()
                                  .CheckItembefore()
                                  .CheckPutToBasket()
                                  .CheckIfItemIsInBasket();
        }

        [Test]
        public void SearchField()
        {
            string myItem = "ZARQA VONIOS IR DUŠO GELIS JAUTRIAI ODAI, 200 ml";
            _eshopNewPage.NavigateToDefaultPage()
                         .CheckSearchField(myItem);

        }
        
        [Test]
        public void BuyFirstItem()
        {
            _eshopNewBuyItemPage.NavigateToDefaultPage()
                .AcceptCookie()
                .ChooseFindItem()
                .ClickOnBasketButtonToBuy()
                .FirstStepToBuy()
                .SecondStepToBuy()
                .CheckSum()
                .FinalButton()
                .FinalInfo();
        }
    }
}
