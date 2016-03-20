using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HWUtils;
using System.Collections.Generic;
using System.Linq;

namespace TestHWUtils
{
    [TestClass]
    public class TestHWUtils
    {
        [TestMethod]
        public void TestSearch()
        {
            Persona[] persons = Factoria<Persona>.CrearPersonas();
            Predicate<Persona> criterio = (x) => x.Nif[x.Nif.Length - 1].Equals('A');
            Assert.AreEqual("9876384A", Factoria<Persona>.Search(persons, criterio).Nif);

            //Using LINQ
            Assert.AreEqual("9876384A", persons.Where((x) => x.Nif[x.Nif.Length - 1].Equals('A')).First().Nif);

        }

        [TestMethod]
        public void TestFilter() {
            Persona[] persons = { new Persona("A", "B", "C", "11111K"), new Persona("Aadawdwada", "wdada", "adwaw", "11111K"), new Persona("A", "B", "C", "2222J") };
            List<Persona> expected = new List<Persona>();
            expected.Add(persons[0]);
            expected.Add(persons[1]);

            Predicate<Persona> criterio = (x) => x.Nif[x.Nif.Length - 1].Equals('K');
            List<Persona> result = Factoria<Persona>.Filter(persons, criterio);

            //Assert.AreEqual(expected.Count, result.Count);
            CollectionAssert.AreEqual(expected, result);

            //Using LINQ
            CollectionAssert.AreEqual(expected, persons.Where((x) => x.Nif[x.Nif.Length - 1].Equals('K')).ToArray());
        }

        [TestMethod]
        public void TestReduce() {
            Angulo[] a = { new Angulo(10), new Angulo(20), new Angulo(30)};
            Persona[] p = { new Persona("Juan", "dawda", "dwda", "dwadwaK"), new Persona("Juan", "dawda", "dwda", "dwadwaK") , new Persona("Pepe", "dawda", "dwda", "dwadwaK") };

            Func<Angulo, double, double> sumaGrados = (x, y) => x.Grados + y;
            Assert.AreEqual(60, Factoria<Angulo>.Reduce(sumaGrados, a));
            
            //Using LINQ
            float[] toGrados = (from i in Enumerable.Range(0, a.Length) select a[i].Grados).ToArray();
            Assert.AreEqual(60, toGrados.Aggregate((x,y) => x + y));

            Func<Angulo, double, double> senoMax = (x, y) => x.Seno()>y ? x.Seno(): 0;
            Assert.AreEqual(0.5, (float) Factoria<Angulo>.Reduce(senoMax, a));// sen(30)

            //Using LINQ
            double[] toSeno = (from i in Enumerable.Range(0, a.Length) select a[i].Seno()).ToArray();
            Assert.AreEqual(0.5, (float) toSeno.Aggregate((x, y) => x > y ? x : y));

            //Func<Persona, double, string, double> countPersonsByName = (x, y, s) => x.Nombre.Equals(s) ? y + 1 : y + 0;
            //Assert.AreEqual(2, Factoria<Persona>.Reduce(countPersonsByName, p));
        }
    }
}
