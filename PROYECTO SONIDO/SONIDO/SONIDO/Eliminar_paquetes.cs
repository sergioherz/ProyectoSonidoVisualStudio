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
    public partial class Eliminar_paquetes : Form
    {
        static String cadConexion = "Server=localhost;Database=faraon;Uid=root;Pwd=1234";
        MySqlConnection conexion = new MySqlConnection(cadConexion);
        public Eliminar_paquetes()
        {
            InitializeComponent();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {

            String id = comboBox1.Text;
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            MySqlCommand Eliminar = new MySqlCommand("delete from paquetes where id_paq = @id_paq", conexion);
            Eliminar.Parameters.AddWithValue("@id_paq", id);
            Eliminar.ExecuteNonQuery();
            MessageBox.Show("El paquete se ha eliminado");

            Paquetes ol = new Paquetes();
            ol.Show();
            this.Hide();
            conexion.Close();
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            Menu_principal ol = new Menu_principal();
            ol.Show();
            this.Hide();
        }

        private void Eliminar_paquetes_Load(object sender, EventArgs e)
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            MySqlDataAdapter eliminar = new MySqlDataAdapter("select id_paq from paquetes", conexion);
            DataSet el = new DataSet();
            eliminar.Fill(el);
            comboBox1.DataSource = el.Tables[0];
            comboBox1.ValueMember = "id_paq";

            conexion.Close();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Paquetes ol = new Paquetes();
            ol.Show();
            this.Hide();
        }

        private void Eliminar_paquetes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;   //Permite cancelar el cierre 
            }
        }
    }
}
