using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimoLaboratorio
{
    [Serializable]
    public class Base_de_Datos
    {
        public List<Pelicula> Pelicula;
        public List<Persona> Persona;
        public List<Estudio> Estudio;
        public List<PeliculaActor> PeliculaActor;
        public List<PeliculaProductor> PeliculaProductor;

        public Base_de_Datos(List<Pelicula> MiPelicula, List<Persona> MiPersona, List<Estudio> MiEstudio, List<PeliculaActor> MiPeliculaActor, List<PeliculaProductor> MiPeliculaProductor)
        {
            Pelicula = MiPelicula;
            Persona = MiPersona;
            Estudio = MiEstudio;
            PeliculaActor = MiPeliculaActor;
            PeliculaProductor = MiPeliculaProductor;
        }
    }
}
