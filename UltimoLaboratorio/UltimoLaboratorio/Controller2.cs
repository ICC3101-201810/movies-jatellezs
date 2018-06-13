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
    class Controller2
    {
        Base_de_Datos Data;
        ButtonView Vista;

        public Controller2(Base_de_Datos Datos, ButtonView MiVista)
        {
            Data = Datos;
            Vista = MiVista;
            Vista.OnCritica += Vista_OnCritica;
            Vista.AsignarActor += Vista_AsignarActor;
            Vista.AsignarProductor += Vista_AsignarProductor;
        }

        private void Vista_OnCritica(object sender, CrearCriticaEventArgs e)
        {
            Critica crit = new Critica(e.emisor, e.mensaje);
            foreach(Pelicula p in Data.Pelicula)
            {
                if(p.Nombre == e.pelicula.Nombre)
                {
                    p.Critica.Add(crit);
                    break;
                }
            }
            using (Stream stream = new FileStream("Data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Data);
                stream.Close();
            }
        }

        private void Vista_AsignarActor(object sender, PAEventArgs e)
        {
            PeliculaActor peliculaActor = new PeliculaActor(e.pelicula, e.actor);
            Data.PeliculaActor.Add(peliculaActor);
            using (Stream stream = new FileStream("Data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Data);
                stream.Close();
            }
        }

        private void Vista_AsignarProductor(object sender, PPEventArgs e)
        {
            PeliculaProductor peliculaProductor = new PeliculaProductor(e.pelicula, e.productor);
            Data.PeliculaProductor.Add(peliculaProductor);
            using (Stream stream = new FileStream("Data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Data);
                stream.Close();
            }
        }
    }
}
