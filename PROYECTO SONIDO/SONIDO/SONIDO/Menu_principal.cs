using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONIDO
{
    public partial class Menu_principal : Form
    {
        public Menu_principal()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void bnt_Inventario_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Estás seguro que deseas salir?", "Confirmación", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                //Invocar otro formulario.
            }
            
        }

        private void Menu_principal_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Trabajadores_Click(object sender, EventArgs e)
        {
            
        }

        private void Menu_principal_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Menu_principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("¿Desea salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;   //Permite cancelar el cierre 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Paquetes_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Contratos_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Contratos ja = new Contratos();
            ja.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Agregar")
            {
                Trabajadores tr = new Trabajadores();
                tr.Show();
                this.Hide();
            }
            if(comboBox1.Text == "Eliminar")
            {
                Eliminar_trabajador eli = new Eliminar_trabajador();
                eli.Show();
                this.Hide();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Agregar")
            {
                Paquetes paq = new Paquetes();
                paq.Show();
                this.Hide();
            }
            if (comboBox4.Text == "Eliminar")
            {
                Eliminar_paquetes paq = new Eliminar_paquetes();
                paq.Show();
                this.Hide();
            }
            if (comboBox4.Text == "Modificar")
            {
                Modificar_paquetes paq = new Modificar_paquetes();
                paq.Show();
                this.Hide();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Agregar")
            {
                Contratos paq = new Contratos();
                paq.Show();
                this.Hide();
            }
            if (comboBox3.Text == "Eliminar")
            {
                Eliminar_contrato paq = new Eliminar_contrato();
                paq.Show();
                this.Hide();
            }
            if (comboBox3.Text == "Modificar")
            {
                Modificar_contrato paq = new Modificar_contrato();
                paq.Show();
                this.Hide();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Agregar")
            {
                Inventario paq = new Inventario();
                paq.Show();
                this.Hide();
            }
            if (comboBox2.Text == "Modificar")
            {
                Modificar_inventario paq = new Modificar_inventario();
                paq.Show();
                this.Hide();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox5.Text == "Generales")
            {
                Consultas con = new Consultas();
                con.Show();
                this.Hide();
            }
            if(comboBox5.Text== "Detallada Contrato")
            {
                Consulta_Detallada con = new Consulta_Detallada();
                con.Show();
                this.Hide();
            }
        }
    }
}
