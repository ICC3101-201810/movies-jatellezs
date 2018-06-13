using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltimoLaboratorio
{
    public partial class Form1 : Form
    {
        Timer formClose = new Timer();
        Base_de_Datos Data;

        public Form1(Base_de_Datos Datos)
        {
            Data = Datos;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            formClose.Interval = 5000;
            formClose.Tick += new EventHandler(formClose_Tick);
            formClose.Start();
        }

        void formClose_Tick(object sender, EventArgs e)
        {
            formClose.Stop();
            formClose.Tick -= new EventHandler(formClose_Tick);
            Principal main = new Principal(Data);
            this.Hide();
            main.Show();
        }
    }
}
