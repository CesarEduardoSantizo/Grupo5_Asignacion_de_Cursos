//sergio izeppi
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginadmi
{
    public partial class Facultades : Form
    {
        public Facultades()
        {
            InitializeComponent();
        }

        private void Facultades_Load(object sender, EventArgs e)
        {

        }

        private void pnl_home_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            homeadmi nuevoFormulario = new homeadmi();

            nuevoFormulario.Show();

            this.Hide();
        }

        private void btn_agregar4_Click(object sender, EventArgs e)
        {
            Facultades2 nuevoFormulario = new Facultades2();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btn_agregar6_Click(object sender, EventArgs e)
        {
            Carreras nuevoFormulario = new Carreras();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btn_agregar5_Click(object sender, EventArgs e)
        {
            Pensum nuevoFormulario = new Pensum();
            nuevoFormulario.Show();
            this.Hide();
        }
    }
}