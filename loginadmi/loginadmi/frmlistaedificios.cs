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
    public partial class frmlistaedificios : Form
    {
        public frmlistaedificios()
        {
            InitializeComponent();
            CargarEdificios();
        }

        private void CargarEdificios()
        {
            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();
                    string consulta = "SELECT codigoEdificio_pk, nombreEdificio FROM edificio";
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    listEdificios.DataSource = tabla;

                    // Cambiar encabezados de columna
                    listEdificios.Columns["codigoEdificio_pk"].HeaderText = "Código";
                    listEdificios.Columns["nombreEdificio"].HeaderText = "Nombre del Edificio";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los edificios: " + ex.Message);
                }
            }
        }

        private void btneliminarEdificio_Click(object sender, EventArgs e)
        {
            string nombreEdificio = txtnombreEdificio.Text.Trim();

            if (string.IsNullOrEmpty(nombreEdificio))
            {
                MessageBox.Show("Por favor, ingresa el nombre del edificio que deseas eliminar.");
                return;
            }

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    string consulta = "DELETE FROM edificio WHERE nombreEdificio = @nombreEdificio";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@nombreEdificio", nombreEdificio);
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Edificio eliminado correctamente.");
                        CargarEdificios();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un edificio con ese nombre.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el edificio: " + ex.Message);
                }
            }
        }

        private void btnmodificarEdificio_Click(object sender, EventArgs e)
        {
            if (listEdificios.CurrentRow == null)
            {
                MessageBox.Show("Por favor selecciona un edificio de la lista.");
                return;
            }

            try
            {
                DataGridViewRow fila = listEdificios.CurrentRow;
                int codigoEdificio = Convert.ToInt32(fila.Cells["codigoEdificio_pk"].Value);
                string nombreEdificio = fila.Cells["nombreEdificio"].Value.ToString().Trim();

                if (string.IsNullOrEmpty(nombreEdificio))
                {
                    MessageBox.Show("El nombre del edificio no puede estar vacío.");
                    return;
                }

                string conexionBD = ConexionBD.CadenaConexion();

                using (MySqlConnection conexion = new MySqlConnection(conexionBD))
                {
                    conexion.Open();
                    string consulta = "UPDATE edificio SET nombreEdificio = @nombreEdificio WHERE codigoEdificio_pk = @codigoEdificio";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@nombreEdificio", nombreEdificio);
                    comando.Parameters.AddWithValue("@codigoEdificio", codigoEdificio);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Edificio modificado exitosamente.");
                        CargarEdificios();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar el edificio.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el edificio: " + ex.Message);
            }
        }

        private void btnfacultades5_Click(object sender, EventArgs e)
        {
            Facultades nuevoFormulario = new Facultades();
            nuevoFormulario.Show();
            this.Hide();
        }
    }
}
