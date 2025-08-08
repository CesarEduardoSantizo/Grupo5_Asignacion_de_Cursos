using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginadmi
{
    // ----------------------------------------- Programado por: Anderson Trigueros ----------------------------- //
    public class clsCurso
    {
        public clsCurso() { }
        public List<Curso> ObtenerListadoCursos()
        {
            string sConexionBD = ConexionBD.CadenaConexion();
            List<Curso> listadoCursos = new List<Curso>();

            using (MySqlConnection conexion = new MySqlConnection(sConexionBD))
            {
                try
                {
                    conexion.Open();
                    string sConsultaSeleccion = "SELECT codigoCurso_pk, nombreCurso FROM Curso";
                    MySqlCommand comando = new MySqlCommand(sConsultaSeleccion, conexion);

                    MySqlDataReader datos = comando.ExecuteReader();

                    while (datos.Read())
                    {
                        Curso curso = new Curso
                        {
                            iCodigoCurso = Convert.ToInt32(datos["codigoCurso_pk"]),
                            sNombreCurso = datos["nombreCurso"].ToString()
                        };
                        listadoCursos.Add(curso);
                    }
                    datos.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener los cursos: " + ex.Message);
                }
            }
            return listadoCursos;
        }
    }

    // Clase para representar un Catedrático
    public class Curso
    {
        public int iCodigoCurso { get; set; }
        public string sNombreCurso { get; set; }
    }
}
