using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Practica3
{
    public class Barra:Intervalo
    {
        public double alto { get; protected internal set; }

        public Barra(): base() { 
            alto = 0;
        }

        public Barra(double? a, double? b, double c):base(a,b) {
            if (c < 0) throw new ArgumentException("Parámetro incorrecto para el constructor de Barra");
            else    alto = c;
        }
        new bool Check() {
            return base.Check() && alto >= 0;
        }

        public double? Area() {
            Debug.Assert(Check());
            if (base.Ancho() == null && alto == null)
                return null;
            return base.Ancho() * alto;
        }

        public override bool Equals(object obj)
        {
            Barra auxB = obj as Barra;
            if (auxB == null) return false;
            else    return (alto==auxB.alto && auxB.Ancho() == Ancho() && auxB.Area() == Area());
        }

        public override int GetHashCode(){
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        //checker si el intervalo se ha hecho bien: interseccion
        public static Barra operator *(Barra a, Barra b){
            double newAlto = 0;
            if (a.alto <= b.alto)
                newAlto = a.alto;
            else
                newAlto = b.alto;

            Intervalo c = new Intervalo(a.izq, a.dch) * new Intervalo(b.izq, b.dch);
            return new Barra(c.izq, c.dch, newAlto);

        }
    }
}
