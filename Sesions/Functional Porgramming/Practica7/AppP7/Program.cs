using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P7Lib;
using System.Diagnostics;

namespace AppP7
{
    class Program
    {
        static void Main(string[] args)
        {
            PerfectSquares p = new PerfectSquares();
            Console.WriteLine(p.IsPerfectSquare(3));


            Console.WriteLine("#################");
            var crono = new Stopwatch();
            crono.Start();
            foreach (int i in p.EagerPerfectSquares(10, 100)) Console.WriteLine(i);
            crono.Stop();
            long ticksEager = crono.ElapsedTicks;
            Console.WriteLine("Eager version: {0:N} ticks.", ticksEager);

            Console.WriteLine("################");
            var crono1 = new Stopwatch();
            crono1.Start();
            foreach (int i in p.LazyPerfectSquares(10, 100)) Console.WriteLine(i);
            crono1.Stop();
            long ticksEager1 = crono1.ElapsedTicks;
            Console.WriteLine("Lazy version: {0:N} ticks.", ticksEager1);


            Console.WriteLine("#########   TEST FOREACH    #######");
            int[] t = Enumerable.Range(0, 20).ToArray();
            t.ForEach(Console.Write, integer => Console.Write(", "));
            Console.WriteLine();
            t.ForEachOdd((x) => Console.Write("{0} ", x));
            Console.WriteLine();
            //t.ForEachNth();


            Console.WriteLine("############### LAST EXERCISE ##############");


            int[] testArray = {1,9,6,5,8,7,85,8,4,5,2,33,5,66,8,5,4,2,5,5,2,1,4,5,2,6};
            int[] testArray2 = {5,6,8,95,2,1,5,6,3,1,4,5,8,9,6,3,2,5,6,54,87,1,4,52,3};

            //max value
            Console.WriteLine(testArray.Aggregate((x, y) => x>y ? x: y));

            //difference
            testArray.Where(x => !testArray2.Contains(x)).ForEach(x => Console.Write("{0}, ", x));
            Console.WriteLine();

            //duplicates
            int[] withoutDuplicates = testArray.GroupBy(x => x).Select(y => y.FirstOrDefault()).ToArray();
            withoutDuplicates.ForEach(x => Console.Write("{0}, ", x));

            //s^2
            Console.WriteLine();
            int media = (testArray.Aggregate((x, y) => x+y))/testArray.Length;
            int varianza = (testArray.Aggregate((x, y) => ((x-media)*(x-media)) + ((y-media)*(y-media))))/testArray.Length;
            Console.WriteLine(varianza);

            //Last exercise
            Console.WriteLine();
            Console.WriteLine(testArray.Where((x) => x % 2 == 0).Select((x) => x*x).Aggregate((x, y) => x+y));

        }
    }
}
