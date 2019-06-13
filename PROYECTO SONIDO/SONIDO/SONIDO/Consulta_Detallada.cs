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
using Excell = Microsoft.Office.Interop.Excel;

namespace SONIDO
{
    public partial class Consulta_Detallada : Form
    {
        static String cadConexion = "Server=localhost;Database=faraon;Uid=root;Pwd=1234";
        MySqlConnection conexion = new MySqlConnection(cadConexion);
        public Consulta_Detallada()
        {
            InitializeComponent();
        }

        private void Consulta_Detallada_Load(object sender, EventArgs e)
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
                MySqlDataAdapter LNombres = new MySqlDataAdapter("select nombre_persona from contratos", conexion);
                DataSet lista = new DataSet();
                LNombres.Fill(lista);
                comboBox1.DataSource = lista.Tables[0];
                comboBox1.DisplayMember = "nombre_persona";

                conexion.Close();

            }

        }
        private void Consulta_Detallada_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;   //Permite cancelar el cierre 
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu_principal men = new Menu_principal();
            men.Show();
            this.Hide();
        }

        private void text_Direccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();

            }
            //MySqlCommand Carga = new MySqlCommand("call carga (@id_con)", conexion);
            //Carga.Parameters.AddWithValue("@id_con", textBox3.Text);
            //MySqlDataReader lee = Carga.ExecuteReader();
            //if (lee.Read())
            //{
            //    textBox4.Text = lee["Nombre_persona"].ToString();
            //    text_Direccion.Text = lee["Dirección"].ToString();
            //    text_Telefono.Text = lee["Telefono"].ToString();
            //    //text_Fecha.Text = lee["Nombre_persona"].ToString();

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();

            }

            MySqlCommand ListaDatosC = new MySqlCommand("select * from contratos where nombre_persona=@nombre_p", conexion);
            ListaDatosC.Parameters.AddWithValue("@nombre_p", comboBox1.Text);
            MySqlDataReader leidos = ListaDatosC.ExecuteReader();
            if (leidos.Read())
            {
                text_Direccion.Text = leidos["Dirección"].ToString();
                text_Telefono.Text = leidos["Telefono"].ToString();
                textBox5.Text = leidos["Fecha"].ToString();
                textBox2.Text = leidos["paquetes_id_paq"].ToString();
                text_Anticipo.Text = leidos["Anticipo"].ToString();
                text_Resto.Text = leidos["Resto"].ToString();
                text_Costo.Text = leidos["costo"].ToString();
                

            }
            if (text_Resto.Text == "0"){
                text_Status.ForeColor = Color.Green;
                text_Status.Text="¡PAGADO!";
                
            }
            else
            {
                text_Status.ForeColor = Color.Red;
                text_Status.Text = "¡CON ADEUDO! Debe: $"+ text_Resto.Text;
            }
            if (text_Resto.Text == "")
            {
                text_Status.Text ="";
            }

            conexion.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excell = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook libro = excell.Workbooks.Open("C:\\H.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet hoja = excell.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
            hoja.Cells[13, 2] = comboBox1.Text;
            hoja.Cells[17, 2] = text_Direccion.Text;
            hoja.Cells[25, 2] = textBox2.Text;
            hoja.Cells[21, 2] = textBox5.Text;
            hoja.Cells[13, 7] = text_Anticipo.Text;
            hoja.Cells[17, 7] = text_Resto.Text;
            hoja.Cells[21, 7] = text_Status.Text;
            hoja.Cells[34, 5] = comboBox1.Text;
            libro.Close(true, Type.Missing, Type.Missing);
            excell.Quit();
        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void text_Anticipo_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //conexion.Close();

    }
    }
   // }

