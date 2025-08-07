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
    public partial class agregarestudiante : Form
    {
        public agregarestudiante()
        {
            InitializeComponent();
        }


        private void agregarestudiante_Load(object sender, EventArgs e)
        {
            LlenarCarreras();
        }

        private void LlenarCarreras()
{
    string sconexionBD = ConexionBD.CadenaConexion();

    using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
    {
        try
        {
            conexion.Open();

            string consulta = "SELECT nombreCarrera FROM carrera";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            cboCarrera.Items.Clear(); // Limpiar el ComboBox antes de llenar

            while (reader.Read())
            {
                string nombreCarrera = reader.GetString("nombreCarrera");
                cboCarrera.Items.Add(nombreCarrera);
            }

            if (cboCarrera.Items.Count > 0)
            {
                cboCarrera.SelectedIndex = 0; // Seleccionar la primera carrera por defecto
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al cargar las carreras: " + ex.Message);
        }
    }
}




        private void lbl_año_Click(object sender, EventArgs e)
        {

        }


        

        private void btn_estudiantes_Click(object sender, EventArgs e)
        {
            agregarestudiante nuevoFormulario = new agregarestudiante();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }


        private void lbl_carrera_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void txt_año_TextChanged(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            string snombres = txt_nombres.Text;
            string sapellidos = txt_apellidos.Text;
            string scarne = txt_carne.Text;
            string scarrera = cboCarrera.Text;
            string scorreo = txt_correo.Text;
            string stelefono = txt_telefono.Text;
            string susuario = txt_usuario.Text;
            string scontraseña = txt_contraseña.Text;

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


                    string sconsultaUsuario = "SELECT COUNT(*) FROM usuario WHERE usuario = @usuario";
                    MySqlCommand comandoValidarUsuario = new MySqlCommand(sconsultaUsuario, conexion);
                    comandoValidarUsuario.Parameters.AddWithValue("@usuario", susuario);
                    int count = Convert.ToInt32(comandoValidarUsuario.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("El nombre de usuario ya está en uso. Por favor elige otro.");
                        return;
                    }

                    string sconsultaCarnet = "SELECT COUNT(*) FROM estudiante WHERE carnetEstudiante_pk = @carnet";
                    MySqlCommand comandoValidarCarnet = new MySqlCommand(sconsultaCarnet, conexion);
                    comandoValidarCarnet.Parameters.AddWithValue("@carnet", scarne);
                    count = Convert.ToInt32(comandoValidarCarnet.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("El carné ya está registrado. Por favor, ingresa otro carné.");
                        return;
                    }

                    string sconsultacorreo = "SELECT COUNT(*) FROM estudiante WHERE correoEstudiante = @correo";
                    MySqlCommand comandoValidarCorreo = new MySqlCommand(sconsultacorreo, conexion);
                    comandoValidarCorreo.Parameters.AddWithValue("@correo", scorreo);
                    count = Convert.ToInt32(comandoValidarCorreo.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("El correo ya está registrado. Por favor, ingresa otro correo.");
                        return;
                    }

                    // Verificar si la carrera existe
                    string sconsulta = "SELECT codigoCarrera_pk FROM carrera where nombreCarrera = @carrera";
                    MySqlCommand comando = new MySqlCommand(sconsulta, conexion);
                    comando.Parameters.AddWithValue("@carrera", scarrera);
                    object resultado = comando.ExecuteScalar();
                    int codigoCarrera;

                    if (resultado == null)
                    {

                        string sinsertarCarrera = "INSERT INTO carrera (nombreCarrera) VALUES (@carrera)";
                        MySqlCommand comandoInsertarCarrera = new MySqlCommand(sinsertarCarrera, conexion);
                        comandoInsertarCarrera.Parameters.AddWithValue("@carrera", scarrera);
                        comandoInsertarCarrera.ExecuteNonQuery();

                        comando = new MySqlCommand("SELECT LAST_INSERT_ID()", conexion);
                        codigoCarrera = Convert.ToInt32(comando.ExecuteScalar());
                    }
                    else
                    {
                        codigoCarrera = Convert.ToInt32(resultado);
                    }


                    string sinsertarEstudiante = "INSERT INTO estudiante (nombreEstudiante, apellidosEstudiante, carnetEstudiante_pk, codigoCarrera_fk, correoEstudiante, telefonoEstudiante) " +
                                                "VALUES (@nombres, @apellidos, @carne, @codigoCarrera, @correo, @telefono)";
                    MySqlCommand comandoInsertarEstudiante = new MySqlCommand(sinsertarEstudiante, conexion);
                    comandoInsertarEstudiante.Parameters.AddWithValue("@nombres", snombres);
                    comandoInsertarEstudiante.Parameters.AddWithValue("@apellidos", sapellidos);
                    comandoInsertarEstudiante.Parameters.AddWithValue("@carne", scarne);
                    comandoInsertarEstudiante.Parameters.AddWithValue("@codigoCarrera", codigoCarrera);
                    comandoInsertarEstudiante.Parameters.AddWithValue("@correo", scorreo);
                    comandoInsertarEstudiante.Parameters.AddWithValue("@telefono", stelefono);
                    comandoInsertarEstudiante.ExecuteNonQuery();


                    string insertarUsuario = "INSERT INTO usuario (usuario, contraseña, carnetEstudiante_fk, codigoRolUsuario_fk) " +
                                                "VALUES (@usuario, @contraseña, @carnetEstudiante, 1)";
                    MySqlCommand comandoInsertarUsuario = new MySqlCommand(insertarUsuario, conexion);
                    comandoInsertarUsuario.Parameters.AddWithValue("@usuario", susuario);
                    comandoInsertarUsuario.Parameters.AddWithValue("@contraseña", scontraseña);
                    comandoInsertarUsuario.Parameters.AddWithValue("@carnetEstudiante", scarne);
                    comandoInsertarUsuario.ExecuteNonQuery();

                    MessageBox.Show("Estudiante registrado exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                    return;
                }
            }
        }

        private void lbl_agregar_estudiante_Click(object sender, EventArgs e)
        {

        }


        private void btn_listaEstudiantes_Click(object sender, EventArgs e)
        {
            ListaEstudiantes nuevoFormulario = new ListaEstudiantes();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

 
        private void btnInicio_Click(object sender, EventArgs e)
        {
            homeadmi nuevoFormulario = new homeadmi();
            nuevoFormulario.Show();
            this.Hide();

        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            agregarestudiante nuevoFormulario = new agregarestudiante();
            nuevoFormulario.Show();
            this.Hide(); 
        }

        private void btnCatedratico_Click(object sender, EventArgs e)
        {
            agregar_catedratico nuevoFormulario = new agregar_catedratico();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            FrmNotas nuevoFormulario = new FrmNotas();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnFacultad_Click(object sender, EventArgs e)
        {
            Facultades nuevoFormulario = new Facultades();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            FrmInscripcion nuevoFormulario = new FrmInscripcion();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            frmCursos nuevoFormulario = new frmCursos();
            nuevoFormulario.Show();
        }
    }
}
