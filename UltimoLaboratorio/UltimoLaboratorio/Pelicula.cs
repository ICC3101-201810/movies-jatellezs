using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimoLaboratorio
{
    [Serializable]
    public class Pelicula
    {
        public string Nombre;
        public Director Director;
        public string FechaEstreno;
        public string Descripcion;
        public int Presupuesto;
        public Estudio Estudio;
        public List<Critica> Critica;

        public Pelicula(string MiNombre, Director MiDirector, string MiFechaEstreno, string MiDescripcion, int MiPresupuesto, Estudio MiEstudio)
        {
            Nombre = MiNombre;
            Director = MiDirector;
            FechaEstreno = MiFechaEstreno;
            Descripcion = MiDescripcion;
            Presupuesto = MiPresupuesto;
            Estudio = MiEstudio;
            Critica = new List<Critica>();
        }
    }
}
