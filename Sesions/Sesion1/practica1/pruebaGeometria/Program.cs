using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    class Program
    {
        static void Main(string[] args)
        {
            //DISTANCIA ENTRE PUNTOS
            Punto2d a = new Punto2d(10, 20, Color.Negro);
            Punto2d b = new Punto2d(20, 10, Color.Rojo);

            Console.WriteLine("Punto A: {0} || Punto B: {1}", a.ToString(), b.ToString());
            Console.WriteLine("La distancia entre el punto A y el punto B es => {0}", a.distancia(b));

            //INTERSECCIÓN RECTA
            Recta y0 = new Recta(50, 60);
            Recta y1 = new Recta(60, 50);

            Console.WriteLine("Intersección de las rectas se produce en el punto: {0}", y0.interseccionRecta(y1));

            //PERPENDICULAR DE UN PUNTO
            Console.WriteLine("La perpendicular del punto A es: {0}", y0.perpendicular(a));

            //DISTANCIA ENTRE RECTA Y PUNTO
            Console.WriteLine("Distancia entre la perpendicular y el punto donde intersecta: {0}", y0.distanciaEntreRectaYPunto(a));
        }
    }
}
