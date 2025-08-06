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
    public partial class frmListaFacultades : Form
    {
        public frmListaFacultades()
        {
            InitializeComponent();
            CargarFacultades(); 
        }

        private void CargarFacultades()
        {
            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();
                    string consulta = "SELECT codigoFacultad_pk, nombreFacultad, codigoEdificio_fk FROM facultad";
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    list_facultades.DataSource = tabla; 

                    // Cambiar los títulos de las columnas
                    list_facultades.Columns["codigoFacultad_pk"].HeaderText = "Código Facultad";
                    list_facultades.Columns["nombreFacultad"].HeaderText = "Nombre de la Facultad";
                    list_facultades.Columns["codigoEdificio_fk"].HeaderText = "Código Edificio";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las facultades: " + ex.Message);
                }
            }
        }


        private void txt_nombrefacu_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_eliminarFacultad_Click(object sender, EventArgs e)
        {
            string nombreFacultad = txt_nombrefacu.Text.Trim();

            if (string.IsNullOrEmpty(nombreFacultad))
            {
                MessageBox.Show("Por favor, ingresa el nombre de la facultad que deseas eliminar.");
                return;
            }

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    // Eliminar todas las filas que coincidan con el nombre de la facultad
                    string consulta = "DELETE FROM facultad WHERE nombreFacultad = @nombreFacultad";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@nombreFacultad", nombreFacultad);
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Facultad eliminada correctamente.");
                        CargarFacultades();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró una facultad con ese nombre.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la facultad: " + ex.Message);
                }
            }

        }
    }
}
