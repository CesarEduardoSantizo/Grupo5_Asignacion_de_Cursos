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
    public partial class frmCursos : Form
    {
        public frmCursos()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnregistraredificio_Click(object sender, EventArgs e)
        {
            // Cambia los nombres de los TextBox por los reales en tu formulario
            string nombreCurso = txtnombrecurso.Text.Trim();
            string strCodigoCurso = txtcodigocurso.Text.Trim();
            string strCreditosAsignados = txtcreditos.Text.Trim();
            string strPrecio = txtPrecio.Text.Trim();
            string strCreditosNecesarios = txtcreditosnecesarios.Text.Trim();

            if (string.IsNullOrEmpty(nombreCurso) || string.IsNullOrEmpty(strCodigoCurso) ||
                string.IsNullOrEmpty(strCreditosAsignados) || string.IsNullOrEmpty(strPrecio) ||
                string.IsNullOrEmpty(strCreditosNecesarios))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            if (!int.TryParse(strCodigoCurso, out int codigoCurso) ||
                !int.TryParse(strCreditosAsignados, out int creditosAsignados) ||
                !decimal.TryParse(strPrecio, out decimal precio) ||
                !int.TryParse(strCreditosNecesarios, out int creditosNecesarios))
            {
                MessageBox.Show("Los campos de código, créditos y precio deben tener valores válidos.");
                return;
            }

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                try
                {
                    conexion.Open();

                    // Verificar si ya existe el curso
                    string consulta = "SELECT codigoCurso_pk FROM curso WHERE codigoCurso_pk = @codigoCurso";
                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@codigoCurso", codigoCurso);
                    object resultado = comando.ExecuteScalar();

                    if (resultado == null)
                    {
                        // Insertar nuevo curso
                        string insertar = @"INSERT INTO curso 
                                            (codigoCurso_pk, nombreCurso, creditosAsignados, precio, creditosNecesarios)
                                            VALUES (@codigoCurso, @nombreCurso, @creditosAsignados, @precio, @creditosNecesarios)";
                        MySqlCommand insertarCmd = new MySqlCommand(insertar, conexion);
                        insertarCmd.Parameters.AddWithValue("@codigoCurso", codigoCurso);
                        insertarCmd.Parameters.AddWithValue("@nombreCurso", nombreCurso);
                        insertarCmd.Parameters.AddWithValue("@creditosAsignados", creditosAsignados);
                        insertarCmd.Parameters.AddWithValue("@precio", precio);
                        insertarCmd.Parameters.AddWithValue("@creditosNecesarios", creditosNecesarios);

                        insertarCmd.ExecuteNonQuery();
                        MessageBox.Show("Curso insertado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("El curso con ese código ya existe.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar el curso: " + ex.Message);
                }
            }
        }

        private void btnlistaedificio_Click(object sender, EventArgs e)
        {
            frmlistacursos nuevoFormulario = new frmlistacursos();
            nuevoFormulario.Show();
            this.Hide();
        }

        private void btnfacus4_Click(object sender, EventArgs e)
        {
            Facultades nuevoFormulario = new Facultades();
            nuevoFormulario.Show();
            this.Hide();
        }
    }
}
