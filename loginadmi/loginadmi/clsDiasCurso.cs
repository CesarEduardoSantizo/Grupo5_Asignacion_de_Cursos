using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginadmi
{
    // ----------------------------------------- Programado por: Anderson Trigueros ----------------------------- //
    public static class clsDiasCurso
    {
        public static string sObtenerDiasCurso(int codigoDia)
        {
            switch (codigoDia)
            {
                case 1: return "Lunes y Miércoles";
                case 2: return "Martes y Jueves";
                case 3: return "Lunes, Miércoles y Viernes";
                case 4: return "Martes, Jueves y Viernes";
                case 5: return "Viernes";
                case 6: return "Sábado";
                default: return "No valido";
            }
        }
        public static int sObtenerCodigoDia(string Dia)
        {
            switch (Dia)
            {
                case "Lunes y Miércoles": return 1;
                case "Martes y Jueves": return 2;
                case "Lunes, Miércoles y Viernes": return 3;
                case "Martes, Jueves y Viernes": return 4;
                case "Viernes": return 5;
                case "Sábado": return 6;
                default: return 0;
            }
        }

    }
}
