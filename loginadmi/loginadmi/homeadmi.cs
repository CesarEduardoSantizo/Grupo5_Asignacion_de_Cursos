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
    public partial class homeadmi : Form
    {
        public homeadmi()
        {
            InitializeComponent();
        }


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_home_Paint(object sender, PaintEventArgs e)
        {

        }

        private void homeadmi_Load(object sender, EventArgs e)
        {

        }


        private void btnCursos_Click(object sender, EventArgs e)
        {
            frmModuloCursos frmModuloCursos = new frmModuloCursos();
            frmModuloCursos.Show();
            this.Hide();
        }

        private void btnfacultades_Click(object sender, EventArgs e)
        {
            Facultades facultades = new Facultades();
            facultades.Show();
            this.Hide();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            homeadmi homeadmi = new homeadmi();
            homeadmi.Show();
            this.Hide();
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            agregarestudiante agregarestudiante = new agregarestudiante();
            agregarestudiante.Show();
            this.Hide();
        }

        private void btnCatedratico_Click(object sender, EventArgs e)
        {
            agregar_catedratico agregar_Catedratico = new agregar_catedratico();
            agregar_Catedratico.Show();
            this.Hide();
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            FrmNotas frmNotas = new FrmNotas();
            frmNotas.Show();
            this.Hide();
        }

        private void btnFacultad_Click(object sender, EventArgs e)
        {
            Facultades facultades = new Facultades();
            facultades.Show();
            this.Hide();
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            FrmInscripcion frmCostoInscripcion = new FrmInscripcion();
            frmCostoInscripcion.Show();
            this.Hide();
        }

        private void btnAEstudiantes_Click(object sender, EventArgs e)
        {
            agregarestudiante agregarestudiante = new agregarestudiante();
            agregarestudiante.Show();
            this.Hide();
        }

        private void btnACatedraticos_Click(object sender, EventArgs e)
        {
            agregar_catedratico agregar_Catedratico = new agregar_catedratico();
            agregar_Catedratico.Show();
            this.Hide();
        }

        private void btnANotas_Click(object sender, EventArgs e)
        {
            FrmNotas frmNotas = new FrmNotas();
            frmNotas.Show();
            this.Hide();
        }

        private void btnAInscripcion_Click(object sender, EventArgs e)
        {
            frmCostoInscripcion frmCostoInscripcion = new frmCostoInscripcion();
            frmCostoInscripcion.Show();
            this.Hide();
        }

        private void btnACursos_Click(object sender, EventArgs e)
        {
            frmModuloCursos frmModuloCursos = new frmModuloCursos();
            frmModuloCursos.Show();
            this.Hide();
        }
    }
}
