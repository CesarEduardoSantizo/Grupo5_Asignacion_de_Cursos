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
    public partial class agregar_catedratico : Form
    {
        public agregar_catedratico()
        {
            InitializeComponent();
        }

        private void agregar_catedratico_Load(object sender, EventArgs e)
        {

        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            homeadmi nuevoFormulario = new homeadmi();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btn_estudiantes_Click(object sender, EventArgs e)
        {
            agregarestudiante nuevoFormulario = new agregarestudiante();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btn_catedratico_Click(object sender, EventArgs e)
        {
            agregar_catedratico nuevoFormulario = new agregar_catedratico();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void lbl_carrera_Click(object sender, EventArgs e)
        {

        }

        private void txt_nombres_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_agregar_estudiante_Click(object sender, EventArgs e)
        {

        }
    }
}
