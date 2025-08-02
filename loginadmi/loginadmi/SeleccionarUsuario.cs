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
    public partial class SeleccionarUsuario : Form
    {
        public SeleccionarUsuario()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            frm_login nuevoFormulario = new frm_login();

            nuevoFormulario.Show();

            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            frm_login nuevoFormulario = new frm_login();

            nuevoFormulario.Show();

            this.Hide(); 
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frm_login nuevoFormulario = new frm_login();

            nuevoFormulario.Show();

            this.Hide();
       
    }
    }
}
