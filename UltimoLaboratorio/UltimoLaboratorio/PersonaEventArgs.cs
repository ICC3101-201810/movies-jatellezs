﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimoLaboratorio
{
    public class PersonaEventArgs : EventArgs
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string fecha { get; set; }
        public string biografia { get; set; }
        public string tipo { get; set; }

    }
}