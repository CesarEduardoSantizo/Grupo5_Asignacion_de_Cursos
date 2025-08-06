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
    public partial class frmListadoLaboratorio : Form
    {

        /*------------------------------------------- Programado por: Anderson Trigueros ---------------------------*/
        public frmListadoLaboratorio()
        {
            InitializeComponent();
        }

        //Listas para almacenar datos originales de los laboratorios ingresados en la base
        List<string> sListaDatosSeccion = new List<string>();
        List<string> sListaDatosHoraInicio = new List<string>();
        List<string> sListaDatosHoraSalida = new List<string>();
        List<string> sListaDatosDias = new List<string>();
        List<string> sListaDatosPrecios = new List<string>();
        List<int> iListaCodigoAsignaciones = new List<int>();


        private bool eliminarAsignacion(int codigoAsignacion)
        {
            string conexionBD = ConexionBD.CadenaConexion();
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(conexionBD))
                {
                    conexion.Open();
                    string sEliminacion = "DELETE FROM asignacionlaboratorio WHERE codigoAsignacionLaboratorio_pk = @codigoAsignacion";
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


        private bool actualizarLaboratorio(int codigoAsignacion, Dictionary<string, string> camposActualizados)
        {
            if ((camposActualizados == null || camposActualizados.Count == 0) )
                return false;

            string conexionBD = ConexionBD.CadenaConexion();

            using (MySqlConnection conexion = new MySqlConnection(conexionBD))
            {
                conexion.Open();

                List<string> sets = new List<string>();
                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexion;

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
                if (camposActualizados.ContainsKey("diaLaboratorio"))
                {
                    sets.Add("diaLaboratorio = @diaLaboratorio");
                    comando.Parameters.AddWithValue("@diaLaboratorio", camposActualizados["diaLaboratorio"]);
                }
                if (camposActualizados.ContainsKey("precioLaboratorio"))
                {
                    sets.Add("precioLaboratorio = @precioLaboratorio");
                    comando.Parameters.AddWithValue("@precioLaboratorio", camposActualizados["precioLaboratorio"]);
                }

                if (sets.Count == 0)
                    return false;

                string setClause = string.Join(", ", sets);
                comando.CommandText = $"UPDATE asignacionlaboratorio SET {setClause} WHERE codigoAsignacionLaboratorio_pk = @codigoAsignacion";
                comando.Parameters.AddWithValue("@codigoAsignacion", codigoAsignacion);

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }


        private void cargarLaboratorios()
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
                    string sSeleccionCursos = @"SELECT al.codigoAsignacionLaboratorio_pk AS codigoLaboratorio, 
                                                        al.codigocurso_fk AS codigoCurso, 
                                                        c.nombreCurso AS Curso, 
                                                        al.seccion AS Seccion, 
                                                        al.horaInicio AS horaInicio, 
                                                        al.horaSalida AS horaSalida,
                                                        al.diaLaboratorio AS Dia,
                                                        al.precioLaboratorio AS Precio
                                                FROM asignacionlaboratorio al 
                                                JOIN Curso c ON al.codigoCurso_fk = c.codigoCurso_pk 
                                                JOIN Carrera cr ON al.codigoCarrera_fk = cr.codigoCarrera_pk 
                                                WHERE al.añoAsignacion = @año 
                                                    AND al.semestreAsignacion = @semestre 
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
                    tabla.Columns.Add("Día Asignado");
                    tabla.Columns.Add("Precio");

                    while (resultado.Read())
                    {
                        string sCodigo = resultado["codigoCurso"].ToString();
                        string sCurso = resultado["Curso"].ToString();
                        string sSeccion = resultado["Seccion"].ToString();
                        string sHoraInicio = resultado["horaInicio"].ToString();
                        string sHoraSalida = resultado["horaSalida"].ToString();
                        string sDia = resultado["Dia"].ToString();
                        string sPrecio = resultado["Precio"].ToString();

                        tabla.Rows.Add(sCodigo, sCurso, sSeccion, sHoraInicio, sHoraSalida, sDia, sPrecio);
                        
                        iListaCodigoAsignaciones.Add(Convert.ToInt32(resultado["codigoLaboratorio"]));
                        sListaDatosSeccion.Add(sSeccion);
                        sListaDatosHoraInicio.Add(sHoraInicio);
                        sListaDatosHoraSalida.Add(sHoraSalida);
                        sListaDatosDias.Add(sDia);
                        sListaDatosPrecios.Add(sPrecio);

                    }
                    if (tabla.Rows.Count > 0)
                    {
                        dgvLaboratorios.DataSource = tabla;
                        if (!dgvLaboratorios.Columns.Contains("btnEliminar"))
                        {
                            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                            btnEliminar.HeaderText = "Eliminar";
                            btnEliminar.Text = "Eliminar";
                            btnEliminar.Name = "btnEliminar";
                            btnEliminar.UseColumnTextForButtonValue = true;
                            dgvLaboratorios.Columns.Add(btnEliminar);
                        }
                        if (!dgvLaboratorios.Columns.Contains("btnModificar"))
                        {
                            DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
                            btnModificar.HeaderText = "Modificar";
                            btnModificar.Text = "Modificar";
                            btnModificar.Name = "btnModificar";
                            btnModificar.UseColumnTextForButtonValue = true;
                            dgvLaboratorios.Columns.Add(btnModificar);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron laboratorios con los datos proporcionados");
                        return;
                    }
                    dgvLaboratorios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvLaboratorios.Columns["Curso"].ReadOnly = true;
                    dgvLaboratorios.Columns["Código"].ReadOnly = true;

                    dgvLaboratorios.Columns["Código"].FillWeight = 50;
                    dgvLaboratorios.Columns["Sección"].FillWeight = 55;
                    dgvLaboratorios.Columns["btnEliminar"].FillWeight = 70;
                    dgvLaboratorios.Columns["btnModificar"].FillWeight = 70;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los laboratorios: " + ex.Message);
            }
        }

        private void btnMostrarLaboratorios_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAño.Text) || string.IsNullOrEmpty(txtSemestre.Text) || string.IsNullOrEmpty(txtCarrera.Text))
            {
                MessageBox.Show("Complete todos los campos para mostrar los laboratorios.");
                return;
            }
            else
            {
                cargarLaboratorios();
            }

        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            frmModuloCursos frmModuloCursos = new frmModuloCursos();
            frmModuloCursos.Show();
            this.Hide();
        }

        private void dgvLaboratorios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColumnaSeleccionada = dgvLaboratorios.Columns[e.ColumnIndex].Name;
                if (sColumnaSeleccionada == "btnEliminar")
                {
                    int iFila = e.RowIndex;
                    var filaSeleccionada = dgvLaboratorios.Rows[iFila];
                    int codigoAsignacion = iListaCodigoAsignaciones[iFila];
                    bool eliminacion = eliminarAsignacion(codigoAsignacion);
                    if (eliminacion)
                    {
                        MessageBox.Show("Eliminación realizada con éxito");
                        cargarLaboratorios();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error en la eliminación.");
                    }
                }
                else if (sColumnaSeleccionada == "btnModificar")
                {
                    int iFilaIndex = e.RowIndex;
                    var fila = dgvLaboratorios.Rows[iFilaIndex];

                    Dictionary<string, string> valoresActualizados = new Dictionary<string, string>();

                    string sNuevaSeccion = fila.Cells["Sección"].Value.ToString();
                    string sNuevaHoraInicio = fila.Cells["Hora Inicio"].Value.ToString();
                    string sNuevaHoraSalida = fila.Cells["Hora Salida"].Value.ToString();
                    string sNuevoDia = fila.Cells["Día Asignado"].Value.ToString();
                    string sNuevoPrecio = fila.Cells["Precio"].Value.ToString();
                    int codigoAsignacion = iListaCodigoAsignaciones[iFilaIndex];

                    if (sNuevoDia == sListaDatosDias[iFilaIndex] && sNuevaSeccion == sListaDatosSeccion[iFilaIndex] &&
                       sNuevaHoraInicio == sListaDatosHoraInicio[iFilaIndex] && sNuevaHoraSalida == sListaDatosHoraSalida[iFilaIndex] &&
                       sNuevoPrecio == sListaDatosPrecios[iFilaIndex])
                    {
                        MessageBox.Show("No hay datos nuevos");
                    }

                    else
                    {
                        if (sNuevoDia != sListaDatosDias[iFilaIndex])
                        {
                            valoresActualizados["diaLaboratorio"] = sNuevoDia;
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
                        if (sNuevoPrecio != sListaDatosPrecios[iFilaIndex])
                        {
                            valoresActualizados["precioLaboratorio"] = sNuevoPrecio;
                        }

                        bool actualizacion = actualizarLaboratorio(codigoAsignacion, valoresActualizados);
                        if (actualizacion)
                        {
                            MessageBox.Show("Actualización realizada con éxito");
                            cargarLaboratorios();
                        }
                        else
                        {
                            MessageBox.Show("No se realizó ninguna actualización");
                        }

                    }
                }
            }
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
    }
}
