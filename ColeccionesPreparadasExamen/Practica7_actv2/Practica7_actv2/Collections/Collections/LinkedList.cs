using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

/// <summary>
/// Author: Esteban Montes Morales
/// Subject: TPP at uniovi
/// </summary>
namespace Collections
{
    /// <summary>   
    /// LinkedList Class
    /// </summary>
    public class LinkedList<T> : IEnumerable<T>
    {

        public Node<T> head { get; private set; }
        private int numOfElements { get; set; }

        public int NumOfElements {
            get { return numOfElements; }
            set { if (value >= 0) numOfElements = value; } //else numOfElements = 0; }
        }

        public LinkedList() {
            head = null;
            NumOfElements = 0;
        }

        /// <summary>
        /// Method for get a node by an index
        /// </summary>
        /// <param name="index">The position of the node you want to get</param>
        /// <returns>The wanted Node</returns>
        private Node<T> getNode(int index)
        {
            //precondition: index>=0, whatever is not necessary
            //if index<0, node=null
            Node<T> node = head;
            int pos = 0;

            while (pos < index)
            {
                node = node.next;
                pos++;
            }

            return node;
        }

        public virtual void add(T value)
        {
            int auxSize = numOfElements;

            if (isEmpty())
                head = new Node<T>(value, null);
            else {
                Node<T> last = getNode(size() - 1);
                last.next = new Node<T>(value, null);
            }
            numOfElements++;
            Debug.Assert(checkINC(auxSize, numOfElements), "[Postcondition]: Se ha añadido un elemento");
        }

        public void add(int index, T value)
        {
            int auxSize = numOfElements;
            //precondition: index>=0 && index<size
            if (index >= 0 && index < size())
            {
                if (isEmpty())
                    head = new Node<T>(value, null);
                else if (index == 0)
                {
                    head = new Node<T>(value, head.next);
                }
                else {
                    Node<T> previous = getNode(index - 1);
                    previous.next = new Node<T>(value, previous.next);
                }
                numOfElements++;
                Debug.Assert(checkINC(auxSize, numOfElements), "[Postcondition]: Se ha añadido un elemento");
            }
        }

        public T get(int index)
        {
            //getNode is correctly validated
            return getNode(index).value;
        }

        public void set(int index, T value)
        {
            //geNode is correctly validated
            getNode(index).value = value;
        }

        /// <summary>
        /// Method that extract all indexes(position) of a value and return all as a int[] array
        /// </summary>
        /// <param name="value"></param>
        /// <returns>An array of integers</returns>
        public int[] allIndexesOf(T value)
        {
            return (from num in Enumerable.Range(0, numOfElements).ToArray() where getNode(num).value.Equals(value) select num).ToArray();
        }

        public int indexOf(T value)
        {
            int indexOf = -1;

            for (int i = 0; i < numOfElements; i++)
            {
                if (getNode(i).value.Equals(value))
                {
                    indexOf = i;
                    return indexOf;
                }
            }

            return indexOf;
        }

        public bool isEmpty()
        {
            return (numOfElements == 0);
        }

        public virtual T remove(T value)
        {
            Node<T> currentNode = null;
            if (size() != 0)
            {
                int auxSize = NumOfElements;
                int index = indexOf(value);
                if (index != -1)
                {
                    currentNode = getNode(index);
                    if (index != 0)
                    {
                        Node<T> previous = getNode(index - 1);
                        previous.next = currentNode.next;
                    }
                    else {
                        head = head.next;
                    }
                    numOfElements--;
                    Debug.Assert(checkINC(auxSize, numOfElements), "[Postcondition]: Se ha borrado un elemento");
                }
            }
            return currentNode.value;
        }

        /// <summary>
        /// Remove all elements with the same value
        /// </summary>
        /// <param name="value">An array of objects(removed elements)</param>
        /// <returns></returns>
        public T[] removeAllValues(T value)
        {
            int[] indexes = allIndexesOf(value);
            T[] result = new T[indexes.Length];

            for (int i = 0; i < indexes.Length; i++)
            {
                result[i] = removeByIndex(indexes[i]);
                indexes = (from j in indexes.Select(x => x - 1) select j).ToArray();
            }

            return result;
        }

