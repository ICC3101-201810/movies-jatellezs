using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimoLaboratorio
{
    [Serializable]
    public class PeliculaActor
    {
        public Pelicula Pelicula;
        public Actor Actor;

        public PeliculaActor(Pelicula MiPelicula, Actor MiActor)
        {
            Pelicula = MiPelicula;
            Actor = MiActor;
        }
    }
}
