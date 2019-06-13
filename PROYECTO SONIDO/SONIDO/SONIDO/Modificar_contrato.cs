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
    public partial class Modificar_contrato : Form
    {
        static String cadConexion = "Server=localhost;Database=faraon;Uid=root;Pwd=1234";
        MySqlConnection conexion = new MySqlConnection(cadConexion);
        
        public Modificar_contrato()
        {
            InitializeComponent();
        }

        private void Modificar_contrato_Load(object sender, EventArgs e)
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }

            MySqlDataAdapter cargarDatosTrab = new MySqlDataAdapter("select id_con from contratos", conexion);
            DataSet datosT = new DataSet();
            cargarDatosTrab.Fill(datosT);
            comboBox1.DataSource = datosT.Tables[0];
            comboBox1.ValueMember = "id_con";
            conexion.Close();

            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }

            MySqlDataAdapter CargarPaquetes = new MySqlDataAdapter("select id_paq from paquetes", conexion);
            DataSet datosP = new DataSet();
            CargarPaquetes.Fill(datosP);
            comboBox2.DataSource = datosP.Tables[0];
            comboBox2.DisplayMember = "id_paq";
            conexion.Close();
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }

            MySqlDataAdapter CargarContratos = new MySqlDataAdapter("select id_con from contratos", conexion);
            DataSet datosC = new DataSet();
            CargarContratos.Fill(datosC);
            comboBox1.DataSource = datosC.Tables[0];
            comboBox1.DisplayMember = "id_con";
            conexion.Close();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (text_nombre.Text != "" && text_direccion.Text != "" && text_telefono.Text != "" && comboBox2.Text != "")
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }
                
                MySqlCommand Modificaemp = new MySqlCommand("update contratos set Nombre_persona=@Nombre_persona,Dirección=@Dirección,Telefono=@Telefono,Fecha=@Fecha,Paquetes_id_paq=@Paquetes_id_paq where id_con=@id_con", conexion);
                Modificaemp.Parameters.AddWithValue("@Nombre_persona", text_nombre.Text);
                Modificaemp.Parameters.AddWithValue("@Dirección", text_direccion.Text);
                Modificaemp.Parameters.AddWithValue("@Telefono", text_telefono.Text);
                Modificaemp.Parameters.AddWithValue("@Fecha", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                String valor = comboBox2.Text;
                int ValorEntero = Convert.ToInt32(valor);
                Modificaemp.Parameters.AddWithValue("@Paquetes_id_paq", ValorEntero);
                int RD = 0;


                int N = int.Parse(comboBox1.Text);

                Modificaemp.Parameters.AddWithValue("@id_con", N);
                Modificaemp.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("Modificación existosa!");

                try
                {


                    Consultas a = new Consultas();
                    RD = Modificaemp.ExecuteNonQuery();
                    a.Show();
                    this.Hide();

                }
                catch (Exception ex)
                {

                }
                conexion.Close();

            }
            else
            {

                MessageBox.Show("Primero rellene los campos que faltan....");

            }
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            Menu_principal men = new Menu_principal();
            men.Show();
            this.Hide();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            text_nombre.Clear();
            text_direccion.Clear();
            text_telefono.Clear();
            //Contratos lo = new Contratos();
            //lo.Show();
            //this.Hide();
        }

        private void Modificar_contrato_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;   //Permite cancelar el cierre 
            }
        }
    }
    }

    

