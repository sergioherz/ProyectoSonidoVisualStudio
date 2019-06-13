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
    public partial class menuprincipall : Form
    {
        public menuprincipall()
        {
            InitializeComponent();
        }

        private void btn_Trabajadores_Click(object sender, EventArgs e)
        {
            Trabajadores trab = new Trabajadores();
            trab.Show();
            this.Hide();
        }

        private void bnt_Inventario_Click(object sender, EventArgs e)
        {
            Inventario inve = new Inventario();
            inve.Show();
            this.Hide();
        }

        private void btn_Paquetes_Click(object sender, EventArgs e)
        {
            Paquetes paqe = new Paquetes();
            paqe.Show();
            this.Hide();
        }

        private void btn_Contratos_Click(object sender, EventArgs e)
        {
            Contratos con = new Contratos();
            con.Show();
            this.Hide();
        }

        private void menuprincipall_Load(object sender, EventArgs e)
        {

        }
    }
}
