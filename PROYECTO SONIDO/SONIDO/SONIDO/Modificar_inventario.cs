using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Word = Microsoft.Office.Interop.Word;
//using Excell = Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;

namespace SONIDO
{
    public partial class Modificar_inventario : Form
    {
        static String cadConexion = "Server=localhost;Database=faraon;Uid=root;Pwd=1234";
        MySqlConnection conexion = new MySqlConnection(cadConexion);
        public Modificar_inventario()
        {
            InitializeComponent();
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            Menu_principal men = new Menu_principal();
            men.Show();
            this.Hide();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            text_nombre_producto.Clear();
            text_tipo.Clear();
            text_status.Clear();
            text_costo.Clear();

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            MySqlCommand Modificaemp = new MySqlCommand("update inventario set Nombre_producto=@Nombre_producto,Tipo=@Tipo,Status=@Status,Costo=@Costo where id_inven=@id_inven", conexion);
            Modificaemp.Parameters.AddWithValue("@Nombre_producto", text_nombre_producto.Text);
            Modificaemp.Parameters.AddWithValue("@Tipo", text_tipo.Text);
            Modificaemp.Parameters.AddWithValue("@Status", text_status.Text);
            Modificaemp.Parameters.AddWithValue("@Costo", text_costo.Text);


            int N = int.Parse(comboBox1.Text);

            Modificaemp.Parameters.AddWithValue("@id_inven", N);
            Modificaemp.ExecuteNonQuery();
            conexion.Close();
            text_nombre_producto.Clear();
            text_tipo.Clear();
            text_status.Clear();
            text_costo.Clear();
            MessageBox.Show("Modificación existosa!");
        }

        private void Modificar_inventario_Load(object sender, EventArgs e)
        {

            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }

            MySqlDataAdapter cargarDatosTrab = new MySqlDataAdapter("select id_inven from inventario", conexion);
            DataSet datosT = new DataSet();
            cargarDatosTrab.Fill(datosT);
            comboBox1.DataSource = datosT.Tables[0];
            comboBox1.ValueMember = "id_inven";
            conexion.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Microsoft.Office.Interop.Excel.Application excell = new Microsoft.Office.Interop.Excel.Application();
            //Microsoft.Office.Interop.Excel.Workbook libro = excell.Workbooks.Open("Escritorio\\Libro.xlsx");
            //Microsoft.Office.Interop.Excel.Worksheet hoja = excell.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
            //hoja.Cells[4, 5] = comboBox1.Text;
            //hoja.Cells[4, 9] = text_nombre_producto.Text;
            //hoja.Cells[10, 5] = text_status.Text;
            //hoja.Cells[8, 5] = text_tipo.Text;
            //hoja.Cells[8.9] = text_costo.Text;
            //libro.Close(true, Type.Missing, Type.Missing);
            //excell.Quit();
        }

        private void Modificar_inventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;   //Permite cancelar el cierre 
            }
        }
    }
}
