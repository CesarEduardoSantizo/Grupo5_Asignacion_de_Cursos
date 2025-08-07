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
    public partial class ListaCatedratico : Form
    {
        public ListaCatedratico()
        {
            InitializeComponent();
            CargarCatedraticos();
        }
        private void CargarCatedraticos()
        {
            string sconexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
            {
                try
                {
                    conexion.Open();
                    string sconsulta = "SELECT nombreCatedratico, apellidosCatedratico, carnetCatedratico_pk, correoCatedratico, telefonoCatedratico FROM Catedratico";
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(sconsulta, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    list_catedratico.DataSource = tabla;

                    // Cambiar los títulos de las columnas
                    list_catedratico.Columns["nombreCatedratico"].HeaderText = "Nombres";
                    list_catedratico.Columns["apellidosCatedratico"].HeaderText = "Apellidos";
                    list_catedratico.Columns["carnetCatedratico_pk"].HeaderText = "Carné";
                    list_catedratico.Columns["correoCatedratico"].HeaderText = "Correo";
                    list_catedratico.Columns["telefonoCatedratico"].HeaderText = "Teléfono";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los catedráticos: " + ex.Message);
                }
            }
        }
        private void lbl_Lista_estudiantes_Click(object sender, EventArgs e)
        {

        }

        private void btn_EditarEstudiante_Click(object sender, EventArgs e)
        {
            
        }


        private void btn_eliminarCatedratico_Click(object sender, EventArgs e)
        {
            string scarnet = txt_nocarnetcatedratico.Text.Trim();

            if (string.IsNullOrEmpty(scarnet))
            {
                MessageBox.Show("Por favor ingresa el número de carné.");
                return;
            }

            string sconexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
            {
                try
                {
                    conexion.Open();

                    string seliminacionUser = "DELETE FROM usuario WHERE carnetCatedratico_fk = @carnet";
                    MySqlCommand comandoUser = new MySqlCommand(seliminacionUser, conexion);
                    comandoUser.Parameters.AddWithValue("@carnet", scarnet);
                    comandoUser.ExecuteNonQuery();

                    string sconsulta = "DELETE FROM catedratico WHERE carnetCatedratico_pk = @carnet";
                    MySqlCommand comandoCatedratico = new MySqlCommand(sconsulta, conexion);
                    comandoCatedratico.Parameters.AddWithValue("@carnet", scarnet);
                    int filasAfectadas = comandoCatedratico.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Catedratico eliminado correctamente.");
                        CargarCatedraticos();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un Catedratico con ese carné.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el Catedratico: " + ex.Message);
                }
            }
        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            homeadmi nuevoFormulario = new homeadmi();
            nuevoFormulario.Show();
            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btn_EditarCatedratico_Click(object sender, EventArgs e)
        {
            string scarnet = txt_nocarnetcatedratico.Text.Trim();

            if (string.IsNullOrEmpty(scarnet))
            {
                MessageBox.Show("Por favor ingresa el número de carné.");
                return;
            }

            string sconexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
            {
                try
                {
                    conexion.Open();

                    string sconsulta = "SELECT COUNT(*) FROM catedratico WHERE carnetCatedratico_pk = @carnet";
                    MySqlCommand comando = new MySqlCommand(sconsulta, conexion);
                    comando.Parameters.AddWithValue("@carnet", scarnet);
                    int existe = Convert.ToInt32(comando.ExecuteScalar());

                    if (existe > 0)
                    {
                        
                        EditarCatedratico ventanaEditar = new EditarCatedratico(scarnet);
                        ventanaEditar.ShowDialog();
                        CargarCatedraticos();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un Catedratico con ese carné.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar Catedratico: " + ex.Message);
                }
            }
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
    }
}
