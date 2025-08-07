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

                    string consulta = @"
                SELECT 
                    p.codigoPensum_pk AS 'Código Pensum',
                    c.nombreCarrera AS 'Carrera',
                    cu.nombreCurso AS 'Curso',
                    IFNULL(pr.nombreCurso, 'Sin Pre-requisito') AS 'Pre-Requisito',
                    p.numeroCiclo AS 'Ciclo'
                FROM pensum p
                INNER JOIN carrera c ON p.codigoCarrera_fk = c.codigoCarrera_pk
                INNER JOIN curso cu ON p.codigoCurso_fk = cu.codigoCurso_pk
                LEFT JOIN curso pr ON p.codigoPreRequisito_fk = pr.codigoCurso_pk";

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    list_pensum.DataSource = tabla;
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
            if (list_pensum.CurrentRow == null)
            {
                MessageBox.Show("Por favor selecciona un registro del pensum.");
                return;
            }

            try
            {
                // Obtener datos de la fila seleccionada
                DataGridViewRow fila = list_pensum.CurrentRow;

                int codigoPensum = Convert.ToInt32(fila.Cells["codigoPensum_pk"].Value);
                int codigoCarrera = Convert.ToInt32(fila.Cells["codigoCarrera_fk"].Value);
                int codigoCurso = Convert.ToInt32(fila.Cells["codigoCurso_fk"].Value);
                int codigoPreRequisito = Convert.ToInt32(fila.Cells["codigoPreRequisito_fk"].Value);
                int numeroCiclo = Convert.ToInt32(fila.Cells["numeroCiclo"].Value);

                // Validación básica
                if (codigoCarrera <= 0 || codigoCurso <= 0 || numeroCiclo <= 0)
                {
                    MessageBox.Show("Los campos Carrera, Curso y Ciclo deben tener valores válidos.");
                    return;
                }

                string conexionBD = ConexionBD.CadenaConexion();

                using (MySqlConnection conexion = new MySqlConnection(conexionBD))
                {
                    conexion.Open();

                    string consulta = @"
                UPDATE pensum 
                SET codigoCarrera_fk = @codigoCarrera, 
                    codigoCurso_fk = @codigoCurso, 
                    codigoPreRequisito_fk = @codigoPreRequisito, 
                    numeroCiclo = @numeroCiclo 
                WHERE codigoPensum_pk = @codigoPensum";

                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@codigoCarrera", codigoCarrera);
                    comando.Parameters.AddWithValue("@codigoCurso", codigoCurso);
                    comando.Parameters.AddWithValue("@codigoPreRequisito", codigoPreRequisito);
                    comando.Parameters.AddWithValue("@numeroCiclo", numeroCiclo);
                    comando.Parameters.AddWithValue("@codigoPensum", codigoPensum);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Pensum modificado exitosamente.");
                        CargarPensum(); // Refresca la tabla
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar el pensum.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el pensum: " + ex.Message);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnfacul_Click(object sender, EventArgs e)
        {
            Facultades facultades = new Facultades();
            facultades.Show();
            this.Hide(); 
        }

        private void list_pensum_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
