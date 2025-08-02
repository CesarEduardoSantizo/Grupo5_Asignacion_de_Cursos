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
            string año = txtAnio.Text;
            string semestre = txtSemestre.Text;
            string valor = txtValor.Text;

            if (string.IsNullOrWhiteSpace(año) || string.IsNullOrWhiteSpace(semestre) || string.IsNullOrWhiteSpace(valor))
            {
                MessageBox.Show("Por favor debe completar todos los campos.");
                return;
            }

            if (valor != "1050")
            {
                MessageBox.Show("Costo está malo. El valor debe ser exactamente 1050.");
                return;
            }

            string sconecionBD = ConexionBD.CadenaConexion();
            long codigo = 0;

            using (MySqlConnection conexion = new MySqlConnection(sconecionBD))
            {
                try
                {
                    conexion.Open();

                    string insertar = "INSERT INTO costoinscripcion (semestre, año, costo) VALUES (@semestre, @año, @costo)";
                    using (MySqlCommand cmd = new MySqlCommand(insertar, conexion))
                    {
                        cmd.Parameters.AddWithValue("@semestre", semestre);
                        cmd.Parameters.AddWithValue("@año", año);
                        cmd.Parameters.AddWithValue("@costo", valor);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        // Ahora sí puedes obtener el ID insertado
                        codigo = cmd.LastInsertedId;

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Inscripción hecha correctamente");

                            // Limpiar los campos
                            txtAnio.Text = "";
                            txtSemestre.Text = "";
                            txtValor.Text = "";

                            // Ahora generas el PDF con el código correcto
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
                                doc.Add(new Paragraph("Valor pagado: Q" + valor));

                                doc.Close();

                                MessageBox.Show("PDF generado exitosamente.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo realizar la inscripción");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar: " + ex.Message);
                }
            }
        }

    }
}


