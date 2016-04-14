using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collections;

/// <summary>
/// Author: Esteban Montes Morales
/// Subject: TPP at uniovi
/// </summary>
namespace LinkedListTest
{
    //*PD: NOT EXHAUSTIVE TESTS

    [TestClass]
    public class LinkedListTest
    {
        LinkedList<int> list = new LinkedList<int>();

        [TestMethod]
        public void TestAdd()
        {
            list = new LinkedList<int>();

            //Positive tests
            //Adding objects:
            //Adding Integers or ints
            list.add(1);
            Assert.AreEqual(1, list.size());
            //Adding Strings and Chars
            // list.add("a");
            //Assert.AreEqual(2, list.size());
        }


        [TestMethod]
        public void TestGet()
        {
            list = new LinkedList<int>();
            for (int i = 0; i < 50; i++)
            {
                list.add(i);
                Assert.AreEqual(i + 1, list.size());
            }

            list.add(2, 999);
            Assert.AreEqual(999, list.get(2));
            Assert.AreEqual(2, list.get(3));
            Assert.AreEqual(1, list.get(1));

            list = new LinkedList<int>();
            for (int i = 0; i < 50; i++)
            {
                list.add(i);
                Assert.AreEqual(i + 1, list.size());
            }

            list.add(0, 999);
            Assert.AreEqual(999, list.get(0));
            //System.Console.WriteLine(list.size());
            list.add(list.size() - 1, 888);
            Assert.AreEqual(49, list.get(list.size() - 3));
            Assert.AreEqual(888, list.get(list.size() - 2));
        }

        [TestMethod]
        public void TestAddByPosition()
        {
            list = new LinkedList<int>();
            for (int i = 0; i < 50; i++)
            {
                list.add(i);
                Assert.AreEqual(i + 1, list.size());
            }

            //Positive tests
            //Implemented inside TestGet() for testing both methods


            //Negative tests
            //index>=size
            list.add(list.size(), 999);
            list.add(list.size() + 1, 999);
            Assert.AreEqual(50, list.size());

            //index<0
            list.add(-6, 999);
            Assert.AreEqual(50, list.size());
        }

        [TestMethod]
        public void TestRemove()
        {
            list = new LinkedList<int>();
            list.add(1);
            list.add(2);
            list.add(3);
            list.add(1);
            list.add(3);

            // 1, 2, 3, 1, 3, remove(3) -> 1,2,1,3
            Assert.AreEqual(3, list.remove(3));
            Assert.AreEqual(4, list.size());
            Assert.AreEqual(1, list.get(0));
            Assert.AreEqual(2, list.get(1));
            Assert.AreEqual(1, list.get(2));
            Assert.AreEqual(3, list.get(3));
        }

        [TestMethod]
        public void testRemoveByIndex()
        {
            list = new LinkedList<int>();
            LinkedList<int> list2 = new LinkedList<int>();
            LinkedList<int> list3 = new LinkedList<int>();

            for (int i = 0; i < 50; i++)
            {
                list.add(i);
                list2.add(i);
                list3.add(i);
            }

            //remove first element
            list.removeByIndex(0);
            Assert.AreEqual(1, list.get(0));
            Assert.AreEqual(49, list.size());

            //remove last element
            list.removeByIndex(list.size() - 1);
            Assert.AreEqual(48, list.get(list.size() - 1));
            Assert.AreEqual(48, list.size());

            //remove [firstElement, lastElement]
            Assert.AreEqual(0, list2.removeByIndex(0));
            Assert.AreEqual(25 + 1, list2.removeByIndex(25));
            Assert.AreEqual(32 + 2, list2.removeByIndex(32));
            //Assert.AreEqual(49, list2.removeByIndex(list2.size()-1));


            //remove all
            for (int i = 0; i < 50; i++)
            {
                list3.removeByIndex(0);
            }
            Assert.AreEqual(0, list3.size());


            //Negative tests
            //Index >= size

            //Index < 0
        }

        [TestMethod]
        public void testSize()
        {
            list = new LinkedList<int>();

            //list.add(1);
            //Assert.AreEqual(1, list.size());

            //adding elems
            for (int i = 1; i < 51; i++)
            {
                list.add(i);
                Assert.AreEqual(i, list.size());
            }

            //removing elems
            for (int i = 1; i < 51; i++)
            {
                list.remove(i);
                Assert.AreEqual(50 - i, list.size());
            }

        }

        [TestMethod]
        public void testIndexOf()
        {
            list = new LinkedList<int>();
            for (int i = 0; i < 50; i++)
            {
                list.add(i);
                Assert.AreEqual(i, list.indexOf(i));
            }
        }

        [TestMethod]
        public void testAllIndexesOf()
        {
            list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.add(1);
            }
            int[] expected = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.AreEqual(expected.Length, list.size());
            CollectionAssert.AreEqual(expected, list.allIndexesOf(1));
        }

        [TestMethod]
        public void testRemoveAllValues()
        {
            list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.add(1);
            }
            list.add(2);
            list.add(3);
            int auxSize = list.size();


