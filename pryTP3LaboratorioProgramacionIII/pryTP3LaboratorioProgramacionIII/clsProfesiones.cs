using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace pryTP3LaboratorioProgramacionIII
{
    internal class clsProfesiones
    {
        private OleDbConnection conector;
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataTable tabla;
        private string varNombreProfesion;

        public string NombreProfesion
        {
            get { return varNombreProfesion; }
            set { varNombreProfesion = value; }
        }

        public clsProfesiones()
        {
            conector = new OleDbConnection(Properties.Settings.Default.Cadena);
            comando = new OleDbCommand();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Profesiones";

            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);
            DataColumn[] dc = new DataColumn[1];
            dc[0] = tabla.Columns["profesion"];
            tabla.PrimaryKey = dc;

        }
        public DataTable getAll()
        {
            return tabla;
        }
        public string nombreProfesion(int profesion)
        {
            DataRow filabuscar = tabla.Rows.Find(profesion);
            if (filabuscar != null)
            {
                varNombreProfesion = filabuscar[1].ToString();
            }
            else
            {
                varNombreProfesion = "";
            }
            return varNombreProfesion;
        }





    }
}
