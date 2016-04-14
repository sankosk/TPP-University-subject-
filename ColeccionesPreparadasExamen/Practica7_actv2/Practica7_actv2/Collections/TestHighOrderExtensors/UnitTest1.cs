using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Collections;

namespace TestHighOrderExtensors
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Search(){
            LinkedList<object> enteros = new LinkedList<object>();
            for (int i=0; i<15; i++) {
                enteros.add(i);
            }         
            Assert.AreEqual(2, enteros.Search((x) => (int)x % 2 == 0));
        }
    }
}
