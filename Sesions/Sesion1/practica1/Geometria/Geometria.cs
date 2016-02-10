using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    //*NOTA: No se han implementado getters ni setters, esta tarea la he desarrollado durante la primera práctica de TPP
    // donde básicamente estabamos haciendo una toma de contacto con el lenguaje
    /// <summary>
    /// Clase para representar un punto en un espacio 2D
    /// </summary>
    public class Punto2d {
        public double x;
        public double y;
        public Color c;

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="laX">Punto x en el espacio euclideo</param>
        /// <param name="laY">Punto y en el espacio euclideo</param>
        /// <param name="elColor">Color, tipo enumerado donde definiremos el color</param>
        public Punto2d(double laX, double laY, Color elColor) {
            this.x = laX;
            this.y = laY;
            this.c = elColor;
        }

        /// <summary>
        /// Distancia entre 2 puntos
        /// </summary>
        /// <param name="a">Punto al que llegar</param>
        /// <returns></returns>
        public double distancia(Punto2d a) {
            return Math.Sqrt((this.x - a.x) * (this.x - a.x) + (this.y - a.y) * (this.y - a.y));
        }

        /// <summary>
        /// Método toString que mostrará la información genérica de la Clase
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("x=");
            sb.Append(this.x);
            sb.Append(", y=");
            sb.Append(this.y);
            sb.Append(", Color=");
            sb.Append(this.c);
            return sb.ToString();
        }
    }

    public class Recta {
        /// <summary>
        /// Atributo para definir m en la ecuacion de la recta
        /// </summary>
        public double m;
        /// <summary>
        /// Atributo para definir n en la ecuación de la recta
        /// </summary>
        public double n;

        /// <summary>
        /// Constructor con parametros para la Recta
        /// </summary>
        /// <param name="m">punto origen, Valor doble</param>
        /// <param name="n">punto destino, Valor doble</param>
        public Recta(double m, double n) {
            this.m = m;
            this.n = n;
        }

        /// <summary>
        /// Método para calcular el punto en el que se produce la intersección de una recta
        /// </summary>
        /// <param name="b">Recta a intersectar</param>
        /// <returns>Un punto</returns>
        public Punto2d interseccionRecta(Recta b) { 
            double corteY = ((this.n/this.m) - (b.n/b.m))/((1/this.m)-(1/b.m));
            double corteX = (corteY - b.n)/b.m;
            return new Punto2d(corteX, corteY, Color.Negro);
        }

        /// <summary>
        /// Método para calcular la perpendicular de un punto, devuelve una recta(perpendicular)
        /// </summary>
        /// <param name="punto">Punto desde el que se obtiene la recta perpendicular</param>
        /// <returns>Una recta</returns>
        public Recta perpendicular(Punto2d punto) {
            double nuevaM = (-1 / this.m);
            double nuevaN = ((punto.y + (1 / this.m) * punto.x));
            return new Recta(nuevaM, nuevaN);
        }

        /// <summary>
        /// Método para calcular la distancia entre una recta y un punto
        /// </summary>
        /// <param name="a">a es el Punto desde el que se calculara la distancia hacia la recta, para ello hacemos uso
        /// de los anteriores métodos
        /// </param>
        /// <returns>Retorna un valor doble, que será la distancia entre dicha recta y punto</returns>
        public double distanciaEntreRectaYPunto(Punto2d a){
            Recta rectaAux = perpendicular(a);
            Punto2d interseccion = interseccionRecta(rectaAux);
            return a.distancia(interseccion);
        }

        /// <summary>
        /// Método redefinido para mostrar la información de la clase como nosotros gustemos o requiramos
        /// </summary>
        /// <returns>Devuelve un String</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("y=" + this.m + "x" + "+" + this.n);

            return sb.ToString();
        }

        /// <summary>
        /// Destructor que liberara la memoria, en este caso no es muy util puesto que no tenemos recursos suficientes para usarlo
        /// Igualmente, es un ejemplo de uso
        /// </summary>
        ~Recta()
        {
            System.Diagnostics.Trace.WriteLine("Se ha llamado al destructor de Recta");
        }
    }

    /// <summary>
    /// Enumerado donde definimos los colores disponibles para nuestras formas geométricas
    /// </summary>
    public enum Color { 
        /// <summary>
        /// Color transparente
        /// </summary>
        Transparente, 
        /// <summary>
        /// Color negro
        /// </summary>
        Negro,
        /// <summary>
        /// Color rojo
        /// </summary>
        Rojo
    };


}
