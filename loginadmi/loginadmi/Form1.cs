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
// Cesar Eduardo Santizo 0901-22-5215//
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
                conexion.Open();
                string sConsulta = @"
                    SELECT codigoUsuario_pk, usuario, codigoRolUsuario_fk, carnetEstudiante_fk
                    FROM usuario
                    WHERE usuario = @usuario AND contraseña = @contraseña";
                MySqlCommand comando = new MySqlCommand(sConsulta, conexion);
                comando.Parameters.AddWithValue("@usuario", sUsuario);
                comando.Parameters.AddWithValue("@contraseña", sContraseña);

                using (var reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        clsSesion.CodigoUsuario = reader.GetInt32("codigoUsuario_pk");
                        clsSesion.Usuario = reader.GetString("usuario");
                        clsSesion.CodigoRol = reader.GetInt32("codigoRolUsuario_fk");
                        clsSesion.CarnetEstudiante = reader.IsDBNull(reader.GetOrdinal("carnetEstudiante_fk")) ? 0 : reader.GetInt32("carnetEstudiante_fk");

                        MessageBox.Show("Inicio de sesión exitoso.");

                        if (clsSesion.CodigoRol == 1)
                        {
                            FrmHomeEstudiantes frmEstudiante = new FrmHomeEstudiantes();
                            frmEstudiante.Show();
                        }
                        else if (clsSesion.CodigoRol == 2)
                        {
                            homeadmi frmAdmin = new homeadmi();
                            frmAdmin.Show();

                        }
                        else if (clsSesion.CodigoRol == 3)
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
