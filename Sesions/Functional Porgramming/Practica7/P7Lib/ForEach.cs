using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P7Lib
{
    public static class EnumerableExtensionMethods
    {

        /// <summary>
        /// Extension method to apply an action to the items in a collection
        /// </summary>
        /// <typeparam name="T">The type of the elements in the collection</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="action">The action to be performed with every element in the collection</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (T item in collection)
                action(item);
        }

        /// <summary>
        /// Extension method to apply two actions to the items in a collection
        /// </summary>
        /// <typeparam name="T">The type of the elements in the collection</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="action1">The first action to be performed with every element in the collection</param>
        /// <param name="action2">The second action to be performed with every element in the collection</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action1, Action<T> action2)
        {
            foreach (T item in collection)
            {
                action1(item);
                action2(item);
            }
        }

        public static void ForEachOdd<T>(this IEnumerable<T> collection, Action<T> action) {
            int n = collection.Count();
            for (int i = 0; i<n; i++ ){
                if (i % 2 != 0)
                    action(collection.Skip(i).First());
            }
        }

        public static void ForEachNth<T>(this IEnumerable<T> collection, Action<T> action, int n) {
            int tam = collection.Count();
            for (int i = 0; i < n; i++){
                if (i % n == 0)
                    action(collection.Skip(i).First());
            }
        }

        public static void ForEachPred<T>(this IEnumerable<T> collection, Action<T> action, Func<bool> pred) {
            int n = collection.Count();
            for (int i = 0; i < n; i++){
                if (pred())
                    action(collection.Skip(i).First());
            }
        }

    }
}
