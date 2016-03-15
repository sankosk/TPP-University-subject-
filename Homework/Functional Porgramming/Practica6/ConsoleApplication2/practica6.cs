using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica6
{
    class Practica
    {

        public static void repeatUntilLoop(Func<bool> condition, Action body) {
            while (true) {
                body();
                if (condition()) break;
            }
        }

        public static Func<int> FibCl()
        {
            int x1 = 1, x2 = 1, counter = 0, next;

            return () =>
            {
                if (counter == 0 || counter == 1)
                {
                    counter++;
                    return 1;
                }
                else
                {
                    next = x1 + x2;
                    x2 = x1;
                    x1 = next;
                    counter++;
                    return next;
                }
            };
        }

        public static Predicate<int> contieneDivisores(int[] vector)
        {
            return element => {
                //bool flag=
                foreach (int i in vector)
                {
                    if (element % i == 0)
                        return true;
                }
                return false;
            };
        }

        public static IEnumerable<int> FinitePrimeGenerator(int term) {
            int prime = 2;
            int counter = term;
            while (counter >= 0) {
                yield return prime;
                prime = _nextPrime(prime);
                counter--;
            }
        }

        public static IEnumerable<int> InfinitePrimeGenerator(int fromN) {
            int prime = fromN;
            while (true) {
                yield return prime;
                prime = _nextPrime(prime);
            }
        }

        private static bool _IsPrime(int number){
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0 && i != number) return false;
            }
            return true;
        }


        private static int _nextPrime(int prime) {
            for (int i= prime+1; i<=prime* prime; i++) {
                if (_IsPrime(i))
                    return i;
            }
            return -1;
        }


        private static IDictionary<int, int> values = new Dictionary<int, int>() {
            {0, 2}
        };

        public static int MemoizedPrimes(int n)
        {
            if (values.ContainsKey(n)) return values[n];
            for (int i=values.Count; i<=n; i++) {
                values.Add(i, _nextPrime(values[values.Count-1]));
            }
            return values[n];
        }

        static void Main(string[] args)
        {
            //repeatUntil
            int a = 1;
            repeatUntilLoop(() => a>3, () => a++);
            Console.WriteLine(a);

            //Fib cl
            Func<int> c = FibCl();
            for (int i = 0; i < 10; i++)
                Console.WriteLine(c());

            //contieneDiv
            int[] b = {2,3,5};
            if (contieneDivisores(b)(10)) Console.WriteLine(true);
            if (!contieneDivisores(b)(11)) Console.WriteLine(false);

            Console.WriteLine("# FINITE PRIME GENERATOR #");
            //foreach (int i in PrimeGenerator(10))
            foreach(int i in FinitePrimeGenerator(10)) // 11 first primes
                Console.WriteLine(i);
            Console.WriteLine("#########################");

            //Console.WriteLine("# INFINITE PRIME GENERATOR #");
            //foreach (int i in InfinitePrimeGenerator(1000))
            //Console.WriteLine(i);
            //Console.WriteLine("#########################");

            Console.WriteLine(MemoizedPrimes(0)); // -> 2
            Console.WriteLine(MemoizedPrimes(4)); // -> 11

        }
    }
}
