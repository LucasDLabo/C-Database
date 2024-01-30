using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerDatabase
{
    internal class Conexion
    {
        public static MySqlConnection conexion()
        {
            String server = "localhost";
            String puerto = "3306";
            String user = "root";
            String password = "DAMASgratis10";
            String database = "curso";

            String conex = "Database=" + database + "; Data Source=" + server + "; Port=" + puerto + "; User Id=" + user + "; Password=" + password + "";

            
            try
            {
                MySqlConnection conexionbd = new MySqlConnection(conex);
                return conexionbd;
    
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
                return null;
            }
        }
        

    }
}
