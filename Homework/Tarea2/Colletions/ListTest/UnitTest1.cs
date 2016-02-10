using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// Author: Esteban Montes Morales
/// Subject: TPP at uniovi
/// </summary>
namespace ListTest
{
    //*PD: NOT EXHAUSTIVE TESTS

    [TestClass]
    public class UnitTest1
    {
        Colletions.LinkedList<int> list = new Colletions.LinkedList<int>();

        [TestMethod]
        public void TestAdd(){
            list = new Colletions.LinkedList<int>();

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
        public void TestGet(){
            list = new Colletions.LinkedList<int>();
            for (int i=0; i<50; i++){
                list.add(i);
                Assert.AreEqual(i+1, list.size());
            }

            list.add(2, 999);
            Assert.AreEqual(999, list.get(2));
            Assert.AreEqual(2, list.get(3));
            Assert.AreEqual(1, list.get(1));

            list = new Colletions.LinkedList<int>();
            for (int i = 0; i < 50; i++)
            {
                list.add(i);
                Assert.AreEqual(i + 1, list.size());
            }

            list.add(0,999);
            Assert.AreEqual(999, list.get(0));
            //System.Console.WriteLine(list.size());
            list.add(list.size()-1, 888);
            Assert.AreEqual(49, list.get(list.size() - 3));
            Assert.AreEqual(888, list.get(list.size()-2));
        }

        [TestMethod]
        public void TestAddByPosition(){
            list = new Colletions.LinkedList<int>();
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
            list.add(list.size()+1, 999);
            Assert.AreEqual(50, list.size());
            
            //index<0
            list.add(-6, 999);
            Assert.AreEqual(50, list.size());
        }

        [TestMethod]
        public void TestRemove() {
            list = new Colletions.LinkedList<int>();
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
        public void testRemoveByIndex() {
            list = new Colletions.LinkedList<int>();
            Colletions.LinkedList<int> list2 = new Colletions.LinkedList<int>();
            Colletions.LinkedList<int> list3 = new Colletions.LinkedList<int>();

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
            list.removeByIndex(list.size()-1);
            Assert.AreEqual(48, list.get(list.size() - 1));
            Assert.AreEqual(48, list.size());

            //remove [firstElement, lastElement]
            Assert.AreEqual(0, list2.removeByIndex(0));
            Assert.AreEqual(25+1, list2.removeByIndex(25));
            Assert.AreEqual(32+2, list2.removeByIndex(32));
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
            list = new Colletions.LinkedList<int>();

            //list.add(1);
            //Assert.AreEqual(1, list.size());

            //adding elems
            for (int i=1; i<51; i++) {
                list.add(i);
                Assert.AreEqual(i, list.size());
            }

            //removing elems
            for (int i = 1; i < 51; i++){
                list.remove(i);
                Assert.AreEqual(50-i, list.size());
            }

        }

        [TestMethod]
        public void testIndexOf(){
            list = new Colletions.LinkedList<int>();
            for (int i=0; i<50; i++) {
                list.add(i);
                Assert.AreEqual(i, list.indexOf(i));
            }
        }

        [TestMethod]
        public void testAllIndexesOf() {
            list = new Colletions.LinkedList<int>();
            for (int i=0; i<10; i++) {
                list.add(1);
            }
            int[] expected = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            Assert.AreEqual(expected.Length, list.size());
            CollectionAssert.AreEqual(expected, list.allIndexesOf(1));
        }

        [TestMethod]
        public void testRemoveAllValues() {
            list = new Colletions.LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.add(1);
            }
            list.add(2);
            list.add(3);
            int auxSize = list.size();


            int[] expected = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
            int[] result = list.removeAllValues(1);
            CollectionAssert.AreEqual(expected, result);
            Assert.AreEqual(expected.Length, result.Length);
            Assert.AreEqual(auxSize-result.Length, list.size());

        }

        [TestMethod]
        public void testContains() {
            list = new Colletions.LinkedList<int>();
            for (int i=0; i<50; i++) {
                list.add(i);
                Assert.AreEqual(true, list.contains(i));
            }

            Assert.AreEqual(false, list.contains(50));
            Assert.AreEqual(false, list.contains(51));
            // ...
        }

        [TestMethod]
        public void genericListTest() {
            Colletions.LinkedList<int> intsList = new Colletions.LinkedList<int>();// -> INT TYPE WAS TESTED
            Colletions.LinkedList<double> doublesList = new Colletions.LinkedList<double>();
            Colletions.LinkedList<String> strsList = new Colletions.LinkedList<String>();
            Colletions.LinkedList<Persona> personsList = new Colletions.LinkedList<Persona>();

            //Adding doubles
            for (int i=0; i<50; i++) {
                doublesList.add((double) i);
                Assert.AreEqual((double) i, doublesList.get(i));//get
                Assert.AreEqual(i, doublesList.indexOf((double) i));//index of a double
                Assert.AreEqual(true, doublesList.contains((double) i));//contains double?
            }
            Assert.AreEqual(50, doublesList.size());

            //removing doubles
            for (int i=0; i<50; i++) {
                Assert.AreEqual((double) i, doublesList.remove((double) i));
            }
            Assert.AreEqual(0, doublesList.size());

            //removing doubles by position
            doublesList.add(1.0);
            doublesList.add(2.0);

            Assert.AreEqual(1.0, doublesList.removeByIndex(0));
            Assert.AreEqual(2.0, doublesList.removeByIndex(0));
        }

    }

    //Inner class only for testing reasons
    class Persona {
        public String name { get; protected internal set;}
        public String dni { get; protected internal set; }
        public int age { get; protected internal set; }
    }
}
