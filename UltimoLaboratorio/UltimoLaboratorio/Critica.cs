using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimoLaboratorio
{
    [Serializable]
    public class Critica
    {
        public string Emisor;
        public string Mensaje;

        public Critica(string MiEmisor, string MiMensaje)
        {
            Emisor = MiEmisor;
            Mensaje = MiMensaje;
        }
    }
}
