using System;
using _1C_Enterprise;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodInputControl1()
        {
            bool expectation = true;
            string Number = "12";
            bool result = Method.inputControl(Number);
            Assert.AreEqual(expectation, result);
        }

        [TestMethod]
        public void TestMethodInputControl2()
        {
            bool expectation = false;
            string Number = null;
            bool result = Method.inputControl(Number);
            Assert.AreEqual(expectation, result);
        }

        [TestMethod]
        public void TestMethodInputControl3()
        {
            bool expectation = false;
            string Number = "DELETE Employee;";
            bool result = Method.inputControl(Number);
            Assert.AreEqual(expectation, result);
        }

        [TestMethod]
        public void TestMethodMinMax1()
        {
            bool expectation = true;
            string Number = "50";
            bool result = Method.MinMax(Number);
            Assert.AreEqual(expectation, result);
        }

        [TestMethod]
        public void TestMethodMinMax2()
        {
            bool expectation = false;
            string Number = null;
            bool result = Method.MinMax(Number);
            Assert.AreEqual(expectation, result);
        }

        [TestMethod]
        public void TestMethodMinMax3()
        {
            bool expectation = false;
            string Number = "DELETE Employee;";
            bool result = Method.MinMax(Number);
            Assert.AreEqual(expectation, result);
        }
    }
}
