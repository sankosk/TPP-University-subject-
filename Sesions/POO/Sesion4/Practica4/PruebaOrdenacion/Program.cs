using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4
{
    class Program
    {
        static void Main(string[] args)
        {
            Par<int>[] p = new Par<int>[10];
            Random random = new Random();

            for (int i = 0; i < p.Length; i++ ){
                p[i] = new Par<int>(random.Next(0,20), random.Next(0,20));
            }

            Console.WriteLine("Sin Ordenar:");
            foreach(var i in p){
                Console.WriteLine(i);
            }
            Console.WriteLine("#########################");

            Algorithms.Sort(p);

            Console.WriteLine("Ordenado:");
            foreach(var i in p){
                Console.WriteLine(i);
            }
            Console.WriteLine("#########################");
            Console.WriteLine("Maximo: {0}", Algorithms.Max(p));

        }
    }
}
