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
            string nombres = txt_nombres.Text;
            string facultad = txt_facultad.Text;

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))

            {
                try
                {
                    conexion.Open();

                    // Verifica si la facultad ya existe
                    string consultaFacultad = "SELECT codigoFacultad_pk FROM facultad WHERE nombreFacultad = @facultad";
                    MySqlCommand comandoFacultad = new MySqlCommand(consultaFacultad, conexion);
                    comandoFacultad.Parameters.AddWithValue("@facultad", facultad);
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

                    // esto es para insertar la carrera asociada a esa facultad
                    string insertarCarrera = "INSERT INTO carrera (nombreCarrera, codigoFacultad_fk) VALUES (@carrera, @codigoFacultad)";
                    MySqlCommand insertarCarreraCmd = new MySqlCommand(insertarCarrera, conexion);
                    insertarCarreraCmd.Parameters.AddWithValue("@carrera", nombres); // nombres = nombre de la carrera
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
            ////ListaCarrera listaCarrera = new ListaCarrera();
            //listaCarrera.Show();
            //this.Hide(); 
        }

        private void txt_nombres_TextChanged(object sender, EventArgs e)
        {

        }
    }
 }
        
