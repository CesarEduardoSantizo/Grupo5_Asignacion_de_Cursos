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
    public partial class frmPensum : Form
    {
        public frmPensum()
        {
            InitializeComponent();
        }

        private void txt_nombrescarrera_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_nombrecurso_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_codigoPre_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_numerociclo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_registrarpensum_Click(object sender, EventArgs e)
        {
            string nombreCarrera = txt_nombrescarrera.Text.Trim();
            int codigoCurso = int.Parse(txt_nombrecurso.Text.Trim());
            int codigoPreRequisito = int.Parse(text_codigoPre.Text.Trim());
            int numeroCiclo = int.Parse(text_numerociclo.Text.Trim());

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    // Buscar el código de la carrera por nombre
                    string consultaCarrera = "SELECT codigoCarrera_pk FROM carrera WHERE nombreCarrera = @nombreCarrera";
                    MySqlCommand comandoCarrera = new MySqlCommand(consultaCarrera, conexion);
                    comandoCarrera.Parameters.AddWithValue("@nombreCarrera", nombreCarrera);
                    object resultadoCarrera = comandoCarrera.ExecuteScalar();

                    if (resultadoCarrera == null)
                    {
                        MessageBox.Show("No se encontró una carrera con ese nombre.");
                        return;
                    }

                    int codigoCarrera = Convert.ToInt32(resultadoCarrera);

                    // Insertar el pensum
                    string insertarPensum = "INSERT INTO pensum (codigoCarrera_fk, codigoCurso_fk, codigoPreRequisito_fk, numeroCiclo) " +
                                            "VALUES (@codigoCarrera, @codigoCurso, @codigoPreRequisito, @numeroCiclo)";
                    MySqlCommand comandoInsertar = new MySqlCommand(insertarPensum, conexion);
                    comandoInsertar.Parameters.AddWithValue("@codigoCarrera", codigoCarrera);
                    comandoInsertar.Parameters.AddWithValue("@codigoCurso", codigoCurso);
                    comandoInsertar.Parameters.AddWithValue("@codigoPreRequisito", codigoPreRequisito);
                    comandoInsertar.Parameters.AddWithValue("@numeroCiclo", numeroCiclo);
                    comandoInsertar.ExecuteNonQuery();

                    MessageBox.Show("Pensum insertado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar el pensum: " + ex.Message);
                }
            }

        }

        private void btn_listapensum_Click(object sender, EventArgs e)
        {
            frmListadoPensum listaPensum = new frmListadoPensum();
            listaPensum.Show();
            this.Hide();
        }
    }
}
