using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimoLaboratorio
{
    public class PPEventArgs : EventArgs
    {
        public Productor productor { get; set; }
        public Pelicula pelicula { get; set; }
    }
}
