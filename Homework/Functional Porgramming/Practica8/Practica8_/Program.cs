using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica8_
{
    class Modelo
    {
        public Modelo()
        {
            cart.Add(productsWithOutVat[0], 4);
            cart.Add(productsWithOutVat[1], 2);
            cart.Add(productsWithOutVat[3], 3);
        }


        class Product
        {
            public string Name { get; set; }

            public int CategoryID { get; set; }

        }

        class ProductWithOutVat
        {
            public string Name { get; set; }

            public int VatID { get; set; }

            public double Price { get; set; }

            public int CategoryID { get; set; }
            public override string ToString()
            {
                return String.Format("{0} {1} {2} {3}", Name, Price, VatID, CategoryID);
            }
        }

        class Category
        {
            public string Name { get; set; }

            public int ID { get; set; }
        }

        class Vat
        {
            public string Name { get; set; }

            public double Value { get; set; }

            public double VatID { get; set; }
        }
        #region Data
        // Specify the first data source.
        List<Category> categories = new List<Category>()
    {
        new Category (){Name="Beverages", ID=001},
        new Category (){ Name="Condiments", ID=002},
        new Category (){ Name="Vegetables", ID=003},
        new Category () {  Name="Grains", ID=004},
        new Category () {  Name="Fruit", ID=005},
        new Category () {  Name="Books", ID=006},
        new Category () {  Name="Gadgets", ID=007},

    };


        // VAT
        List<Vat> currentVat = new List<Vat>()
        {
        new     Vat{Name="Super Reduced",Value=0.04,VatID=001},
        new     Vat{Name="Reduced",Value=0.10,VatID=002},
        new     Vat{Name="General",Value=0.21,VatID=003},
        };

        // Specify the second data source.
        List<ProductWithOutVat> productsWithOutVat = new List<ProductWithOutVat>()
   {
      new ProductWithOutVat{Name="Cola", Price=1.0, VatID=002, CategoryID=001},
      new ProductWithOutVat{Name="Tea",  Price=2.0, VatID=002, CategoryID=001},
      new ProductWithOutVat{Name="Mustard", Price=3.0, VatID=002, CategoryID=002},
      new ProductWithOutVat{Name="Pickles", Price=1.0, VatID=001, CategoryID=002},
      new ProductWithOutVat{Name="Carrots", Price=2.5, VatID=001, CategoryID=003},
      new ProductWithOutVat{Name="Bread", Price=2.0, VatID=001, CategoryID=003},
      new ProductWithOutVat{Name="Peaches", Price=3.0, VatID=002, CategoryID=005},
      new ProductWithOutVat{Name="Melons", Price=1.5, VatID=002, CategoryID=005},
      new ProductWithOutVat{Name="Transcendental Crystallography", Price=20.0,VatID=001,CategoryID=006},
      new ProductWithOutVat{Name="eYePhone", Price=666,VatID=003,CategoryID=007}
    };
        Dictionary<ProductWithOutVat, int> cart = new Dictionary<ProductWithOutVat, int>();

        #endregion
        //1)
        private void ej1(double y)        {
            foreach (var item in productsWithOutVat.Where(x => x.Price < y))
                Console.WriteLine(item.Name);
            //si se ha definido ForEach como método extensor de IEnumerable se puede hacer así:
            //productsWithVat.Where(x => x.Price < 2.0).Select(p=>p.Name).ForEach(Console.WriteLine);
        }

        private void ej2() {
            foreach (var item in productsWithOutVat)
                Console.WriteLine("{0}:{1}:{2}", item.Name, item.Price, currentVat[item.VatID-1].Value);
        }

        private void ej3() {
            foreach (var item in productsWithOutVat) {
                Console.WriteLine("{0}:{1}", item.Name, item.Price + (item.Price * currentVat[item.VatID - 1].Value));
            }
        }

        private void ej5() {
            var sorted = productsWithOutVat.OrderBy(n => categories[n.CategoryID-1].Name);
            foreach (var item in sorted)
                Console.WriteLine("{0}:{1}", item.Name, item.Price + (item.Price * currentVat[item.VatID - 1].Value));
        }

        private void ej6() {
            foreach (var vat in currentVat) {
                Console.WriteLine("{0}: Productos con este iva aplicado:", vat.Name);
                foreach (var item in productsWithOutVat.OrderBy(i => currentVat[i.VatID - 1].Name)){
                    if (item.VatID == vat.VatID) Console.WriteLine("{0}:{1}", item.Name, categories[item.CategoryID-1].Name);
                }
                Console.WriteLine();
            }            
        }

        private void ej7() {
            foreach (var category in categories) {
                Console.WriteLine("La categoria {0} tiene {1} productos", category.Name, productsWithOutVat.Where(i => i.CategoryID == category.ID).Count());
                foreach (var item in productsWithOutVat.Where(i => i.CategoryID == category.ID)) {
                    Console.WriteLine("{0}:{1}", item.Name, categories[item.CategoryID-1].Name);
                }
                Console.WriteLine();
            }
        }

        private void ej8(){
            double avg = 0;
            foreach (var prod in productsWithOutVat) {
                double finalPrice = prod.Price + (prod.Price * currentVat[prod.VatID - 1].Value);
                avg += finalPrice;
            }
            avg = avg / productsWithOutVat.Count;
            Console.WriteLine("El precio medio de todos los productos es: {0}", avg);
        }

        private void coolestEj8() {
            Console.WriteLine((productsWithOutVat.Select(x => x.Price + (x.Price * currentVat[x.VatID-1].Value)).Aggregate((x, y) => x + y))/productsWithOutVat.Count);
        }

        private void coolestEj9() {
            productsWithOutVat.Where(x => x.Price <= 100).Select(x => x.Price + (x.Price * currentVat[x.VatID - 1].Value));
        }

        private void ej10() {
            Console.WriteLine("El precio con el valor más alto es :{0}", productsWithOutVat.Select(x => x.Price).Max());

            double ptrResult=0;
            foreach (var item in productsWithOutVat.OrderBy(x => x.Price)) {
                Console.WriteLine("{0}: [ {1} euros ]", item.Name, item.Price);
                ptrResult = item.Price;
            }
            Console.WriteLine("El precio más alto entonces, seria el último elemento al que apunta el puntero: {0}", ptrResult);
        }

        private void ej11() {
            var grouped = productsWithOutVat.OrderBy(x => x.Price);
            Console.WriteLine("{0}:({1} euros)",grouped.Last().Name, grouped.Last().Price);
        }

        private void ej12(string categoryName) {
            foreach (var item in productsWithOutVat.Where(x => categories[x.CategoryID-1].Name.Equals(categoryName))) {
                Console.WriteLine(item.Name);
            }
        }

        private void ej13() {
            foreach (var item in cart) {
                Console.WriteLine("{0}: {1} eur/ud, cantidad:{2} , precio final:{3} euros", item.Key.Name, item.Key.Price+(item.Key.Price*currentVat[item.Key.VatID-1].Value), item.Value, item.Key.Price + (item.Key.Price * currentVat[item.Key.VatID - 1].Value)* item.Value);
            }
        }

        private void ej14() {
            double result = 0;
            foreach (var item in cart) {
                result += item.Key.Price + (item.Key.Price * currentVat[item.Key.VatID-1].Value);
            }
            Console.WriteLine("El precio final de la compra es: {0} euros", result);
        }

        private void ej15() {
            var sorted = cart.OrderBy(x => x.Value);
            Console.WriteLine("{0}:{1}", sorted.Last().Key.Name, sorted.Last().Value);
        }

        private void ej16() {
            var sorted = cart.OrderBy(x => (x.Value * x.Key.Price));
            Console.WriteLine("{0}:{1} eur/ud, cantidad={2}, {3} euros gastados en total en este producto", sorted.Last().Key.Name, sorted.Last().Key.Price, sorted.Last().Value, (sorted.Last().Key.Price * sorted.Last().Value));
        }

        //Nota* Creo que solo he usado el precio + IVA aplicado cuando se ha indicado en el
        //pdf, por lo que he interpretado, por ejemplo en este último ejercicio, tal vez uno de los productos comprados
        //tenga un IVA aplicado mayor que otro producto, y eso al final influya para decidir si es el producto en el que
        // más dinero se ha gastado.

        static void Main(string[] args)
        {
            Modelo datos = new Modelo();
            //datos.ej1(2);
            //datos.ej2();
            //datos.ej3();
            //datos.ej4();
            //datos.ej5();
            //datos.ej7();
            //datos.ej8();
            //datos.coolestEj8();
            //datos.coolestEj9();
            //datos.ej10();
            //datos.ej11();
            //datos.ej12("Gadgets");
            //datos.ej13();
            //datos.ej14();
            //datos.ej15();
            //datos.ej16();
        }
    }
}