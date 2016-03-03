using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace SetTest
{
    [TestClass]
    public class SetTest
    {
        [TestMethod]
        public void plusTest()
        {
            Collections.Set<int> s = new Collections.Set<int>();
            Collections.Set<int> s2 = new Collections.Set<int>();
            int[] a = { 1, 5, 6, 9 };
            int[] b = { 1, 4, 7, 9 };

            for (int i = 0; i < a.Length; i++)
            {
                s += (a[i]);
                s2 += (b[i]);
            }

            Assert.AreEqual(4, s.size());
            Assert.AreEqual(4, s2.size());

        }

        public void minusTest()
        {
            Collections.Set<int> s = new Collections.Set<int>();
            Collections.Set<int> s2 = new Collections.Set<int>();
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
        public void unionTest()
        {
            Collections.Set<int> s = new Collections.Set<int>();
            Collections.Set<int> s2 = new Collections.Set<int>();
            int[] a = { 1, 5, 6, 9 };
            int[] b = { 1, 4, 7, 9 };

            for (int i = 0; i < a.Length; i++)
            {
                s += (a[i]);
                s2 += (b[i]);
            }

            int[] expected = { 1, 4, 5, 6, 7, 9 };

            Collections.Set<int> res = (s | s2);
            int[] k = new int[res.size()];
            for (int i = 0; i < res.size(); i++)
            {
                k[i] = res.get(i);
            }
            Array.Sort(k);

            CollectionAssert.AreEqual(expected, k);

        }

        [TestMethod]
        public void intersectTest()
        {
            Collections.Set<int> s = new Collections.Set<int>();
            Collections.Set<int> s2 = new Collections.Set<int>();
            int[] a = { 1, 5, 6, 9 };
            int[] b = { 1, 4, 7, 9 };

            for (int i = 0; i < a.Length; i++)
            {
                s += (a[i]);
                s2 += (b[i]);
            }

            int[] expected = { 1, 9 };

            Collections.Set<int> res = (s & s2);
            int[] k = new int[res.size()];
            for (int i = 0; i < res.size(); i++) {
                k[i] = res.get(i);
            }
            Array.Sort(k);

            CollectionAssert.AreEqual(expected, k);
        }

        [TestMethod]
        public void differenceTest()
        {
            Collections.Set<int> s = new Collections.Set<int>();
            Collections.Set<int> s2 = new Collections.Set<int>();
            int[] a = { 1, 5, 6, 9 };
            int[] b = { 1, 4, 7, 9 };

            for (int i = 0; i < a.Length; i++)
            {
                s += (a[i]);
                s2 += (b[i]);
            }
            int[] expected = { 5, 6 };


            Collections.Set<int> res = (s - s2);
            int[] k = new int[res.size()];
            for (int i = 0; i < res.size(); i++)
            {
                k[i] = res.get(i);
            }
            Array.Sort(k);

            CollectionAssert.AreEqual(expected, k);
        }
    }
}
