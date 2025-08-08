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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
// Cesar Eduardo Santizo 0901-22-5215//


namespace loginadmi
{
    public partial class FrmInscripcion : Form
    {
        public FrmInscripcion()
        {
            InitializeComponent();
        }

        private void PicInicio_Click(object sender, EventArgs e)
        {

        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            FrmNotasEstudiante nuevoFormulario = new FrmNotasEstudiante();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            FrmCursosEstudiante nuevoFormulario = new FrmCursosEstudiante();
            nuevoFormulario.Show();
            this.Hide(); 
        }

        private void btnAsignacion_Click(object sender, EventArgs e)
        {
            FrmAsignacion nuevoFormulario = new FrmAsignacion();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            FrmInscripcion nuevoFormulario = new FrmInscripcion();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            FrmHomeEstudiantes nuevoFormulario = new FrmHomeEstudiantes();

            nuevoFormulario.Show();

            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void btnPensum_Click(object sender, EventArgs e)
        {
            FrmPensumEstudiante nuevoFormulario = new FrmPensumEstudiante();
            nuevoFormulario.Show();
            this.Hide(); // o this.Close(); si quieres cerrarlo
        }

        private void PicAsignacion_Click(object sender, EventArgs e)
        {

        }

        private void PicInscripcion_Click(object sender, EventArgs e)
        {

        }

        private void PicCursos_Click(object sender, EventArgs e)
        {

        }

        private void picPensum_Click(object sender, EventArgs e)
        {

        }

        private void PicNotas_Click(object sender, EventArgs e)
        {

        }

        private void PicLogo_Click(object sender, EventArgs e)
        {

        }

        private void PanMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblInscripcion_Click(object sender, EventArgs e)
        {

        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCarné_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCarnet_Click(object sender, EventArgs e)
        {

        }



        private void txtAnio_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPago_Click(object sender, EventArgs e)
     
        {
            string año = cboAnio.Text;
            string semestre = cboSemestre.Text;

            if (string.IsNullOrWhiteSpace(año) || string.IsNullOrWhiteSpace(semestre))
            {
                MessageBox.Show("Por favor debe completar todos los campos.");
                return;
            }

            string conexionBD = ConexionBD.CadenaConexion();
            long codigoCosto = 0;
            decimal valorCosto = 0m;
            long noDocumentoInsert = 0;

            using (var conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    // 1. Obtener código y costo de inscripción
                    const string sqlCosto = @"
                SELECT codigoCostoInscripcion_pk, costo
                  FROM CostoInscripcion
                 WHERE semestre = @semestre
                   AND año      = @año";
                    using (var cmdCosto = new MySqlCommand(sqlCosto, conexion))
                    {
                        cmdCosto.Parameters.AddWithValue("@semestre", semestre);
                        cmdCosto.Parameters.AddWithValue("@año", año);

                        using (var reader = cmdCosto.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                codigoCosto = reader.GetInt64("codigoCostoInscripcion_pk");
                                valorCosto = reader.GetDecimal("costo");
                            }
                            else
                            {
                                MessageBox.Show("No existe un costo de inscripción para ese semestre y año.");
                                return;
                            }
                        }
                    }

                    // 2. Verificar si ya está inscrito
                    const string sqlVerificar = @"
                SELECT COUNT(*)
                  FROM Inscripcion
                 WHERE carnetEstudiante_fk       = @carnet
                   AND codigoCostoInscripcion_fk = @codigoCosto";
                    using (var cmdVerificar = new MySqlCommand(sqlVerificar, conexion))
                    {
                        cmdVerificar.Parameters.AddWithValue("@carnet", clsSesion.CarnetEstudiante);
                        cmdVerificar.Parameters.AddWithValue("@codigoCosto", codigoCosto);

                        int yaInscrito = Convert.ToInt32(cmdVerificar.ExecuteScalar());
                        if (yaInscrito > 0)
                        {
                            MessageBox.Show("Ya tienes una inscripción para este semestre y año.");
                            return;
                        }
                    }

                    // 3. Insertar nueva inscripción
                    const string sqlInsert = @"
                INSERT INTO Inscripcion
                            (carnetEstudiante_fk,
                             codigoCostoInscripcion_fk,
                             fechaInscripcion)
                VALUES (@carnet, @codigoCosto, @fecha)";
                    using (var cmdInsert = new MySqlCommand(sqlInsert, conexion))
                    {
                        cmdInsert.Parameters.AddWithValue("@carnet", clsSesion.CarnetEstudiante);
                        cmdInsert.Parameters.AddWithValue("@codigoCosto", codigoCosto);
                        cmdInsert.Parameters.AddWithValue("@fecha", DateTime.Now.Date);

                        cmdInsert.ExecuteNonQuery();
                        noDocumentoInsert = cmdInsert.LastInsertedId;
                    }

                    MessageBox.Show("Inscripción registrada exitosamente. Boleta No.: " + noDocumentoInsert);



                    // Variables para el nombre completo
                    string nombreAlumno = "";
                    string apellidoAlumno = "";

                    // 2.1 Obtener nombre y apellidos desde la tabla estudiante
                    const string sqlAlumno = @"
                        SELECT nombreEstudiante, apellidosEstudiante
                        FROM Estudiante
                         WHERE carnetEstudiante_pk = @carnet";

                    using (var cmdAlumno = new MySqlCommand(sqlAlumno, conexion))
                    {
                        cmdAlumno.Parameters.AddWithValue("@carnet", clsSesion.CarnetEstudiante);

                        using (var readerAl = cmdAlumno.ExecuteReader())
                        {
                            if (readerAl.Read())
                            {
                                nombreAlumno = readerAl.GetString("nombreEstudiante");
                                apellidoAlumno = readerAl.GetString("apellidosEstudiante");
                            }
                        }
                    }

                    // 4. Generar PDF
using (var save = new SaveFileDialog())
{
    save.Filter   = "Archivo PDF (*.pdf)|*.pdf";
    save.FileName = $"boleta_inscripcion_{noDocumentoInsert}.pdf";

    if (save.ShowDialog() == DialogResult.OK)
    {
        using (var fs = new FileStream(save.FileName, FileMode.Create))
        {
            var doc = new Document();
            PdfWriter.GetInstance(doc, fs);
            doc.Open();

            doc.Add(new Paragraph("BOLETA DE INSCRIPCIÓN", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)));
            doc.Add(new Paragraph(""));

            doc.Add(new Paragraph("Fecha: "       + DateTime.Now.ToString("dd/MM/yyyy")));
            doc.Add(new Paragraph("Boleta No.: "  + noDocumentoInsert));
            doc.Add(new Paragraph("Carnet: "       + clsSesion.CarnetEstudiante));

            // Aquí añadimos Nombre y Apellidos
            doc.Add(new Paragraph("Nombre: "       + nombreAlumno));
            doc.Add(new Paragraph("Apellidos: "    + apellidoAlumno));

            doc.Add(new Paragraph("Año: "          + año));
            doc.Add(new Paragraph("Semestre: "     + semestre));
            doc.Add(new Paragraph("Valor pagado: Q" + valorCosto.ToString("F2")));

            doc.Close();
        }

        MessageBox.Show("PDF generado exitosamente.");
    }
}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al procesar la inscripción: " + ex.Message);
                }
            }
        }



