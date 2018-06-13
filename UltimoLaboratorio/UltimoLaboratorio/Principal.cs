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
    public partial class Principal : Form
    {
        public event EventHandler<PersonaEventArgs> OnCrear;
        public event EventHandler<PeliculaEventArgs> AgregarPelicula;
        public event EventHandler<EstudioEventArgs> AgregarEstudio;

        Base_de_Datos Data;

        public Principal(Base_de_Datos Datos)
        {
            Data = Datos;
            InitializeComponent();
            Controller controlador = new Controller(Data, this);
            listBox1.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            numericUpDown1.Hide();
            textBox5.Hide();
            comboBox1.Hide();
            comboBox2.Hide();
            groupBox1.Hide();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            button9.Hide();
            button10.Hide();
            button11.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tipo;
            tipo = "Peliculas";
            ButtonView view = new ButtonView(Data, tipo);
            view.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tipo;
            tipo = "Actores";
            ButtonView view = new ButtonView(Data, tipo);
            view.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tipo;
            tipo = "Directores";
            ButtonView view = new ButtonView(Data, tipo);
            view.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tipo;
            tipo = "Productores";
            ButtonView view = new ButtonView(Data, tipo);
            view.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tipo;
            tipo = "Estudios";
            ButtonView view = new ButtonView(Data, tipo);
            view.Show();
            this.Close();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void Buscador_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if(Buscador.Text.Length >= 3)
            {
                string busqueda = this.Buscador.Text.ToLower();
                string finder = null;
                listBox1.Items.Add("Personas: ");
                int i = 0;
                while (i <= 50)
                {
                    foreach (Persona o in Data.Persona)
                    {
                        if (o.Nombre.ToLower().Contains(busqueda) || o.Apellido.ToLower().Contains(busqueda))
                        {
                            finder = o.GetType().Name.ToString() + ": " + o.Nombre + " " + o.Apellido;
                            listBox1.Items.Add(finder);
                            i++;
                        }
                    }

                    listBox1.Items.Add("Peliculas: ");
                    foreach (Pelicula p in Data.Pelicula)
                    {
                        if (p.Nombre.ToLower().Contains(busqueda) || p.Descripcion.ToLower().Contains(busqueda))
                        {
                            finder = p.Nombre + ": " + p.Descripcion;
                            listBox1.Items.Add(finder);
                            i++;
                        }
                    }

                    listBox1.Items.Add("Estudios: ");
                    foreach (Estudio es in Data.Estudio)
                    {
                        if (es.Nombre.ToLower().Contains(busqueda) || es.Direccion.ToLower().Contains(busqueda))
                        {
                            finder = es.Nombre + ": " + es.Direccion;
                            listBox1.Items.Add(finder);
                            i++;
                        }
                    }
                    break;
                }
                listBox1.Show();
            }
            else
            {
                listBox1.Hide();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Show();
            textBox2.Show();
            textBox3.Show();
            textBox5.Hide();
            comboBox1.Hide();
            comboBox2.Hide();
            numericUpDown1.Hide();
            label2.Text = "Direccion";
            label3.Text = "Fecha de Apertura";
            label2.Show();
            label1.Show();
            label3.Show();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            button9.Show();
            button10.Hide();
            button11.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Show();
            textBox2.Show();
            textBox3.Show();
            textBox5.Show();
            groupBox1.Show();
            comboBox1.Hide();
            comboBox2.Hide();
            numericUpDown1.Hide();
            label2.Text = "Apellido";
            label3.Text = "Fecha de nacimiento";
            label7.Text = "Biografia";
            label2.Show();
            label7.Show();
            label3.Show();
            label1.Show();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            button10.Show();
            button9.Hide();
            button11.Hide();            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Show();
            textBox2.Show();
            textBox3.Hide();            
            textBox5.Show();
            numericUpDown1.Show();
            foreach(Persona p in Data.Persona)
            {
                if(p.GetType().Name == "Director")
                {
                    comboBox1.Items.Add(p.Nombre + " " + p.Apellido);
                }
            }
            foreach(Estudio est in Data.Estudio)
            {
                comboBox2.Items.Add(est.Nombre);
            }
            comboBox1.Show();
            comboBox2.Show();
            groupBox1.Hide();
            label2.Text = "Fecha de lanzamiento";
            label7.Text = "Descripcion";
            label2.Show();
            label7.Show();
            label5.Show();
            label6.Show();
            label1.Show();
            label3.Hide();
            label4.Show();
            button11.Show();
            button9.Hide();
            button10.Hide();           
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PeliculaEventArgs peli = new PeliculaEventArgs();
            peli.nombre = this.textBox1.Text;
            peli.fecha = this.textBox2.Text;
            peli.presupuesto = Convert.ToInt32(this.numericUpDown1.Value);
            peli.descripcion = this.textBox5.Text;
            foreach (Persona pe in Data.Persona)
            {
                if (this.comboBox1.Text.Split(' ')[0] == pe.Nombre && this.comboBox1.Text.Split(' ')[1] == pe.Apellido && pe.GetType().Name == "Director")
                {
                    Director pe2 = new Director(pe.Nombre, pe.Apellido, pe.FechaNacimiento, pe.Biografia);
                    peli.director = pe2;
                    break;
                }
            }
            foreach (Estudio estu in Data.Estudio)
            {
                if (this.comboBox2.Text == estu.Nombre)
                {
                    peli.estudio = estu;
                    break;
                }
            }
            AgregarPelicula(this, peli);
            MessageBox.Show("Operacion Exitosa!");
            
            this.Refresh();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PersonaEventArgs per = new PersonaEventArgs();
            per.nombre = this.textBox1.Text;
            per.apellido = this.textBox2.Text;
            per.fecha = this.textBox3.Text;
            per.biografia = this.textBox5.Text;
            foreach (RadioButton rad in groupBox1.Controls.OfType<RadioButton>())
            {
                if (rad.Checked)
                {
                    per.tipo = rad.Text;
                }
            }
            OnCrear(this, per);
            MessageBox.Show("Operacion Exitosa!");
            this.Refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            EstudioEventArgs estudio = new EstudioEventArgs();
            estudio.nombre = this.textBox1.Text;
            estudio.direccion = this.textBox2.Text;
            estudio.fecha = this.textBox3.Text;
            AgregarEstudio(this, estudio);
            MessageBox.Show("Operacion Exitosa!");
            this.Refresh();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (Stream stream = new FileStream("Data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Data);
                stream.Close();
            }
            Application.Exit();
        }
    }
}
