using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppAvoMart;

namespace UnitTest
{
    [TestClass]
    public class OffersTest
    {
        [TestMethod]
        public void Input_Empty()
        {
            string inputStr = "";
            double expected = 0;
            double actual = 0;
            actual = Program.CheckoutBill(inputStr);
            Assert.AreEqual(expected, actual, 0.001, "Please add items.");
        }
    }
}
