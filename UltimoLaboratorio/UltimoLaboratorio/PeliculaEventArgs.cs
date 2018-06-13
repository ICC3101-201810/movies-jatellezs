using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimoLaboratorio
{
    public class PeliculaEventArgs : EventArgs
    {
        public string nombre { get; set; }
        public string fecha { get; set; }
        public string descripcion { get; set; }
        public int presupuesto { get; set; }
        public Director director { get; set; }
        public Estudio estudio { get; set; }

    }
}
