using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntExtension;
namespace intExtensionTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testReverseNumber()
        {
            //Possitive numbers
            Assert.AreEqual(987654321, 123456789.reverseNumber());
            //Negative numbers
            Assert.AreEqual(-987654321, -123456789.reverseNumber());

            Assert.AreEqual(1111, 1111.reverseNumber());
            Assert.AreEqual(1221, 1221.reverseNumber());
        }

        [TestMethod]
        public void testIsPrime() {
            //all primes from 1 to 100
            int[] primes = {2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,73,79,83,89,97};
            foreach(int n in primes) {
                Assert.AreEqual(true, n.isPrime());
            }
        }

        [TestMethod]
        public void testMCD() {
            Assert.AreEqual(12, 24.mcd(36));
        }

        [TestMethod]
        public void testMCM() {
            Assert.AreEqual(72, 36.mcm(24));
        }

        [TestMethod]
        public void testConcat() {
            int a = 10; int b=20;
            Assert.AreEqual(1020, a.concat(b));
            Assert.AreEqual(2010, b.concat(a));

            //iterative testing
            String aux="";
            int res = 0;
            for (int i=1; i<=5; i++) {
                aux += i;
                res = res.concat(i);
            }
            Assert.AreEqual(int.Parse(aux), res);
        }
    }
}
