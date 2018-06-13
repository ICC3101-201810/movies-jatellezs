using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace UltimoLaboratorio
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region "Datos"
            /*List<Estudio> Estudios = new List<Estudio>();
            Estudio e = new Estudio("Lucas Films", "Aqui", "Hoy");
            Estudios.Add(e);

            List<Persona> Personas = new List<Persona>();
            Director d = new Director("Joaquin", "Tellez", "1995", "naci");
            Actor a = new Actor("Joaquin", "Sim", "1996", "nose");
            Productor pr = new Productor("Jats", "Tell", "1998", "buena");
            Personas.Add(d);
            Personas.Add(a);
            Personas.Add(pr);

            List<Pelicula> Peliculas = new List<Pelicula>();
            Pelicula p = new Pelicula("Star Wars", d, "2018", " ", 100, e);
            Peliculas.Add(p);

            List<PeliculaActor> Pactor = new List<PeliculaActor>();
            PeliculaActor pa = new PeliculaActor(p, a);
            Pactor.Add(pa);

            List<PeliculaProductor> Pproductor = new List<PeliculaProductor>();
            PeliculaProductor pp = new PeliculaProductor(p, pr);
            Pproductor.Add(pp);

            Base_de_Datos Data = new Base_de_Datos(Peliculas, Personas, Estudios, Pactor, Pproductor);
            

            using (Stream stream = new FileStream("Data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Data);
                stream.Close();
            }*/
            #endregion

            Base_de_Datos Data = null;
            try
            {
                using (Stream stream = new FileStream("Data.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    IFormatter formatter = new BinaryFormatter();
                    Data = (Base_de_Datos)formatter.Deserialize(stream);
                    stream.Close();
                }
            }
            catch (IOException)
            {

            }

            

            Application.Run(new Form1(Data));
        }
    }
}
