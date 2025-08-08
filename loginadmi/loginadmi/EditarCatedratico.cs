//PROGRAMADO POR: GERBER ALEXANDER ASTURIAS TEJAXÚN CARNET: 0901-22-11992
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
    public partial class EditarCatedratico : Form
    {
        private string scarnetCatedratico;
        public EditarCatedratico()
        {
            InitializeComponent();
        }

        public EditarCatedratico(string carnet)
        {
            InitializeComponent();
            scarnetCatedratico = carnet;
            txt_carne.Enabled = false; 
            CargarDatosCatedratico();
        }
        
        private void CargarDatosCatedratico()
        {
            string sconexionBD = ConexionBD.CadenaConexion();
            using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
            {
                try
                {
                    conexion.Open();
                    string sconsulta = @"SELECT c.nombreCatedratico, c.apellidosCatedratico, c.telefonoCatedratico,
                                                c.correoCatedratico, u.usuario, u.contraseña
                                         FROM Catedratico c
                                         LEFT JOIN Usuario u ON c.carnetCatedratico_pk = u.carnetCatedratico_fk
                                         WHERE c.carnetCatedratico_pk = @carnet";
                    MySqlCommand cmd = new MySqlCommand(sconsulta, conexion);
                    cmd.Parameters.AddWithValue("@carnet", scarnetCatedratico);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txt_carne.Text = scarnetCatedratico;
                            txt_nombres.Text = reader["nombreCatedratico"].ToString();
                            txt_apellidos.Text = reader["apellidosCatedratico"].ToString();
                            txt_telefono.Text = reader["telefonoCatedratico"].ToString();
                            txt_correo.Text = reader["correoCatedratico"].ToString();
                            txt_usuario.Text = reader.IsDBNull(reader.GetOrdinal("usuario")) ? "" : reader["usuario"].ToString();
                            txt_contraseña.Text = reader.IsDBNull(reader.GetOrdinal("contraseña")) ? "" : reader["contraseña"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron datos del catedrático.");
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos del catedrático: " + ex.Message);
                }
            }
        }

        private void editarCatedratico_Click(object sender, EventArgs e)
        {
            string sconexionBD = ConexionBD.CadenaConexion();
            using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
            {
                try
                {
                    conexion.Open();
                    string sconsulta = @"UPDATE Catedratico 
                                         SET nombreCatedratico = @nombre, 
                                             apellidosCatedratico = @apellidos, 
                                             telefonoCatedratico = @telefono, 
                                             correoCatedratico = @correo
                                         WHERE carnetCatedratico_pk = @carnet";
                    MySqlCommand cmd = new MySqlCommand(sconsulta, conexion);
                    cmd.Parameters.AddWithValue("@carnet", scarnetCatedratico);
                    cmd.Parameters.AddWithValue("@nombre", txt_nombres.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellidos", txt_apellidos.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txt_telefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", txt_correo.Text.Trim());
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Datos del catedrático actualizados correctamente.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron datos del catedrático para actualizar.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar los datos del catedrático: " + ex.Message);
                }
            }
        }
        private void EditarCatedratico_Load(object sender, EventArgs e)
        {

        }

        private void lbl_agregar_estudiante_Click(object sender, EventArgs e)
        {

        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            homeadmi nuevoFormulario = new homeadmi();
            nuevoFormulario.Show();
            this.Hide(); 
        }

        private void btn_estudiantes_Click(object sender, EventArgs e)
        {
            agregarestudiante nuevoFormulario = new agregarestudiante();
            nuevoFormulario.Show();
            this.Hide(); 
        }

        private void btn_catedratico_Click(object sender, EventArgs e)
        {
            agregar_catedratico nuevoFormulario = new agregar_catedratico();
            nuevoFormulario.Show();
            this.Hide(); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            homeadmi nuevoFormulario = new homeadmi();
            nuevoFormulario.Show();
            this.Hide(); 
        }

        private void txt_carne_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_apellidos_TextChanged(object sender, EventArgs e)
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
            FrmNotas nuevoFormulario = new FrmNotas();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnFacultad_Click(object sender, EventArgs e)
        {
            Facultades nuevoFormulario = new Facultades();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            frmCostoInscripcion nuevoFormulario = new frmCostoInscripcion();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            frmCursos nuevoFormulario = new frmCursos();
            nuevoFormulario.Show();
            this.Hide();
        }
    }
}
