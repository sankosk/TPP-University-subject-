using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperbolicFunctions
{
    public class Hyperbolic<T>
    {
        public double x { get; protected internal set; }
        private static Random _rndN;

        public Hyperbolic(int x1) {
            x = x1;
            _rndN = new Random();
        }

        //hyperbolic functions
        public Func<double, double> asinH = (x) => ((x*x)+1);
        public Func<double, double> acosH = (x) => ((x*x)-1);
        public Func<double, double> atanH = (x) => ((Math.Log(Math.E, 1+x) - Math.Log(Math.E, 1-x))/2);

        //Generate random array of integers
        public static Func<int, int[]> genRndArray = (n) => (from i in Enumerable.Range(0, n).ToArray() select _rndN.Next(0, 101)).ToArray();
        private static Predicate<int> isEven = (x) => (x%2==0);
        public static Func<int[], int[]> arrayOfEvens = (x) => (from i in x where isEven(i) select i).ToArray();
        public static Func<int[], int> countEvens = (x) => x.Count();

        public List<int> getPrimes(int n) {
            List<int> result = new List<int>();
            result.Add(2);

            for (int i = 0; i < n; i++ ){
                if (i < result.Max()) {
                    if (IsPrime(i) && !result.Exists(x => x % i == 0))
                        result.Add(i);
                }
            }
            return result;
        }

        public static Func<double, double> ComposeDouble(Func<double, double> f, Func<double, double> g) {
            return x => g(f(x));
        }

        public static Func<Func<double, double>, Func<double, double>, Func<double, double>> composeD = (f, g) => x => g(f(x));
        public static Func<Func<T, T>, Func<T, T>, Func<T, T>> composeG = (f, g) => x => g(f(x));

        public static Func<int, int> incN = x => x + 1;
        public static Func<char, int> toInt = x => Convert.ToInt32(x);
        public static Func<int, char> toChar = x => (char) x;

        public static Func<char, char> nextChar = x => toChar(incN(toInt(x)));
        //public static Func<char, char> siguienteChar = x => composeG(incN(toInt(x => x)), toChar(y => y))(x);

        private bool IsPrime(int num)
        {
            bool _isPrime = true;
            if (num % 2 == 0) return false;
            for (int i = 3; i <= Convert.ToInt32(Math.Sqrt(num)); i = i + 2)
            {
                if (num % i == 0)
                {
                    _isPrime = false;
                    break;
                }
            }
            return _isPrime;

        }

    }
}
