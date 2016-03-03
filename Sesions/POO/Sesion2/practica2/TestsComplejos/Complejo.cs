using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsComplejos
{
    class Complejo
    {
        public double R { get; protected internal set; }
        public double I { get; protected internal set; }



        public Complejo(double p1, double p2){
            R = p1;
            I = p2;
        }

        internal Complejo Conjugado(){
            return new Complejo(R, -I);
        }

        internal double Modulo()
        {
            return Math.Sqrt((R*R)+(I*I));
        }

        public static Complejo operator+(Complejo a, Complejo b){
            return new Complejo(a.R + b.R, a.I + b.I);
        }
    }
}