        private void FrmInscripcion_Load(object sender, EventArgs e)
        {
            cboSemestre.Items.Add("1");
            cboSemestre.Items.Add("2");

            cboAnio.Items.Add("2024");
            cboAnio.Items.Add("2025");
            cboAnio.Items.Add("2026");
            cboAnio.Items.Add("2027");
            cboAnio.Items.Add("2028");

            // Enlazar los eventos que detectan cambios
            cboSemestre.SelectedIndexChanged += new EventHandler(Cbo_SelectedIndexChanged);
            cboAnio.SelectedIndexChanged += new EventHandler(Cbo_SelectedIndexChanged);
            txtValor.ReadOnly = true;

        }

        private void Cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string semestre = cboSemestre.Text;
            string anio = cboAnio.Text;

            if (string.IsNullOrWhiteSpace(semestre) || string.IsNullOrWhiteSpace(anio))
            {
                txtValor.Text = "";
                return;
            }

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    string query = "SELECT costo FROM CostoInscripcion WHERE semestre = @semestre AND año = @anio LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@semestre", semestre);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null)
                        {
                            decimal costo = Convert.ToDecimal(resultado);
                            txtValor.Text = "Q" + costo.ToString("F2");
                        }
                        else
                        {
                            txtValor.Text = "No encontrado";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el valor: " + ex.Message);
                }
            }
        }

        private void ObtenerValorInscripcion()
        {
            string semestre = cboSemestre.Text;
            string anio = cboAnio.Text;

            if (string.IsNullOrWhiteSpace(semestre) || string.IsNullOrWhiteSpace(anio))
            {
                txtValor.Text = ""; // Limpia si faltan datos
                return;
            }

            string query = "SELECT costo FROM costoinscripcion WHERE semestre = @semestre AND año = @anio LIMIT 1";

            string conexionBD = ConexionBD.CadenaConexion(); // Usa tu método de conexión
            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@semestre", semestre);
                        cmd.Parameters.AddWithValue("@anio", anio);

                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null)
                        {
                            decimal costo = Convert.ToDecimal(resultado);
                            txtValor.Text = "Q" + costo.ToString("F2");
                        }
                        else
                        {
                            txtValor.Text = "No encontrado";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el costo: " + ex.Message);
                }
            }
        }





        private void txtSemestre_TextChanged(object sender, EventArgs e)
        {

        }

        private void PanInscripcion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboAnio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtValor_TextChanged_1(object sender, EventArgs e)
        {
                
        }
    }
}


