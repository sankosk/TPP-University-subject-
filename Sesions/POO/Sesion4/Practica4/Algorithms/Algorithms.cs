﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica4 {


    public static class Algorithms {

        static public void Sort<T>(T[] vector) where T: IComparable<T> {
            for (int i=0; i<vector.Length; i++)
                for (int j = vector.Length-1; j > i; j--)
                    if (vector[i].CompareTo(vector[j]) >0) {
                        T aux = vector[i];
                        vector[i] = vector[j];
                        vector[j] = aux;
                    }
        }

        static public T Max<T>(T[] vector) where T: IComparable<T> {
            T aux = vector[0];
            for (int i = 1; i < vector.Length; i++ ){
                if (vector[i].CompareTo(aux)>0)
                    aux = vector[i];
            }
            return aux;
        }
    }


    //Implementar aqui función Max, devuelve T
}
