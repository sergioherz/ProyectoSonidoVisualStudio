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
    public partial class Consulta_contratos : Form
    {
        static String cadConexion = "Server=localhost;Database=faraon;Uid=root;Pwd=1234";
        MySqlConnection conexion = new MySqlConnection(cadConexion);
        public Consulta_contratos()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Contratos con = new Contratos();
            con.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "contratos")
            {

                Consulta_paquetes();

            }
        }
        public void Consulta_paquetes(){
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            MySqlCommand invent = new MySqlCommand("select id_con as ID, Nombre_persona as 'Nombre de la persona', Dirección, Telefono, Fecha, Paquetes_id_paq from contratos", conexion);
            MySqlDataAdapter listaLe = new MySqlDataAdapter(invent);
            DataSet datosLe = new DataSet();
            listaLe.Fill(datosLe);
            dataGridView1.DataSource = datosLe.Tables[0];
            conexion.Close();
        }

        private void Consulta_contratos_Load(object sender, EventArgs e)
        {

        }
    }
}
