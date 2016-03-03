using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IListTest
{
    [TestClass]
    public class ListTest
    {
        //private IList<T> list = new List<T>();
        private IList<int> list;

        [TestMethod]
        public void TestAdd()
        {
            list = new List<int>();
            //List<int> aux = list as List<int>;
            for (int i = 1; i <= 10; i++)
            {
                list.Add(i);
                Assert.AreEqual(true, list.Contains(i));
                Assert.AreEqual(i, list.Count);
            }
        }

        [TestMethod]
        public void TestNumberOfElements()
        {
            list = new List<int>();
            Assert.AreEqual(0, list.Count);
            list.Add(1);
            Assert.AreEqual(1, list.Count);
            list.Add(2);
            Assert.AreEqual(2, list.Count);
            list.Remove(2);
            Assert.AreEqual(1, list.Count);
            list.Remove(1);
            Assert.AreEqual(0, list.Count);

            //if element doesnt exist you cant remove
            list.Add(1);
            Assert.AreEqual(1, list.Count);
            list.Remove(5);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void TestGetAndSet()
        {
            list = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                list.Add(i);
            }

            Assert.AreEqual(1, list[0]);
            list[0] = 20;
            Assert.AreEqual(20, list[0]);

            list[list.Count - 1] = 50;
            Assert.AreEqual(50, list[list.Count - 1]);
        }

        [TestMethod]
        public void TestContains()
        {
            list = new List<int>();
            list.Add(1);
            Assert.AreEqual(true, list.Contains(1));
            list.Add(1);
            Assert.AreEqual(true, list.Contains(1));
            list.Remove(1);
            Assert.AreEqual(true, list.Contains(1));
            list.RemoveAt(0);
            Assert.AreEqual(false, list.Contains(0));
        }

        [TestMethod]
        public void TestIndexOf()
        {
            list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
                Assert.AreEqual(i, list.IndexOf(i));
            }
        }

        [TestMethod]
        public void TestRemove()
        {
            list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(1);

            Assert.AreEqual(true, list.Remove(1));
            Assert.AreEqual(2, list[0]);
            Assert.AreEqual(1, list[1]);
            Assert.AreEqual(true, list.Remove(1));
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(false, list.Contains(1));
            Assert.AreEqual(false, list.Remove(10)); //doesnt exist
        }

        [TestMethod]
        public void TestForEach()
        {
            list = new List<int>();
            for (int i = 0; i < 50; i++) { list.Add(i); }

            foreach (int x in list)
            {
                Assert.AreEqual(true, list.Contains(x));
            }

        }
    }
}
