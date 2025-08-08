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
    public partial class frmCarreras : Form
    {
        public frmCarreras()
        {
            InitializeComponent();
        }

        private void lbl_Facultad_Click(object sender, EventArgs e)
        {

        }

        private void btn_registrarCarrera_Click(object sender, EventArgs e)
        {
            string nombres = txt_nombres.Text.Trim();
            string facultad = txt_facultad.Text.Trim();

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    // Normaliza el nombre para la búsqueda
                    string consultaFacultad = "SELECT codigoFacultad_pk FROM facultad WHERE TRIM(LOWER(nombreFacultad)) = TRIM(LOWER(@facultad))";
                    MySqlCommand comandoFacultad = new MySqlCommand(consultaFacultad, conexion);
                    comandoFacultad.Parameters.AddWithValue("@facultad", facultad.ToLower());
                    object resultadoFacultad = comandoFacultad.ExecuteScalar();
                    int codigoFacultad;

                    if (resultadoFacultad == null)
                    {
                        // Insertar nueva facultad
                        string insertarFacultad = "INSERT INTO facultad (nombreFacultad) VALUES (@facultad)";
                        MySqlCommand insertarFacultadCmd = new MySqlCommand(insertarFacultad, conexion);
                        insertarFacultadCmd.Parameters.AddWithValue("@facultad", facultad);
                        insertarFacultadCmd.ExecuteNonQuery();

                        // Obtener el ID generado (automatico)
                        comandoFacultad = new MySqlCommand("SELECT LAST_INSERT_ID()", conexion);
                        codigoFacultad = Convert.ToInt32(comandoFacultad.ExecuteScalar());
                    }
                    else
                    {
                        codigoFacultad = Convert.ToInt32(resultadoFacultad);
                    }

                    // Insertar la carrera asociada a esa facultad
                    string insertarCarrera = "INSERT INTO carrera (nombreCarrera, codigoFacultad_fk) VALUES (@carrera, @codigoFacultad)";
                    MySqlCommand insertarCarreraCmd = new MySqlCommand(insertarCarrera, conexion);
                    insertarCarreraCmd.Parameters.AddWithValue("@carrera", nombres);
                    insertarCarreraCmd.Parameters.AddWithValue("@codigoFacultad", codigoFacultad);
                    insertarCarreraCmd.ExecuteNonQuery();

                    MessageBox.Show("Carrera insertada exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar la carrera: " + ex.Message);
                    return;
                }

            }
            
        }

        private void btn_listaCarrera_Click(object sender, EventArgs e)
        {
            frmListaCarrera listaCarrera = new frmListaCarrera();
            listaCarrera.Show();
            this.Hide(); 
        }

        private void txt_nombres_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnfacultade_Click(object sender, EventArgs e)
        {
            Facultades facultades = new Facultades();
            facultades.Show();
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
