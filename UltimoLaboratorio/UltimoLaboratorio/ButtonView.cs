using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace UltimoLaboratorio
{
    public partial class ButtonView : Form
    {
        public event EventHandler<CrearCriticaEventArgs> OnCritica;
        public event EventHandler<PPEventArgs> AsignarProductor;
        public event EventHandler<PAEventArgs> AsignarActor;

        Base_de_Datos Data;
        string tipo;

        public ButtonView(Base_de_Datos Datos, string tipos)
        {
            Data = Datos;
            tipo = tipos;
            InitializeComponent();
            Controller2 controller2 = new Controller2(Data, this);
            label12.Hide();
            listBox4.Hide();
            listBox2.Hide();
            label9.Hide();
            label10.Hide();
            textBox8.Hide();
            textBox9.Hide();

            if (tipo == "Peliculas")
            {
                textBox1.Show();
                textBox2.Show();
                textBox3.Hide();
                textBox4.Show();
                textBox5.Show();
                textBox6.Show();
                textBox7.Show();
                label2.Text = "Fecha de Estreno";
                label5.Text = "Descripcion";
                label1.Show();
                label2.Show();
                label3.Hide();
                label4.Show();
                label5.Show();
                label6.Show();
                label7.Show();
                label8.Hide();
                button3.Hide();
                button4.Hide();
                button5.Show();
                button6.Hide();
                foreach (Pelicula p in Data.Pelicula)
                {
                    listBox1.Items.Add(p.Nombre);
                }
                label11.Text = "Staff";
                label12.Show();
                listBox4.Show();
            }
            else if (tipo == "Actores")
            {
                textBox1.Show();
                textBox2.Show();
                textBox3.Show();
                textBox4.Hide();
                textBox5.Show();
                textBox6.Hide();
                textBox7.Hide();
                label2.Text = "Apellido";
                label3.Text = "Fecha de Nacimiento";
                label5.Text = "Biografia";
                label1.Show();
                label2.Show();
                label3.Show();
                label4.Hide();
                label5.Show();
                label6.Hide();
                label7.Hide();
                label8.Hide();
                button3.Hide();
                button4.Show();
                button5.Hide();
                button6.Hide();
                foreach (Persona a in Data.Persona)
                {
                    if(a.GetType().Name == "Actor")
                    {
                        listBox1.Items.Add(a.Nombre + " " + a.Apellido);
                    }
                }
                label11.Text = "Peliculas Actuadas";
            }
            else if(tipo == "Directores")
            {
                textBox1.Show();
                textBox2.Show();
                textBox3.Show();
                textBox4.Hide();
                textBox5.Show();
                textBox6.Hide();
                textBox7.Hide();
                label2.Text = "Apellido";
                label3.Text = "Fecha de Nacimiento";
                label5.Text = "Biografia";
                label1.Show();
                label2.Show();
                label3.Show();
                label4.Hide();
                label5.Show();
                label6.Hide();
                label7.Hide();
                label8.Hide();
                button3.Hide();
                button4.Hide();
                button5.Hide();
                button6.Hide();
                foreach (Persona d in Data.Persona)
                {
                    if(d.GetType().Name == "Director")
                    {
                        listBox1.Items.Add(d.Nombre + " " + d.Apellido);
                    }
                }
                label11.Text = "Peliculas Dirigidas";
            }
            else if(tipo == "Productores")
            {
                textBox1.Show();
                textBox2.Show();
                textBox3.Show();
                textBox4.Hide();
                textBox5.Show();
                textBox6.Hide();
                textBox7.Hide();
                label2.Text = "Apellido";
                label3.Text = "Fecha de Nacimiento";
                label5.Text = "Biografia";
                label1.Show();
                label2.Show();
                label3.Show();
                label4.Hide();
                label5.Show();
                label6.Hide();
                label7.Hide();
                label8.Hide();
                button3.Show();
                button4.Hide();
                button5.Hide();
                button6.Hide();
                foreach (Persona pr in Data.Persona)
                {
                    if(pr.GetType().Name == "Productor")
                    {
                        listBox1.Items.Add(pr.Nombre + " " + pr.Apellido);
                    }
                }
                label11.Text = "Peliculas Producidas";
            }
            else if(tipo == "Estudios")
            {
                textBox1.Show();
                textBox2.Show();
                textBox3.Show();
                textBox4.Hide();
                textBox5.Hide();
                textBox6.Hide();
                textBox7.Hide();
                label2.Text = "Direccion";
                label3.Text = "Fecha de Apertura";
                label1.Show();
                label2.Show();
                label3.Show();
                label4.Hide();
                label5.Hide();
                label6.Hide();
                label7.Hide();
                label8.Hide();
                button3.Hide();
                button4.Hide();
                button5.Hide();
                button6.Hide();
                foreach (Estudio e in Data.Estudio)
                {
                    listBox1.Items.Add(e.Nombre);
                }
                label11.Text = "Peliculas Producidas";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            if(listBox1.SelectedIndex >= 0 && listBox1.SelectedIndex < listBox1.Items.Count)
            {
                if (tipo == "Peliculas")
                {
                    foreach (Pelicula p in Data.Pelicula)
                    {
                        if(listBox1.SelectedItem.ToString() == p.Nombre)
                        {
                            textBox1.Text = p.Nombre;
                            textBox2.Text = p.FechaEstreno;
                            textBox4.Text = p.Presupuesto.ToString();
                            textBox5.Text = p.Descripcion;
                            textBox6.Text = p.Director.Nombre + " " + p.Director.Apellido;
                            textBox7.Text = p.Estudio.Nombre;
                            listBox3.Items.Add("Director: " + p.Director.Nombre + " " + p.Director.Apellido);
                            foreach(Critica c in p.Critica)
                            {
                                listBox4.Items.Add(c.Emisor + ": ");
                                listBox4.Items.Add(c.Mensaje);
                                listBox4.Items.Add(" ");
                            }
                            break;
                        }
                    }
                    foreach(PeliculaActor pa in Data.PeliculaActor)
                    {
                        if(listBox1.SelectedItem.ToString() == pa.Pelicula.Nombre)
                        {
                            listBox3.Items.Add("Actor: " + pa.Actor.Nombre + " " + pa.Actor.Apellido);
                        }
                    }
                    foreach(PeliculaProductor pp in Data.PeliculaProductor)
                    {
                        if(listBox1.SelectedItem.ToString() == pp.Pelicula.Nombre)
                        {
                            listBox3.Items.Add("Productor: " +  pp.Productor.Nombre + " " + pp.Productor.Apellido);
                        }
                    }
                }
                else if (tipo == "Actores")
                {
                    foreach (Persona a in Data.Persona)
                    {
                        if(listBox1.SelectedItem.ToString().Split(' ')[0] == a.Nombre && listBox1.SelectedItem.ToString().Split(' ')[1] == a.Apellido && a.GetType().Name.ToString() == "Actor")
                        {
                            textBox1.Text = a.Nombre;
                            textBox2.Text = a.Apellido;
                            textBox3.Text = a.FechaNacimiento;
                            textBox5.Text = a.Biografia;
                        }
                    }
                    foreach(PeliculaActor pa in Data.PeliculaActor)
                    {
                        if (listBox1.SelectedItem.ToString().Split(' ')[0] == pa.Actor.Nombre && listBox1.SelectedItem.ToString().Split(' ')[1] == pa.Actor.Apellido)
                        {
                            listBox3.Items.Add(pa.Pelicula.Nombre);
                        }
                    }
                }
                else if (tipo == "Directores")
                {
                    foreach (Persona d in Data.Persona)
                    {
                        if (listBox1.SelectedItem.ToString().Split(' ')[0] == d.Nombre && listBox1.SelectedItem.ToString().Split(' ')[1] == d.Apellido && d.GetType().Name.ToString() == "Director")
                        {
                            textBox1.Text = d.Nombre;
                            textBox2.Text = d.Apellido;
                            textBox3.Text = d.FechaNacimiento;
                            textBox5.Text = d.Biografia;
                        }
                    }
                    foreach(Pelicula p in Data.Pelicula)
                    {
                        if (listBox1.SelectedItem.ToString().Split(' ')[0] == p.Director.Nombre && listBox1.SelectedItem.ToString().Split(' ')[1] == p.Director.Apellido)
                        {
                            listBox3.Items.Add(p.Nombre);
                        }
                    }
                }
                else if (tipo == "Productores")
                {
                    foreach (Persona pr in Data.Persona)
                    {
                        if (listBox1.SelectedItem.ToString().Split(' ')[0] == pr.Nombre && listBox1.SelectedItem.ToString().Split(' ')[1] == pr.Apellido && pr.GetType().Name.ToString() == "Productor")
                        {
                            textBox1.Text = pr.Nombre;
                            textBox2.Text = pr.Apellido;
                            textBox3.Text = pr.FechaNacimiento;
                            textBox5.Text = pr.Biografia;
                            button3.Show();
                        }
                    }
                    foreach(PeliculaProductor pp in Data.PeliculaProductor)
                    {
                        if (listBox1.SelectedItem.ToString().Split(' ')[0] == pp.Productor.Nombre && listBox1.SelectedItem.ToString().Split(' ')[1] == pp.Productor.Apellido)
                        {
                            listBox3.Items.Add(pp.Pelicula.Nombre);
                        }
                    }
                }
                else if (tipo == "Estudios")
                {
                    foreach (Estudio es in Data.Estudio)
                    {
                        if(listBox1.SelectedItem.ToString() == es.Nombre)
                        {
                            textBox1.Text = es.Nombre;
                            textBox2.Text = es.Direccion;
                            textBox3.Text = es.FechaApertura;
                        }
                    }
                    foreach(Pelicula p in Data.Pelicula)
                    {
                        if(listBox1.SelectedItem.ToString() == p.Estudio.Nombre)
                        {
                            listBox3.Items.Add(p.Nombre);
                        }
                    }
                }
                this.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Stream stream = new FileStream("Data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Data);
                stream.Close();
            }
            Principal main = new Principal(Data);
            main.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Stream stream = new FileStream("Data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Data);
                stream.Close();
            }
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            foreach(Pelicula p in Data.Pelicula)
            {
                listBox2.Items.Add(p.Nombre);
            }
            listBox2.Show();
            label8.Show();
            button6.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            foreach (Pelicula p in Data.Pelicula)
            {
                listBox2.Items.Add(p.Nombre);
            }
            listBox2.Show();
            label8.Show();
            button6.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label9.Show();
            label10.Show();
            textBox8.Show();
            textBox9.Show();
            label8.Show();
            button6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button3.Visible)
            {
                PPEventArgs pp = new PPEventArgs();
                foreach(Pelicula pel in Data.Pelicula)
                {
                    if(pel.Nombre == this.listBox2.SelectedItem.ToString())
                    {
                        pp.pelicula = pel;
                        break;
                    }
                }
                foreach(Persona pr in Data.Persona)
                {
                    if(pr.Nombre == this.listBox1.SelectedItem.ToString().Split(' ')[0] && pr.Apellido == this.listBox1.SelectedItem.ToString().Split(' ')[1] && pr.GetType().Name.ToString() == "Productor")
                    {
                        Productor pr2 = new Productor(pr.Nombre, pr.Apellido, pr.FechaNacimiento, pr.Biografia);
                        pp.productor = pr2;
                        break;
                    }
                }
                AsignarProductor(this, pp);
            }
            else if (button4.Visible)
            {
                PAEventArgs pa = new PAEventArgs();
                foreach (Pelicula pel in Data.Pelicula)
                {
                    if (pel.Nombre == this.listBox2.SelectedItem.ToString())
                    {
                        pa.pelicula = pel;
                        break;
                    }
                }
                foreach (Persona ac in Data.Persona)
                {
                    if (ac.Nombre == this.listBox1.SelectedItem.ToString().Split(' ')[0] && ac.Apellido == this.listBox1.SelectedItem.ToString().Split(' ')[1] && ac.GetType().Name.ToString() == "Actor")
                    {
                        Actor ac2 = new Actor(ac.Nombre, ac.Apellido, ac.FechaNacimiento, ac.Biografia);
                        pa.actor = ac2;
                        break;
                    }
                }
                AsignarActor(this, pa);
            }
            else if (button5.Visible)
            {
                CrearCriticaEventArgs cc = new CrearCriticaEventArgs();
                foreach (Pelicula pel in Data.Pelicula)
                {
                    if (pel.Nombre == this.listBox1.SelectedItem.ToString())
                    {
                        cc.pelicula = pel;
                        break;
                    }
                }
                cc.emisor = textBox8.Text;
                cc.mensaje = textBox9.Text;
                OnCritica(this, cc);
            }
            MessageBox.Show("Operacion Exitosa!");
            this.Refresh();
        }
    }
}
