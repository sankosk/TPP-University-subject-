using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4
{
    //Genericidad acotada: para todos los Par comparables donde cada elemento sea comparable
    public class Par<T>:IComparable<Par<T>> where T:IComparable<T>
    {
        public T firstElem { get; protected internal set;}
        public T secondElem { get; protected internal set; }


        public int CompareTo(Par<T> other)
        {

            if (firstElem.CompareTo(other.firstElem) == 0)
                return secondElem.CompareTo(other.secondElem);

            return firstElem.CompareTo(other.firstElem);
        }

        public Par() { 
            firstElem=default(T);
            secondElem = default(T);
        }

        public Par(T a, T b) {
            firstElem = a;
            secondElem = b;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[{0},{1}]", firstElem, secondElem);
            return sb.ToString();
        }

    }
}
