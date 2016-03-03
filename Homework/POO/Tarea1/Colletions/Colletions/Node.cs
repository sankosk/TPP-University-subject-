using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colletions
{
    /// <summary>
    /// Node class
    /// </summary>
    public class Node
    {
        public Object value { get; protected internal set; }
        public Node next { get; protected internal set; }

        public Node(Object value, Node next)
        {
            this.value = value;
            this.next = next;
        }

    }
}
