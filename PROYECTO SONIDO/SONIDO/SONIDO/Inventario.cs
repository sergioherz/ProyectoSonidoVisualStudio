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

namespace SONIDO
{
    public partial class Inventario : Form
    {
        //cadena de conexion
        static String cadConexion = "Server=localhost;Database=faraon;Uid=root;Pwd=1234";
        MySqlConnection conexion = new MySqlConnection(cadConexion);
        public Inventario()
        {
            InitializeComponent();
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            Menu_principal ol = new Menu_principal();
            ol.Show();
            this.Hide();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (text_nombre.Text != "" && text_tipo.Text != "" && text_status.Text != "" && text_costo.Text != "")
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }
                MySqlCommand RegistraEm = new MySqlCommand("insert into inventario values( 0,@Nombre_producto,@Tipo,@Status,@Costo)", conexion);
                RegistraEm.Parameters.AddWithValue("@Nombre_producto", text_nombre.Text);
                RegistraEm.Parameters.AddWithValue("@Tipo", text_tipo.Text);
                RegistraEm.Parameters.AddWithValue("@Status", text_status.Text);
                RegistraEm.Parameters.AddWithValue("@Costo", text_costo.Text);
                int RD = 0;
                try
                {
                    text_nombre.Clear();
                    text_tipo.Clear();
                    text_status.Clear();
                    text_costo.Clear();
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

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            Modificar_inventario ol = new Modificar_inventario();
            ol.Show();
            this.Hide();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            text_nombre.Clear();
            text_tipo.Clear();
            text_status.Clear();
            text_costo.Clear();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consultas ol = new Consultas();
            ol.Show();
            this.Hide();
        }

        private void Inventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;   //Permite cancelar el cierre 
            }
        }
    }
}
