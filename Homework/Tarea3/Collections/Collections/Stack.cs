using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

//programación por contratos // diseño por contratos
namespace Collections
{
    public class Stack<T>
    {
        public LinkedList<T> listOfElems { get; protected internal set; }
        private uint maxNumOfElements; //invariant: max size >= number of elements >= 0

        public uint MaxNumOfElements {
            get { return maxNumOfElements; }
            set { if (value >= listOfElems.NumOfElements) maxNumOfElements = value; } //pre-condition
        }

        public Stack( uint maxNumOfElements) {
            listOfElems = new LinkedList<T>();
            MaxNumOfElements = maxNumOfElements;
            Debug.Assert(isEmpty, "[Postcondition]: Se ha creado el Stack");   
        }

        public void Push(T element) {
            if (!isFull) //precondition: can add elems if stack is full
                listOfElems.add(element);

            //postcondition: if you add an element, the stack cant be empty
            Debug.Assert(!isEmpty, "[Postcondition]: Se ha añadido un elemento, El stack ya no esta vacio");
        }

        public T Pop() {
            //precondition: Stack size have to be > 0, cant be empty
            if (!isEmpty){
                return listOfElems.removeByIndex(listOfElems.NumOfElements - 1);
                Debug.Assert(isFull, "[Postcondition]: Se ha borrado un elemento, por tanto no puede estar llena");
            }
            return default(T);
        }

        public bool isFull {
            get { return (MaxNumOfElements == listOfElems.NumOfElements); }
        }

        public bool isEmpty {
            get { return (listOfElems.NumOfElements == 0); }
        }

    }
}
