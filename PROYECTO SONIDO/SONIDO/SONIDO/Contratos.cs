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
    public partial class Contratos : Form
    {
        //cadena de conexion
        static String cadConexion = "Server=localhost;Database=faraon;Uid=root;Pwd=1234";
        MySqlConnection conexion = new MySqlConnection(cadConexion);
        public Contratos()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu_principal me = new Menu_principal();
            me.Show();
            this.Hide();
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            Modificar_contrato co = new Modificar_contrato();
            co.Show();
            this.Hide();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            Eliminar_contrato el = new Eliminar_contrato();
            el.Show();
            this.Hide();
        }
        private void ConsultaPaquetes()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            MySqlCommand invent = new MySqlCommand("select id_paq as ID, Nombre as 'Nombre del paquete' from paquetes", conexion);
            MySqlDataAdapter listaLe = new MySqlDataAdapter(invent);
            DataSet datosLe = new DataSet();
            listaLe.Fill(datosLe);
            dataGridView1.DataSource = datosLe.Tables[0];
            conexion.Close();
        }
        private void Contratos_Load(object sender, EventArgs e)
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }

            MySqlDataAdapter CargarPaquetes = new MySqlDataAdapter("select id_paq from paquetes", conexion);
            DataSet datosP = new DataSet();
            CargarPaquetes.Fill(datosP);
            combo_paquete.DataSource = datosP.Tables[0];
            combo_paquete.DisplayMember = "id_paq";
            conexion.Close();



        }
        



        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            
            String nombre = combo_paquete.Text;
            String pa = "LIQUIDADO";
            String de = "DEBE";
            
            String ant = text_Anticipo.Text;
            int g;
            
            if (text_nombre.Text != "" && text_dire.Text != "" && text_tel.Text != "" && combo_paquete.Text != "")
            {
                
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }
                MySqlCommand RegistraEm = new MySqlCommand("insert into contratos values( 0,@Nombre_persona,@Dirección,@Telefono,@Fecha,@Paquetes_id_paq,@Anticipo,@Resto,@Costo)", conexion);
                RegistraEm.Parameters.AddWithValue("@Nombre_persona", text_nombre.Text);
                RegistraEm.Parameters.AddWithValue("@Dirección", text_dire.Text);
                RegistraEm.Parameters.AddWithValue("@Telefono", text_tel.Text);
                RegistraEm.Parameters.AddWithValue("@Fecha", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                String valor = combo_paquete.Text;
                int ValorEntero = Convert.ToInt32(valor);
                RegistraEm.Parameters.AddWithValue("@Paquetes_id_paq", ValorEntero);
                RegistraEm.Parameters.AddWithValue("@Anticipo", text_Anticipo.Text);
                RegistraEm.Parameters.AddWithValue("@Resto", text_Resto.Text);
                RegistraEm.Parameters.AddWithValue("@Costo", text_Pagado.Text);
                

                int RD = 0;
                
                try
                {
                    text_nombre.Clear();
                    text_dire.Clear();
                    text_tel.Clear();
                    text_Anticipo.Clear();
                    //text_Pagado.Clear();
                    text_Resto.Clear();
                    MessageBox.Show("Contrato guardado existosamente!");
                    RD = RegistraEm.ExecuteNonQuery();
                    


                }
                catch (Exception ex)
                {

                }
                conexion.Close();
              //  if (text_Anticipo == text_Pagado)
               // {

                 //   text_Resto.Text = (double.Parse(text_Pagado.Text) == double.Parse(text_Anticipo.Text)).ToString();
                 //   text_Resto.Text = "Pagado";
                //}
                //else
               // {
                 //   text_Resto.Text = (double.Parse(text_Pagado.Text) - double.Parse(text_Anticipo.Text)).ToString();
                 //   text_Resto.Text= "Debe" ;
               // }
            }

            else
            {

                MessageBox.Show("Primero rellene los campos que faltan....");

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consultas con = new Consultas();
            con.Show();
            this.Hide();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            text_nombre.Clear();
            text_dire.Clear();
            text_tel.Clear();
            text_Anticipo.Clear();
            text_Pagado.Clear();
            text_Resto.Clear();
            
            //Menu_principal men = new Menu_principal();
            //men.Show();
            //this.Hide();
        }

        private void Contratos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;   //Permite cancelar el cierre 
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void combo_paquete_SelectedValueChanged(object sender, EventArgs e)
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();

            }

            MySqlCommand ListaDatosC = new MySqlCommand("select * from Paquetes where id_paq=@id_paq", conexion);
            ListaDatosC.Parameters.AddWithValue("@id_paq", combo_paquete.Text);
            MySqlDataReader leidos = ListaDatosC.ExecuteReader();
            if (leidos.Read())
            {
                text_Pagado.Text = leidos["Costo"].ToString();
             

            }
            conexion.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int ant = Convert.ToInt32(text_Anticipo.Text), costo = Convert.ToInt32(text_Pagado.Text);
            if(ant > costo)
            {
                MessageBox.Show("¡Error! Anticipo ingresado es mayor al costo del paquete.");
                text_Anticipo.Clear();

            }
            if (ant < 0)
            {
                MessageBox.Show("¡Error! ¡Anticipo ingresado es invalido!");
                text_Anticipo.Clear();
                text_Resto.Clear();
            }

            if (text_Anticipo.Text == "") { 
                text_Anticipo.Text = "0";
                int num1 = Convert.ToInt32(text_Pagado.Text), num2 = Convert.ToInt32(text_Anticipo.Text), resta;
                resta = num1 - num2;
                text_Resto.Text = "" + resta;
            }
            else
            {
                int num1 = Convert.ToInt32(text_Pagado.Text), num2 = Convert.ToInt32(text_Anticipo.Text), resta;
                resta = num1 - num2;
                text_Resto.Text = "" + resta;
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Paquetes")
            {

                ConsultaPaquetes();
            }
        }
    }
}
