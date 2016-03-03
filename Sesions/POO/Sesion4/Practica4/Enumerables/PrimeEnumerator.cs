using System;
using System.Collections;
using System.Collections.Generic;

namespace Practica4
{


    /// <summary>
    /// Class that implements a Fibonacci enumerator (iterator).
    /// </summary>
    internal class PrimeEnumerator : IEnumerator<int>
    {
        /// <summary>
        /// Index is the position of the term in the sequence.
        /// FirstTerm and secondTerm store the two last terms.
        /// SecondTerm is the current term.
        /// </summary>
        int index, secondTerm;

        /// <summary>
        /// Maximum number of elements in this enumerator (iterator).
        /// </summary>
        int elements;

        public PrimeEnumerator(int elements)
        {
            this.elements = elements;
            Reset();
        }

        /// <summary>
        /// The current term (generic version)
        /// </summary>
        int IEnumerator<int>.Current
        {
            get { return secondTerm; }
        }

        /// <summary>
        /// The current term (polymorphic method)
        /// </summary>
        object IEnumerator.Current
        {
            get { return secondTerm; }
        }

        /// <summary>
        /// Increments the enumerator (iterator) going to the following term
        /// </summary>
        /// <returns>True if the increment was successful; false if the end was reached</returns>
        public bool MoveNext()
        {
            if (index >= this.elements)
                return false;

            index++;
            if (IsPrime(index)) {
                secondTerm = index;
            }

            return true;
        }

        /// <summary>
        /// Resets the enumerator (iterator), setting it to the begining of the sequence
        /// </summary>
        public void Reset()
        {
            index = 1;
            secondTerm = 2;
        }

        /// <summary>
        /// This method is called when the object is destroyed.
        /// It is used to free its resources (nothing in this case).
        /// It must be implemented, though, because it is part of the IEnumerator.
        /// </summary>
        public void Dispose()
        {
        }

        public bool IsPrime(int num){
            bool _isPrime = true;
            if (num % 2 == 0) return false;
            for (int i = 3; i <= Convert.ToInt32(Math.Sqrt(num)); i = i + 2)
            {
                if (num % i == 0)
                {
                    _isPrime = false;
                    break;
                }
            }

            return _isPrime;

        }

        private bool isCapicua(Prime p)
        {
            String aux = "";
            foreach (var item in p)
            {
                aux = "" + item;
                if (aux.Equals(reverseString(aux)))
                    return true;
            }
            return false;
        }

        private String reverseString(String str)
        {
            String res = "";
            for (int i = 0; i < str.Length; i++)
            {
                res += str[str.Length - i];
            }
            return res;
        }

    } // PrimeEnumerator

} // namespace
