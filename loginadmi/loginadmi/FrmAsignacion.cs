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
            string documento = txtDocumento.Text.Trim();

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

                    string consulta = "SELECT COUNT(*) FROM costoinscripcion WHERE codigoCostoInscripcion_pk = @codigo AND semestre = @semestre AND año = @año";

                    using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@codigo", documento);
                        cmd.Parameters.AddWithValue("@semestre", semestre);
                        cmd.Parameters.AddWithValue("@año", año);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Todos los datos son correctos.");

                            FrmAsignacionCursos nuevoFormulario = new FrmAsignacionCursos();
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
    }
}

