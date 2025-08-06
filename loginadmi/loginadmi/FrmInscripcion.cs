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

        }

        private void btnCursos_Click(object sender, EventArgs e)
        {

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
            long codigo = 0;
            string valorDesdeBD = "";

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    string consulta = "SELECT codigoCostoInscripcion_pk, costo FROM costoinscripcion WHERE semestre = @semestre AND año = @año";
                    using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@semestre", semestre);
                        cmd.Parameters.AddWithValue("@año", año);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                codigo = reader.GetInt64("codigoCostoInscripcion_pk");
                                valorDesdeBD = reader.GetDecimal("costo").ToString("F2");

                                MessageBox.Show("Datos verificados correctamente.");

                                // Generar PDF
                                SaveFileDialog saveFileDialog = new SaveFileDialog();
                                saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
                                saveFileDialog.FileName = "boleta_inscripcion_" + codigo + ".pdf";

                                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    Document doc = new Document();
                                    PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                                    doc.Open();

                                    doc.Add(new Paragraph("BOLETA DE INSCRIPCIÓN", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)));
                                    doc.Add(new Paragraph(" "));
                                    doc.Add(new Paragraph("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy")));
                                    doc.Add(new Paragraph("Código de inscripción: " + codigo));
                                    doc.Add(new Paragraph("Año: " + año));
                                    doc.Add(new Paragraph("Semestre: " + semestre));
                                    doc.Add(new Paragraph("Valor pagado: Q" + valorDesdeBD));

                                    doc.Close();

                                    MessageBox.Show("PDF generado exitosamente.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontró una inscripción con esos datos.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar los datos: " + ex.Message);
                }
            }
        }


        private void FrmInscripcion_Load(object sender, EventArgs e)
        {

           
                cboSemestre.Items.Clear();
                cboSemestre.Items.Add("1");
                cboSemestre.Items.Add("2");

                cboAnio.Items.Clear();
                cboAnio.Items.Add("2024");
                cboAnio.Items.Add("2025");
                cboAnio.Items.Add("2026");
                cboAnio.Items.Add("2027");
                cboAnio.Items.Add("2028");
                cboAnio.Items.Add("2029");

     
            

        }

        private void ObtenerValorInscripcion()
        {
            string semestre = cboSemestre.Text;
            string anio = cboAnio.Text;

            if (string.IsNullOrWhiteSpace(semestre) || string.IsNullOrWhiteSpace(anio))
                return;

            string query = "SELECT costo FROM costoinscripcion WHERE semestre = @semestre AND año = @anio LIMIT 1";

            using (MySqlConnection conexion = new MySqlConnection("tu_conexion"))
            {
                conexion.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@semestre", semestre);
                    cmd.Parameters.AddWithValue("@anio", anio);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                      
                        txt_nombres.Text = reader["nombreCatedratico"].ToString();
                    }
                    else
                    {
                        txtValor.TextBox.Clear();
                        txtValor.Items.Add("No encontrado");
                        txtValor.SelectedIndex = 0;
                    }

                }
            }
        }




        private void txtSemestre_TextChanged(object sender, EventArgs e)
        {

        }

        private void PanInscripcion_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


