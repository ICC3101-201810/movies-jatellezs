using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimoLaboratorio
{
    public class CrearCriticaEventArgs : EventArgs
    {
        public string emisor { get; set; }
        public string mensaje { get; set; }
        public Pelicula pelicula { get; set; }
    }
}
