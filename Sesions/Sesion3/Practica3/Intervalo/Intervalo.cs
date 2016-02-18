using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Practica3
{
    public class Intervalo : IMedible {
        public double? izq { get; protected internal set; }
        public double? dch { get; protected internal set; }

        public Intervalo() {
            izq = null;
            dch = null;
        }

        public Intervalo(double? a, double? b) {
            #if  DEBUG
                Console.WriteLine("Constructor por defecto");
            #endif
            if (a > b)
                throw new ArgumentException("Parametro incorrecto en constructor de Intervalo");
            izq = a; 
            dch = b;
        }

        public double? Ancho() {
            Debug.Assert(Check());
            if (izq == null && dch == null)
                return null;
            else return dch - izq;
        }

        public bool Mayor(IMedible c) {
            Intervalo tmp = c as Intervalo;
            return this.Ancho()>tmp.Ancho();
            //throw new NotImplementedException();
        }

        protected internal bool Check() { 
            return (izq>dch || (izq == null && dch != null) || (izq != null && dch == null));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[{0};{1}]", izq, dch);
            return base.ToString();
        }

        public override bool Equals(object obj){
            //Intervalo tmp = obj as Intervalo;
            //if (tmp == null)    return false;
            //else return (izq == tmp.izq && dch == tmp.dch);
            if (!(obj is Intervalo))
                return false;
            else {
                Intervalo tmp = (Intervalo)obj;
                if (tmp == null)    return false;
                else    return (tmp.izq == izq && tmp.dch == dch);
            }
        }

        public override int GetHashCode(){
            return this.ToString().GetHashCode();
        }

        //Sean A=(-2,4) y B=(2,5) dos intervalos de la recta real, 
        //su unión será A∪B=(-2,5), y su intersección será A∩B=(2,4)
        public static Intervalo operator *(Intervalo a, Intervalo b){
            double? newA=0;
            if (a.izq >= b.izq)
                newA = a.izq;
            else
                newA = b.izq;

            double? newB = 0;
            if (a.dch <= b.dch)
                newB = a.dch;
            else
                newB = b.dch;

            return new Intervalo(newA, newB);
        }
    }
}
