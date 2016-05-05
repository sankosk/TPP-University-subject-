using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vector1 = { 1,1,1,1,1};
            int[] vector2 = {1,2,3,4,5};

            int threadLimit = 10;
            for (int i = 0; i < threadLimit; i++) {
                Console.WriteLine("Ejecutandose con {0} hilos:", i);
                Master master = new Master(vector1, 3);
                Console.WriteLine(master.ComputeModulus(vector2));

            }

        }
    }
}
