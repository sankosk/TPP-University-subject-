using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canciones
{
    public class ModeloCanciones
    {
        public class Cancion
        {
            public string TituloCancion { get; set; }
            public int Duracion { get; set; }
            public int CancionID { get; set; }
            public int FormatoID { get; set; }
        }
        class Formato
        {
            public string NombreFormato { get; set; }
            public int FormatoID { get; set; }
        }
        class Disco
        {
            public string TituloDisco { get; set; }
            public int Year { get; set; }
            public int discoID { get; set; }
            public override string ToString()
            {
                return String.Format("{0} {1}", TituloDisco, Year);
            }
        }
        class CancionDisco
        {
            public int CancionID { get; set; }
            public int DiscoID { get; set; }
        }
        class Etiqueta
        {
            public string EtiquetaS { get; set; }
            public int EtiquetaID { get; set; }
        }
        class CancionEtiqueta
        {
            public int CancionID { get; set; }
            public int EtiquetaID { get; set; }
        }
        List<Formato> formatos = new List<Formato>(){
            new Formato{NombreFormato="mp3",FormatoID=001},
            new Formato{NombreFormato="flac",FormatoID=002},
            new Formato{NombreFormato="aac",FormatoID=003}
        };
        List<Cancion> canciones = new List<Cancion>(){
            new Cancion{TituloCancion="Balada de Joe Hill",Duracion=200,CancionID=001,FormatoID=001},
            new Cancion{TituloCancion="Aturuxo",Duracion=190,CancionID=002,FormatoID=001},
            new Cancion{TituloCancion="Nos roban todo el Rato",Duracion=390,CancionID=003,FormatoID=001},
            new Cancion{TituloCancion="EL miedo va a cambiar de bando",Duracion=295,CancionID=004,FormatoID=001},
            new Cancion{TituloCancion="Que te den, Esperanza",Duracion=360,CancionID=005,FormatoID=003},
            new Cancion{TituloCancion="Allegro Moderato",Duracion=446,CancionID=006,FormatoID=002},
            new Cancion{TituloCancion="Andante",Duracion=352,CancionID=007,FormatoID=002},
            new Cancion{TituloCancion="Menuetto",Duracion=186,CancionID=008,FormatoID=002},
            new Cancion{TituloCancion="Allegro Con Spirito",Duracion=379,CancionID=009,FormatoID=002},
            new Cancion{TituloCancion="Mari",Duracion=312,CancionID=010,FormatoID=002},
            new Cancion{TituloCancion="Covadonga",Duracion=348,CancionID=011,FormatoID=002},
            new Cancion{TituloCancion="Afhe y Güelita",Duracion=1108,CancionID=012,FormatoID=002},
            new Cancion{TituloCancion="Mariyina",Duracion=877,CancionID=013,FormatoID=002},
            new Cancion{TituloCancion="Josefa - Arriba limón",Duracion=338,CancionID=014,FormatoID=002},
            new Cancion{TituloCancion="Elvira y Felita",Duracion=315,CancionID=015,FormatoID=002},
            new Cancion{TituloCancion="Divina",Duracion=697,CancionID=016,FormatoID=003},
            new Cancion{TituloCancion="Olga",Duracion=774,CancionID=017,FormatoID=003},
            new Cancion{TituloCancion="Milia",Duracion=386,CancionID=018,FormatoID=003}
        };
        List<Disco> discos = new List<Disco>(){
            new Disco{TituloDisco="Severina",Year=2015,discoID=001},
            new Disco{TituloDisco="Symphony No. 29 in A, KV 201-186a",Year=1998,discoID=002},
            new Disco{TituloDisco="Canciones como adoquines",Year=2005,discoID=003},
            new Disco{TituloDisco="Chill out Mix",Year=2000,discoID=004}
        };
        List<CancionDisco> cancionesDiscos = new List<CancionDisco>(){
            new CancionDisco{CancionID=010,DiscoID=001},
            new CancionDisco{CancionID=011,DiscoID=001},
            new CancionDisco{CancionID=012,DiscoID=001},
            new CancionDisco{CancionID=013,DiscoID=001},
            new CancionDisco{CancionID=014,DiscoID=001},
            new CancionDisco{CancionID=015,DiscoID=001},
            new CancionDisco{CancionID=016,DiscoID=001},
            new CancionDisco{CancionID=017,DiscoID=001},
            new CancionDisco{CancionID=018,DiscoID=001},
            new CancionDisco{CancionID=006,DiscoID=002},
            new CancionDisco{CancionID=007,DiscoID=002},
            new CancionDisco{CancionID=008,DiscoID=002},
            new CancionDisco{CancionID=009,DiscoID=002},
            new CancionDisco{CancionID=001,DiscoID=003},
            new CancionDisco{CancionID=002,DiscoID=003},
            new CancionDisco{CancionID=003,DiscoID=003},
            new CancionDisco{CancionID=004,DiscoID=003},
            new CancionDisco{CancionID=005,DiscoID=003},
            new CancionDisco{CancionID=011,DiscoID=004},
            new CancionDisco{CancionID=012,DiscoID=004},
            new CancionDisco{CancionID=006,DiscoID=004},
            new CancionDisco{CancionID=009,DiscoID=004}
        };
        List<Etiqueta> etiquetas = new List<Etiqueta>()
        {
            new Etiqueta{EtiquetaS="Pop",EtiquetaID=001},
            new Etiqueta{EtiquetaS="Folk",EtiquetaID=002},
            new Etiqueta{EtiquetaS="Clásica",EtiquetaID=003},
            new Etiqueta{EtiquetaS="Instrumental",EtiquetaID=004},
            new Etiqueta{EtiquetaS="Tradicional",EtiquetaID=005},
            new Etiqueta{EtiquetaS="Protesta",EtiquetaID=006},
            new Etiqueta{EtiquetaS="Rap",EtiquetaID=007}
        };
        List<CancionEtiqueta> cancionesEtiquetas = new List<CancionEtiqueta>(){
            new CancionEtiqueta{CancionID=001,EtiquetaID=006},
            new CancionEtiqueta{CancionID=001,EtiquetaID=002},
            new CancionEtiqueta{CancionID=002,EtiquetaID=002},
            new CancionEtiqueta{CancionID=003,EtiquetaID=007},
            new CancionEtiqueta{CancionID=004,EtiquetaID=007},
            new CancionEtiqueta{CancionID=005,EtiquetaID=006},
            new CancionEtiqueta{CancionID=006,EtiquetaID=003},
            new CancionEtiqueta{CancionID=007,EtiquetaID=003},
            new CancionEtiqueta{CancionID=008,EtiquetaID=003},
            new CancionEtiqueta{CancionID=009,EtiquetaID=003},
            new CancionEtiqueta{CancionID=009,EtiquetaID=004},
            new CancionEtiqueta{CancionID=010,EtiquetaID=002},
            new CancionEtiqueta{CancionID=011,EtiquetaID=002},
            new CancionEtiqueta{CancionID=012,EtiquetaID=002},
            new CancionEtiqueta{CancionID=013,EtiquetaID=002},
            new CancionEtiqueta{CancionID=014,EtiquetaID=002},
            new CancionEtiqueta{CancionID=014,EtiquetaID=005},
            new CancionEtiqueta{CancionID=015,EtiquetaID=002},
            new CancionEtiqueta{CancionID=016,EtiquetaID=002},
            new CancionEtiqueta{CancionID=017,EtiquetaID=002},
            new CancionEtiqueta{CancionID=018,EtiquetaID=002}
        };
        //Ejemplo aclaratorio de como enlazar tablas
        public void CancionesEtiquetas()
        {
            canciones.Join(cancionesEtiquetas, c => c.CancionID, e => e.CancionID,
                           (c, e) => new { TituloCancion = c.TituloCancion, EtiquetaID = e.EtiquetaID })
                .Join(etiquetas, c => c.EtiquetaID, e => e.EtiquetaID, (c, e) => new { Titulo = c.TituloCancion, EtiquetaS = e.EtiquetaS })
                    .ForEach(Console.WriteLine);
        }


        //implementar aquí métodos de ejercicios 1, 2 y 3
        public void ej1(int formato) {
            List<int> duraciones = new List<int>(canciones.Filter(x => x.FormatoID == formato).Select(x => x.Duracion));
            int media = duraciones.Reduce((x,y) => x + y) / canciones.Filter(x => x.FormatoID == formato).Count();
            Console.WriteLine(duraciones.Map(x => (x-media)*(x-media)).Sum());
        }

        //( 2 puntos) Usando funciones de LinQ, mostrar listado de etiquetas utilizadas y
        // número de canciones por etiqueta.

        public void ej2()
        {
            cancionesEtiquetas.GroupBy(x => x.EtiquetaID, p => p.CancionID,    (key, g) => new { id = key, canc = g.ToList() }).ForEach(item => Console.WriteLine("Para la etiqueta {0} tiene {1} canciones", etiquetas[item.id - 1].EtiquetaS, item.canc.Count));
        }



        //3. (2.5 puntos) Usando funciones de LinQ, mostrar cada disco y su duración.
        public void ej3() {
            var cancionesPorDisco = cancionesDiscos.Select(x => x.CancionID);
            cancionesPorDisco.Aggregate((x, y) => canciones[x-1].Duracion + canciones[y-1].Duracion);
            Console.WriteLine("Duracion por disco: ");


            foreach (var disco in cancionesDiscos.OrderBy(x => x.DiscoID)) {
                Console.WriteLine("Para el disco: {0} -> {1}", disco.CancionID);
            }
        }



        public void ejercicio3()
        {
            var result = cancionesDiscos.GroupBy(x => x.DiscoID,
                                                  y => y.CancionID,
                                                  (key, g) => new { id = key, canc = g.ToList() }

            );

            foreach (var x in result)
            {
                Console.WriteLine("Para el disco: {0}", discos[x.id - 1].TituloDisco);
                var res = x.canc.Select(i => canciones[i-1].Duracion).Sum();
                Console.WriteLine("La duracion total de las canciones es: {0}", res);
            }
        }

        public void exercise3()
        {
            var result = cancionesDiscos.GroupBy(x => x.DiscoID,
                                                  y => y.CancionID,
                                                  (key, g) => new { id = key, canc = g.ToList() }

            );

        }

        public void BucleWhile(Func<bool> condition, Action[] bodies)
        {
            if (condition())
            {
                foreach(var x in bodies)
                    x();
                BucleWhile(condition, bodies);
            }
        }


        public void ej5() {
            int i = 0;  int j = 0;
            BucleWhile(() => i < 3, new Action[] { () => BucleWhile(() => j < 5, new Action[] { () => Console.Write("[{0} {1}]", i, j), () => j++}), () => i++, () => j=0, () => Console.WriteLine()});
        }

    }
}


