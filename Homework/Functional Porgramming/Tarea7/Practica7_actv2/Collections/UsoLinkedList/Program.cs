using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsoLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Usage sample
            Collections.LinkedList<int> list = new Collections.LinkedList<int>();

            //ADDING OPERATIONS
            list.add(1);
            list.add(2);
            list.add(3);
            list.add(3);
            list.add(4);
            list.add(5);
            list.add(6);
            list.add(6);
            list.add(6);
            list.add(6);

            list.add(1, 1); // adding by index
            Console.WriteLine(list.ToString());

            //REMOVE
            list.remove(1);
            list.remove(2);
            list.removeByIndex(4); //removing by index
            list.removeAllValues(6); //removing all '6' in the linkedlist
            Console.WriteLine(list.ToString());

            //INDEXOF
            Console.WriteLine("El 3 se encuentra en la posición {0}", list.indexOf(3));
            int[] indexes = list.allIndexesOf(3);
            String positions = "[ ";
            for (int i = 0; i < indexes.Length; i++)
            {
                if (i != indexes.Length - 1)
                    positions += indexes[i] + ", ";
                else
                    positions += indexes[i] + " ]";
            }
            Console.WriteLine("Estas son todas las posiciones en las que hay un 3: {0}", positions);

            //SIZE
            Console.WriteLine("El tamaño de la lista actualmente es: {0}", list.size());

            //GET/SET
            Console.WriteLine("El primer elemento de la lista es el: {0}", list.get(0));
            list.set(0, 10);
            Console.WriteLine("Ahora el primer elemento a cambiado (tras usar el setter)");
            Console.WriteLine("El primer elemento de la lista es el: {0}", list.get(0));

            /// ...
        }
    }
}
