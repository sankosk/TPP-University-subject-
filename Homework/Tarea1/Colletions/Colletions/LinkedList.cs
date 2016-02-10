using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Author: Esteban Montes Morales
/// Subject: TPP at uniovi
/// </summary>
namespace Colletions
{
    /// <summary>
    /// LinkedList Class
    /// </summary>
    public class LinkedList : List {

        public Node head { get; private set; }
        public int counter { get; private set; }

        /// <summary>
        /// Method for get a node by an index
        /// </summary>
        /// <param name="index">The position of the node you want to get</param>
        /// <returns>The wanted Node</returns>
        private Node getNode(int index){
            Node node = head;
            int pos = 0;

            while(pos<index){
                node = node.next;
                pos++;
            }
            return node;
        }

        public void add(object value){
            if (isEmpty())
                head = new Node(value, null);
            else{
                Node last = getNode(size()-1);
                last.next = new Node(value, null);
            }
            counter++;
        }

        public void add(int index, object value){
            if (index >= 0 && index < size()){
                if (isEmpty())
                    head = new Node(value, null);
                else if (index == 0){
                    head = new Node(value, head.next);
                }
                else{
                    Node previous = getNode(index - 1);
                    previous.next = new Node(value, previous.next);
                }
                counter++;
            }
        }

        public object get(int index){
            return getNode(index).value;
        }

        public void set(int index, object value){
            getNode(index).value = value;
        }

        /// <summary>
        /// Method that extract all indexes(position) of a value and return all as a int[] array
        /// </summary>
        /// <param name="value"></param>
        /// <returns>An array of integers</returns>
        public int[] allIndexesOf(object value){
            return (from num in Enumerable.Range(0, counter).ToArray() where getNode(num).value.Equals(value) select num).ToArray();
        }

        public int indexOf(object value){
            int indexOf = -1;

            for(int i=0; i< counter; i++){
                if(getNode(i).value.Equals(value)){
                    indexOf = i;
                    return indexOf;
                }
            }

            return indexOf;
        }

        public bool isEmpty(){
            return (counter==0);
        }

        public object remove(object value){
            Node currentNode = null;
            if (size() != 0)
            {
                int index = indexOf(value);
                if (index != -1) {
                    currentNode = getNode(index);
                    if (index != 0){
                        Node previous = getNode(index - 1);
                        previous.next = currentNode.next;
                    }
                    else {
                        head = head.next;
                    }
                    counter--;
                }
            }
            return currentNode.value;
        }

        /// <summary>
        /// Remove all elements with the same value
        /// </summary>
        /// <param name="value">An array of objects(removed elements)</param>
        /// <returns></returns>
        public object[] removeAllValues(object value) {
            int[] indexes = allIndexesOf(value);
            object[] result = new object[indexes.Length];

            for (int i=0; i<indexes.Length; i++) {
                result[i] = removeByIndex(indexes[i]);
                indexes = (from j in indexes.Select(x => x - 1) select j).ToArray();
            }
            
            return result;
        }

        public object removeByIndex(int index){
            //empty or out of limits
            if(isEmpty() || index<0 || index>=size()){
                return null;
            }

            Object value;
            if (index == 0){
                value = head.value;
                head = head.next;
            }
            else{
                Node previous = getNode(index-1);
                value = previous.next.value;
                previous.next = previous.next.next;
            }

            counter--;
            return value;
            
        }

        public int size(){
            return counter;
        }

        public override String ToString(){
            StringBuilder sb = new StringBuilder("[");
            Node node = head;

            for (int i = 0; i < size(); i++){
                if(i==size()-1)
                    sb.Append(node.value.ToString());
                else
                    sb.Append(node.value.ToString()).Append(", ");

                node = node.next;
            }
            sb.Append("]");

            return sb.ToString();
        }
    }
}
