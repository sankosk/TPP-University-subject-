using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collections;

namespace StackTests
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void PushTest(){
            Collections.Stack<int> s = new Collections.Stack<int>(10);

            for (int i=0; i<10; i++) {
                s.Push(i);
                Assert.AreEqual(i+1, s.listOfElems.NumOfElements);
            }

            int[] expected = s.Map(x => x*1).ConvertToArray();
            CollectionAssert.AreEqual(s.ConvertToArray(), expected);

            for (int i = 0; i < s.MaxNumOfElements; i++) {
                Assert.AreEqual(s.listOfElems.get(i), expected[i]);
                Assert.AreEqual(s.listOfElems.get(i), i);
            }
        }

        [TestMethod]
        public void PopTest() {
            Collections.Stack<int> s = new Collections.Stack<int>(10);
            for (int i = 0; i < 10; i++){
                s.Push(i);
                Assert.AreEqual(i + 1, s.listOfElems.NumOfElements);
            }

            for (int i=0; i<10; i++) {
                Assert.AreEqual(9-i, s.Pop());
                Assert.AreEqual(9-i, s.listOfElems.NumOfElements);
            }
        }

    }
}
