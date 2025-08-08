//PROGRAMADO POR: GERBER ALEXANDER ASTURIAS TEJAXÚN CARNET: 0901-22-11992
using MySql.Data.MySqlClient;
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

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            string snombres = txt_nombres.Text.Trim();
            string sapellidos = txt_carne.Text.Trim();
            string scarne = txt_carne.Text.Trim();
            string stelefono = txt_telefono.Text.Trim();
            string scorreo = txt_correo.Text.Trim();
            string susuario = txt_usuario.Text.Trim();         
            string scontraseña = txt_contraseña.Text.Trim();   

            
            if (string.IsNullOrWhiteSpace(snombres) || string.IsNullOrWhiteSpace(sapellidos) ||
                string.IsNullOrWhiteSpace(scarne) || string.IsNullOrWhiteSpace(stelefono) ||
                string.IsNullOrWhiteSpace(scorreo) || string.IsNullOrWhiteSpace(susuario) ||
                string.IsNullOrWhiteSpace(scontraseña))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            string sconexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
            {
                try
                {
                    conexion.Open();

                    string scarnetExistente = @"SELECT COUNT(*) FROM Catedratico WHERE carnetCatedratico_pk = @carnet";
                    MySqlCommand comandoValidarCarnet = new MySqlCommand(scarnetExistente, conexion);
                    comandoValidarCarnet.Parameters.AddWithValue("@carnet", scarne);
                    int countCarnet = Convert.ToInt32(comandoValidarCarnet.ExecuteScalar());
                    if (countCarnet > 0)
                    {
                        MessageBox.Show("El carnet ya está en uso. Por favor, elige otro.");
                        return;
                    }

                    string susuarioExistente = @"SELECT COUNT(*) FROM Usuario WHERE usuario = @usuario";
                    MySqlCommand comandoValidarUsuario = new MySqlCommand(susuarioExistente, conexion);
                    comandoValidarUsuario.Parameters.AddWithValue("@usuario", susuario);
                    int countUsuario = Convert.ToInt32(comandoValidarUsuario.ExecuteScalar());
                    if (countUsuario > 0)
                    {
                        MessageBox.Show("El nombre de usuario ya está en uso. Por favor, elige otro.");
                        return;
                    }

                    string scorreoExistente = @"SELECT COUNT(*) FROM Catedratico WHERE correoCatedratico = @correo";
                    MySqlCommand comandoValidarCorreo = new MySqlCommand(scorreoExistente, conexion);
                    comandoValidarCorreo.Parameters.AddWithValue("@correo", scorreo);
                    int countCorreo = Convert.ToInt32(comandoValidarCorreo.ExecuteScalar());
                    if (countCorreo > 0)
                    {
                        MessageBox.Show("El correo ya está en uso. Por favor, elige otro.");
                        return;
                    }

                    string sinsertarCatedratico = @"INSERT INTO Catedratico 
                    (carnetCatedratico_pk, nombreCatedratico, apellidosCatedratico, telefonoCatedratico, correoCatedratico)
                     VALUES (@carnet, @nombres, @apellidos, @telefono, @correo)";

                    MySqlCommand comandoInsertarCatedratico = new MySqlCommand(sinsertarCatedratico, conexion);
                    comandoInsertarCatedratico.Parameters.AddWithValue("@carnet", scarne);
                    comandoInsertarCatedratico.Parameters.AddWithValue("@nombres", snombres);
                    comandoInsertarCatedratico.Parameters.AddWithValue("@apellidos", sapellidos);
                    comandoInsertarCatedratico.Parameters.AddWithValue("@telefono", stelefono);
                    comandoInsertarCatedratico.Parameters.AddWithValue("@correo", scorreo);

                    comandoInsertarCatedratico.ExecuteNonQuery();

                    
                    string sinsertarUsuario = @"INSERT INTO Usuario 
                (usuario, contraseña, codigoRolUsuario_fk, carnetCatedratico_fk) 
                VALUES (@usuario, @contraseña, @rol, @carnetCatedratico)";

                    MySqlCommand comandoInsertarUsuario = new MySqlCommand(sinsertarUsuario, conexion);
                    comandoInsertarUsuario.Parameters.AddWithValue("@usuario", susuario);
                    comandoInsertarUsuario.Parameters.AddWithValue("@contraseña", scontraseña);
                    comandoInsertarUsuario.Parameters.AddWithValue("@rol", 2); 
                    comandoInsertarUsuario.Parameters.AddWithValue("@carnetCatedratico", scarne);

                    comandoInsertarUsuario.ExecuteNonQuery();

                    MessageBox.Show("Catedrático y usuario registrados exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar catedrático: " + ex.Message);
                }
            }
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
      

        private void btn_listacatedratico_Click(object sender, EventArgs e)
        {
             ListaCatedratico nuevoFormulario = new ListaCatedratico();
             nuevoFormulario.Show();
             this.Hide(); // o this.Close(); si quieres cerrarlo
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
            frmCostoInscripcion frmCostoInscripcion = new frmCostoInscripcion();
            frmCostoInscripcion.Show();
            this.Hide();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            frmModuloCursos frmModuloCursos = new frmModuloCursos();
            frmModuloCursos.Show();
            this.Hide();
        }
    }
}
