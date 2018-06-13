using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace UltimoLaboratorio
{
    class Controller
    {
        Base_de_Datos Data;
        Principal main;

        public Controller(Base_de_Datos Datos, Principal MiMain)
        {
            Data = Datos;
            main = MiMain;
            main.OnCrear += main_OnCrear;
            main.AgregarPelicula += main_AgregarPelicula;
            main.AgregarEstudio += main_AgregarEstudio;
        }

        private void main_OnCrear(object sender, PersonaEventArgs e)
        {
            if(e.tipo == "Director")
            {
                Director dir = new Director(e.nombre, e.apellido, e.fecha, e.biografia);
                Data.Persona.Add(dir);
            }
            else if(e.tipo == "Actor")
            {
                Actor act = new Actor(e.nombre, e.apellido, e.fecha, e.biografia);
                Data.Persona.Add(act);
            }
            else if(e.tipo == "Productor")
            {
                Productor pro = new Productor(e.nombre, e.apellido, e.fecha, e.biografia);
                Data.Persona.Add(pro);
            }
            using (Stream stream = new FileStream("Data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Data);
                stream.Close();
            }
        }

        private void main_AgregarPelicula(object sender, PeliculaEventArgs e)
        {
            Pelicula pel = new Pelicula(e.nombre, e.director, e.fecha, e.descripcion, e.presupuesto, e.estudio);
            Data.Pelicula.Add(pel);
            using (Stream stream = new FileStream("Data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Data);
                stream.Close();
            }
        }

        private void main_AgregarEstudio(object sender, EstudioEventArgs e)
        {
            Estudio estudio = new Estudio(e.nombre, e.direccion, e.fecha);
            Data.Estudio.Add(estudio);
            using (Stream stream = new FileStream("Data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Data);
                stream.Close();
            }
        }
    }
}
