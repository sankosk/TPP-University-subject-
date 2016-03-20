using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    /// <summary>
    /// Node class
    /// </summary>
    public class Node<T>
    {
        public T value { get; protected internal set; }
        public Node<T> next { get; protected internal set; }

        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }

    }
}
