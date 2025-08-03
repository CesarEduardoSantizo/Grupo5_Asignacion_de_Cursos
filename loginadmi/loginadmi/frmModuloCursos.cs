using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginadmi.Administrador.Cursos
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
    }
}
