using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimoLaboratorio
{
    [Serializable]
    public class PeliculaProductor
    {
        public Pelicula Pelicula;
        public Productor Productor;

        public PeliculaProductor(Pelicula MiPelicula, Productor MiProductor)
        {
            Pelicula = MiPelicula;
            Productor = MiProductor;
        }
    }
}
