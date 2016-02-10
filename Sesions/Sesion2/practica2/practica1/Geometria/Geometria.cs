using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    /// <summary>
    /// Clase para representar un punto en un espacio 2D
    /// </summary>
    public class Punto2d {
        public double x { get; protected internal set; }
        public double y { get; protected internal set; }
        public Color c  { get; protected internal set; }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="laX">Punto x en el espacio euclideo</param>
        /// <param name="laY">Punto y en el espacio euclideo</param>
        /// <param name="elColor">Color, tipo enumerado donde definiremos el color</param>
        public Punto2d(double laX, double laY, Color elColor) {
            x = laX;
            y = laY;
            c = elColor;
        }

        /// <summary>
        /// Distancia entre 2 puntos
        /// </summary>
        /// <param name="a">Punto al que llegar</param>
        /// <returns></returns>
        public double distancia(Punto2d a) {
            return Math.Sqrt((x - a.x) * (x - a.x) + (y - a.y) * (y - a.y));
        }

        /// <summary>
        /// Método toString que mostrará la información genérica de la Clase
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("x=");
            sb.Append(x);
            sb.Append(", y=");
            sb.Append(y);
            sb.Append(", Color=");
            sb.Append(c);
            return sb.ToString();
        }
    }

    public class Recta {
        /// <summary>
        /// Atributo para definir m en la ecuacion de la recta
        /// </summary>
        public double m { get; protected internal set; }
        /// <summary>
        /// Atributo para definir n en la ecuación de la recta
        /// </summary>
        public double n { get; protected internal set; }

        /// <summary>
        /// Constructor con parametros para la Recta
        /// </summary>
        /// <param name="m">punto origen, Valor doble</param>
        /// <param name="n">punto destino, Valor doble</param>
        public Recta(double laM, double laN) {
            this.m = laM;
            this.n = laN;
        }

        /// <summary>
        /// Método para calcular el punto en el que se produce la intersección de una recta
        /// </summary>
        /// <param name="b">Recta a intersectar</param>
        /// <returns>Un punto</returns>
        public Punto2d interseccionRecta(Recta b) { 
            double corteY = ((n/m) - (b.n/b.m))/((1/m)-(1/b.m));
            double corteX = (corteY - b.n)/b.m;
            return new Punto2d(corteX, corteY, Color.Negro);
        }

        /// <summary>
        /// Método para calcular la perpendicular de un punto, devuelve una recta(perpendicular)
        /// </summary>
        /// <param name="punto">Punto desde el que se obtiene la recta perpendicular</param>
        /// <returns>Una recta</returns>
        public Recta perpendicular(Punto2d punto) {
            double nuevaM = (-1 / m);
            double nuevaN = ((punto.y + (1 / m) * punto.x));
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
            sb.Append("y=" + m + "x" + "+" + n);

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
