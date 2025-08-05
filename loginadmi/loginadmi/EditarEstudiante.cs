using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace loginadmi
{
    public partial class EditarEstudiante : Form
    {
        private string scarnetEstudiante;

        public EditarEstudiante()
        {
            InitializeComponent();
        }

        public EditarEstudiante(string carnet)
        {
            InitializeComponent();
            scarnetEstudiante = carnet;
            txt_carne.Enabled = false; 
            CargarDatosEstudiante();
        }

        private void CargarDatosEstudiante()
        {
            string sconexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
            {
                try
                {
                    conexion.Open();
                    string sconsulta = @"SELECT e.nombreEstudiante, e.apellidosEstudiante, e.telefonoEstudiante,
                                               e.correoEstudiante, c.nombreCarrera,
                                               u.usuario, u.contraseña
                                        FROM Estudiante e
                                        LEFT JOIN Usuario u ON e.carnetEstudiante_pk = u.carnetEstudiante_fk
                                        LEFT JOIN Carrera c ON e.codigoCarrera_fk = c.codigoCarrera_pk
                                        WHERE e.carnetEstudiante_pk = @carnet";

                    MySqlCommand cmd = new MySqlCommand(sconsulta, conexion);
                    cmd.Parameters.AddWithValue("@carnet", scarnetEstudiante);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txt_carne.Text = scarnetEstudiante;
                            txt_nombres.Text = reader["nombreEstudiante"].ToString();
                            txt_apellidos.Text = reader["apellidosEstudiante"].ToString();
                            txt_telefono.Text = reader["telefonoEstudiante"].ToString();
                            txt_correo.Text = reader["correoEstudiante"].ToString();
                            txt_carrera.Text = reader["nombreCarrera"].ToString();
                            txt_usuario.Text = reader.IsDBNull(reader.GetOrdinal("usuario")) ? "" : reader["usuario"].ToString();
                            txt_contraseña.Text = reader.IsDBNull(reader.GetOrdinal("contraseña")) ? "" : reader["contraseña"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron datos del estudiante.");
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
        }

        private void btn_editarestudiante_Click(object sender, EventArgs e)
        {
            string snombreCarrera = txt_carrera.Text.Trim();

            if (string.IsNullOrWhiteSpace(snombreCarrera))
            {
                MessageBox.Show("Debe ingresar el nombre de la carrera.");
                return;
            }

            int codigoCarrera = ObtenerOCrearCarrera(snombreCarrera);
            if (codigoCarrera == -1) return;

            string sconexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
            {
                try
                {
                    conexion.Open();

                   
                    string sactualizarEstudiante = @"UPDATE Estudiante SET 
                                                    nombreEstudiante = @nombres,
                                                    apellidosEstudiante = @apellidos,
                                                    telefonoEstudiante = @telefono,
                                                    correoEstudiante = @correo,
                                                    codigoCarrera_fk = @carrera
                                                    WHERE carnetEstudiante_pk = @carnet";

                    MySqlCommand cmd = new MySqlCommand(sactualizarEstudiante, conexion);
                    cmd.Parameters.AddWithValue("@nombres", txt_nombres.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellidos", txt_apellidos.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txt_telefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@correo", txt_correo.Text.Trim());
                    cmd.Parameters.AddWithValue("@carrera", codigoCarrera);
                    cmd.Parameters.AddWithValue("@carnet", scarnetEstudiante);
                    cmd.ExecuteNonQuery();

                   
                    string sactualizarUsuario = @"UPDATE Usuario SET 
                                                 usuario = @usuario, 
                                                 contraseña = @contraseña 
                                                 WHERE carnetEstudiante_fk = @carnet";

                    MySqlCommand cmdUsuario = new MySqlCommand(sactualizarUsuario, conexion);
                    cmdUsuario.Parameters.AddWithValue("@usuario", txt_usuario.Text.Trim());
                    cmdUsuario.Parameters.AddWithValue("@contraseña", txt_contraseña.Text.Trim());
                    cmdUsuario.Parameters.AddWithValue("@carnet", scarnetEstudiante);
                    cmdUsuario.ExecuteNonQuery();

                    MessageBox.Show("Datos actualizados correctamente.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar los cambios: " + ex.Message);
                }
            }
        }

        private int ObtenerOCrearCarrera(string nombreCarrera)
        {
            string sconexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(sconexionBD))
            {
                try
                {
                    conexion.Open();

                    
                    string sconsultaExistente = "SELECT codigoCarrera_pk FROM Carrera WHERE nombreCarrera = @nombre";
                    MySqlCommand cmd = new MySqlCommand(sconsultaExistente, conexion);
                    cmd.Parameters.AddWithValue("@nombre", nombreCarrera);
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        return Convert.ToInt32(resultado);
                    }
                    else
                    {
                      
                        string sinsertar = "INSERT INTO Carrera (nombreCarrera) VALUES (@nombre)";
                        MySqlCommand insertCmd = new MySqlCommand(sinsertar, conexion);
                        insertCmd.Parameters.AddWithValue("@nombre", nombreCarrera);
                        insertCmd.ExecuteNonQuery();

                        return (int)insertCmd.LastInsertedId;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener o crear carrera: " + ex.Message);
                    return -1;
                }
            }
        }

       

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void lbl_agregar_estudiante_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            homeadmi nuevoFormulario = new homeadmi();
            nuevoFormulario.Show();
            this.Hide(); 
        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            homeadmi nuevoFormulario = new homeadmi();
            nuevoFormulario.Show();
            this.Hide(); 
        }

        private void btn_estudiantes_Click(object sender, EventArgs e)
        {
            agregarestudiante estudiantesForm = new agregarestudiante();
            estudiantesForm.Show();
            this.Hide(); 
        }

        private void btn_catedratico_Click(object sender, EventArgs e)
        {
            agregar_catedratico catedraticoForm = new agregar_catedratico();
            catedraticoForm.Show();
            this.Hide(); 
        }
    }
}

