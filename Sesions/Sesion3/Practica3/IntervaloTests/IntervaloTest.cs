using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Practica3

{
    [TestClass]
    public class IntervaloTest
    {
        [TestMethod]
        public void IntersectionTest()
        {
            Intervalo A = new Intervalo(0,3);
            Intervalo B = new Intervalo(1, 4);

            //Assert.AreEqual(expected, A*B);
            Intervalo expected = new Intervalo(1, 1);
        }
    }
}
