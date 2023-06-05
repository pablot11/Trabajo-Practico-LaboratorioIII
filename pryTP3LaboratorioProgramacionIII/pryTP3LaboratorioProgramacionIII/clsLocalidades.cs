using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;



namespace pryTP3LaboratorioProgramacionIII
{
    internal class clsLocalidades
    {

        private OleDbConnection conector;
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataTable tabla;
        private string varNombreCiudad;

        public string NombreCiudad
        {
            get { return varNombreCiudad; }
            set { varNombreCiudad = value; }
        }

        public clsLocalidades()
        {
            conector = new OleDbConnection(Properties.Settings.Default.Cadena);
            comando = new OleDbCommand();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Localidades";

            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);
            DataColumn[] dc = new DataColumn[1];
            dc[0] = tabla.Columns["localidad"];
            tabla.PrimaryKey = dc;
        }
        public DataTable getAll()
        {
            return tabla;
        }
        public string nombreLocalidad(int Localidad)
        {
            DataRow filabuscar = tabla.Rows.Find(Localidad);
            if (filabuscar != null)
            {
                 varNombreCiudad = filabuscar[1].ToString();
            }
            else
            {
                varNombreCiudad = "";
            }
            return varNombreCiudad;
        }












    }
}
