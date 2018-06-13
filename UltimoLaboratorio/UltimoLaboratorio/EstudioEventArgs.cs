using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimoLaboratorio
{
    public class EstudioEventArgs : EventArgs
    {
        public string nombre { get; set; }
        public string fecha { get; set; }
        public string direccion { get; set; }
    }
}
