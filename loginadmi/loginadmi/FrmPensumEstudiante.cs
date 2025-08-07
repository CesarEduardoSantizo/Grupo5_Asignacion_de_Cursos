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


        private int ObtenerCarreraDelEstudiante()
        {
            int icarnet = clsSesion.CarnetEstudiante;
            int icodigoCarrera = -1;

            string sconexionBD = ConexionBD.CadenaConexion();
            string query = "SELECT codigoCarrera_fk FROM Estudiante WHERE carnetEstudiante_pk = @carnet";

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
                {
                    conexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@carnet", icarnet);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            icodigoCarrera = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la carrera del estudiante: " + ex.Message);
            }

            return icodigoCarrera;
        }

        private void CargarPensum()
        {
            int codigoCarrera = ObtenerCarreraDelEstudiante();
            if (codigoCarrera == -1)
            {
                MessageBox.Show("No se pudo determinar la carrera del estudiante.");
                return;
            }

            string sconexionBD = ConexionBD.CadenaConexion();
            string query = @"
                SELECT 
                    p.codigoCurso_fk,
                    c.nombreCurso,
                    p.codigoPreRequisito_fk,
                    p.numeroCiclo
                FROM Pensum p
                INNER JOIN Curso c ON p.codigoCurso_fk = c.codigoCurso_pk
                WHERE p.codigoCarrera_fk = @codigoCarrera
            ";

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
                {
                    conexion.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@codigoCarrera", codigoCarrera);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvPensumEstudiante.DataSource = dt;

                        dgvPensumEstudiante.Columns["codigoCurso_fk"].HeaderText = "Código";
                        dgvPensumEstudiante.Columns["nombreCurso"].HeaderText = "Nombre";
                        dgvPensumEstudiante.Columns["codigoPreRequisito_fk"].HeaderText = "Pre requisito";
                        dgvPensumEstudiante.Columns["numeroCiclo"].HeaderText = "Ciclo";
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
            int codigoCarrera = ObtenerCarreraDelEstudiante();
            if (codigoCarrera == -1)
            {
                MessageBox.Show("No se pudo determinar la carrera del estudiante.");
                return;
            }

            string sconexionBD = ConexionBD.CadenaConexion();
            string query = "SELECT MAX(numeroCiclo) FROM Pensum WHERE codigoCarrera_fk = @codigoCarrera";

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
                {
                    conexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@codigoCarrera", codigoCarrera);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
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

        // Carga los cursos del ciclo seleccionado
        private void cboPensum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPensum.SelectedItem != null)
            {
                int cicloSeleccionado = Convert.ToInt32(cboPensum.SelectedItem);
                CargarPensumPorCiclo(cicloSeleccionado);
            }
        }

        // Carga el pensum del ciclo filtrado por carrera
        private void CargarPensumPorCiclo(int ciclo)
        {
            int codigoCarrera = ObtenerCarreraDelEstudiante();
            if (codigoCarrera == -1)
            {
                MessageBox.Show("No se pudo determinar la carrera del estudiante.");
                return;
            }

            string sconexionBD = ConexionBD.CadenaConexion();
            string query = @"
                SELECT 
                    p.codigoCurso_fk,
                    c.nombreCurso,
                    p.codigoPreRequisito_fk,
                    p.numeroCiclo
                FROM Pensum p
                INNER JOIN Curso c ON p.codigoCurso_fk = c.codigoCurso_pk
                WHERE p.numeroCiclo = @ciclo AND p.codigoCarrera_fk = @codigoCarrera
            ";

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
                {
                    conexion.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@ciclo", ciclo);
                        adapter.SelectCommand.Parameters.AddWithValue("@codigoCarrera", codigoCarrera);

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvPensumEstudiante.DataSource = dt;

                        dgvPensumEstudiante.Columns["codigoCurso_fk"].HeaderText = "Código";
                        dgvPensumEstudiante.Columns["nombreCurso"].HeaderText = "Nombre";
                        dgvPensumEstudiante.Columns["codigoPreRequisito_fk"].HeaderText = "Pre requisito";
                        dgvPensumEstudiante.Columns["numeroCiclo"].HeaderText = "Ciclo";
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

        private void FrmPensumEstudiante_Load(object sender, EventArgs e)
        {

        }



        private void btnNotas_Click(object sender, EventArgs e)
        {
            FrmNotasEstudiante nuevoFormulario = new FrmNotasEstudiante();
            nuevoFormulario.Show();
            this.Hide(); 
        }

        private void dgvPensumEstudiante_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            FrmCursosEstudiante nuevoFormulario = new FrmCursosEstudiante();
            nuevoFormulario.Show();
            this.Hide();
        }
    }
}
