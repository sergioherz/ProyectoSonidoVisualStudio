using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SONIDO
{
    public partial class Trabajadores : Form
    {
        //cadena de conexion
        static String cadConexion = "Server=localhost;Database=faraon;Uid=root;Pwd=1234";
        MySqlConnection conexion = new MySqlConnection(cadConexion);
        public Trabajadores()
        {
            InitializeComponent();
        }

        private void Trabajadores_Load(object sender, EventArgs e)
        {

        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            Menu_principal men = new Menu_principal();
            men.Show();
            this.Hide();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            textNombre.Clear();
            textTelefono.Clear();
            textEdad.Clear();
            textDireccion.Clear();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            Eliminar_trabajador Etr = new Eliminar_trabajador();
            Etr.Show();
            this.Hide();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (textNombre.Text != "" && textTelefono.Text != "" && textEdad.Text != "" && textDireccion.Text != "")
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }
                MySqlCommand RegistraEm = new MySqlCommand("insert into trabajadores values( 0,@Nombre, @Telefono, @Edad, @Dirección)", conexion);
                RegistraEm.Parameters.AddWithValue("@Nombre", textNombre.Text);
                RegistraEm.Parameters.AddWithValue("@Telefono", textTelefono.Text);
                RegistraEm.Parameters.AddWithValue("@Edad", textEdad.Text);
                RegistraEm.Parameters.AddWithValue("@Dirección", textDireccion.Text);

                int RD = 0;
                try
                {
                    textNombre.Clear();
                    textTelefono.Clear();
                    textEdad.Clear();
                    textDireccion.Clear();
                    MessageBox.Show("Guardado existoso!");
                    RD = RegistraEm.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                }
                conexion.Close();

            }
            //

            else
            {

                MessageBox.Show("Primero rellene los campos que faltan....");

            }
        }

        private void Trabajadores_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;   //Permite cancelar el cierre 
            }
        }
    }
}
