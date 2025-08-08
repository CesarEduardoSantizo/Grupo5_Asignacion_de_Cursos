using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginadmi
{
    public class clsCatedraticos
    {
        // ----------------------------------------- Programado por: Anderson Trigueros ----------------------------- //
        public clsCatedraticos() { }
        public List<Catedratico> ObtenerCatedraticos()
        {
            string sConexionBD = ConexionBD.CadenaConexion();
            List<Catedratico> catedraticos = new List<Catedratico>();

            using (MySqlConnection conexion = new MySqlConnection(sConexionBD))
            {
                try
                {
                    conexion.Open();
                    string sConsultaSeleccion = "SELECT carnetCatedratico_pk, nombreCatedratico FROM Catedratico";
                    MySqlCommand comando = new MySqlCommand(sConsultaSeleccion, conexion);

                    MySqlDataReader datos = comando.ExecuteReader();

                    while (datos.Read())
                    {
                        Catedratico catedratico = new Catedratico
                        {
                            iCarnetCatedratico = Convert.ToInt32(datos["carnetCatedratico_pk"]),
                            sNombreCatedratico = datos["nombreCatedratico"].ToString()
                        };
                        catedraticos.Add(catedratico);
                    }
                    datos.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener los catedráticos: " + ex.Message);
                }
            }
            return catedraticos;
        }
    }

    // Clase para representar un Catedrático
    public class Catedratico
    {
        public int iCarnetCatedratico { get; set; }
        public string sNombreCatedratico { get; set; }
    }
}
