using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using Guna.UI.WinForms;

namespace Componentes_para_diseño_winforms
{
    public class RJButton : GunaGradientButton
    {
        //Fields
        //borde
        private int borderRadius = 20;
        private int borderSize = 2;

        //colores
        private Color borderColor = Color.PaleVioletRed;
        private Color baseColor1 = Color.FromArgb(0, 120, 215); // first color
        private Color baseColor2 = Color.FromArgb(0, 80, 143);

        //animaciones 
        private Boolean anim = true;

        //texto
        private string txt = "botón";

        //Properties
        [Category("Control Personalizado")]
        public new Color BaseColor1
        {
            get { return baseColor1; }
            set { baseColor1 = value; Invalidate(); }
        }

        [Category("Control Personalizado")]
        public new Color BaseColor2
        {
            get { return baseColor2; }
            set { baseColor2 = value; Invalidate(); }
        }

        [Category("Control Personalizado")]
        public new bool Animated
        {
            get { return anim; }
            set { anim = value; Invalidate();  }
        }
        [Category("Control Personalizado")]
        public new string Text
        {
            get { return txt; }
            set { Text = value; Invalidate(); }
        }

        //Constructor
        public RJButton()
        {
            

        }

        //Methods

        protected override void OnPaint(PaintEventArgs pe)
        {
            // Calling the base class OnPaint
            base.OnPaint(pe);
            // Create two semi-transparent colors
            Color c1 = baseColor1;
            Color c2 = baseColor2;

            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush
                (ClientRectangle, c1, c2, 10);
            pe.Graphics.FillRectangle(b, ClientRectangle);
            b.Dispose();
        }


    }
}
