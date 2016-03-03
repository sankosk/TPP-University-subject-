using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperbolicFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            Hyperbolic<int> h = new Hyperbolic<int>(10);
            int[] a = Hyperbolic<int>.genRndArray(10);
            int[] evensOfA = Hyperbolic<int>.arrayOfEvens(a);
            foreach (int i in a) {
                System.Console.WriteLine(i);
            }
            System.Console.WriteLine("Número de pares: {0}", Hyperbolic<int>.countEvens(evensOfA));

            Console.WriteLine(Hyperbolic<double>.ComposeDouble(x => Math.Exp(x), y => Math.Log(y))(3));
            Console.WriteLine(Hyperbolic<double>.composeD(x => Math.Exp(x), y => Math.Log(y))(3));
            Console.WriteLine(Hyperbolic<double>.composeG(x => Math.Exp(x), y=> Math.Log(y))(3));
            Console.WriteLine(Hyperbolic<double>.nextChar('a'));
        }
    }
}
