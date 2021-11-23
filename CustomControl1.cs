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
    public partial class CustomControl1 : Guna.UI.WinForms.GunaGradientButton
    {
        public CustomControl1()
        {
            InitializeComponent();
            
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
