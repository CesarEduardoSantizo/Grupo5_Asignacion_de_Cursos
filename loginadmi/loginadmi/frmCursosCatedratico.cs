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
    public partial class frmCursosCatedratico : Form
    {
        public frmCursosCatedratico()
        {
            InitializeComponent();
        }

        private void btnMostrarCursos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAño.Text) || string.IsNullOrEmpty(txtSemestre.Text))
            {
                MessageBox.Show("Complete todos los campos para mostrar los cursos.");
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
                        string sSeleccionCursos = @"SELECT ac.codigoCurso_fk as codigo, c.nombreCurso as Curso, ac.seccion as Seccion,
                                                    ac.salon as Salon, ac.diasCurso AS Dia, CONCAT(horaInicio, ' - ', horaSalida) AS horario, 
                                                    ca.nombreCarrera as Carrera
                                                    FROM AsignacionCurso ac
                                                    JOIN Carrera ca ON ac.codigoCarrera_fk = ca.codigoCarrera_pk
                                                    JOIN Curso c ON ac.codigoCurso_fk = c.codigoCurso_pk
                                                    WHERE ac.codigoCatedratico_fk = @carnet AND ac.semestreAsignacion = @semestre 
                                                    AND ac.añoAsignacion = @año";
                        MySqlCommand comando = new MySqlCommand(sSeleccionCursos, conexion);
                        comando.Parameters.AddWithValue("@carnet", clsSesion.CarnetCatedratico);
                        comando.Parameters.AddWithValue("@año", txtAño.Text);
                        comando.Parameters.AddWithValue("@semestre", txtSemestre.Text);
                        MySqlDataReader resultado = comando.ExecuteReader();
                        DataTable tabla = new DataTable();
                        tabla.Columns.Add("Código");
                        tabla.Columns.Add("Curso");
                        tabla.Columns.Add("Sección");
                        tabla.Columns.Add("Carrera");
                        tabla.Columns.Add("Días Asignados");
                        tabla.Columns.Add("Horario");
                        tabla.Columns.Add("Salón");
                        while (resultado.Read())
                        {
                            string sCodigo = resultado["codigo"].ToString();
                            string sCurso = resultado["Curso"].ToString();
                            string sSeccion = resultado["Seccion"].ToString();
                            string sCarrera = resultado["Carrera"].ToString();
                            string sHorario = resultado["horario"].ToString();
                            int dia = Convert.ToInt32(resultado["Dia"]);
                            string sSalon = resultado["Salon"].ToString();
                            string sDiasAsignados = clsDiasCurso.sObtenerDiasCurso(dia);

                            tabla.Rows.Add(sCodigo, sCurso, sSeccion, sCarrera, sDiasAsignados, sHorario, sSalon);
                        }
                        if (tabla.Rows.Count > 0)
                        {
                            dgvCursos.DataSource = tabla;
                            dgvCursos.Columns["Código"].FillWeight = 50;
                            dgvCursos.Columns["Sección"].FillWeight = 60;
                            dgvCursos.Columns["Salón"].FillWeight = 60;
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron cursos con los datos proporcionados");
                            return;
                        }
                        dgvCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener los cursos: " + ex.Message);
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

        private void btnListados_Click(object sender, EventArgs e)
        {
            frmListadosAlumnos frmListadosAlumnos = new frmListadosAlumnos();
            frmListadosAlumnos.Show();
            this.Hide();
        }
    }
}
