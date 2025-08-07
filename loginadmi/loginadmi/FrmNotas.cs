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
    public partial class FrmNotas : Form
    {
        string conexion = "server=localhost;user=grupoCinco;password=U&grupo5_2501.;database=bd_asignacioncursos";
        public FrmNotas()
        {
            InitializeComponent();
        }

        private void FrmNotas_Load(object sender, EventArgs e)
        {

            CargarNotas();
        }

        private void pnl_home_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btn_Click(object sender, EventArgs e)
        {
            FrmNotas nuevoFormulario = new FrmNotas();
            nuevoFormulario.Show();
            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void btn_lab_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_notas_Click(object sender, EventArgs e)
        {

        }

        private void btn_catedratico_Click(object sender, EventArgs e)
        {
            agregar_catedratico nuevoFormulario = new agregar_catedratico();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btn_estudiantes_Click(object sender, EventArgs e)
        {

            agregarestudiante nuevoFormulario = new agregarestudiante();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            FrmHomeEstudiantes nuevoFormulario = new FrmHomeEstudiantes();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_cursos_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigoNotas_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonInsert_Click_Click(object sender, EventArgs e)
        {
            string sCarnetEstudiante = txtCarnetEstudiante.Text;
            string sNombreCurso = txtNombreCurso.Text;
            string sNotaPrimerParcial = txtNotaPrimerParcial.Text;
            string sNotaSegundoParcial = txtNotaSegundoParcial.Text;
            string sNotaActividades = txtNotaActividades.Text;
            string sNotaFinalParcial = txtNotaFinalParcial.Text;

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();
                    string sConsulta = "SELECT codigoCurso_pk FROM curso where nombreCurso = @curso";
                    MySqlCommand comando = new MySqlCommand(sConsulta, conexion);
                    comando.Parameters.AddWithValue("@curso", sNombreCurso);
                    object resultado = comando.ExecuteScalar();
                    int codigoCurso;

                    if (resultado == null)
                    {
                        MessageBox.Show("Debe Ingresar Primero Informacion del Curso ");
                        return;
                    }
                    else
                    {
                        // Curso ya existe, obtener ID
                        codigoCurso = Convert.ToInt32(resultado);
                    }

                    string sConsultaEstudiante = "SELECT carnetEstudiante_pk FROM estudiante where carnetEstudiante_pk  = @carnetestudiante";
                    MySqlCommand comandoE = new MySqlCommand(sConsultaEstudiante, conexion);
                    comandoE.Parameters.AddWithValue("@carnetestudiante", sCarnetEstudiante);
                    object resultadoE = comandoE.ExecuteScalar();
                    int carnetEstudiante;

                    if (resultadoE == null)
                    {
                        MessageBox.Show("Debe Ingresar Primero el Estudiante ");
                        return;
                    }
                    else
                    {
                        // Carnet ya existe, obtener ID
                        carnetEstudiante = Convert.ToInt32(resultadoE);

                    }

                    object notaPrimerParcial = string.IsNullOrWhiteSpace(sNotaPrimerParcial) ? DBNull.Value : (object)sNotaPrimerParcial;
                    object notaSegundoParcial = string.IsNullOrWhiteSpace(sNotaSegundoParcial) ? DBNull.Value : (object)sNotaSegundoParcial;
                    object notaActividades = string.IsNullOrWhiteSpace(sNotaActividades) ? DBNull.Value : (object)sNotaActividades;
                    object notaFinalParcial = string.IsNullOrWhiteSpace(sNotaFinalParcial) ? DBNull.Value : (object)sNotaFinalParcial;

                    // Ingresar las notas en la base de datos
                    string sinsertarNotas = "INSERT INTO notas (carnetEstudiante_fk, codigoCurso_fk, notaPrimerParcial, notaSegundoParcial, notaActividades, examenFinal) " +
                                             "VALUES (@carnetEstudiante, @codigoCurso, @nota1, @nota2, @notaA, @notaF)";
                    MySqlCommand comandoInsertarNota = new MySqlCommand(sinsertarNotas, conexion);
                    comandoInsertarNota.Parameters.AddWithValue("@carnetEstudiante", carnetEstudiante);
                    comandoInsertarNota.Parameters.AddWithValue("@codigoCurso", codigoCurso);
                    comandoInsertarNota.Parameters.AddWithValue("@nota1", notaPrimerParcial);
                    comandoInsertarNota.Parameters.AddWithValue("@nota2", notaSegundoParcial);
                    comandoInsertarNota.Parameters.AddWithValue("@notaA", notaActividades);
                    comandoInsertarNota.Parameters.AddWithValue("@notaF", notaFinalParcial);
                    comandoInsertarNota.ExecuteNonQuery();

                    if (comandoInsertarNota.LastInsertedId > 0)
                    {
                        MessageBox.Show("Notas registradas exitosamente.");
                        CargarNotas();
                    }

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al registrar notas: " + ex.Message);
                    CargarNotas();
                    return;
                }

            }
        }



        private void CargarNotas()
        {
            // 1) Construimos la conexión (puedes usar tu helper ConexionBD si lo prefieres)
            string cadena = ConexionBD.CadenaConexion();     // o tu string literal

            using (MySqlConnection cn = new MySqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    // 2) Preparamos el SELECT
                    string sql = @"SELECT codigoNota_pk AS Código,
                           carnetEstudiante_fk AS Carnet,
                           c.nombreCurso     AS Curso,
                           notaPrimerParcial  AS '1er Parcial',
                           notaSegundoParcial AS '2º Parcial',
                           notaActividades    AS Actividades,
                           examenFinal        AS Final
                    FROM notas join curso c on notas.codigocurso_fk=c.codigocurso_pk";


                    // 3) Llenamos un DataTable
                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, cn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // 4) Lo enlazamos al DataGridView
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"No pude cargar las notas: {ex.Message}");
                }
            }
        }


        private void buttonEli_click(object sender, EventArgs e)
        {

        }

        private void LimpiarCampos()
{
    
    txtCarnetEstudiante.Clear();
    txtNombreCurso.Clear();
    txtNotaPrimerParcial.Clear();
    txtNotaSegundoParcial.Clear();
    txtNotaActividades.Clear();
    txtNotaFinalParcial.Clear();
}
        private void buttonEli_click_Click(object sender, EventArgs e)
        {
            // Verificamos si hay un código de nota seleccionado
            if (string.IsNullOrWhiteSpace(txtCarnetEstudiante.Text))
            {
                MessageBox.Show("Por favor selecciona una nota para eliminar.");
                return;
            }

            int carnetEstudiante = Convert.ToInt32(txtCarnetEstudiante.Text);
            string conexionBD = ConexionBD.CadenaConexion();

            // Confirmación de eliminación
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta nota?",
                                                  "Confirmar eliminación",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionBD))
                {
                    try
                    {
                        conexion.Open();

                        string consultaEliminar = "DELETE FROM notas WHERE carnetEstudiante_fk = @estudiante";
                        MySqlCommand comandoEliminar = new MySqlCommand(consultaEliminar, conexion);
                        comandoEliminar.Parameters.AddWithValue("@estudiante", carnetEstudiante);

                        int filasAfectadas = comandoEliminar.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Nota eliminada correctamente.");
                            CargarNotas(); // Actualiza el DataGridView
                            LimpiarCampos(); // Limpia los campos de texto (ver siguiente paso)
                        }
                        else
                        {
                            MessageBox.Show("No se encontró la nota a eliminar.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al eliminar la nota: " + ex.Message);
                    }
                }
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;               // Evita edición directa si lo deseas
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                // Asignamos los valores de la fila seleccionada a los TextBox
                txtCarnetEstudiante.Text = fila.Cells["Carnet"].Value.ToString();
                txtNombreCurso.Text = fila.Cells["Curso"].Value.ToString();
                txtNotaPrimerParcial.Text = fila.Cells["1er Parcial"].Value.ToString();
                txtNotaSegundoParcial.Text = fila.Cells["2º Parcial"].Value.ToString();
                txtNotaActividades.Text = fila.Cells["Actividades"].Value.ToString();
                txtNotaFinalParcial.Text = fila.Cells["Final"].Value.ToString();
            }
        }

        private void buttonMod_Click(object sender, EventArgs e)

        {

            string sCodigoNota = txtCodigoNotas.Text;
            string sCarnetEstudiante = txtCarnetEstudiante.Text;
            string sNombreCurso = txtNombreCurso.Text;
            string sNotaPrimerParcial = txtNotaPrimerParcial.Text;
            string sNotaSegundoParcial = txtNotaSegundoParcial.Text;
            string sNotaActividades = txtNotaActividades.Text;
            string sNotaFinalParcial = txtNotaFinalParcial.Text;

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    // Obtener código del curso
                    string consultaCurso = "SELECT codigoCurso_pk FROM curso WHERE nombreCurso = @nombreCurso";
                    MySqlCommand cmdCurso = new MySqlCommand(consultaCurso, conexion);
                    cmdCurso.Parameters.AddWithValue("@nombreCurso", sNombreCurso);
                    object resultCurso = cmdCurso.ExecuteScalar();

                    if (resultCurso == null)
                    {
                        MessageBox.Show("El curso no existe.");
                        return;
                    }

                    int codigoCurso = Convert.ToInt32(resultCurso);

                    // Validar si el estudiante existe
                    string consultaEst = "SELECT carnetEstudiante_pk FROM estudiante WHERE carnetEstudiante_pk = @carnet";
                    MySqlCommand cmdEst = new MySqlCommand(consultaEst, conexion);
                    cmdEst.Parameters.AddWithValue("@carnet", sCarnetEstudiante);
                    object resultEst = cmdEst.ExecuteScalar();

                    if (resultEst == null)
                    {
                        MessageBox.Show("El estudiante no existe.");
                        return;
                    }

                    int carnetEstudiante = Convert.ToInt32(resultEst);

                    // UPDATE
                    string consultaUpdate = @"UPDATE notas 
                                SET carnetEstudiante_fk = @carnet,
                                    codigoCurso_fk = @curso,
                                    notaPrimerParcial = @nota1,
                                    notaSegundoParcial = @nota2,
                                    notaActividades = @notaA,
                                    examenFinal = @notaF
                              WHERE codigoNota_pk = @codigoNota";
                    object notaPrimerParcial = string.IsNullOrWhiteSpace(sNotaPrimerParcial) ? DBNull.Value : (object)sNotaPrimerParcial;
                    object notaSegundoParcial = string.IsNullOrWhiteSpace(sNotaSegundoParcial) ? DBNull.Value : (object)sNotaSegundoParcial;
                    object notaActividades = string.IsNullOrWhiteSpace(sNotaActividades) ? DBNull.Value : (object)sNotaActividades;
                    object notaFinalParcial = string.IsNullOrWhiteSpace(sNotaFinalParcial) ? DBNull.Value : (object)sNotaFinalParcial;

                    MySqlCommand cmdUpdate = new MySqlCommand(consultaUpdate, conexion);
                    cmdUpdate.Parameters.AddWithValue("@carnet", carnetEstudiante);
                    cmdUpdate.Parameters.AddWithValue("@curso", codigoCurso);
                    cmdUpdate.Parameters.AddWithValue("@nota1", notaPrimerParcial);
                    cmdUpdate.Parameters.AddWithValue("@nota2", notaSegundoParcial);
                    cmdUpdate.Parameters.AddWithValue("@notaA", notaActividades);
                    cmdUpdate.Parameters.AddWithValue("@notaF", notaFinalParcial);
                    cmdUpdate.Parameters.AddWithValue("@codigoNota", sCodigoNota);

                    int filasAfectadas = cmdUpdate.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Nota modificada correctamente.");
                        CargarNotas(); // Recarga el DataGridView
                    }
                    else
                    {
                        MessageBox.Show("No se modificó ninguna fila.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al modificar la nota: " + ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Notas_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtCodigoNotas_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNotaFinalParcial_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNotaActividades_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNotaSegundoParcial_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNotaPrimerParcial_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreCurso_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCarnetEstudiante_TextChanged(object sender, EventArgs e)
        {

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

        private void btnFacultad_Click(object sender, EventArgs e)
        {
            Facultades facultades = new Facultades();
            facultades.Show();
            this.Hide();
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            FrmInscripcion frmCostoInscripcion = new FrmInscripcion();
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
