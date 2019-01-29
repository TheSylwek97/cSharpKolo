using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath;

namespace UnitTestWielomian
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow(0, 1)]
        public void TestConnectionString(int stopien, int c)
        {
            Wielomian w = c;
            c = (Wielomian)w;
            w.Stopien = stopien;
            Assert.AreEqual(w.Stopien, stopien);
        }
    }
}
