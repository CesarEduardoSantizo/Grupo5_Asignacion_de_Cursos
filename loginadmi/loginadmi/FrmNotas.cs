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
            {
                // Validar que los campos no estén vacíos
                if (txtNotaPrimerParcial.Text == "" || txtNotaSegundoParcial.Text == "" ||
                    txtNotaActividades.Text == "" || txtNotaFinalParcial.Text == "")
                {
                    MessageBox.Show("Por favor, llene todos los campos.");
                    return;
                }

                try
                {
                    using (MySqlConnection conexion = new MySqlConnection(ConexionBD.CadenaConexion()))
                    {
                        conexion.Open();

                        string consulta = @"INSERT INTO Notas 
                        (notaPrimerParcial, notaSegundoParcial, notaActividades, examenFinal) 
                        VALUES (@carnet, @curso, @nota1, @nota2, @actividades, @examenFinal)";

                        using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                        {
                            // Aquí puedes reemplazar estos valores por datos reales o controles en el formulario
                            comando.Parameters.AddWithValue("@carnet", 123); // Suponiendo que tienes el carnet del estudiante
                            comando.Parameters.AddWithValue("@curso", 456);  // Supón que tienes el código del curso

                            comando.Parameters.AddWithValue("@nota1", Convert.ToInt32(txtNotaPrimerParcial.Text));
                            comando.Parameters.AddWithValue("@nota2", Convert.ToInt32(txtNotaSegundoParcial.Text));
                            comando.Parameters.AddWithValue("@actividades", Convert.ToInt32(txtNotaActividades.Text));
                            comando.Parameters.AddWithValue("@examenFinal", Convert.ToInt32(txtNotaFinalParcial.Text));

                            comando.ExecuteNonQuery();

                            MessageBox.Show("Datos insertados correctamente.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar los datos: " + ex.Message);
                }


            }
        }



        private void buttonEli_click(object sender, EventArgs e)
        {
          
            }

        private void buttonEli_click_Click(object sender, EventArgs e)
        {

           
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonMod_Click(object sender, EventArgs e)

        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
