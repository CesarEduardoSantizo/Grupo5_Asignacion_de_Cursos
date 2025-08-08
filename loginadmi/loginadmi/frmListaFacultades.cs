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
                    string consulta = "SELECT codigoFacultad_pk, nombreFacultad, codigoEdificio_fk FROM Facultad";
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
                    string consulta = "DELETE FROM Facultad WHERE nombreFacultad = @nombreFacultad";
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

        private void btnfacu2_Click(object sender, EventArgs e)
        {
            Facultades facultades = new Facultades();  
            facultades.Show();
            this.Hide(); 
        }

        private void btnmodificarfacultad_Click(object sender, EventArgs e)
        {
            if (list_facultades.CurrentRow == null)
            {
                MessageBox.Show("Por favor selecciona una facultad de la lista.");
                return;
            }

            try
            {
                // Obtener la fila seleccionada
                DataGridViewRow fila = list_facultades.CurrentRow;

                int codigoFacultad = Convert.ToInt32(fila.Cells["codigoFacultad_pk"].Value);
                string nombreFacultad = fila.Cells["nombreFacultad"].Value.ToString().Trim();
                int codigoEdificio = Convert.ToInt32(fila.Cells["codigoEdificio_fk"].Value);

                // Validar
                if (string.IsNullOrEmpty(nombreFacultad))
                {
                    MessageBox.Show("El nombre de la facultad no puede estar vacío.");
                    return;
                }

                string conexionBD = ConexionBD.CadenaConexion();

                using (MySqlConnection conexion = new MySqlConnection(conexionBD))
                {
                    conexion.Open();

                    string consulta = @"
                UPDATE Facultad 
                SET nombreFacultad = @nombreFacultad,
                    codigoEdificio_fk = @codigoEdificio
                WHERE codigoFacultad_pk = @codigoFacultad";

                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@nombreFacultad", nombreFacultad);
                    comando.Parameters.AddWithValue("@codigoEdificio", codigoEdificio);
                    comando.Parameters.AddWithValue("@codigoFacultad", codigoFacultad);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Facultad modificada exitosamente.");
                        CargarFacultades(); // Refrescar la tabla
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar la facultad.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la facultad: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCostoInscripcion frmCostoInscripcion = new frmCostoInscripcion();
            frmCostoInscripcion.Show();
            this.Hide();
        }
    }
}
