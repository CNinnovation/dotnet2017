using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expected = "abc";
            var s = new LibSample.Sample();
            string result = s.ATest("ABC");
            Assert.AreEqual(expected, result);
        }
    }
}
