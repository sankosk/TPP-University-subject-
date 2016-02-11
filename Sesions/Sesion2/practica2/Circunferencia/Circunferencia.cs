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
            //Recta r = new Recta(centro.x, centro.y);
            //r.perpendicular(punto);
            return null;
        }

        public static Circunferencia operator<(Circunferencia a, Circunferencia b){
            return null;
        }

        public static Circunferencia operator >(Circunferencia a, Circunferencia b){
            return null;
        }


        ~Circunferencia() {
            Console.WriteLine("Se ha ejecutado el destructor de la clase Circunferencia");
        }

    }
}
