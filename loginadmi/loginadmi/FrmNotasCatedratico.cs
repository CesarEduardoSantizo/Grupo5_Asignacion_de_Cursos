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
    public partial class FrmNotasCatedratico : Form
    {
        public FrmNotasCatedratico()
        {
            InitializeComponent();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            string sCarnetEstudiante = txtCarnetEstudiante.Text;
            string sNombreCurso = txtNombreCurso.Text;
            string sNotaPrimerParcial = txtNotaPrimerParcial.Text;
            string sNotaSegundoParcial = txtNotaSegundoParcial.Text;
            string sNotaActividades = txtNotaActividades.Text;
            string sNotaFinalParcial = txtNotaFinalParcial.Text;

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();
                    string sConsulta = "SELECT codigoCurso_pk FROM Curso where nombreCurso = @curso";
                    MySqlCommand comando = new MySqlCommand(sConsulta, conexion);
                    comando.Parameters.AddWithValue("@curso", sNombreCurso);
                    object resultado = comando.ExecuteScalar();
                    int codigoCurso;

                    if (resultado == null)
                    {
                        MessageBox.Show("Debe Ingresar Primero Informacion del Curso ");
                        return;
                    }
                    else
                    {
                        // Curso ya existe, obtener ID
                        codigoCurso = Convert.ToInt32(resultado);
                    }

                    string sConsultaEstudiante = "SELECT carnetEstudiante_pk FROM Estudiante where carnetEstudiante_pk  = @carnetestudiante";
                    MySqlCommand comandoE = new MySqlCommand(sConsultaEstudiante, conexion);
                    comandoE.Parameters.AddWithValue("@carnetestudiante", sCarnetEstudiante);
                    object resultadoE = comandoE.ExecuteScalar();
                    int carnetEstudiante;

                    if (resultadoE == null)
                    {
                        MessageBox.Show("Debe Ingresar Primero el Estudiante ");
                        return;
                    }
                    else
                    {
                        // Carnet ya existe, obtener ID
                        carnetEstudiante = Convert.ToInt32(resultadoE);

                    }

                    object notaPrimerParcial = string.IsNullOrWhiteSpace(sNotaPrimerParcial) ? DBNull.Value : (object)sNotaPrimerParcial;
                    object notaSegundoParcial = string.IsNullOrWhiteSpace(sNotaSegundoParcial) ? DBNull.Value : (object)sNotaSegundoParcial;
                    object notaActividades = string.IsNullOrWhiteSpace(sNotaActividades) ? DBNull.Value : (object)sNotaActividades;
                    object notaFinalParcial = string.IsNullOrWhiteSpace(sNotaFinalParcial) ? DBNull.Value : (object)sNotaFinalParcial;

                    // Ingresar las notas en la base de datos
                    string sinsertarNotas = "INSERT INTO Notas (carnetEstudiante_fk, codigoCurso_fk, notaPrimerParcial, notaSegundoParcial, notaActividades, examenFinal) " +
                                             "VALUES (@carnetEstudiante, @codigoCurso, @nota1, @nota2, @notaA, @notaF)";
                    MySqlCommand comandoInsertarNota = new MySqlCommand(sinsertarNotas, conexion);
                    comandoInsertarNota.Parameters.AddWithValue("@carnetEstudiante", carnetEstudiante);
                    comandoInsertarNota.Parameters.AddWithValue("@codigoCurso", codigoCurso);
                    comandoInsertarNota.Parameters.AddWithValue("@nota1", notaPrimerParcial);
                    comandoInsertarNota.Parameters.AddWithValue("@nota2", notaSegundoParcial);
                    comandoInsertarNota.Parameters.AddWithValue("@notaA", notaActividades);
                    comandoInsertarNota.Parameters.AddWithValue("@notaF", notaFinalParcial);
                    comandoInsertarNota.ExecuteNonQuery();

                    if (comandoInsertarNota.LastInsertedId > 0)
                    {
                        MessageBox.Show("Notas registradas exitosamente.");
                        CargarNotas();
                    }

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al registrar notas: " + ex.Message);
                    CargarNotas();
                    return;
                }

            }
        }
             private void CargarNotas()
        {
            // 1) Construimos la conexión (puedes usar tu helper ConexionBD si lo prefieres)
            string cadena = ConexionBD.CadenaConexion();     // o tu string literal

            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    // 2) Preparamos el SELECT
                    string sql = @"SELECT codigoNota_pk AS Código,
                                  carnetEstudiante_fk AS Carnet,
                                  codigoCurso_fk     AS Curso,
                                  notaPrimerParcial  AS '1er Parcial',
                                  notaSegundoParcial AS '2º Parcial',
                                  notaActividades    AS Actividades,
                                  examenFinal        AS Final
                           FROM Notas";

                    // 3) Llenamos un DataTable
                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, cn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // 4) Lo enlazamos al DataGridView
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"No pude cargar las notas: {ex.Message}");
                }
            }

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            frmHomeCatedraticos frmHomeCatedraticos = new frmHomeCatedraticos();
            frmHomeCatedraticos.Show();
            this.Hide();
        }

        private void btnListadoCursos_Click(object sender, EventArgs e)
        {
            frmCursosCatedratico frmCursosCatedratico = new frmCursosCatedratico();
            frmCursosCatedratico.Show();
            this.Hide();
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            FrmNotasCatedratico frmNotasCatedratico = new FrmNotasCatedratico();
            frmNotasCatedratico.Show();
            this.Hide();
        }

        private void buttonMod_Click(object sender, EventArgs e)
        {
            string sCodigoNota = txtCodigoNotas.Text;
            string sCarnetEstudiante = txtCarnetEstudiante.Text;
            string sNombreCurso = txtNombreCurso.Text;
            string sNotaPrimerParcial = txtNotaPrimerParcial.Text;
            string sNotaSegundoParcial = txtNotaSegundoParcial.Text;
            string sNotaActividades = txtNotaActividades.Text;
            string sNotaFinalParcial = txtNotaFinalParcial.Text;

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    // Obtener código del curso
                    string consultaCurso = "SELECT codigoCurso_pk FROM Curso WHERE nombreCurso = @nombreCurso";
                    MySqlCommand cmdCurso = new MySqlCommand(consultaCurso, conexion);
                    cmdCurso.Parameters.AddWithValue("@nombreCurso", sNombreCurso);
                    object resultCurso = cmdCurso.ExecuteScalar();

                    if (resultCurso == null)
                    {
                        MessageBox.Show("El curso no existe.");
                        return;
                    }

                    int codigoCurso = Convert.ToInt32(resultCurso);

                    // Validar si el estudiante existe
                    string consultaEst = "SELECT carnetEstudiante_pk FROM Estudiante WHERE carnetEstudiante_pk = @carnet";
                    MySqlCommand cmdEst = new MySqlCommand(consultaEst, conexion);
                    cmdEst.Parameters.AddWithValue("@carnet", sCarnetEstudiante);
                    object resultEst = cmdEst.ExecuteScalar();

                    if (resultEst == null)
                    {
                        MessageBox.Show("El estudiante no existe.");
                        return;
                    }

                    int carnetEstudiante = Convert.ToInt32(resultEst);

                    // UPDATE
                    string consultaUpdate = @"UPDATE Notas 
                                SET carnetEstudiante_fk = @carnet,
                                    codigoCurso_fk = @curso,
                                    notaPrimerParcial = @nota1,
                                    notaSegundoParcial = @nota2,
                                    notaActividades = @notaA,
                                    examenFinal = @notaF
                              WHERE codigoNota_pk = @codigoNota";
                    object notaPrimerParcial = string.IsNullOrWhiteSpace(sNotaPrimerParcial) ? DBNull.Value : (object)sNotaPrimerParcial;
                    object notaSegundoParcial = string.IsNullOrWhiteSpace(sNotaSegundoParcial) ? DBNull.Value : (object)sNotaSegundoParcial;
                    object notaActividades = string.IsNullOrWhiteSpace(sNotaActividades) ? DBNull.Value : (object)sNotaActividades;
                    object notaFinalParcial = string.IsNullOrWhiteSpace(sNotaFinalParcial) ? DBNull.Value : (object)sNotaFinalParcial;

                    MySqlCommand cmdUpdate = new MySqlCommand(consultaUpdate, conexion);
                    cmdUpdate.Parameters.AddWithValue("@carnet", carnetEstudiante);
                    cmdUpdate.Parameters.AddWithValue("@curso", codigoCurso);
                    cmdUpdate.Parameters.AddWithValue("@nota1", notaPrimerParcial);
                    cmdUpdate.Parameters.AddWithValue("@nota2", notaSegundoParcial);
                    cmdUpdate.Parameters.AddWithValue("@notaA", notaActividades);
                    cmdUpdate.Parameters.AddWithValue("@notaF", notaFinalParcial);
                    cmdUpdate.Parameters.AddWithValue("@codigoNota", sCodigoNota);

                    int filasAfectadas = cmdUpdate.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Nota modificada correctamente.");
                        CargarNotas(); // Recarga el DataGridView
                    }
                    else
                    {
                        MessageBox.Show("No se modificó ninguna fila.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al modificar la nota: " + ex.Message);
                }
            }
        }

        private void btnListados_Click(object sender, EventArgs e)
        {
            frmListadosAlumnos frmListadosAlumnos = new frmListadosAlumnos();
            frmListadosAlumnos.Show();
            this.Hide();
        }
    }
}
