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
    public partial class frmHomeCatedraticos : Form
    {
        public frmHomeCatedraticos()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            frmHomeCatedraticos frmHomeCatedraticos = new frmHomeCatedraticos();
            frmHomeCatedraticos.Show();
            this.Hide();
        }

        private void btnListados_Click(object sender, EventArgs e)
        {
            frmListadosAlumnos frmListadosAlumnos = new frmListadosAlumnos();
            frmListadosAlumnos.Show();
            this.Hide();
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            FrmNotasCatedratico frmNotasCatedratico = new FrmNotasCatedratico();
            frmNotasCatedratico.Show();
            this.Hide();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            frmCursosCatedratico frmCursosCatedratico = new frmCursosCatedratico();
            frmCursosCatedratico.Show();
            this.Hide();
        }

        private void btnCursosC_Click(object sender, EventArgs e)
        {
            frmCursosCatedratico frmCursosCatedratico = new frmCursosCatedratico();
            frmCursosCatedratico.Show();
            this.Hide();
        }

        private void btnModuloListados_Click(object sender, EventArgs e)
        {
            frmListadosAlumnos frmListadosAlumnos = new frmListadosAlumnos();
            frmListadosAlumnos.Show();
            this.Hide();
        }

        private void btnModuloNotas_Click(object sender, EventArgs e)
        {
            FrmNotasCatedratico frmNotasCatedratico = new FrmNotasCatedratico();
            frmNotasCatedratico.Show();
            this.Hide();
        }
    }
}
