using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Practica3
{
    class Program
    {
        static void Main(string[] args)
        {
            Intervalo a = new Intervalo(1,2);
            Console.WriteLine(a.Ancho());
            try
            {
                Intervalo b = new Intervalo(5, 3);
                Console.WriteLine(a.Mayor(b));
            }
            catch (ArgumentException e)
            {
                Console.Error.WriteLine(e.Message);
            }
            finally {
                Console.WriteLine("Esto sale siempre, mítico finally");
            }

            Barra bar = new Barra(1,2,3);
        }
    }
}
