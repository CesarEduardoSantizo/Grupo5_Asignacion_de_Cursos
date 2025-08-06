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
    public partial class FrmHomeEstudiantes : Form
    {
        public FrmHomeEstudiantes()
        {
            InitializeComponent();
        }

        private void pnl_home_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_notas_Click(object sender, EventArgs e)
        {

        }

        private void FrmHomeEstudiantes_Load(object sender, EventArgs e)
        {

        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            FrmInscripcion nuevoFormulario = new FrmInscripcion();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btnIrInscipcion_Click(object sender, EventArgs e)
        {
            FrmInscripcion nuevoFormulario = new FrmInscripcion();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btnAsignacion_Click(object sender, EventArgs e)
        {
            FrmAsignacion nuevoFormulario = new FrmAsignacion();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btnAsignacion1_Click(object sender, EventArgs e)
        {
            FrmAsignacion nuevoFormulario = new FrmAsignacion();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btnPensum1_Click(object sender, EventArgs e)
        {
            FrmPensumEstudiante nuevoFormulario = new FrmPensumEstudiante();
            nuevoFormulario.Show();
            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btnPensum_Click(object sender, EventArgs e)
        {
            FrmPensumEstudiante nuevoFormulario = new FrmPensumEstudiante();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            FrmNotas nuevoFormulario = new FrmNotas();
            nuevoFormulario.Show();
            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btnNotas1_Click(object sender, EventArgs e)
        {
            FrmNotas nuevoFormulario = new FrmNotas();
            nuevoFormulario.Show();
            this.Hide(); // o this.Close(); si quieres cerrarlo
        }
    }
}
