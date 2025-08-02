using System.Configuration;

namespace loginadmi
{
    public static class ConexionBD 
    {
        public static string CadenaConexion()
        {
            return ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        }
    }
}
