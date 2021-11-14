using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomatinisTestavimas2
{
    class demo01//-----pirmoji pamoka 2021-11-03---
    {
        [Test]
        public static void TestIf4IsEven()
        {
            int leftover = 4 % 2;
            Assert.AreEqual(0, leftover, "4 is not even");
        }
        [Test]
        public static void TestNowIs19()
        {
            DateTime CurrentTime = DateTime.Now;
            Assert.IsTrue(CurrentTime.Hour.Equals(19));
        }
        [Test]
        public static void Test995division3()
        {
            int leftover = 995 % 3;
            Assert.AreEqual(0, leftover, "995 nesidalija is 3");
        }
        [Test]
        public static void TestIfTodayIsMonday()
        {
            DateTime CurrentDay = DateTime.Now;
            Assert.AreEqual(DayOfWeek.Monday, CurrentDay.DayOfWeek, "Today is not Monday");
        }
        [Test]
        public static void TestWaitFor5sec()
        {
            Thread.Sleep(5000);
        }
        /*[Test]
        public static void TestIfTodayIsMontag() 
        {
            DayOfWeek Today = DayOfWeek.Monday;
            Assert.IsTrue(DayOfWeek.Monday.Equals(Today), "siandien ne pirmadienis");
        }*/
        //linos variantas
    }
}
