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
    public partial class frmListadosAlumnos : Form
    {
        public frmListadosAlumnos()
        {
            InitializeComponent();
        }

        private void btnMostrarCursos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAño.Text) || string.IsNullOrEmpty(txtSemestre.Text)
                || string.IsNullOrEmpty(txtCurso.Text) || string.IsNullOrEmpty(txtCarrera.Text)
                || string.IsNullOrEmpty(txtSeccion.Text))
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
                        string sSeleccionCursos = @"SELECT e.carnetEstudiante_pk as carnet, e.nombreEstudiante as Nombre, 
                                                    e.apellidosEstudiante as Apellido, e.correoEstudiante AS correo
                                                    FROM AsignacionAlumnoD ad
                                                    JOIN AsignacionAlumnoE ae ON ad.codigoAsignacion_fk = ae.codigoAsignacion_pk
                                                    JOIN Estudiante e ON ae.carnetEstudiante_fk = e.carnetEstudiante_pk
                                                    JOIN AsignacionCurso ac ON ad.codigoAsignacionCurso_fk = ac.codigoAsignacionCurso_pk
                                                    JOIN Curso c ON ac.codigoCurso_fk = c.codigoCurso_pk
                                                    JOIN Carrera ca ON ac.codigoCarrera_fk = ca.codigoCarrera_pk
                                                    WHERE c.nombreCurso = @nombreCurso AND ca.nombreCarrera = @nombreCarrera
                                                    AND ac.seccion = @seccion AND ac.añoAsignacion = @año AND ac.semestreAsignacion = @semestre
                                                    AND ac.codigoCatedratico_fk = @carnet;";
                        MySqlCommand comando = new MySqlCommand(sSeleccionCursos, conexion);
                        comando.Parameters.AddWithValue("@nombreCurso", txtCurso.Text);
                        comando.Parameters.AddWithValue("@nombreCarrera", txtCarrera.Text);
                        comando.Parameters.AddWithValue("@seccion", txtSeccion.Text);
                        comando.Parameters.AddWithValue("@año", txtAño.Text);
                        comando.Parameters.AddWithValue("@semestre", txtSemestre.Text);
                        comando.Parameters.AddWithValue("@carnet", clsSesion.CarnetCatedratico);
                        MySqlDataReader resultado = comando.ExecuteReader();
                        DataTable tabla = new DataTable();
                        tabla.Columns.Add("Carnet");
                        tabla.Columns.Add("Nombres");
                        tabla.Columns.Add("Apellidos");
                        tabla.Columns.Add("Correo");
                        while (resultado.Read())
                        {
                            string sCarnet = resultado["carnet"].ToString();
                            string sNombre = resultado["Nombre"].ToString();
                            string sApellido = resultado["Apellido"].ToString();
                            string sCorreo = resultado["Correo"].ToString();
                            tabla.Rows.Add(sCarnet, sNombre, sApellido, sCorreo);
                        }
                        if (tabla.Rows.Count > 0)
                        {
                            dgvListado.DataSource = tabla;
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron cursos con los datos proporcionados");
                            return;
                        }
                        dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void btnListados_Click(object sender, EventArgs e)
        {
            frmListadosAlumnos frmListadosAlumnos = new frmListadosAlumnos();
            frmListadosAlumnos.Show();
            this.Hide();
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            FrmNotasCatedratico frmNotasCatedratico = new FrmNotasCatedratico();
            frmNotasCatedratico.Show();
            this.Hide();
        }
    }
}
