using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica1;

namespace Circunferencia
{
    public class Circunferencia{
        public Punto2d centro { get; protected internal set; }
        public double radio { get; protected internal set; }

        public Circunferencia(Punto2d elCentro, double elRadio) {
            centro = elCentro;
            radio = elRadio;
        }

        public Circunferencia tangenteCentro(Punto2d punto){

            return null;
        }

        public static Circunferencia operator<(Circunferencia a, Circunferencia b){
            return new Circunferencia(new Punto2d(10,20, Color.Negro), 15);
        }

        public static Circunferencia operator >(Circunferencia a, Circunferencia b){
            return new Circunferencia(new Punto2d(10, 20, Color.Negro), 15);
        }


        ~Circunferencia() {
            Console.WriteLine("Se ha ejecutado el destructor de la clase Circunferencia");
        }


        //public static Complejo operator+(Complejo a, Complejo b){


    }
}
