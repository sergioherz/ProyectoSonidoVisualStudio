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
    public partial class Modificar_paquetes : Form
    {
        static String cadConexion = "Server=localhost;Database=faraon;Uid=root;Pwd=1234";
        MySqlConnection conexion = new MySqlConnection(cadConexion);
        public Modificar_paquetes()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            String id = comboBox1.Text;
            int id_paq = Convert.ToInt32(id);

            int modPa = conectar.modificarPaquetes(id_paq, textBox2.Text, textBox3.Text, textBox4.Text);
            if (modPa > 0)
            {
                MessageBox.Show("Paquete Modificado");
            }
            else
            {
                MessageBox.Show("No se modifico el paquete");
            }

            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();



        }

        private void Modificar_paquetes_Load(object sender, EventArgs e)
        {
            conectar.listarPaquetes(comboBox1);
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            Menu_principal men = new Menu_principal();
            men.Show();
            this.Hide();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void Modificar_paquetes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;   //Permite cancelar el cierre 
            }
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            String id_paq = comboBox1.Text;
            String[] DetallePaquetes;
            if ((DetallePaquetes = conectar.BuscarPaquetes(Convert.ToInt32(id_paq))) != null)
            {
                textBox2.Text = DetallePaquetes[0];
                textBox3.Text = DetallePaquetes[1];
                textBox4.Text = DetallePaquetes[2];
            }

        }
    }
}
