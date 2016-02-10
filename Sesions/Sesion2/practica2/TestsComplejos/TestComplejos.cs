using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Complejos;
using TestsComplejos;

namespace Complejos.Test
{
    [TestClass]
    public class TestComplejos
    {
        [TestMethod]
        public void TestModulo()
        {
            Complejo unComplejo = new Complejo(1.0, 1.0);
            Assert.AreEqual(Math.Sqrt(2.0), unComplejo.Modulo());
        }
        [TestMethod]
        public void TestConjugado()
        {
            Complejo unComplejo = new Complejo(1.0, 1.0),
                     valorEsperado = new Complejo(1.0, -1.0),
                     valorObtenido;
            valorObtenido = unComplejo.Conjugado();
            Assert.AreEqual(valorEsperado.R, unComplejo.Conjugado().R);
            Assert.AreEqual(valorEsperado.I, unComplejo.Conjugado().I);
        }
        [TestMethod]
        public void TestSuma()
        {
            Complejo unComplejo = new Complejo(1.0, 1.0),
                     otroComplejo = new Complejo(2.0, 3.0),
                     valorEsperado = new Complejo(3.0, 4.0),
                     valorObtenido;
            valorObtenido = unComplejo + otroComplejo;
            Assert.AreEqual(valorEsperado.R, valorObtenido.R);
            Assert.AreEqual(valorEsperado.I, valorObtenido.I);
        }
    }
}
