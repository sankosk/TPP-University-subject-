using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica1;

namespace practica2
{
    class Program
    {

        public class CalculosTrayectos {
            //PRACTICA 2 METHODS

            public static void incrementaDosDouble(ref double x, ref double y, double x1, double y1)
            {
                x += x1;
                y += y1;
            }

            public static Punto2d[] generaTrayecto(int longitud = 10, double laX = 0.0, double laY = 0.0, double incX = 1.0, double incY = 1.0){
                Punto2d[] trayecto = new Punto2d[longitud];
                trayecto[0] = new Punto2d(laX, laY, Color.Rojo);

                for (int i = 0; i < longitud - 1; i++){
                    incrementaDosDouble(ref laX, ref laY, incX, incY);
                    trayecto[i] = new Punto2d(laX, laY, Color.Rojo);
                }
                return trayecto;
            }

            public static void muestraTrayecto(Punto2d[] trayecto, bool? mostrar)
            {
                if (mostrar == true)
                {
                    Punto2d[] primerCuadrante = (from punto in trayecto where punto.x >= 0 && punto.y >= 0 select punto).ToArray();
                    Console.WriteLine("PRIMER CUADRANTE:");
                    foreach (Punto2d p in primerCuadrante)
                    {
                        Console.WriteLine(p);
                    }
                }
                else
                {
                    Console.WriteLine("TODOS LOS PUNTOS:");
                    foreach (Punto2d p in trayecto)
                    {
                        Console.WriteLine(p);
                    }
                }
            }

            public static double getLongitud(Punto2d[] trayecto)
            {
                double resultado = 0;
                for (int i = 0; i < trayecto.Length - 1; i++){
                    resultado += trayecto[i].distancia(trayecto[i+1]);
                }

                return resultado;
            }

            public static void getLongitudInicioFin(Punto2d[] trayecto, out double longitud, out Punto2d principio, out Punto2d final){
                longitud = getLongitud(trayecto);
                principio = new Punto2d(trayecto[0].x, trayecto[0].y, Color.Rojo);
                final = new Punto2d(trayecto.Last().x, trayecto.Last().y, Color.Negro);

                Console.WriteLine("Longitud: {0}", longitud);
                Console.WriteLine("Punto inicial: {0}", principio);
                Console.WriteLine("Longitud: {0}", final);
            }

            //END PRACTICA 2 METHODS
        }

        static void Main(string[] args)
        {

            // LONGITUD
            Punto2d[] trayecto = { new Punto2d(1, 2, Color.Negro), new Punto2d(4, 2, Color.Negro), new Punto2d(4, 10, Color.Negro)};
            Console.WriteLine("LONGITUD: {0}", CalculosTrayectos.getLongitud(trayecto));   

            //LONGITUD INICIO FIN
            double longitud = 10;
            Punto2d inicial = new Punto2d(1,1,Color.Transparente);
            Punto2d final = new Punto2d(2,2,Color.Transparente);
            CalculosTrayectos.getLongitudInicioFin(trayecto, out longitud, out inicial, out final);
        }

    }
}
