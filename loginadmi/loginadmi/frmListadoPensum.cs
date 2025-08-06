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
    public partial class frmListadoPensum : Form
    {
        public frmListadoPensum()
        {
            InitializeComponent();
            CargarPensum(); 
        }

        private void CargarPensum()
        {
            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();
                    string consulta = "SELECT codigoPensum_pk, codigoCarrera_fk, codigoCurso_fk, codigoPreRequisito_fk, numeroCiclo FROM pensum";
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    list_pensum.DataSource = tabla; // Cambia 'list_pensum' por el nombre real de tu DataGridView

                    // Cambiar los títulos de las columnas
                    list_pensum.Columns["codigoPensum_pk"].HeaderText = "Código Pensum";
                    list_pensum.Columns["codigoCarrera_fk"].HeaderText = "Carrera";
                    list_pensum.Columns["codigoCurso_fk"].HeaderText = "Curso";
                    list_pensum.Columns["codigoPreRequisito_fk"].HeaderText = "Pre-Requisito";
                    list_pensum.Columns["numeroCiclo"].HeaderText = "Ciclo";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el pensum: " + ex.Message);
                }
            }
        }


        private void txt_codigopensum_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_eliminarPensum_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txt_codigopensum.Text.Trim(), out int codigoPensum))
            {
                MessageBox.Show("Por favor, ingresa un código de pensum válido.");
                return;
            }

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    string consultaEliminar = "DELETE FROM pensum WHERE codigoPensum_pk = @codigoPensum";
                    MySqlCommand comandoEliminar = new MySqlCommand(consultaEliminar, conexion);
                    comandoEliminar.Parameters.AddWithValue("@codigoPensum", codigoPensum);

                    int filasAfectadas = comandoEliminar.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Pensum eliminado correctamente.");
                        CargarPensum(); // Método que refresca el listado de pensum si existe
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un pensum con ese código.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el pensum: " + ex.Message);
                }
            }
        }


        private void btn_modificarpensum_Click(object sender, EventArgs e)
        {

        }
    }
}
