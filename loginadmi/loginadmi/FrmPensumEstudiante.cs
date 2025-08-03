using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace loginadmi
{
    public partial class FrmPensumEstudiante : Form
    {
        public FrmPensumEstudiante()
        {
            InitializeComponent();
            CargarPensum();
            CargarCiclos();
        }

        private void CargarPensum()
        {
            string sconexionBD = ConexionBD.CadenaConexion();
            string query = @"
                SELECT 
                    p.codigoCurso_fk,
                    c.nombreCurso,
                    p.codigoPreRequisito_fk,
                    p.numeroCiclo
                FROM Pensum p
                INNER JOIN Curso c ON p.codigoCurso_fk = c.codigoCurso_pk
            ";

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
                {
                    conexion.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        lstPensumEstudiante.DataSource = dt;


                        lstPensumEstudiante.Columns["codigoCurso_fk"].HeaderText = "Código";
                        lstPensumEstudiante.Columns["nombreCurso"].HeaderText = "Nombre";
                        lstPensumEstudiante.Columns["codigoPreRequisito_fk"].HeaderText = "Pre rrequisito";
                        lstPensumEstudiante.Columns["numeroCiclo"].HeaderText = "Ciclo";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el pensum: " + ex.Message);
            }
        }

        private void CargarCiclos()
        {
            string sconexionBD = ConexionBD.CadenaConexion();
            string query = "SELECT MAX(numeroCiclo) FROM Pensum";
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
                {
                    conexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            int maxCiclo = Convert.ToInt32(result);
                            cboPensum.Items.Clear();
                            for (int i = 1; i <= maxCiclo; i++)
                            {
                                cboPensum.Items.Add(i);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ciclos: " + ex.Message);
            }
        }

        private void lstPensumEstudiante_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboPensum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPensum.SelectedItem != null)
            {
                int cicloSeleccionado = Convert.ToInt32(cboPensum.SelectedItem);
                CargarPensumPorCiclo(cicloSeleccionado);
            }
        }

        private void CargarPensumPorCiclo(int ciclo)
        {
            string sconexionBD = ConexionBD.CadenaConexion();
            string query = @"
                SELECT 
                    p.codigoCurso_fk,
                    c.nombreCurso,
                    p.codigoPreRequisito_fk,
                    p.numeroCiclo
                FROM Pensum p
                INNER JOIN Curso c ON p.codigoCurso_fk = c.codigoCurso_pk
                WHERE p.numeroCiclo = @ciclo
            ";

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
                {
                    conexion.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@ciclo", ciclo);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        lstPensumEstudiante.DataSource = dt;

                        lstPensumEstudiante.Columns["codigoCurso_fk"].HeaderText = "Código";
                        lstPensumEstudiante.Columns["nombreCurso"].HeaderText = "Nombre";
                        lstPensumEstudiante.Columns["codigoPreRequisito_fk"].HeaderText = "Pre rrequisito";
                        lstPensumEstudiante.Columns["numeroCiclo"].HeaderText = "Ciclo";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar el pensum: " + ex.Message);
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            FrmHomeEstudiantes nuevoFormulario = new FrmHomeEstudiantes();
            nuevoFormulario.Show();
            this.Hide(); 
        }

        private void btnPensum_Click(object sender, EventArgs e)
        {
            FrmPensumEstudiante nuevoFormulario = new FrmPensumEstudiante();
            nuevoFormulario.Show();
            this.Hide();

        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            FrmInscripcion nuevoFormulario = new FrmInscripcion();
            nuevoFormulario.Show();
            this.Hide(); 
        }

        private void btnAsignacion_Click(object sender, EventArgs e)
        {
            FrmAsignacion nuevoFormulario = new FrmAsignacion();
            nuevoFormulario.Show();
            this.Hide();
        }
    }
}
