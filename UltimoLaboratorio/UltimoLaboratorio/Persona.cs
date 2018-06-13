using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimoLaboratorio
{
    [Serializable]
    public abstract class Persona
    {
        public string Nombre;
        public string Apellido;
        public string FechaNacimiento;
        public string Biografia;

        public Persona(string MiNombre, string MiApellido, string MiFechaNacimiento, string MiBiografia)
        {
            Nombre = MiNombre;
            Apellido = MiApellido;
            FechaNacimiento = MiFechaNacimiento;
            Biografia = MiBiografia;
        }

        public string GetNombre()
        {
            return Nombre;
        }

        public string GetApellido()
        {
            return Apellido;
        }
    }
}
