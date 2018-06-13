using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimoLaboratorio
{
    public class PAEventArgs : EventArgs
    {
        public Actor actor { get; set; }
        public Pelicula pelicula { get; set; }
    }
}
