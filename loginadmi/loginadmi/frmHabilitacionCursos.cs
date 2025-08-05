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

namespace loginadmi.Administrador.Cursos
{
    public partial class frmHabilitacionCursos : Form
    {
        public frmHabilitacionCursos()
        {
            InitializeComponent();
            this.Load += frmHabilitacionCursos_Load;
        }


        // --------------------------------- Programado por:  Anderson Trigueros ---------------------------------//


        private Dictionary<int, string> diasAsignados = new Dictionary<int, string>
        {
            {1, "Lunes y Miércoles"},
            {2, "Martes y Jueves" },
            {3, "Lunes, Miércoles y Viernes"},
            {4, "Martes, Jueves y Viernes" },
            {5, "Viernes"},
            {6, "Sábado" }
        };

        private int fObtenerOpcionDia()
        {
            foreach (var dia in diasAsignados)
            {
                if (dia.Value == cboDías.Text)
                {
                    return dia.Key;
                }
            }
            return 0;
        }

        private void frmHabilitacionCursos_Load(object sender, EventArgs e)
        {
            //Opciones de Días de Cursos
            cboDías.Items.Clear();
            foreach (var dia in diasAsignados)
            {
                cboDías.Items.Add(dia.Value);
            }

            //Opciones de catedraticos
            clsCatedraticos catedratico = new clsCatedraticos();
            var catedraticos = catedratico.ObtenerCatedraticos();
            cboCatedrático.DataSource = catedraticos;
            cboCatedrático.DisplayMember = "sNombreCatedratico";
            cboCatedrático.ValueMember = "iCarnetCatedratico";
            cboCatedrático.SelectedIndex = -1;
            

            //Opciones de Semestre
            cboSemestre.Items.Clear();
            cboSemestre.Items.Add("1");
            cboSemestre.Items.Add("2");

            //Opciones de Cursos
            clsCurso curso = new clsCurso();
            var cursos = curso.ObtenerListadoCursos();
            cboCurso.DataSource = cursos;
            cboCurso.DisplayMember = "sNombreCurso";
            cboCurso.ValueMember = "iCodigoCurso";
            cboCurso.SelectedIndex = -1;

            //Opciones de Carreras
            clsCarrera carrera = new clsCarrera();
            var carreras = carrera.ObtenerCarreras();
            cboCarreras.DataSource = carreras;
            cboCarreras.DisplayMember = "sNombreCarrera";
            cboCarreras.ValueMember = "iCodigoCarrera";
            cboCarreras.SelectedIndex = -1;
        }

        private bool EsOpcionValida(ComboBox combo)
        {
            return combo.SelectedIndex != -1;
        }

