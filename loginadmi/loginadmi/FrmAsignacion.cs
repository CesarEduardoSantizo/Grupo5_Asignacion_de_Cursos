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
    public partial class FrmAsignacion : Form
    {
        public FrmAsignacion()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            FrmHomeEstudiantes nuevoFormulario = new FrmHomeEstudiantes();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
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

        private void lblDatos_Click(object sender, EventArgs e)
        {

        }
    }
}
