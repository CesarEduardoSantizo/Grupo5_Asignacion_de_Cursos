using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginadmi
{
    // ----------------------------------------- Programado por: Anderson Trigueros ----------------------------- //
    public class clsCarrera
    {
        public clsCarrera() { }
        public List<Carrera> ObtenerCarreras()
        {
            string sConexionBD = ConexionBD.CadenaConexion();
            List<Carrera> listaCarrera = new List<Carrera>();

            using (MySqlConnection conexion = new MySqlConnection(sConexionBD))
            {
                try
                {
                    conexion.Open();
                    string sConsultaSeleccion = "SELECT codigoCarrera_pk, nombreCarrera FROM carrera";
                    MySqlCommand comando = new MySqlCommand(sConsultaSeleccion, conexion);
                    MySqlDataReader datos = comando.ExecuteReader();

                    while (datos.Read())
                    {
                        Carrera carrera = new Carrera
                        {
                            iCodigoCarrera = Convert.ToInt32(datos["codigoCarrera_pk"]),
                            sNombreCarrera = datos["nombreCarrera"].ToString()
                        };
                        listaCarrera.Add(carrera);
                    }
                    datos.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener los catedráticos: " + ex.Message);
                }
            }
            return listaCarrera;
        }
    }

    public class Carrera
    {
        public int iCodigoCarrera { get; set; }
        public string sNombreCarrera { get; set; }
    }
}
