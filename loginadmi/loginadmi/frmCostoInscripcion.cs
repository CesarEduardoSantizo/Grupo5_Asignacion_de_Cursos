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
    public partial class frmCostoInscripcion : Form
    {
        public frmCostoInscripcion()
        {
            InitializeComponent();
        }

        private void btnRegistroAsignacion_Click(object sender, EventArgs e)
        {
            int numero;

            if (string.IsNullOrEmpty(txtAño.Text) || string.IsNullOrEmpty(cboSemestre.Text) || string.IsNullOrEmpty(txtCosto.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            if(!int.TryParse(txtCosto.Text, out numero)) {
                MessageBox.Show("Debe ingresar un numero para el costo");
                return;
            }

            else
            {
                string conexionBD = ConexionBD.CadenaConexion();
                try
                {
                    using (MySqlConnection conexion = new MySqlConnection(conexionBD))
                    {
                        conexion.Open();
                        //Verificar si existe ya un registro de costo de inscripción con los datos ingresados
                        string sConsultaExistencia = @"SELECT codigoCostoInscripcion_pk FROM CostoInscripcion
                                                        WHERE semestre = @semestre AND año = @año";
                        MySqlCommand comandoSeleccion = new MySqlCommand(sConsultaExistencia, conexion);
                        comandoSeleccion.Parameters.AddWithValue("@semestre", cboSemestre.Text);
                        comandoSeleccion.Parameters.AddWithValue("@año", txtAño.Text);
                        object resultado = comandoSeleccion.ExecuteScalar();
                        if (resultado != null)
                        {
                            MessageBox.Show("Ya se ha registrado un costo de inscripción para el semestre " + cboSemestre.Text + " del " + txtAño.Text);
                            return;
                        }


                        else
                        {
                            string sConsultaInsertar = @"INSERT INTO CostoInscripcion (semestre, año, costo) 
                                                        VALUES (@semestre, @año, @costo)";
                            MySqlCommand comando = new MySqlCommand(sConsultaInsertar, conexion);
                            comando.Parameters.AddWithValue("@semestre", cboSemestre.Text);
                            comando.Parameters.AddWithValue("@año", txtAño.Text);
                            comando.Parameters.AddWithValue("@costo", txtCosto.Text);
                            comando.ExecuteNonQuery();

                            if (comando.LastInsertedId > 0)
                            {
                                MessageBox.Show("Registro de costo de inscripción realizado con éxito");
                                cboSemestre.SelectedIndex = -1;
                                txtAño.Clear();
                                txtCosto.Clear();
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al ingresar el costo de inscripción: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado: " + ex.Message);
                }
            }

        }

        private void frmCostoInscripcion_Load(object sender, EventArgs e)
        {
            //Opciones de Semestre
            cboSemestre.Items.Clear();
            cboSemestre.Items.Add("1");
            cboSemestre.Items.Add("2");
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            homeadmi homeadmi = new homeadmi();
            homeadmi.Show();
            this.Hide();
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            agregarestudiante agregarestudiante = new agregarestudiante();
            agregarestudiante.Show();
            this.Hide();
        }

        private void btnCatedratico_Click(object sender, EventArgs e)
        {
            agregar_catedratico agregar_Catedratico = new agregar_catedratico();
            agregar_Catedratico.Show();
            this.Hide();
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            FrmNotas frmNotas = new FrmNotas();
            frmNotas.Show();
            this.Hide();
        }

        private void btnFacultades_Click(object sender, EventArgs e)
        {
            Facultades facultades = new Facultades();
            facultades.Show();
            this.Hide();
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            frmCostoInscripcion frmCostoInscripcion = new frmCostoInscripcion();
            frmCostoInscripcion.Show();
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
