using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimoLaboratorio
{
    [Serializable]
    public class Estudio
    {
        public string Nombre;
        public string Direccion;
        public string FechaApertura;

        public Estudio(string MiNombre, string MiDireccion, string MiFechaApertura)
        {
            Nombre = MiNombre;
            Direccion = MiDireccion;
            FechaApertura = MiFechaApertura;
        }
    }
}
