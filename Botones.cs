using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Componentes_para_diseño_winforms
{
    public partial class Botones : Form
    {
        public Botones()
        {
            InitializeComponent();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            ventanaPestañas abrirVentanapestañas = new ventanaPestañas();
            abrirVentanapestañas.Show();
        }

        private void gunaGradientButton9_Click(object sender, EventArgs e)
        {
            extras1 abrirExtras = new extras1();
            abrirExtras.Show();
        }
    }
}
