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
    public partial class frmModuloCursos : Form
    {
        public frmModuloCursos()
        {
            InitializeComponent();
        }

        // ----------------------------- Programado por: Anderson Trigueros ------------------------------------------//
        private void btnListadoCursos_Click(object sender, EventArgs e)
        {
            frmListadoCursos frmListadoCursos = new frmListadoCursos();
            frmListadoCursos.Show();
            this.Hide();
        }

        private void btnAsignarCursos_Click(object sender, EventArgs e)
        {
            frmHabilitacionCursos habilitacionCursos = new frmHabilitacionCursos();
            habilitacionCursos.Show();
            this.Hide();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            frmModuloCursos frmModuloCursos = new frmModuloCursos();
            frmModuloCursos.Show();
            this.Hide();
        }

        private void btnAsignarLaboratorios_Click(object sender, EventArgs e)
        {
            frmAsignacionLaboratorio frmAsignacionLaboratorio = new frmAsignacionLaboratorio();
            frmAsignacionLaboratorio.Show();
            this.Hide();
        }

        private void btnListadoLaboratorios_Click(object sender, EventArgs e)
        {
            frmListadoLaboratorio frmListadoLaboratorio = new frmListadoLaboratorio();
            frmListadoLaboratorio.Show();
            this.Hide();
        }

        private void frmModuloCursos_Load(object sender, EventArgs e)
        {

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

        private void btnFacultades_Click(object sender, EventArgs e)
        {
            Facultades facultades = new Facultades();
            facultades.Show();
            this.Hide();
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            FrmNotas frmNotas = new FrmNotas();
            frmNotas.Show();
            this.Hide();
        }
    }
}
