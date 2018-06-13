using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimoLaboratorio
{
    [Serializable]
    public class Productor : Persona
    {
        

        public Productor(string MiNombre, string MiApellido, string MiFechaNacimiento, string MiBiografia) :
            base (MiNombre, MiApellido, MiFechaNacimiento, MiBiografia)
        {
            
        }
    }
}
