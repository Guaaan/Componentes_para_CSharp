using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Principal
{
    public partial class ReportesNuevos : Form
    {
        public ReportesNuevos()
        {
            InitializeComponent();
        }

        private void btnReimpresiones_Click(object sender, EventArgs e)
        {
            tbcReportes.SelectedTab = Reimprimir;

        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            tbcReportes.SelectedTab = Movimiento;
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            tbcReportes.SelectedTab = Inventario;
        }

        private void gunaGradientButton14_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnDefinir1_Click(object sender, EventArgs e)
        {
            if (pnlOpcional1.Visible == true)
            {
                pnlOpcional1.Hide();
            }
            if (pnlDefinir1.Visible == false)
            {
                pnlDefinir1.Show();
            }
            else
            {
                pnlDefinir1.Hide();
            }
        }

        private void btnOpcionales_Click(object sender, EventArgs e)
        {
            if (pnlDefinir1.Visible == true)
            {
                pnlDefinir1.Hide();
            }
            if (pnlOpcional1.Visible == false)
            {
                pnlOpcional1.Show();
            }
            else
            {
                pnlOpcional1.Hide();
            }
        }

        private void gunaGradientButton15_Click(object sender, EventArgs e)
        {
            pnlDefinir1.Hide();
        }

        private void gunaGradientButton17_Click(object sender, EventArgs e)
        {
            pnlOpcional1.Hide();
        }

        private void gunaGradientButton24_Click(object sender, EventArgs e)
        {
            pnlOpcionales2.Hide();
        }

        private void btnOpcionales2_Click(object sender, EventArgs e)
        {
            if (pnlOpcionales2.Visible == false)
            {
                pnlOpcionales2.Show();
            }
            else
            {
                pnlOpcionales2.Hide();
            }
        }

     

    }
}
