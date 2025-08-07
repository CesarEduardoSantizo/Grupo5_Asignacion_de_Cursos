using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace loginadmi
{
    public partial class FrmNotasEstudiante : Form
    {
        public FrmNotasEstudiante()
        {
            InitializeComponent();
            CargarCiclos();           
            CargarNotasEstudiante(); 
        }

        private void CargarCiclos()
        {
            int carnet = clsSesion.CarnetEstudiante;
            string sconexionBD = ConexionBD.CadenaConexion();

            string query = @"
                SELECT DISTINCT p.numeroCiclo
                FROM Notas n
                INNER JOIN Curso c ON n.codigoCurso_fk = c.codigoCurso_pk
                INNER JOIN Pensum p ON c.codigoCurso_pk = p.codigoCurso_fk
                WHERE n.carnetEstudiante_fk = @carnet
                ORDER BY p.numeroCiclo
            ";

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
                {
                    conexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@carnet", carnet);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            cboCiclo.Items.Clear();
                            cboCiclo.Items.Add("Todos"); // Opción para mostrar todas
                            while (reader.Read())
                            {
                                cboCiclo.Items.Add(reader["numeroCiclo"].ToString());
                            }
                        }
                    }
                }

                cboCiclo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ciclos: " + ex.Message);
            }
        }

  
        private void CargarNotasEstudiante(string ciclo = "")
        {
            int carnet = clsSesion.CarnetEstudiante;
            string sconexionBD = ConexionBD.CadenaConexion();

            string query = @"
                SELECT 
                    c.nombreCurso AS 'Curso',
                    p.numeroCiclo AS 'Ciclo',
                    n.notaPrimerParcial AS 'Primer Parcial',
                    n.notaSegundoParcial AS 'Segundo Parcial',
                    n.notaActividades AS 'Actividades',
                    n.examenFinal AS 'Examen Final'
                FROM Notas n
                INNER JOIN Curso c ON n.codigoCurso_fk = c.codigoCurso_pk
                INNER JOIN Pensum p ON c.codigoCurso_pk = p.codigoCurso_fk
                WHERE n.carnetEstudiante_fk = @carnet
            ";

            if (!string.IsNullOrEmpty(ciclo) && ciclo != "Todos")
            {
                query += " AND p.numeroCiclo = @ciclo ";
            }

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
                {
                    conexion.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@carnet", carnet);
                        if (!string.IsNullOrEmpty(ciclo) && ciclo != "Todos")
                        {
                            adapter.SelectCommand.Parameters.AddWithValue("@ciclo", ciclo);
                        }

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvNotasEstudiante.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las notas del estudiante: " + ex.Message);
            }
        }

        private void cboCiclo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCiclo.SelectedItem != null)
            {
                string cicloSeleccionado = cboCiclo.SelectedItem.ToString();
                CargarNotasEstudiante(cicloSeleccionado);
            }
        }

        private void lblCiclo_Click(object sender, EventArgs e) { }

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

        private void btnInicio_Click(object sender, EventArgs e)
        {
            FrmHomeEstudiantes nuevoFormulario = new FrmHomeEstudiantes();
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

        private void dgvNotasEstudiante_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
