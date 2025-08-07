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
// Cesar Eduardo Santizo 0901-22-5215//
namespace loginadmi
{
    public partial class FrmAsignacion : Form
    {
        public FrmAsignacion()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            FrmHomeEstudiantes nuevoFormulario = new FrmHomeEstudiantes();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {

            FrmInscripcion nuevoFormulario = new FrmInscripcion();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btnAsignacion_Click(object sender, EventArgs e)
        {

            FrmAsignacion nuevoFormulario = new FrmAsignacion();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void lblDatos_Click(object sender, EventArgs e)
        {

        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            string semestre = txtSemestre.Text.Trim();
            string año = txtAnio.Text.Trim();
            string documento = txtValor.Text.Trim();

            if (string.IsNullOrWhiteSpace(semestre) || string.IsNullOrWhiteSpace(año) || string.IsNullOrWhiteSpace(documento))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    string sConsulta = @"SELECT i.noDocumento_pk
                                        FROM Inscripcion i
                                        INNER JOIN CostoInscripcion ci ON i.codigoCostoInscripcion_fk = ci.codigoCostoInscripcion_pk
                                        WHERE i.noDocumento_pk = @noDocumento
                                          AND ci.semestre = @semestre
                                          AND ci.año = @año";

                    using (MySqlCommand cmd = new MySqlCommand(sConsulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@noDocumento", documento);
                        cmd.Parameters.AddWithValue("@semestre", semestre);
                        cmd.Parameters.AddWithValue("@año", año);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            MessageBox.Show("Todos los datos son correctos.");
                            clsSesion.noDocumento = Convert.ToInt32(result);
                            frmAsignarCursosAlumno nuevoFormulario = new frmAsignarCursosAlumno();
                            nuevoFormulario.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Los datos no coinciden con la base de datos. Verifique el semestre, año y número de documento.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar los datos: " + ex.Message);
                }
            }


        }

        private void lblSemestre_Click(object sender, EventArgs e)
        {

        }

        private void FrmAsignacion_Load(object sender, EventArgs e)
        {

        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            FrmCursosEstudiante nuevoFormulario = new FrmCursosEstudiante();
            nuevoFormulario.Show();
            this.Hide(); 
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            FrmNotasEstudiante nuevoFormulario = new FrmNotasEstudiante();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnPensum_Click(object sender, EventArgs e)
        {
            FrmPensumEstudiante nuevoFormulario = new FrmPensumEstudiante();
            nuevoFormulario.Show();
            this.Hide(); 
        }
    }
}