            int[] expected = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int[] result = list.removeAllValues(1);
            CollectionAssert.AreEqual(expected, result);
            Assert.AreEqual(expected.Length, result.Length);
            Assert.AreEqual(auxSize - result.Length, list.size());

        }

        [TestMethod]
        public void testContains()
        {
            list = new LinkedList<int>();
            for (int i = 0; i < 50; i++)
            {
                list.add(i);
                Assert.AreEqual(true, list.contains(i));
            }

            Assert.AreEqual(false, list.contains(50));
            Assert.AreEqual(false, list.contains(51));
            // ...
        }

        [TestMethod]
        public void genericListTest()
        {
            LinkedList<int> intsList = new LinkedList<int>();// -> INT TYPE WAS TESTED
            LinkedList<double> doublesList = new LinkedList<double>();
            LinkedList<String> strsList = new LinkedList<String>();
            LinkedList<Persona> personsList = new LinkedList<Persona>();

            //GENERAL TEST FOR DOUBLES
            for (int i = 0; i < 50; i++)
            {
                doublesList.add((double)i); //add double
                strsList.add(i.ToString()); //add string
                Persona auxP = new Persona(i.ToString());
                personsList.add(auxP); // add persons

                Assert.AreEqual((double)i, doublesList.get(i));//get double
                Assert.AreEqual(i.ToString(), strsList.get(i));//get string
                Assert.AreEqual(auxP, personsList.get(i)); //get person


                Assert.AreEqual(i, doublesList.indexOf((double)i));//index of a double
                Assert.AreEqual(i, strsList.indexOf(i.ToString()));//index of a string
                Assert.AreEqual(i, personsList.indexOf(auxP));// index of a person

                Assert.AreEqual(true, doublesList.contains((double)i));//contains double?
                Assert.AreEqual(true, strsList.contains(i.ToString()));//contains string?
                Assert.AreEqual(true, personsList.contains(auxP));//contains person?
            }
            Assert.AreEqual(50, doublesList.size());
            Assert.AreEqual(50, strsList.size());
            Assert.AreEqual(50, personsList.size());


            //removing doubles
            for (int i = 0; i < 50; i++)
            {
                Persona auxP = new Persona(i.ToString());
                Assert.AreEqual((double)i, doublesList.remove((double)i));
                Assert.AreEqual(i.ToString(), strsList.remove(i.ToString()));
                Assert.AreEqual(auxP, personsList.remove(auxP));
            }
            Assert.AreEqual(0, doublesList.size());
            Assert.AreEqual(0, strsList.size());
            Assert.AreEqual(0, personsList.size());

            //removing by position
            Persona p1 = new Persona("dni1");
            Persona p2 = new Persona("dni2");

            doublesList.add(1.0);
            doublesList.add(2.0);
            strsList.add("texto1");
            strsList.add("texto2");
            personsList.add(p1);
            personsList.add(p2);

            Assert.AreEqual(1.0, doublesList.removeByIndex(0));
            Assert.AreEqual(2.0, doublesList.removeByIndex(0));
            Assert.AreEqual("texto1", strsList.removeByIndex(0));
            Assert.AreEqual("texto2", strsList.removeByIndex(0));
            Assert.AreEqual(p1, personsList.removeByIndex(0));
            Assert.AreEqual(p2, personsList.removeByIndex(0));
        }


        [TestMethod]
        public void Search()
        {
            LinkedList<object> enteros = new LinkedList<object>();
            for (int i = 1; i < 15; i++)
            {
                enteros.add(i);
            }
            Assert.AreEqual(2, enteros.Search((x) => (int)x % 2 == 0));
        }

        [TestMethod]
        public void Filter() {
            LinkedList<int> enteros = new LinkedList<int>();
            for (int i = 1; i < 15; i++)
            {
                enteros.add(i);
            }

            int[] expected = { 2, 4, 6, 8, 10, 12, 14 };

            //int[] res = enteros.oneLineFilter((x) => x % 2 == 0);
            int[] res = enteros.Filter((x) => x % 2 == 0).ConvertToArray();

            CollectionAssert.AreEqual(expected, res);
        }

        [TestMethod]
        public void Reduce() {
            LinkedList<double> enteros = new LinkedList<double>();
            for (int i = 1; i < 15; i++)
            {
                enteros.add(i);
            }

            Assert.AreEqual(105, enteros.Reduce((x,y) => x+y));
        }

        [TestMethod]
        public void Map() {
            LinkedList<int> enteros = new LinkedList<int>();
            for (int i = 1; i < 15; i++){
                enteros.add(i);
            }

            int[] expected = {1+1,2+1,3+1,4+1,5+1,6+1,7+1,8+1,9+1,10+1,11+1,12+1,13+1,14+1};
            //int[] res = enteros.oneLineMap((x) => (x + 1));
            int[] res = enteros.Map((x) => (x + 1)).ConvertToArray();
            CollectionAssert.AreEqual(expected, res);
        }
    }

    //Inner class only for testing reasons
    class Persona
    {
        public String dni { get; protected internal set; }
        public Persona(String elDNI)
        {
            dni = elDNI;
        }

        public override bool Equals(object obj)
        {
            Persona p = obj as Persona;
            return dni.Equals(p.dni);
        }
    }
}
