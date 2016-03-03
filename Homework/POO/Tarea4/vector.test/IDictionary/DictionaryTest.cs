using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace IDictionaryTest
{
    [TestClass]
    public class DictionaryTest
    {
        private IDictionary<string, int> dictionary;

        [TestMethod]
        public void TestAdd()
        {
            dictionary = new Dictionary<string, int>();
            string[] names = { "Cero", "Uno", "Dos", "Tres", "Cuatro", "Cinco" };
            //int[] numbers = (from i in Enumerable.Range(0, 6).ToArray() select i).ToArray();

            for (int i = 0; i < 6; i++)
            {
                dictionary.Add(names[i], i);
                Assert.AreEqual(i + 1, dictionary.Count);
            }
        }

        [TestMethod]
        public void TestCount()
        {
            dictionary = new Dictionary<String, int>();
            dictionary.Add("a", 1);
            Assert.AreEqual(1, dictionary.Count);
            dictionary.Add("b", 2);
            Assert.AreEqual(2, dictionary.Count);

            Assert.AreEqual(true, dictionary.Remove("a"));
            Assert.AreEqual(1, dictionary.Count);
            Assert.AreEqual(true, dictionary.Remove("b"));
            Assert.AreEqual(0, dictionary.Count);
            dictionary.Add("a", 1);
            Assert.AreEqual(1, dictionary.Count);
            dictionary.Remove("c");
            Assert.AreEqual(1, dictionary.Count);

        }

        [TestMethod]
        public void TestGetAndSet()
        {
            dictionary = new Dictionary<string, int>();
            string[] names = { "Cero", "Uno", "Dos", "Tres", "Cuatro", "Cinco" };
            //int[] numbers = (from i in Enumerable.Range(0, 6).ToArray() select i).ToArray();

            for (int i = 0; i < 6; i++)
            {
                dictionary.Add(names[i], i);
                Assert.AreEqual(i + 1, dictionary.Count);
            }

            Assert.AreEqual(0, dictionary["Cero"]);
            Assert.AreEqual(2, dictionary["Dos"]);
            dictionary["Cero"] = 2;
            Assert.AreEqual(2, dictionary["Cero"]);

        }

        [TestMethod]
        public void TestContains()
        {
            dictionary = new Dictionary<string, int>();
            string[] names = { "Cero", "Uno", "Dos", "Tres", "Cuatro", "Cinco" };
            //int[] numbers = (from i in Enumerable.Range(0, 6).ToArray() select i).ToArray();

            for (int i = 0; i < 6; i++)
            {
                dictionary.Add(names[i], i);

            }

            Assert.AreEqual(true, dictionary.Contains(new KeyValuePair<string, int>("Cero", 0)));
            Assert.AreEqual(false, dictionary.Contains(new KeyValuePair<string, int>("Cero", 2)));
            Assert.AreEqual(false, dictionary.Contains(new KeyValuePair<string, int>("Once", 0)));
        }
        [TestMethod]
        public void TestRemove()
        {
            dictionary = new Dictionary<string, int>();
            string[] names = { "Cero", "Uno", "Dos", "Tres", "Cuatro", "Cinco" };
            //int[] numbers = (from i in Enumerable.Range(0, 6).ToArray() select i).ToArray();

            for (int i = 0; i < 6; i++)
                dictionary.Add(names[i], i);

            for (int i = 0; i < 6; i++)
                Assert.AreEqual(true, dictionary.Remove(names[i]));

            Assert.AreEqual(false, dictionary.Remove("Veinticuatro"));
        }

        [TestMethod]
        public void TestForeach()
        {
            dictionary = new Dictionary<string, int>();
            string[] names = { "Cero", "Uno", "Dos", "Tres", "Cuatro", "Cinco" };
            //int[] numbers = (from i in Enumerable.Range(0, 6).ToArray() select i).ToArray();

            for (int i = 0; i < 6; i++)
                dictionary.Add(names[i], i);

            foreach (var x in dictionary)
            {
                Assert.AreEqual(true, dictionary.Contains(x));
            }
        }
    }
}
