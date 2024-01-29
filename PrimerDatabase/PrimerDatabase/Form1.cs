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

namespace PrimerDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            String server = txtServidor.Text;
            String puerto = txtPuerto.Text;
            String user = txtUsuario.Text;
            String password = txtContra.Text;
            String database = txtBD.Text;

            String conexion = "Database=" + database + "; Data Source=" + server + "; Port=" + puerto + "; User Id=" + user + "; Password=" + password;

            MySqlConnection conexionbd = new MySqlConnection(conexion);
            MySqlDataReader reader = null;
            string data = null;

            try
            {
                string consulta = "SHOW DATABASES";
                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = conexionbd;
                conexionbd.Open();
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    data += reader.GetString(0) + "\n";
                }

                MessageBox.Show(data);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            finally 
            {
                conexionbd.Close();
            }
        }
    }
}
