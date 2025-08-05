//sergio izeppi
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
    public partial class frmFacultades : Form
    {
        public frmFacultades()
        {
            InitializeComponent();
        }

        private void Facultades2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbl_edificio_Click(object sender, EventArgs e)
        {

        }

        private void txt_nombresfacu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_codigoedi_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_registrarfacu_Click(object sender, EventArgs e)
        {
            string nombreFacultad = txt_nombresfacu.Text.Trim();
            int codigoEdificio = int.Parse(txt_codigoedi.Text.Trim());

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    // Verifica si la facultad ya existe con ese nombre y código de edificio
                    string consulta = "SELECT codigoFacultad_pk FROM facultad WHERE nombreFacultad = @nombreFacultad AND codigoEdificio_fk = @codigoEdificio";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@nombreFacultad", nombreFacultad);
                    comando.Parameters.AddWithValue("@codigoEdificio", codigoEdificio);
                    object resultado = comando.ExecuteScalar();
                    int codigoFacultad;

                    if (resultado == null)
                    {
                        // Insertar nueva facultad
                        string insertar = "INSERT INTO facultad (nombreFacultad, codigoEdificio_fk) VALUES (@nombreFacultad, @codigoEdificio)";
                        MySqlCommand insertarCmd = new MySqlCommand(insertar, conexion);
                        insertarCmd.Parameters.AddWithValue("@nombreFacultad", nombreFacultad);
                        insertarCmd.Parameters.AddWithValue("@codigoEdificio", codigoEdificio);
                        insertarCmd.ExecuteNonQuery();

                        // Obtener ID generado
                        comando = new MySqlCommand("SELECT LAST_INSERT_ID()", conexion);
                        codigoFacultad = Convert.ToInt32(comando.ExecuteScalar());

                        MessageBox.Show("Facultad insertada correctamente.");
                    }
                    else
                    {
                        codigoFacultad = Convert.ToInt32(resultado);
                        MessageBox.Show("La facultad ya existe.");
                    }

                    // Aquí puedes usar el código de la facultad (`codigoFacultad`) si necesitas continuar
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar la facultad: " + ex.Message);
                }
            }

        }

        private void btn_listaFacu_Click(object sender, EventArgs e)
        {
            ListaFacultades listaFacultades = new ListaFacultades();
            listaFacultades.Show();
            this.Hide();
        }

        private void btn_facus_Click(object sender, EventArgs e)
        {
            Facultades facultades = new Facultades();
            facultades.Show();
            this.Hide();
        }
    }
}
