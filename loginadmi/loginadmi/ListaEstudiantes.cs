
//PROGRAMADO POR: GERBER ALEXANDER ASTURIAS TEJAXÚN CARNET: 0901-22-11992
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace loginadmi
{
    public partial class ListaEstudiantes : Form
    {
        public ListaEstudiantes()
        {
            InitializeComponent();
            CargarEstudiantes();
        }

        private void CargarEstudiantes()
        {
            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();
                    string sconsulta = @"
                SELECT 
                    e.nombreEstudiante, 
                    e.apellidosEstudiante, 
                    e.carnetEstudiante_pk, 
                    c.nombreCarrera AS Carrera, 
                    e.correoEstudiante, 
                    e.telefonoEstudiante
                FROM estudiante e
                LEFT JOIN carrera c ON e.codigoCarrera_fk = c.codigoCarrera_pk";

                    
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(sconsulta, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    list_estudiantes.DataSource = tabla;

                    // Cambiar los títulos de las columnas
                    list_estudiantes.Columns["nombreEstudiante"].HeaderText = "Nombres";
                    list_estudiantes.Columns["apellidosEstudiante"].HeaderText = "Apellidos";
                    list_estudiantes.Columns["carnetEstudiante_pk"].HeaderText = "Carné";
                    list_estudiantes.Columns["Carrera"].HeaderText = "Carrera";
                    list_estudiantes.Columns["correoEstudiante"].HeaderText = "Correo";
                    list_estudiantes.Columns["telefonoEstudiante"].HeaderText = "Teléfono";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los estudiantes: " + ex.Message);
                }
            }
        }

        private void list_estudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_nocarnetestudiante_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_eliminarEstudiantes_Click(object sender, EventArgs e)
        {
            string carnet = txt_nocarnetestudiante.Text.Trim();

            if (string.IsNullOrEmpty(carnet))
            {
                MessageBox.Show("Por favor ingresa el número de carné.");
                return;
            }

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    string eliminacionUser = "DELETE FROM usuario WHERE carnetEstudiante_fk = @carnet";
                    MySqlCommand comandoUser = new MySqlCommand(eliminacionUser, conexion);
                    comandoUser.Parameters.AddWithValue("@carnet", carnet);
                    comandoUser.ExecuteNonQuery();

                    string consulta = "DELETE FROM estudiante WHERE carnetEstudiante_pk = @carnet";
                    MySqlCommand comandoEstudiante = new MySqlCommand(consulta, conexion);
                    comandoEstudiante.Parameters.AddWithValue("@carnet", carnet);
                    int filasAfectadas = comandoEstudiante.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Estudiante eliminado correctamente.");
                        CargarEstudiantes();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un estudiante con ese carné.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el estudiante: " + ex.Message);
                }
            }
        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form homeadmi= new homeadmi();
            homeadmi.Show();
        }

        private void btn_estudiantes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form agregarestudiante = new agregarestudiante();
            agregarestudiante.Show();
        }

        private void btn_catedratico_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form agregar_catedratico = new agregar_catedratico();
            agregar_catedratico.Show();
        }

        private void pnl_home_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_Lista_estudiantes_Click(object sender, EventArgs e)
        {

        }

        private void btn_EditarEstudiante_Click(object sender, EventArgs e)
        {
            string carnet = txt_nocarnetestudiante.Text.Trim();

            if (string.IsNullOrEmpty(carnet))
            {
                MessageBox.Show("Por favor ingresa el número de carné.");
                return;
            }

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    string consulta = "SELECT COUNT(*) FROM estudiante WHERE carnetEstudiante_pk = @carnet";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@carnet", carnet);
                    int existe = Convert.ToInt32(comando.ExecuteScalar());

                    if (existe > 0)
                    {
                        // Abrir ventana para editar el estudiante
                        EditarEstudiante ventanaEditar = new EditarEstudiante(carnet);
                        ventanaEditar.ShowDialog();
                        CargarEstudiantes(); // Refresca los datos al cerrar la ventana
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un estudiante con ese carné.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar estudiante: " + ex.Message);
                }
            }
        }
    }
}
