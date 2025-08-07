using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginadmi
{
    public partial class frmAsignarCursosAlumno : Form
    {
        /* --------------------------------------------- Programado por: Anderson Trigueros --------------------------------------*/
        public frmAsignarCursosAlumno()
        {
            InitializeComponent();
        }

        List<int> iListaCodigoAsignaciones = new List<int>();
        List<int> iListaCodigoCurso = new List<int>();
        List<int> iListaAsignaciones = new List<int>();
        List<int> iListaAsignacionesCurso = new List<int>();


        public int iObtenerCreditos()
        {
            int iTotalCreditos = 0;
            string sConexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(sConexionBD))
            {
                conexion.Open();
                string sSeleccion = "SELECT totalCreditos FROM Estudiante WHERE carnetEstudiante_pk = @carnet";
                MySqlCommand comando = new MySqlCommand(sSeleccion, conexion);
                comando.Parameters.AddWithValue("@carnet", clsSesion.CarnetEstudiante);

                object carnet = comando.ExecuteScalar();

                if (carnet != null && carnet != DBNull.Value)
                {
                    iTotalCreditos = Convert.ToInt32(carnet);
                }
            }

            return iTotalCreditos;
        }


        private void btnMostrarCursos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNoCiclo.Text))
            {
                MessageBox.Show("Debe llenar el campo de número de ciclo");
                return;
            }
            else
            {
                string sConexionBD = ConexionBD.CadenaConexion();
                try
                {
                    using (MySqlConnection conexion = new MySqlConnection(sConexionBD))
                    {
                        conexion.Open();

                        int codigoCarrera = 0;
                        string sSeleccionCarrera = @"SELECT codigoCarrera_fk FROM Estudiante WHERE carnetEstudiante_pk = @carnet";
                        MySqlCommand comando = new MySqlCommand(sSeleccionCarrera, conexion);
                        comando.Parameters.AddWithValue("@carnet", clsSesion.CarnetEstudiante);
                        object carrera = comando.ExecuteScalar();
                        if (carrera != null)
                        {
                            codigoCarrera = Convert.ToInt32(carrera);
                        }
                        

                        string sSeleccionAsignacion = @"SELECT a.codigoAsignacionCurso_pk AS codigoAsignacion, 
                                                        a.codigoCurso_fk AS Codigo, c.nombreCurso AS Curso, a.seccion AS Seccion,
                                                        a.salon AS Salon, a.diasCurso AS Dia, CONCAT(horaInicio, '-', horaSalida) AS horario,
                                                        c.creditosNecesarios, p.codigoPreRequisito_fk
                                                        FROM AsignacionCurso a
                                                        JOIN Curso c ON a.codigoCurso_fk = c.codigoCurso_pk
                                                        JOIN Pensum p ON c.codigoCurso_pk =  p.codigoCurso_fk
                                                        WHERE p.numeroCiclo = @ciclo AND a.codigoCarrera_fk = @carrera";
                        MySqlCommand comandoDatos = new MySqlCommand(sSeleccionAsignacion, conexion);
                        comandoDatos.Parameters.AddWithValue("@ciclo", txtNoCiclo.Text);
                        comandoDatos.Parameters.AddWithValue("@carrera", codigoCarrera);
                        MySqlDataReader resultado = comandoDatos.ExecuteReader();
                        DataTable tabla = new DataTable();
                        tabla.Columns.Add("Código");
                        tabla.Columns.Add("Curso");
                        tabla.Columns.Add("Sección");
                        tabla.Columns.Add("Días Asignados");
                        tabla.Columns.Add("Horario");
                        tabla.Columns.Add("Salon");
                        int iCreditosEstudiante = iObtenerCreditos();
                        while (resultado.Read())
                        {

                            int iCreditosNecesarios = Convert.ToInt32(resultado["creditosNecesarios"]);
                            object prerequisito = resultado["codigoPreRequisito_fk"];
                            int iCodigoPrerequisito = prerequisito != DBNull.Value ? Convert.ToInt32(prerequisito) : -1;
                            bool requisitos = true;

                            if( iCreditosEstudiante < iCreditosNecesarios)
                            {
                                requisitos = false;
                            }

                            if(iCodigoPrerequisito != -1)
                            {
                                string sValidarNota = @"SELECT (notaPrimerParcial + notaSegundoParcial + notaActividades + examenFinal) AS notaFinal
                                                        FROM Notas WHERE carnetEstudiante_fk = @carnet AND codigoCurso_fk = @curso";
                                using (MySqlCommand cmdValidacion = new MySqlCommand(sValidarNota, conexion))
                                {
                                    cmdValidacion.Parameters.AddWithValue("@carnet", clsSesion.CarnetEstudiante);
                                    cmdValidacion.Parameters.AddWithValue("@curso", iCodigoPrerequisito);
                                    object notaFinal = cmdValidacion.ExecuteScalar();

                                    if (notaFinal == null || Convert.ToInt32(notaFinal) < 61)
                                    {
                                        requisitos = false;
                                    }
                                }
                            }

                            if (!requisitos)
                                continue;


                            string sCodigo = resultado["Codigo"].ToString();
                            string sCurso = resultado["Curso"].ToString();
                            string sSeccion = resultado["Seccion"].ToString();
                            string sSalon = resultado["Salon"].ToString();
                            string sHorario = resultado["horario"].ToString();
                            int dia = Convert.ToInt32(resultado["Dia"]);
                            string sDiasAsignados = clsDiasCurso.sObtenerDiasCurso(dia);
                            
                            tabla.Rows.Add(sCodigo, sCurso, sSeccion, sDiasAsignados, sHorario, sSalon);
                            iListaCodigoAsignaciones.Add(Convert.ToInt32(resultado["codigoAsignacion"]));
                            iListaCodigoCurso.Add(Convert.ToInt32(resultado["Codigo"]));

                        }
                        if (tabla.Rows.Count > 0)
                        {
                            dgvAsignaciones.DataSource = tabla;
                            if (!dgvAsignaciones.Columns.Contains("btnAsignar"))
                            {
                                DataGridViewButtonColumn btnAsignar = new DataGridViewButtonColumn();
                                btnAsignar.HeaderText = "Asignar";
                                btnAsignar.Text = "Asignar";
                                btnAsignar.Name = "btnAsignar";
                                btnAsignar.UseColumnTextForButtonValue = true;
                                dgvAsignaciones.Columns.Add(btnAsignar);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron cursos con los datos proporcionados");
                            return;
                        }
                        dgvAsignaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener las asignaciones: " + ex);
                }
            }
        }

        private void dgvAsignaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColumnaSeleccionada = dgvAsignaciones.Columns[e.ColumnIndex].Name;
                if (sColumnaSeleccionada == "btnAsignar")
                {
                    int iFila = e.RowIndex;
                    var filaSeleccionada = dgvAsignaciones.Rows[iFila];
                    int codigoAsignacion = iListaCodigoAsignaciones[iFila];
                    int codigoCurso = iListaCodigoCurso[iFila];
                    if (!iListaAsignaciones.Contains(codigoAsignacion) && !iListaAsignacionesCurso.Contains(codigoCurso))
                    {
                        iListaAsignaciones.Add(codigoAsignacion);
                        iListaAsignacionesCurso.Add(codigoCurso);
                        MessageBox.Show("Curso agregado a la lista de asignación.");

                        // (Opcional) Deshabilitar botón para marcar que ya se seleccionó
                        dgvAsignaciones.Rows[iFila].Cells["btnAsignar"].ReadOnly = true;
                        dgvAsignaciones.Rows[iFila].Cells["btnAsignar"].Style.BackColor = Color.Gray;
                    }
                    else
                    {
                        MessageBox.Show("Ya ha seleccionado una sección para ese curso.");
                    }
                }
            }
        }

        private void btnRegistroAsignacion_Click(object sender, EventArgs e)
        {
            if (iListaAsignaciones.Count == 0)
            {
                MessageBox.Show("No hay cursos seleccionados para asignar.");
                return;
            }

            string sConexionBD = ConexionBD.CadenaConexion();
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(sConexionBD))
                {
                    conexion.Open();
                    string sInsercion = @"INSERT INTO AsignacionAlumnoE (carnetEstudiante_fk, fechaAsignacion, noDocumento_fk)
                                        VALUES (@carnet, @fecha, @noDocumento)";
                    MySqlCommand comandoEncabezado = new MySqlCommand(sInsercion, conexion);
                    comandoEncabezado.Parameters.AddWithValue("@carnet", clsSesion.CarnetEstudiante);
                    comandoEncabezado.Parameters.AddWithValue("@fecha", DateTime.Now);
                    comandoEncabezado.Parameters.AddWithValue("@noDocumento", clsSesion.noDocumento);
                    comandoEncabezado.ExecuteNonQuery();

                    long idAsignacionGenerada =comandoEncabezado.LastInsertedId;

                    foreach (int codigoAsignacion in iListaAsignaciones)
                    {
                        string insertD = @"INSERT INTO AsignacionAlumnoD (codigoAsignacion_fk, codigoAsignacionCurso_fk)
                                            VALUES (@idAsignacion, @idCurso)";
                        MySqlCommand cmdD = new MySqlCommand(insertD, conexion);
                        cmdD.Parameters.AddWithValue("@idAsignacion", idAsignacionGenerada);
                        cmdD.Parameters.AddWithValue("@idCurso", codigoAsignacion);
                        cmdD.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cursos asignados correctamente.");

                    // Limpiar listas
                    iListaAsignaciones.Clear();
                    iListaAsignacionesCurso.Clear();

                    dgvAsignaciones.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la asignación: " + ex.Message);
            }
        }
    }
}
