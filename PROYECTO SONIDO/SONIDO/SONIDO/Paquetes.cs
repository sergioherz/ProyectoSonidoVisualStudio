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
    public partial class Paquetes : Form
    {
        static String cadConexion = "Server=localhost;Database=faraon;Uid=root;Pwd=1234";
        MySqlConnection conexion = new MySqlConnection(cadConexion);
        public Paquetes()
        {
            InitializeComponent();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

            int resPaq = conectar.Registrar(text_nombre.Text, text_costo.Text, text_descripcion.Text);
            if (resPaq > 0)
            {
                MessageBox.Show("Registro almacenado correctamente");
            }
            else
            {
                MessageBox.Show("El registro no se pudo almacenar");
            }
            text_nombre.Clear();
            text_costo.Clear();
            text_descripcion.Clear();

        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            Eliminar_paquetes ol = new Eliminar_paquetes();
            ol.Show();
            this.Hide();

        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            Menu_principal ol = new Menu_principal();
            ol.Show();
            this.Hide();

        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            Modificar_paquetes ol = new Modificar_paquetes();
            ol.Show();
            this.Hide();

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            text_nombre.Clear();
            text_costo.Clear();
            text_descripcion.Clear();

        }

        private void Paquetes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consultas cons = new Consultas();
            cons.Show();
            this.Hide();
           
        }

        private void Paquetes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;   //Permite cancelar el cierre 
            }
        }
    }
}
