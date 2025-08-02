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

        private void ptb_estudiante_Click(object sender, EventArgs e)
        {

        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            homeadmi nuevoFormulario = new homeadmi();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_agregar_estudiantes_Click(object sender, EventArgs e)
        {

        }

        private void lbl_año_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void agregarestudiante_Load(object sender, EventArgs e)
        {

        }

        private void btn_estudiantes_Click(object sender, EventArgs e)
        {
            agregarestudiante nuevoFormulario = new agregarestudiante();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void lbl_dpi_Click(object sender, EventArgs e)
        {

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

        private void btn_catedratico_Click(object sender, EventArgs e)
        {
            agregar_catedratico nuevoFormulario = new agregar_catedratico();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            string nombres = txt_nombres.Text;
            string apellidos = txt_apellidos.Text;
            string carne = txt_carne.Text;
            string carrera = txt_carrera.Text;
            string correo = txt_correo.Text;
            string telefono = txt_telefono.Text;
            string usuario = txt_usuario.Text;
            string contraseña = txt_contraseña.Text;

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();
                    string consulta = "SELECT codigoCarrera_pk FROM carrera where nombreCarrera = @carrera";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@carrera", carrera);
                    object resultado = comando.ExecuteScalar();
                    int codigoCarrera;

                    if (resultado == null)
                    {
                        //Insertar nuevo registro en la tabla carrera
                        string insertarCarrera = "INSERT INTO carrera (nombreCarrera) VALUES (@carrera)";
                        MySqlCommand comandoInsertarCarrera = new MySqlCommand(insertarCarrera, conexion);
                        comandoInsertarCarrera.Parameters.AddWithValue("@carrera", carrera);
                        comandoInsertarCarrera.ExecuteNonQuery();

                        comando = new MySqlCommand("SELECT LAST_INSERT_ID()", conexion);
                        codigoCarrera = Convert.ToInt32(comando.ExecuteScalar());
                    }
                    else
                    {
                        // Carrera ya existe, obtener ID
                        codigoCarrera = Convert.ToInt32(resultado);
                    }
                    string insertarEstudiante = "INSERT INTO estudiante (nombreEstudiante, apellidosEstudiante, carnetEstudiante_pk, codigoCarrera_fk, correoEstudiante, telefonoEstudiante) " +
                                                "VALUES (@nombres, @apellidos, @carne, @codigoCarrera, @correo, @telefono)";
                    MySqlCommand comandoInsertarEstudiante = new MySqlCommand(insertarEstudiante, conexion);
                    comandoInsertarEstudiante.Parameters.AddWithValue("@nombres", nombres);
                    comandoInsertarEstudiante.Parameters.AddWithValue("@apellidos", apellidos);
                    comandoInsertarEstudiante.Parameters.AddWithValue("@carne", carne);
                    comandoInsertarEstudiante.Parameters.AddWithValue("@codigoCarrera", codigoCarrera);
                    comandoInsertarEstudiante.Parameters.AddWithValue("@correo", correo);
                    comandoInsertarEstudiante.Parameters.AddWithValue("@telefono", telefono);
                    comandoInsertarEstudiante.ExecuteNonQuery();


                    string insertarUsuario = "INSERT INTO usuario (usuario, contraseña, carnetEstudiante_fk, codigoRolUsuario_fk) " +
                                                "VALUES (@usuario, @contraseña, @carnetEstudiante, 1)";
                    MySqlCommand comandoInsertarUsuario = new MySqlCommand(insertarUsuario, conexion);
                    comandoInsertarUsuario.Parameters.AddWithValue("@usuario", usuario);
                    comandoInsertarUsuario.Parameters.AddWithValue("@contraseña", contraseña);
                    comandoInsertarUsuario.Parameters.AddWithValue("@carnetEstudiante", carne);
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

        private void txt_carrera_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_listaEstudiantes_Click(object sender, EventArgs e)
        {
            ListaEstudiantes nuevoFormulario = new ListaEstudiantes();
            nuevoFormulario.Show();
            this.Hide(); // o this.Close(); si quieres cerrarlo
        }
    }
}
