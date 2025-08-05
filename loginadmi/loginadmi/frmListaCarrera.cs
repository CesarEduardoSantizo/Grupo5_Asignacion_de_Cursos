//sergio izeppi
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
    public partial class frmListaCarrera : Form
    {
        public frmListaCarrera()
        {
            InitializeComponent();
            CargarCarreras();
        }

        private void CargarCarreras()
        {
            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();
                    string consulta = "SELECT codigoCarrera_pk, nombreCarrera, codigoFacultad_fk FROM carrera";
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    list_carreras.DataSource = tabla; // Asegúrate de que este sea el nombre real de tu DataGridView

                    // Cambiar los títulos de las columnas
                    list_carreras.Columns["codigoCarrera_pk"].HeaderText = "Código";
                    list_carreras.Columns["nombreCarrera"].HeaderText = "Nombre de la Carrera";
                    list_carreras.Columns["codigoFacultad_fk"].HeaderText = "Código Facultad";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las carreras: " + ex.Message);
                }
            }
        }


        private void btn_eliminarCarrera_Click(object sender, EventArgs e)
        {
            string nombreCarrera = txt_nombreCarrera.Text.Trim();

            if (string.IsNullOrEmpty(nombreCarrera))
            {
                MessageBox.Show("Por favor, ingresa el nombre de la carrera que deseas eliminar.");
                return;
            }

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    // Eliminar por nombre
                    string consulta = "DELETE FROM carrera WHERE nombreCarrera = @nombreCarrera";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@nombreCarrera", nombreCarrera);
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Carrera eliminada correctamente.");
                        CargarCarreras(); // método que actualiza el listado
                    }
                    else
                    {
                        MessageBox.Show("No se encontró una carrera con ese nombre.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la carrera: " + ex.Message);
                }
            }
        }

        private void lbl_carrera_Click(object sender, EventArgs e)
        {

        }

        private void list_carreras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
