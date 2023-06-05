using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryTP3LaboratorioProgramacionIII
{
    public partial class frmPrincipal : Form
    {
        clsLocalidades objLocalidad;
        clsProfesiones objProfesion;
        clsEncuestas objEncuesta;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                dgvConsulta.Columns.Add("Grilla", "LOCALIDADES");
                objLocalidad = new clsLocalidades();
                objProfesion = new clsProfesiones();
                objEncuesta = new clsEncuestas();
                DataTable tablaProfesiones = objProfesion.getAll();
                DataTable tablaLocalidades = objLocalidad.getAll();
                DataTable tablaEncuestas = objEncuesta.getAll();
                foreach (DataRow dr in tablaProfesiones.Rows)
                {
                    dgvConsulta.Columns.Add("Profesion", dr.ItemArray[1].ToString());
                }
                foreach (DataRow dr in tablaLocalidades.Rows)
                {
                    dgvConsulta.Rows.Add(dr.ItemArray[1].ToString());
                }
                dgvConsulta.AllowUserToAddRows = false;
                dgvConsulta.AllowUserToResizeColumns = false;
                dgvConsulta.AllowUserToResizeRows = false;
                foreach (DataRow dr in tablaEncuestas.Rows)
                {
                    foreach (DataGridViewTextBoxColumn dcGrilla in dgvConsulta.Columns)
                    {
                        if (objProfesion.nombreProfesion(Convert.ToInt32(dr.ItemArray[1])) == dcGrilla.HeaderText)
                        {
                            int posicionColumna = dcGrilla.Index;
                            foreach (DataGridViewRow drGrilla in dgvConsulta.Rows)
                            {
                                if (objLocalidad.nombreLocalidad(Convert.ToInt32(dr.ItemArray[0])) == drGrilla.Cells[0].Value.ToString())
                                {
                                    int posicionFila = drGrilla.Index;
                                    dgvConsulta.Rows[posicionFila].Cells[posicionColumna].Value = dr["cantidad"];
                                }
                            }
                        }
                    }
                }
                foreach (DataGridViewColumn column in dgvConsulta.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dgvConsulta.AutoResizeColumns();
                dgvConsulta.AutoResizeRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas con la base de datos");
            }
        }
    }
}
