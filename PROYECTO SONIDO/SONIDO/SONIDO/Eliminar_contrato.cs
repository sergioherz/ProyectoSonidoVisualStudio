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
    public partial class Eliminar_contrato : Form
    {
        static String cadConexion = "Server=localhost;Database=faraon;Uid=root;Pwd=1234";
        MySqlConnection conexion = new MySqlConnection(cadConexion);
        public Eliminar_contrato()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Eliminar_contrato_Load(object sender, EventArgs e)
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }

            MySqlDataAdapter cargarDatosTrab = new MySqlDataAdapter("select id_con, Nombre_persona from contratos", conexion);
            DataSet datosT = new DataSet();
            cargarDatosTrab.Fill(datosT);
            comboBox1.DataSource = datosT.Tables[0];
            comboBox1.ValueMember = "id_con";
            comboBox1.DisplayMember = "Nombre_persona";

            conexion.Close();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            String nombre = comboBox1.Text;
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            MySqlCommand Eliminar = new MySqlCommand("delete from contratos where Nombre_persona=@Nombre_persona", conexion);
            Eliminar.Parameters.AddWithValue("@Nombre_persona", nombre);
            Eliminar.ExecuteNonQuery();
            MessageBox.Show("EL CONTRATO A SIDO ELIMINADO ");

            Consultas lol = new Consultas();
            lol.Show();
            this.Hide();


            conexion.Close();
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            Contratos con = new Contratos();
            con.Show();
            this.Hide();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Contratos con = new Contratos();
            con.Show();
            this.Hide();
        }

        private void btn_Regresar_Click_1(object sender, EventArgs e)
        {
            Menu_principal men = new Menu_principal();
            men.Show();
            this.Hide();
        }

        private void btn_cancelar_Click_1(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            // Contratos con = new Contratos();
            //con.Show();
            //this.Hide();
        }

        private void Eliminar_contrato_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;   //Permite cancelar el cierre 
            }
        }
    }
}
    
    

