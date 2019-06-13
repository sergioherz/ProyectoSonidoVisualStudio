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
using System.Configuration;
using System.IO;

namespace SONIDO
{
    public partial class Consultas : Form
    {
        static String cadConexion = "Server=localhost;Database=faraon;Uid=root;Pwd=1234";
        MySqlConnection conexion = new MySqlConnection(cadConexion);
        public Consultas()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Menu_principal m = new Menu_principal();
            m.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Inventario")
            {

                Consultainventario();

            }
            else if (comboBox1.Text == "Trabajadores")
            {
                ConsultaTrabajadores();
            }
            if (comboBox1.Text == "contratos")
            {

                contratos();

            }
            if (comboBox1.Text == "Paquetes")
            {

                ConsultaPaquetes();
                  }
            }
        public void contratos()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            MySqlCommand invent = new MySqlCommand("select id_con as ID, Nombre_persona as 'Nombre de la persona', Dirección, Telefono, Fecha, Paquetes_id_paq,Anticipo,Resto,Costo from contratos", conexion);
            MySqlDataAdapter listaLe = new MySqlDataAdapter(invent);
            DataSet datosLe = new DataSet();
            listaLe.Fill(datosLe);
            dataGridView1.DataSource = datosLe.Tables[0];
            conexion.Close();
        }




    
        private void Consultainventario()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            MySqlCommand invent = new MySqlCommand("select id_inven as ID, Nombre_producto as 'Nombre del producto', Tipo, Status, Costo from inventario", conexion);
            MySqlDataAdapter listaLe = new MySqlDataAdapter(invent);
            DataSet datosLe = new DataSet();
            listaLe.Fill(datosLe);
            dataGridView1.DataSource = datosLe.Tables[0];
            conexion.Close();
        }
        private void ConsultaTrabajadores()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            MySqlCommand invent = new MySqlCommand("select id_trabajador as ID, Nombre as 'Nombre del trabajador', Telefono, Edad, Dirección from trabajadores", conexion);
            MySqlDataAdapter listaLe = new MySqlDataAdapter(invent);
            DataSet datosLe = new DataSet();
            listaLe.Fill(datosLe);
            dataGridView1.DataSource = datosLe.Tables[0];
            conexion.Close();
        }
        private void ConsultaPaquetes()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            MySqlCommand invent = new MySqlCommand("select id_paq as ID, Nombre as 'Nombre del paquete', Costo, Descripción from paquetes", conexion);
            MySqlDataAdapter listaLe = new MySqlDataAdapter(invent);
            DataSet datosLe = new DataSet();
            listaLe.Fill(datosLe);
            dataGridView1.DataSource = datosLe.Tables[0];
            conexion.Close();
        }

        private void Consultas_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "Excel Document (*.xls)|.xls";
            //sfd.FileName = "Exportados.xls";
            //if (sfd.ShowDialog() == DialogResult.OK)
            //{
            //    ExportaExcell(dataGridView1, sfd.FileName);
            //}
        }
        /*Método para exportar a Excel*/
        private void ExportaExcell(DataGridView DGV, String nombreArchivo)
        {
            //String CadenaDeSalida = "";
            //String EncabezadoSalida = "";
            //for (int j = 0; j < DGV.Columns.Count; j++)
            //    EncabezadoSalida = EncabezadoSalida.ToString() + Convert.ToString(DGV.Columns[j].HeaderText) + "\t";
            //CadenaDeSalida += EncabezadoSalida + "\r\n";
            //for (int i = 0; i < DGV.RowCount - 1; i++)
            //{
            //    String Contenido = "";
            //    for (int k = 0; k < DGV.Rows[i].Cells.Count; k++)
                
            //        Contenido = Contenido.ToString() + Convert.ToString(DGV.Rows[i].Cells[k].Value) + "\t";
            //        CadenaDeSalida += Contenido + "\r\n";
            //}
            //Encoding utfl6 = Encoding.GetEncoding(1254);
            //    byte[] Salida = utfl6.GetBytes(CadenaDeSalida);
            //    FileStream fs = new FileStream(nombreArchivo, FileMode.Create);
            //    BinaryWriter bw = new BinaryWriter(fs);
            //    bw.Write(Salida, 0, Salida.Length);
            //    bw.Flush();
            //    bw.Close();
            //    fs.Close();
        
    }

        private void Consultas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;   //Permite cancelar el cierre 
            }
        }
    }
}