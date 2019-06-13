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
    public partial class Eliminar_trabajador : Form
    {
        static String cadConexion = "Server=localhost;Database=faraon;Uid=root;Pwd=1234";
        MySqlConnection conexion = new MySqlConnection(cadConexion);
        public Eliminar_trabajador()
        {
            InitializeComponent();
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            Menu_principal Tr = new Menu_principal();
            Tr.Show();
            this.Hide();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
         
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            String nombret = comboBox1.Text;
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            MySqlCommand Eliminar = new MySqlCommand("delete from trabajadores where nombre=@nombre", conexion);
            Eliminar.Parameters.AddWithValue("@nombre", nombret);
            Eliminar.ExecuteNonQuery();
            MessageBox.Show("Eliminación existosa!");
            conexion.Close();
        }

        private void Eliminar_trabajador_Load(object sender, EventArgs e)
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }

            MySqlDataAdapter cargarDatosTrab = new MySqlDataAdapter("select id_trabajador, nombre from trabajadores", conexion);
            DataSet datosT = new DataSet();
            cargarDatosTrab.Fill(datosT);
            comboBox1.DataSource = datosT.Tables[0];
            comboBox1.ValueMember = "id_trabajador";
            comboBox1.DisplayMember = "nombre";

            conexion.Close();

        }

        private void Eliminar_trabajador_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;   //Permite cancelar el cierre 
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
