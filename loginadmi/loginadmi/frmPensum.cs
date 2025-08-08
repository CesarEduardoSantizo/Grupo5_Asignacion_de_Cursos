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
            string nombreCurso = txt_nombrecurso.Text.Trim();
            string nombrePreRequisito = text_codigoPre.Text.Trim();
            int numeroCiclo = int.Parse(text_numerociclo.Text.Trim());

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    // Buscar el código de la carrera por nombre
                    string consultaCarrera = "SELECT codigoCarrera_pk FROM Carrera WHERE TRIM(LOWER(nombreCarrera)) = TRIM(LOWER(@nombreCarrera))";
                    MySqlCommand comandoCarrera = new MySqlCommand(consultaCarrera, conexion);
                    comandoCarrera.Parameters.AddWithValue("@nombreCarrera", nombreCarrera.ToLower());
                    object resultadoCarrera = comandoCarrera.ExecuteScalar();

                    if (resultadoCarrera == null)
                    {
                        MessageBox.Show("No se encontró una carrera con ese nombre.");
                        return;
                    }
                    int codigoCarrera = Convert.ToInt32(resultadoCarrera);

                    // Buscar el código del curso por nombre
                    string consultaCurso = "SELECT codigoCurso_pk FROM Curso WHERE TRIM(LOWER(nombreCurso)) = TRIM(LOWER(@nombreCurso))";
                    MySqlCommand comandoCurso = new MySqlCommand(consultaCurso, conexion);
                    comandoCurso.Parameters.AddWithValue("@nombreCurso", nombreCurso.ToLower());
                    object resultadoCurso = comandoCurso.ExecuteScalar();

                    if (resultadoCurso == null)
                    {
                        MessageBox.Show("No se encontró un curso con ese nombre.");
                        return;
                    }
                    int codigoCurso = Convert.ToInt32(resultadoCurso);

                    // Buscar el código del prerrequisito por nombre (solo si no está vacío)
                    int? codigoPreRequisito = null;
                    if (!string.IsNullOrWhiteSpace(nombrePreRequisito))
                    {
                        string consultaPre = "SELECT codigoCurso_pk FROM Curso WHERE TRIM(LOWER(nombreCurso)) = TRIM(LOWER(@nombrePre))";
                        MySqlCommand comandoPre = new MySqlCommand(consultaPre, conexion);
                        comandoPre.Parameters.AddWithValue("@nombrePre", nombrePreRequisito.ToLower());
                        object resultadoPre = comandoPre.ExecuteScalar();

                        if (resultadoPre == null)
                        {
                            MessageBox.Show("No se encontró un curso prerrequisito con ese nombre.");
                            return;
                        }
                        codigoPreRequisito = Convert.ToInt32(resultadoPre);
                    }

                    // Insertar el pensum
                    string insertarPensum = "INSERT INTO Pensum (codigoCarrera_fk, codigoCurso_fk, codigoPreRequisito_fk, numeroCiclo) " +
                                            "VALUES (@codigoCarrera, @codigoCurso, @codigoPreRequisito, @numeroCiclo)";
                    MySqlCommand comandoInsertar = new MySqlCommand(insertarPensum, conexion);
                    comandoInsertar.Parameters.AddWithValue("@codigoCarrera", codigoCarrera);
                    comandoInsertar.Parameters.AddWithValue("@codigoCurso", codigoCurso);
                    if (codigoPreRequisito.HasValue)
                        comandoInsertar.Parameters.AddWithValue("@codigoPreRequisito", codigoPreRequisito.Value);
                    else
                        comandoInsertar.Parameters.AddWithValue("@codigoPreRequisito", DBNull.Value);
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

        private void btnfacus3_Click(object sender, EventArgs e)
        {
            Facultades facultades = new Facultades();  
            facultades.Show();
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
