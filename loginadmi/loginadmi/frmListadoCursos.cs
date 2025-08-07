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
    public partial class frmListadoCursos : Form
    {

        // ----------------------------------------- Programado por: Anderson Trigueros ----------------------------- //
        public frmListadoCursos()
        {
            InitializeComponent();
        }

        List<string> sListaDatosSeccion = new List<string>();
        List<string> sListaDatosHoraInicio = new List<string>();
        List<string> sListaDatosHoraSalida = new List<string>();
        List<string> sListaDatosDias = new List<string>();
        List<int> iListaCodigoAsignaciones = new List<int>();

        private void lblTituloHabilitacion_Click(object sender, EventArgs e)
        {

        }

        private void pnl_home_Paint(object sender, PaintEventArgs e)
        {

        }

        private bool eliminarAsignacion(int codigoAsignacion)
        {
            string conexionBD = ConexionBD.CadenaConexion();
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionBD))
                {
                    conexion.Open();
                    string sEliminacion = "DELETE FROM AsignacionCurso WHERE codigoAsignacionCurso_pk = @codigoAsignacion";
                    MySqlCommand comando = new MySqlCommand(sEliminacion, conexion);
                    comando.Parameters.AddWithValue("@codigoAsignacion", codigoAsignacion);
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool actualizarAsignacionCurso(int codigoAsignacion, Dictionary<string, string> camposActualizados, int codigoDia)
        {
            if ((camposActualizados == null || camposActualizados.Count == 0) && codigoDia == 0)
                return false;

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                conexion.Open();

                List<string> sets = new List<string>();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexion;

                if (codigoDia > 0)
                {
                    sets.Add("diasCurso = @diasCurso");
                    comando.Parameters.AddWithValue("@diasCurso", codigoDia);
                }
                if (camposActualizados.ContainsKey("seccion"))
                {
                    sets.Add("seccion = @seccion");
                    comando.Parameters.AddWithValue("@seccion", camposActualizados["seccion"]);
                }
                if (camposActualizados.ContainsKey("horaInicio"))
                {
                    sets.Add("horaInicio = @horaInicio");
                    comando.Parameters.AddWithValue("@horaInicio", camposActualizados["horaInicio"]);
                }
                if (camposActualizados.ContainsKey("horaSalida"))
                {
                    sets.Add("horaSalida = @horaSalida");
                    comando.Parameters.AddWithValue("@horaSalida", camposActualizados["horaSalida"]);
                }

                if (sets.Count == 0)
                    return false;

                string setClause = string.Join(", ", sets);
                comando.CommandText = $"UPDATE AsignacionCurso SET {setClause} WHERE codigoAsignacionCurso_pk = @codigoAsignacion";
                comando.Parameters.AddWithValue("@codigoAsignacion", codigoAsignacion);

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }

        private void dgvListadoAsignaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColumnaSeleccionada = dgvListadoAsignaciones.Columns[e.ColumnIndex].Name;
                if(sColumnaSeleccionada == "btnEliminar")
                {
                    int iFila = e.RowIndex;
                    var filaSeleccionada = dgvListadoAsignaciones.Rows[iFila];
                    int codigoAsignacion = iListaCodigoAsignaciones[iFila];
                    bool eliminacion = eliminarAsignacion(codigoAsignacion);
                    if (eliminacion)
                    {
                        MessageBox.Show("Eliminación realizada con éxito");
                        cargarAsignaciones();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error en la eliminación.");
                    } 

                }
                else if (sColumnaSeleccionada == "btnModificar") {
                    int iFilaIndex = e.RowIndex;
                    var fila = dgvListadoAsignaciones.Rows[iFilaIndex];
                    Dictionary<string, string> valoresActualizados = new Dictionary<string, string>();
                    int codigoDia = 0;

                    string sNuevaSeccion = fila.Cells["Sección"].Value.ToString();
                    string sNuevaHoraInicio = fila.Cells["Hora Inicio"].Value.ToString();
                    string sNuevaHoraSalida = fila.Cells["Hora Salida"].Value.ToString();
                    string sNuevoDias = fila.Cells["Días Asignados"].Value.ToString();
                    int codigoAsignacion = iListaCodigoAsignaciones[iFilaIndex];

                    if(sNuevoDias == sListaDatosDias[iFilaIndex] && sNuevaSeccion == sListaDatosSeccion[iFilaIndex] &&
                       sNuevaHoraInicio == sListaDatosHoraInicio[iFilaIndex] && sNuevaHoraSalida == sListaDatosHoraSalida[iFilaIndex] ){
                        MessageBox.Show("No hay datos nuevos");
                    }

                    else
                    {
                        if(sNuevoDias != sListaDatosDias[iFilaIndex])
                        {
                            codigoDia = clsDiasCurso.sObtenerCodigoDia(sNuevoDias);
                            if (codigoDia == 0)
                            {
                                MessageBox.Show("El valor del día no es válido");
                                return;
                            }
                        }
                        if (sNuevaSeccion != sListaDatosSeccion[iFilaIndex])
                        {
                            valoresActualizados["seccion"] = sNuevaSeccion;
                        }
                        if (sNuevaHoraInicio != sListaDatosHoraInicio[iFilaIndex])
                        {
                            valoresActualizados["horaInicio"] = sNuevaHoraInicio;
                        }
                        if (sNuevaHoraSalida != sListaDatosHoraSalida[iFilaIndex])
                        {
                            valoresActualizados["horaSalida"] = sNuevaHoraSalida;
                        }
                        bool actualizacion = actualizarAsignacionCurso(codigoAsignacion, valoresActualizados, codigoDia);
                        if (actualizacion)
                        {
                            MessageBox.Show("Actualización realizada con éxito");
                            cargarAsignaciones();
                        }
                        else
                        {
                            MessageBox.Show("No se realizó ninguna actualización");
                        }

                    }
                }
            }
        }


        private void cargarAsignaciones()
        {
            sListaDatosSeccion.Clear();
            sListaDatosHoraInicio.Clear();
            sListaDatosHoraSalida.Clear();

            string sConexionBD = ConexionBD.CadenaConexion();
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(sConexionBD))
                {
                    conexion.Open();
                    string sSeleccionCursos = @"SELECT ac.codigoAsignacionCurso_pk AS codigoAsignacion, 
                                                        ac.codigocurso_fk AS codigoCurso, 
                                                        c.nombreCurso AS Curso, 
                                                        ac.seccion AS Seccion, 
                                                        ac.horaInicio AS horaInicio, 
                                                        ac.horaSalida AS horaSalida,
                                                        ca.nombreCatedratico AS Catedratico, 
                                                        ac.diascurso AS Dia 
                                                FROM AsignacionCurso ac 
                                                JOIN Curso c ON ac.codigoCurso_fk = c.codigoCurso_pk 
                                                JOIN Catedratico ca ON ac.codigoCatedratico_fk = ca.carnetCatedratico_pk 
                                                JOIN Carrera cr ON ac.codigoCarrera_fk = cr.codigoCarrera_pk 
                                                WHERE ac.añoAsignacion = @año 
                                                    AND ac.semestreAsignacion = @semestre 
                                                    AND cr.nombreCarrera = @nombreCarrera";
                    MySqlCommand comando = new MySqlCommand(sSeleccionCursos, conexion);
                    comando.Parameters.AddWithValue("@año", txtAño.Text);
                    comando.Parameters.AddWithValue("@semestre", txtSemestre.Text);
                    comando.Parameters.AddWithValue("@nombreCarrera", txtCarrera.Text);
                    MySqlDataReader resultado = comando.ExecuteReader();
                    DataTable tabla = new DataTable();
                    tabla.Columns.Add("Código");
                    tabla.Columns.Add("Curso");
                    tabla.Columns.Add("Sección");
                    tabla.Columns.Add("Hora Inicio");
                    tabla.Columns.Add("Hora Salida");
                    tabla.Columns.Add("Días Asignados");
                    tabla.Columns.Add("Catedrático Asignado");

                    while (resultado.Read())
                    {
                        string sCodigo = resultado["codigoCurso"].ToString();
                        string sCurso = resultado["Curso"].ToString();
                        string sSeccion = resultado["Seccion"].ToString();
                        string sHoraInicio = resultado["horaInicio"].ToString();
                        string sHoraSalida = resultado["horaSalida"].ToString();
                        string sCatedratico = resultado["Catedratico"].ToString();
                        int dia = Convert.ToInt32(resultado["Dia"]);
                        string sDiasAsignados = clsDiasCurso.sObtenerDiasCurso(dia);

                        tabla.Rows.Add(sCodigo, sCurso, sSeccion, sHoraInicio, sHoraSalida, sDiasAsignados, sCatedratico);
                        iListaCodigoAsignaciones.Add(Convert.ToInt32(resultado["codigoAsignacion"]));
                        sListaDatosSeccion.Add(sSeccion);
                        sListaDatosHoraInicio.Add(sHoraInicio);
                        sListaDatosHoraSalida.Add(sHoraSalida);
                        sListaDatosDias.Add(sDiasAsignados);

                    }
                    if (tabla.Rows.Count > 0)
                    {
                        dgvListadoAsignaciones.DataSource = tabla;
                        if (!dgvListadoAsignaciones.Columns.Contains("btnEliminar"))
                        {
                            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                            btnEliminar.HeaderText = "Eliminar";
                            btnEliminar.Text = "Eliminar";
                            btnEliminar.Name = "btnEliminar";
                            btnEliminar.UseColumnTextForButtonValue = true;
                            dgvListadoAsignaciones.Columns.Add(btnEliminar);
                        }
                        if (!dgvListadoAsignaciones.Columns.Contains("btnModificar"))
                        {
                            DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
                            btnModificar.HeaderText = "Modificar";
                            btnModificar.Text = "Modificar";
                            btnModificar.Name = "btnModificar";
                            btnModificar.UseColumnTextForButtonValue = true;
                            dgvListadoAsignaciones.Columns.Add(btnModificar);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron cursos con los datos proporcionados");
                        return;
                    }
                    dgvListadoAsignaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvListadoAsignaciones.Columns["Curso"].ReadOnly = true;
                    dgvListadoAsignaciones.Columns["Código"].ReadOnly = true;
                    dgvListadoAsignaciones.Columns["Catedrático Asignado"].ReadOnly = true;

                    dgvListadoAsignaciones.Columns["Código"].FillWeight = 50;
                    dgvListadoAsignaciones.Columns["Sección"].FillWeight = 55;
                    dgvListadoAsignaciones.Columns["Días Asignados"].FillWeight = 170;
                    dgvListadoAsignaciones.Columns["btnEliminar"].FillWeight = 70;
                    dgvListadoAsignaciones.Columns["btnModificar"].FillWeight = 70;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los cursos: " + ex.Message);
            }
        }



        private void btnMostrarCursos_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtAño.Text) || string.IsNullOrEmpty(txtSemestre.Text) || string.IsNullOrEmpty(txtCarrera.Text))
            {
                MessageBox.Show("Complete todos los campos para mostrar los cursos.");
                return;
            }
            else
            {
                cargarAsignaciones();
            }
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            frmModuloCursos frmModuloCursos = new frmModuloCursos();
            frmModuloCursos.Show();
            this.Hide();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            homeadmi homeadmi = new homeadmi();
            homeadmi.Show();
            this.Hide();
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            agregarestudiante agregarestudiante = new agregarestudiante();
            agregarestudiante.Show();
            this.Hide();
        }

        private void btnCatedratico_Click(object sender, EventArgs e)
        {
            agregar_catedratico agregar_Catedratico = new agregar_catedratico();
            agregar_Catedratico.Show();
            this.Hide();
        }

        private void btnFacultades_Click(object sender, EventArgs e)
        {
            Facultades facultades = new Facultades();
            facultades.Show();
            this.Hide();
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            FrmNotas frmNotas = new FrmNotas();
            frmNotas.Show();
            this.Hide();
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            frmCostoInscripcion frmCostoInscripcion = new frmCostoInscripcion();
            frmCostoInscripcion.Show();
            this.Hide();
        }
    }
}
