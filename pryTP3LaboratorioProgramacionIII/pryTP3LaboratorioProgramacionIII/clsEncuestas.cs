using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
namespace pryTP3LaboratorioProgramacionIII
{
    internal class clsEncuestas
    {
        private OleDbConnection conector;
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataTable tabla;
        public clsEncuestas()
        {
            conector = new OleDbConnection(Properties.Settings.Default.Cadena);
            comando = new OleDbCommand();

            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Encuestas";

            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);
        }
        public DataTable getAll()
        { 
            return tabla; 
        }



    }
}
