using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Examen;

namespace Examen
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio 1
            Console.WriteLine("EJERCICIO 1:");
            int[] vector1 = { 1, 1, 1, 1, 1 };
            int[] vector2 = { 1, 2, 3, 4, 5 };

            int threadLimit = 10;
            for (int i = 0; i < threadLimit; i++)
            {
                Console.WriteLine("Ejecutandose con {0} hilos:", i);
                Master master = new Master(vector1, 3);
                Console.WriteLine(master.ComputeModulus(vector2));

            }
            Console.WriteLine();


            //Ejercicio 2
            Console.WriteLine("EJERCICIO 2:");
            int[] v = { 1, 2, 3, 4, 5, 6, 6, 6, 8, 9 };
            Console.WriteLine(ejercicio2(v, 6));
            Console.WriteLine();


            //Ejercicio 3
            Console.WriteLine("EJERCICIO 3:");
            int[] v1 = {1,2,3,4,5,6,7,8,9,10};
            Console.WriteLine(ejercicio3(v1));
            Console.WriteLine();

            //Ejercicio 4
            Console.WriteLine("EJERCICIO 4:");
            Console.WriteLine(ejercicio4(vector1, vector2));    //15
            Console.WriteLine();

        }

        static int ejercicio2(int[] v, int e) {
            int posicion = -1;
            Parallel.For(0, v.Length, i => {
                if (v[i] == e) posicion = i;
            });

            return posicion;
        }



        static double mean(IEnumerable<int> vector) {
            return vector.Aggregate(0.0, (acc, el) => acc + el) / (double)
            vector.Count();
        }

        static double meanX2(IEnumerable<int> vector) {
            return vector.Aggregate(0.0, (acc, el) => acc + el * el) /
            (double)vector.Count();
        }

        static double ejercicio3(int[] vector) { 
            double x1 = default(double);
            double x2 = default(double);
            double x3 = default(double);
            double x4 = default(double);


            List<int> v1 = new List<int>();
            List<int> v2 = new List<int>();

            for (int i = 0; i < vector.Length; i+=2 ){
                v1.Add(vector[i]);
            }

            for (int i = 1; i < vector.Length; i+=2){
                v2.Add(vector[i]);
            }

            Parallel.Invoke(
                () => x1 = mean(v1.ToArray()),
                () => x2 = mean(v2.ToArray()),
                () => x3 = meanX2(v1.ToArray()),
                () => x4 = meanX2(v2.ToArray())
            );

            return (x3+x4) - ((x1+x2) * (x1+x2));
        }

        static int ejercicio4(int[] v1, int[] v2){
            int s = 0;
            Parallel.For(0, Math.Max(v1.Length, v2.Length), i => Interlocked.Add(ref s, v1[i] * v2[i]));
            return s;
        }

    }
}
