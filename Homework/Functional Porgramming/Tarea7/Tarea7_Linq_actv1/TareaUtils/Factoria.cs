﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace HWUtils
{

    /// <summary>
    /// Crea colecciones de objetos para hacer demos
    /// </summary>
    public class Factoria<T> {

        /// <summary>
        /// Crea una lista de personas para hacer testing
        /// </summary>
        /// <returns></returns>
        public static Persona[] CrearPersonas() {
            string[] nombres = { "María", "Juan", "Pepe", "Luis", "Carlos", "Miguel", "Cristina", "María", "Juan" };
            string[] apellidos1 = { "Díaz", "Pérez", "Hevia", "García", "Rodríguez", "Pérez", "Sánchez", "Díaz", "Hevia" };
            string[] apellidos2 = { "Rodríguez", "Pérez", "Sánchez", "Díaz", "Hevia", "Díaz", "Pérez", "Hevia", "García" };
            string[] nifs = { "9876384A", "103478387F", "23476293R", "4837649A", "67365498B", "98673645T", "56837645F", "87666354D", "9376384K" };

            Debug.Assert(nombres.Length == apellidos1.LongLength && apellidos1.Length == apellidos2.Length && apellidos2.Length == nifs.Length);
            Persona[] personas = new Persona[nombres.Length];
            for (int i = 0; i < personas.Length; i++)
                personas[i] = new Persona(nombres[i], apellidos1[i], apellidos2[i], nifs[i]);
            return personas;
        }


        /// <summary>
        /// Crea ángulos de 0 a 360 grados
        /// </summary>
        /// <returns></returns>
        public static Angulo[] CrearAngulos() {
            Angulo[] angulos = new Angulo[361];
            for(int angulo=0; angulo<=360; angulo++)
                angulos[angulo] = new Angulo(angulo/180.0*Math.PI);
            return angulos;
        }

        public static T Search(T[] collection, Predicate<T> checkPredicate)
        {
            for (int i = 0; i < collection.Length; i++){
                if (checkPredicate(collection[i]))
                    return collection[i];
            }
            return default(T);
        }

        // Using filter and implementing filter
        public static Func<T[], Predicate<T>, T[]> OneLineFilter = (x, p) => (from i in Enumerable.Range(0, x.Length) where p(x[i]) select x[i]).ToArray();
        public static List<T> Filter(T[] collection, Predicate<T> checkPredicate) {
            List<T> result = new List<T>();
            foreach (T e in collection) {
                if (checkPredicate(e))
                    result.Add(e);
            }
            return result;
        }


        public static double Reduce(Func<T, double, double> funct, T[] collection) {
            double counter = 0;
            foreach (var i in collection) {
                counter = funct(i, counter);
            }
            return counter;
        }

    }
}
 