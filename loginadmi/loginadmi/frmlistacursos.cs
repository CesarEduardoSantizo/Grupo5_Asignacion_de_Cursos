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
    public partial class frmlistacursos : Form
    {
        public frmlistacursos()
        {
            InitializeComponent();
            CargarCursos();
        }

        private void CargarCursos()
        {
            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();
                    string consulta = "SELECT codigoCurso_pk, nombreCurso, creditosAsignados, precio, creditosNecesarios FROM curso";
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    listcurso.DataSource = tabla;

                    // Cambiar encabezados de columnas
                    listcurso.Columns["codigoCurso_pk"].HeaderText = "Código";
                    listcurso.Columns["nombreCurso"].HeaderText = "Nombre del Curso";
                    listcurso.Columns["creditosAsignados"].HeaderText = "Créditos Asignados";
                    listcurso.Columns["precio"].HeaderText = "Precio";
                    listcurso.Columns["creditosNecesarios"].HeaderText = "Créditos Necesarios";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los cursos: " + ex.Message);
                }
            }
        }

        private void btneliminarcurso_Click(object sender, EventArgs e)
        {
            string nombreCurso = txtnombreCurso.Text.Trim();

            if (string.IsNullOrEmpty(nombreCurso))
            {
                MessageBox.Show("Por favor, ingresa el nombre del curso que deseas eliminar.");
                return;
            }

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    string consulta = "DELETE FROM curso WHERE nombreCurso = @nombreCurso";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@nombreCurso", nombreCurso);
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Curso eliminado correctamente.");
                        CargarCursos();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un curso con ese nombre.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el curso: " + ex.Message);
                }
            }
        }

        private void btnmodificarCurso_Click(object sender, EventArgs e)
        {
            if (listcurso.CurrentRow == null)
            {
                MessageBox.Show("Por favor selecciona un curso de la lista.");
                return;
            }

            try
            {
                DataGridViewRow fila = listcurso.CurrentRow;

                int codigoCurso = Convert.ToInt32(fila.Cells["codigoCurso_pk"].Value);
                string nombreCurso = fila.Cells["nombreCurso"].Value.ToString().Trim();
                int creditosAsignados = Convert.ToInt32(fila.Cells["creditosAsignados"].Value);
                decimal precio = Convert.ToDecimal(fila.Cells["precio"].Value);
                int creditosNecesarios = Convert.ToInt32(fila.Cells["creditosNecesarios"].Value);

                if (string.IsNullOrEmpty(nombreCurso))
                {
                    MessageBox.Show("El nombre del curso no puede estar vacío.");
                    return;
                }

                string conexionBD = ConexionBD.CadenaConexion();

                using (MySqlConnection conexion = new MySqlConnection(conexionBD))
                {
                    conexion.Open();
                    string consulta = @"UPDATE curso 
                                        SET nombreCurso = @nombreCurso, 
                                            creditosAsignados = @creditosAsignados,
                                            precio = @precio,
                                            creditosNecesarios = @creditosNecesarios
                                        WHERE codigoCurso_pk = @codigoCurso";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@nombreCurso", nombreCurso);
                    comando.Parameters.AddWithValue("@creditosAsignados", creditosAsignados);
                    comando.Parameters.AddWithValue("@precio", precio);
                    comando.Parameters.AddWithValue("@creditosNecesarios", creditosNecesarios);
                    comando.Parameters.AddWithValue("@codigoCurso", codigoCurso);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Curso modificado exitosamente.");
                        CargarCursos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar el curso.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el curso: " + ex.Message);
            }
        }

        private void btnfacultades_Click(object sender, EventArgs e)
        {
            Facultades nuevoFormulario = new Facultades();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCostoInscripcion frmCostoInscripcion = new frmCostoInscripcion();
            frmCostoInscripcion.Show();
            this.Hide();
        }
    }
}
