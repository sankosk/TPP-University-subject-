using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canciones
{
    public static class Extensors
    {

        public static T Search<T>(this IEnumerable<T> collection, Predicate<T> checkPredicate)
        {
            for (int i = 0; i < collection.Count(); i++)
            {
                if (checkPredicate(collection.ElementAt(i)))
                    return collection.ElementAt(i);
            }
            return default(T);
        }

        public static T[] oneLineFilter<T>(this IEnumerable<T> collection, Predicate<T> checkPredicate)
        {
            return (from i in Enumerable.Range(0, collection.Count()).ToArray() where checkPredicate(collection.ElementAt(i)) select collection.ElementAt(i)).ToArray();
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Predicate<T> checkPredicate)
        {
            List<T> list = new List<T>();
            foreach (var it in collection)
            {
                if (checkPredicate(it))
                    list.Add(it);
                //list.Add(it); // yield return
            }
            return list;
        }

        public static IEnumerable<T> Map<T>(this IEnumerable<T> collection, Func<T, T> toApply)
        {
            List<T> list = new List<T>();
            foreach (var it in collection)
                list.Add(toApply(it));

            return list;
        }
        public static T[] oneLineMap<T>(this IEnumerable<T> collection, Func<T, T> toApply)
        {
            return (from i in Enumerable.Range(0, collection.Count()).ToArray() select toApply(collection.ElementAt(i))).ToArray();
        }

        public static void ForEachN<T>(this IEnumerable<T> collection, Action<T>[] action) {
            foreach (T item in collection)
                foreach (var x in action)
                    x(item);
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
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

        public static T Reduce<T>(this IEnumerable<T> collection, Func<T, T, T> funct)
        {
            T seed = default(T);
            foreach (var i in collection)
            {
                seed = funct(i, seed);
            }
            return seed;
        }

        public static T[] ConvertToArray<T>(this IEnumerable<T> collection)
        {
            return collection.ToArray();
        }

        public static IEnumerable<T> ej4<T>(this IEnumerable<T> collection, int i, int? n=default(int)) {
            if (i < 0 || i >= n || n >= collection.Count() || i >= collection.Count()) throw new IndexOutOfRangeException();
            List<T> result = new List<T>();

            if (n == default(int)) n = collection.Count();
            for (int k = i; k < n; k++)
                result.Add(collection.ToArray()[k]);
            return result;
        }

    }
}
