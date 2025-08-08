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
    public partial class frmEdificios : Form
    {
        public frmEdificios()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void btnregistraredificio_Click(object sender, EventArgs e)
        {
            string nombreEdificio = txtnombresedificio.Text.Trim();

            if (string.IsNullOrEmpty(nombreEdificio))
            {
                MessageBox.Show("Por favor, ingresa el nombre del edificio.");
                return;
            }

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    // Verificar si el edificio ya existe
                    string consulta = "SELECT codigoEdificio_pk FROM edificio WHERE nombreEdificio = @nombreEdificio";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@nombreEdificio", nombreEdificio);
                    object resultado = comando.ExecuteScalar();
                    int codigoEdificio;

                    if (resultado == null)
                    {
                        // Insertar nuevo edificio
                        string insertar = "INSERT INTO edificio (nombreEdificio) VALUES (@nombreEdificio)";
                        MySqlCommand insertarCmd = new MySqlCommand(insertar, conexion);
                        insertarCmd.Parameters.AddWithValue("@nombreEdificio", nombreEdificio);
                        insertarCmd.ExecuteNonQuery();

                        // Obtener ID generado automáticamente
                        comando = new MySqlCommand("SELECT LAST_INSERT_ID()", conexion);
                        codigoEdificio = Convert.ToInt32(comando.ExecuteScalar());

                        MessageBox.Show("Edificio insertado correctamente.");
                    }
                    else
                    {
                        codigoEdificio = Convert.ToInt32(resultado);
                        MessageBox.Show("El edificio ya existe.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar el edificio: " + ex.Message);
                }
            }
        }

        private void btnfacus4_Click(object sender, EventArgs e)
        {
            Facultades nuevoFormulario = new Facultades();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnlistaedificio_Click(object sender, EventArgs e)
        {
            frmlistaedificios nuevoFormulario = new frmlistaedificios();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCostoInscripcion frmCostoInscripcion = new frmCostoInscripcion();
            frmCostoInscripcion.Show();
            this.Hide();
        }
    }
}