        public T removeByIndex(int index)
        {
            int auxSize = numOfElements;

            //empty or out of limits
            if (isEmpty() || index < 0 || index >= size())
            {
                return default(T);
            }

            T value;
            if (index == 0)
            {
                value = head.value;
                head = head.next;
            }
            else {
                Node<T> previous = getNode(index - 1);
                value = previous.next.value;
                previous.next = previous.next.next;
            }

            numOfElements--;
            Debug.Assert(checkINC(auxSize, numOfElements), "[Postcondition]: Se han eliminado los elementos con ese valor");
            return value;

        }

        private bool checkINC(int a, int b) {
            return ((a > b && a - b == 1) || (a < b && b - a == 1));
        }

        public int size()
        {
            return numOfElements;
        }



        public override String ToString()
        {
            StringBuilder sb = new StringBuilder("[");
            Node<T> node = head;

            for (int i = 0; i < size(); i++)
            {
                if (i == size() - 1)
                    sb.Append(node.value.ToString());
                else
                    sb.Append(node.value.ToString()).Append(", ");

                node = node.next;
            }
            sb.Append("]");

            return sb.ToString();
        }

        public Boolean contains(T element)
        {
            for (int i = 0; i < size(); i++)
            {
                if (getNode(i).value.Equals(element))
                    return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < NumOfElements; i++) {
                yield return get(i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    public static class Extensors {

        public static T Search<T> (this IEnumerable<T> collection, Predicate<T> checkPredicate) {
            for (int i = 0; i < collection.Count(); i++){
                if (checkPredicate(collection.ElementAt(i)))
                    return collection.ElementAt(i);
            }
            return default(T);
        }

        public static T[] oneLineFilter<T>(this IEnumerable<T> collection, Predicate<T> checkPredicate) {
            return (from i in Enumerable.Range(0, collection.Count()).ToArray() where checkPredicate(collection.ElementAt(i)) select collection.ElementAt(i)).ToArray();
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Predicate<T> checkPredicate) {
            LinkedList<T> list = new LinkedList<T>();
            foreach (var it in collection) {
                if (checkPredicate(it))
                    list.add(it);
                    //list.Add(it); // yield return
            }
            return list;
        }

        public static IEnumerable<T> Map<T>(this IEnumerable<T> collection, Func<T, T> toApply) {
            LinkedList<T> list = new LinkedList<T>();
            foreach (var it in collection)
                list.add(toApply(it));

            return list;
        }
        public static T[] oneLineMap<T>(this IEnumerable<T> collection, Func<T, T> toApply) {
            return (from i in Enumerable.Range(0, collection.Count()).ToArray() select toApply(collection.ElementAt(i))).ToArray();
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action){
            foreach (T item in collection)
                action(item);
        }

        public static void ForEachOdd<T>(this IEnumerable<T> collection, Action<T> action)
        {
            int n = collection.Count();
            for (int i = 0; i < n; i++)
            {
                if (i % 2 != 0)
                    action(collection.Skip(i).First());
            }
        }

        public static void ForEachNth<T>(this IEnumerable<T> collection, Action<T> action, int n)
        {
            int tam = collection.Count();
            for (int i = 0; i < n; i++)
            {
                if (i % n == 0)
                    action(collection.Skip(i).First());
            }
        }

        public static void ForEachPred<T>(this IEnumerable<T> collection, Action<T> action, Func<bool> pred)
        {
            int n = collection.Count();
            for (int i = 0; i < n; i++)
            {
                if (pred())
                    action(collection.Skip(i).First());
            }
        }

        public static T Reduce<T>(this IEnumerable<T> collection, Func<T, T, T> funct){
            T seed = default(T);
            foreach (var i in collection){
                seed = funct(i, seed);
            }
            return seed;
        }

        public static T[] ConvertToArray<T>(this IEnumerable<T> collection) {
            return collection.ToArray();
        }

        // Para reproducir el Reduce Inverso simplemente tenemos que hacer el reverse de la collecion
        // que se le pasa como parámetro.

    }
}
