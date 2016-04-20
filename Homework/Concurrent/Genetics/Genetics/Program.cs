using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetics
{
    public class GenProgram
    {
        public const char ADENINA = 'A';
        public const char TIMINA = 'T';
        public const char CITOSINA = 'C';
        public const char GUANINA = 'G';

        public static void Main(string[] args)
        {

            //SuperBasic Test
            char[] vector = new char[] { 'A', 'B', 'G', 'T', 'A' };
            foreach (var x in vector) Console.Write(x);
            Console.WriteLine();

            int threadLimit = 10;
            for (int i=0; i<threadLimit; i++) {
                Console.WriteLine("Ejecutandose con {0} hilos:", i);
                Master master = new Master(vector, 3);
                char[] toFound = new char[] { 'G', 'T' };
                double results = master.ComputeModulus(toFound);
                Console.WriteLine("<<{0}>>(gen) en <<{1}>>(cromosoma): {2} aparación/es.", toFound.SpecialToString(), vector.SpecialToString(), results);
            }

            Console.WriteLine();
            Console.WriteLine();

            //Context-Switching
            threadLimit = 50;
            char[] vector2 = CreateRandomGeneticString(1000000);
            char[] gens = CreateRandomGeneticString(9);
            String[] lines = new String[threadLimit];
            for (int i=1; i<= threadLimit; i++) {
                Console.WriteLine("Thread Number: {0}", i);
                Master master = new Master(vector2, i);
                DateTime before = DateTime.Now;
                double result = master.ComputeModulus(gens);
                DateTime after = DateTime.Now;
                double ticks = (after - before).Ticks;
                Console.WriteLine("Result: {0}, ticks={1}", result, ticks, result);
                lines[i-1] = prepareDataToCSV(i, result, ticks);
                GC.Collect();
                GC.WaitForFullGCComplete();
            }

            ExportToCSV(@"C:\Users\Esteban\Desktop\fichero.csv", lines);


        }

        public static char[] CreateRandomGeneticString(int seedSize)
        {
            char[] ADN = { ADENINA, TIMINA, CITOSINA, GUANINA };
            char[] result = new char[seedSize];
            Random r = new Random();

            for (int i = 0; i < seedSize; i++){
                result[i] = ADN[r.Next(0, ADN.Length)];
            }

            return result;
        }


        public static String prepareDataToCSV(int threadN, double result, double ticksNumber){
            return ""+threadN+";"+result+";"+ticksNumber+";";
        }

        public static void ExportToCSV(String path, String[] lines) {
            System.IO.File.WriteAllLines(path, lines);
        }

    }


    public static class Extensors
    {
        public static String SpecialToString(this char[] str) {
            String result = "";
            foreach (char x in str) result += x;
            return result;
        }
    }
}
