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
            ///String server = txtServidor.Text;
            ///String puerto = txtPuerto.Text;
            ///String user = txtUsuario.Text;
            ///String password = txtContra.Text;
            ///String database = txtBD.Text;

            ///String conexion = "Database=" + database + "; Data Source=" + server + "; Port=" + puerto + "; User Id=" + user + "; Password=" + password;

            ///MySqlConnection conexionbd = new MySqlConnection(conexion);
            ///MySqlDataReader reader = null;
            ///string data = null;

            ///try
            ///{
            ///string consulta = "SHOW DATABASES";
            ///MySqlCommand comando = new MySqlCommand(consulta);
            ///comando.Connection = conexionbd;
            ///conexionbd.Open();
            ///reader = comando.ExecuteReader();

            ///while (reader.Read())
            ///{
            ///data += reader.GetString(0) + "\n";
            ///}

            ///MessageBox.Show(data);
            ///}
            ///catch (MySqlException ex)
            ///{
            ///MessageBox.Show("Error:" + ex.Message);
            ///}
            ///finally 
            ///{
            ///conexionbd.Close();
            ///}
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            String nombre = txtName.Text;
            String apellido = txtLastname.Text;
            String nacimiento = txtBirth.Text;
            String dni = txtDNI.Text;
            String carrera = comboCarrera.Text;
            String año = comboYear.Text;

            MessageBox.Show(nombre + apellido + nacimiento + dni + carrera + año);

            string sqlInsert = "INSERT INTO alumno (nombre, apellido, fechanac, dni, carrera, year) VALUES ('"+ nombre+ "', '"+ apellido+ "','"+ nacimiento+ "','"+ dni+ "','"+ carrera+ "','"+ año+"') ";

            MySqlConnection conexionbd = Conexion.conexion();
            conexionbd.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sqlInsert, conexionbd);
                comando.ExecuteNonQuery();
                MessageBox.Show("Se cargo correctamente!");
            }
            catch (Exception ex) { 
                MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                conexionbd.Close();
            }
        }

        private void btnBuscarPorNombre_Click(object sender, EventArgs e)
        {
            labelID.Text = "ID:";
            labelNombre.Text = "Nombre:";
            labelApel.Text = "Apellido:";
            labelDNI.Text = "DNI:";
            labelNac.Text = "Fecha de nacimiento:";
            labelCarr.Text = "Carrera:";
            labelYear.Text = "Año:";
            String nombre = txtBuscarNombre.Text;
            String apellido = txtBuscarApellido.Text;

            MySqlDataReader reader = null;

            String BuscarAlumnoPorNombre = "SELECT * FROM alumno WHERE nombre LIKE '" + nombre + "'";
            MySqlConnection conexionbd = Conexion.conexion();
            conexionbd.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(BuscarAlumnoPorNombre, conexionbd);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        labelID.Text = "ID: " + reader.GetString(0);
                        labelNombre.Text = "Nombre: " + reader.GetString(1);
                        labelApel.Text = "Apellido: " + reader.GetString(2);
                        labelDNI.Text = "DNI: " + reader.GetString(4);
                        labelNac.Text = "Fecha de nacimiento: " + reader.GetString(3);
                        labelCarr.Text = "Carrera: " + reader.GetString(5);
                        labelYear.Text = reader.GetString(6) + " Año";
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros del alumno");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar" + ex.Message);
            }
            finally { conexionbd.Close(); }
        }
    }
}
