using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2.Test
{
    public class AlertTest : BaseTest
    {
        [Test]
        public static void TestAlert()
        {
            _alertPage.NavigateToDefaultPage()
                .ClickAlertButton()
                .AcceptAlert();
        }

        [Test]
        public static void TestConfirmationAlert()
        {
            _alertPage.NavigateToDefaultPage()
                .ClickConfirmationAlertButton()
                .DismissConfirmationAlert();
        }

        [Test]
        public static void TestPromptAlert()
        {
            _alertPage.NavigateToDefaultPage()
                .ClickPromptAlertButton()
                .InsertTextAndAcceptPromptAlert("Penktadienis");
        }
    }
}
