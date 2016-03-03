using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
