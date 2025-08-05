using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginadmi
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string sUsuario = txt_usuario.Text;
            string sContraseña = txt_contraseña.Text;

            string sConexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(sConexionBD))
            {
                try
                {
                    conexion.Open();
                    string sConsulta = "SELECT codigoRolUsuario_fk FROM usuario WHERE usuario = @usuario AND contraseña = @contraseña";
                    MySqlCommand comando = new MySqlCommand(sConsulta, conexion);
                    comando.Parameters.AddWithValue("@usuario", sUsuario);
                    comando.Parameters.AddWithValue("@contraseña", sContraseña);

                    object resultado = comando.ExecuteScalar();

                    if (resultado != null)
                    {
                        int iRol = Convert.ToInt32(resultado);

                        MessageBox.Show("Inicio de sesión exitoso.");

                        if (iRol == 1)
                        {
                            FrmHomeEstudiantes frmEstudiante = new FrmHomeEstudiantes();
                            frmEstudiante.Show();
                        }
                        else if (iRol == 2)
                        {
                            homeadmi frmAdmin = new homeadmi();
                            frmAdmin.Show();

                        }
                        else if (iRol == 3)
                        {
                            homeadmi frmAdmin = new homeadmi();
                            frmAdmin.Show();
                        }

                        this.Hide(); // o this.Close(); si quieres cerrarlo
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                    return;
                }
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
