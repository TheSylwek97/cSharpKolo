using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMath;

namespace UnitTestWielomian
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow(1,0)]
        public void TestStopien(int a, int s)
        {
            int[] g = new int[] { a };
            Wielomian w = new Wielomian(g);
            Assert.AreEqual(w.Stopien, s);
        }

        [DataTestMethod]
        [DataRow(-2, 0, 1, -3, 3)]
        public void TestStopienWiele(int a, int b, int c, int d, int s)
        {
            int[] g = new int[] { a,b,c,d };
            Wielomian w = new Wielomian(g);
            Assert.AreEqual(w.Stopien, s);
        }

        [DataTestMethod]
        [DataRow(0, 0, 0, -2, 0, 1, -3, 3)]
        public void TestStopienWiele2(int a, int b, int c, int d, int e, int f, int g, int s)
        {
            int[] o = new int[] { a, b, c, d, e, f, g};
            Wielomian w = new Wielomian(o);
            Assert.AreEqual(w.Stopien, s);
        }
    }
}
/*var w11 = new Wielomian(1, 0);
            Console.WriteLine($"W(1,0) = {w11}, stopień = {w11.Stopien}");
*/