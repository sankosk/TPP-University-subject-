using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class SetTest
    {
        [TestMethod]
        public void plusTest()
        {
            Colletions.Set<int> s = new Colletions.Set<int>();
            Colletions.Set<int> s2 = new Colletions.Set<int>();
            int[] a = { 1 ,5 ,6 ,9};
            int[] b = { 1, 4, 7, 9 };

            for (int i=0; i<a.Length; i++) {
                s += (a[i]);
                s2 += (b[i]);
            }

            Assert.AreEqual(4, s.size());
            Assert.AreEqual(4, s2.size());

        }

        public void minusTest() {
            Colletions.Set<int> s = new Colletions.Set<int>();
            Colletions.Set<int> s2 = new Colletions.Set<int>();
            int[] a = { 1, 5, 6, 9 };
            int[] b = { 1, 4, 7, 9 };

            for (int i = 0; i < a.Length; i++)
            {
                s += (a[i]);
                s2 += (b[i]);
            }

            for (int i = 0; i < a.Length; i++)
            {
                s -= (a[i]);
                s2 -= (b[i]);
            }

            Assert.AreEqual(0, s.size());
            Assert.AreEqual(0, s2.size());
        }

        [TestMethod]
        public void unionTest() {
            Colletions.Set<int> s = new Colletions.Set<int>();
            Colletions.Set<int> s2 = new Colletions.Set<int>();
            int[] a = { 1, 5, 6, 9 };
            int[] b = { 1, 4, 7, 9 };

            for (int i = 0; i < a.Length; i++)
            {
                s += (a[i]);
                s2 += (b[i]);
            }

            Colletions.Set<int> s3 = new Colletions.Set<int>();
            int[] expected = { 1, 4, 5, 6, 7, 9 };
            foreach(int i in expected) {
                s3.add(i);
            }

            Assert.AreEqual(s3, s|s2);
        }

        [TestMethod]
        public void intersectTest()
        {
            Colletions.Set<int> s = new Colletions.Set<int>();
            Colletions.Set<int> s2 = new Colletions.Set<int>();
            int[] a = { 1, 5, 6, 9 };
            int[] b = { 1, 4, 7, 9 };

            for (int i = 0; i < a.Length; i++)
            {
                s += (a[i]);
                s2 += (b[i]);
            }

            Colletions.Set<int> s3 = new Colletions.Set<int>();
            int[] expected = {9,1};
            foreach (int i in expected)
            {
                s3.add(i);
            }

            Assert.AreEqual(s3, s & s2);
        }

        [TestMethod]
        public void differenceTest()
        {
            Colletions.Set<int> s = new Colletions.Set<int>();
            Colletions.Set<int> s2 = new Colletions.Set<int>();
            int[] a = { 1, 5, 6, 9 };
            int[] b = { 1, 4, 7, 9 };

            for (int i = 0; i < a.Length; i++)
            {
                s += (a[i]);
                s2 += (b[i]);
            }

            Colletions.Set<int> s3 = new Colletions.Set<int>();
            int[] expected = { 5, 6 };
            foreach (int i in expected)
            {
                s3.add(i);
            }

            Assert.AreEqual(s3, s - s2);
        }
    }
}