        private void btnRegistroAsignacion_Click(object sender, EventArgs e)
        {
            if (cboCurso.SelectedValue == null || cboCarreras.SelectedValue == null || cboCatedrático.SelectedValue == null ||
                string.IsNullOrEmpty(txtSalon.Text) || string.IsNullOrEmpty(txtSeccion.Text) ||
                string.IsNullOrEmpty(txtHoraInicio.Text) || string.IsNullOrEmpty(txtHoraSalida.Text) ||
                string.IsNullOrEmpty(cboDías.Text) ||string.IsNullOrEmpty(cboSemestre.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            if (!EsOpcionValida(cboCurso) || !EsOpcionValida(cboCarreras) || !EsOpcionValida(cboCatedrático))
            {
                MessageBox.Show("Por favor, seleccione una opción válida de las listas.");
                return;
            }
            else
            {
                string conexionBD = ConexionBD.CadenaConexion();
                try
                {
                    int iNumeroDia = fObtenerOpcionDia();
                    using (MySqlConnection conexion = new MySqlConnection(conexionBD))
                    {
                        conexion.Open();

                        //Verificar si existe ya un curso ingresado en ese semestre del año, con la sección y la carrera ingresada
                        string sConsultaExistencia = @"SELECT ac.codigoAsignacionCurso_pk FROM asignacionCurso ac
                                                        JOIN Curso c ON ac.codigoCurso_fk = c.codigoCurso_pk
                                                        WHERE ac.seccion = @seccion AND ac.semestreAsignacion = @semestre 
                                                        AND ac.añoAsignacion = @año AND c.nombreCurso = @curso AND ac.codigoCarrera_fk = @carrera ";
                        MySqlCommand comandoSeleccion = new MySqlCommand(sConsultaExistencia, conexion);
                        comandoSeleccion.Parameters.AddWithValue("@seccion", txtSeccion.Text);
                        comandoSeleccion.Parameters.AddWithValue("@semestre", cboSemestre.Text);
                        comandoSeleccion.Parameters.AddWithValue("@año", txtAño.Text);
                        comandoSeleccion.Parameters.AddWithValue("@curso", cboCurso.Text);
                        comandoSeleccion.Parameters.AddWithValue("@carrera", cboCarreras.SelectedValue);
                        object resultado = comandoSeleccion.ExecuteScalar();
                        if (resultado != null)
                        {
                            MessageBox.Show("Ya se ha registrado el curso " + cboCurso.Text + ", seccion " + txtSeccion.Text + " en la carrera de " + cboCarreras.Text +  ", en el semestre indicado del año");
                            return;
                        }
                        
                        else
                        {
                            string sConsultaInsertar = "INSERT INTO asignacioncurso (codigoCurso_fk, seccion, salon, " +
                                    "horaInicio, horaSalida, diasCurso, semestreAsignacion, añoAsignacion, codigoCarrera_fk, codigoCatedratico_fk, fechaAsignacion) " +
                                    "VALUES (@codigoCurso, @seccion, @salon, @horaInicio, @horaSalida, @dias, @semestre, @año, @codigoCarrera, @codigoCatedratico, @fecha)";
                            MySqlCommand comando = new MySqlCommand(sConsultaInsertar, conexion);
                            comando.Parameters.AddWithValue("@codigoCurso", cboCurso.SelectedValue);
                            comando.Parameters.AddWithValue("@seccion", txtSeccion.Text);
                            comando.Parameters.AddWithValue("@salon", txtSalon.Text);
                            comando.Parameters.AddWithValue("@horaInicio", txtHoraInicio.Text);
                            comando.Parameters.AddWithValue("@horaSalida", txtHoraSalida.Text);
                            comando.Parameters.AddWithValue("@dias", iNumeroDia);
                            comando.Parameters.AddWithValue("@semestre", cboSemestre.Text);
                            comando.Parameters.AddWithValue("@año", txtAño.Text);
                            comando.Parameters.AddWithValue("@codigoCarrera", cboCarreras.SelectedValue);
                            comando.Parameters.AddWithValue("@codigoCatedratico", cboCatedrático.SelectedValue);
                            comando.Parameters.AddWithValue("@fecha", DateTime.Now);
                            comando.ExecuteNonQuery();

                            if (comando.LastInsertedId > 0)
                            {
                                MessageBox.Show("Asignación de curso registrada con éxito");
                                cboCurso.SelectedIndex = -1;
                                cboCarreras.SelectedIndex = -1;
                                txtSalon.Clear();
                                txtSeccion.Clear();
                                txtHoraInicio.Clear();
                                txtHoraSalida.Clear();
                                cboCatedrático.SelectedIndex = -1;
                                cboDías.SelectedIndex = -1;
                                cboSemestre.SelectedIndex = -1;
                                txtAño.Clear();
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al registrar la asignación de curso: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado: " + ex.Message);
                }
            }

        }

        private void btnListadoCursos_Click(object sender, EventArgs e)
        {
            frmListadoCursos frmListadoCursos = new frmListadoCursos();
            frmListadoCursos.Show();
            this.Hide();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            frmModuloCursos frmModuloCursos = new frmModuloCursos();
            frmModuloCursos.Show();
            this.Hide();
        }
    }
}
