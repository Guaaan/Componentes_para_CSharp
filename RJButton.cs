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
        private Color borderColor = Color.PaleVioletRed;
        //colores
        private Color m_color1 = Color.FromArgb(0, 120, 215); // first color
        private Color m_color2 = Color.FromArgb(0, 80, 143);
        //animaciones 
        private Boolean anim = true;
        //texto 
        private String text = "";




        //Properties
        [Category("Modificadores Personalizados")]
        public Color BaseColor1
        {
            get { return m_color1; }
            set { m_color1 = value; this.Invalidate(); }
        }

        [Category("Modificadores Personalizados")]
        public Color BaseColor2
        {
            get { return m_color2; }
            set { m_color2 = value; this.Invalidate(); }
        }

        [Category("Modificadores Personalizados")]
        public Boolean Animated
        {
            get { return anim; }
            set { anim = value; this.Invalidate(); }
        }

        [Category("Modificadores Personalizados")]
        public String Text
        {
            get { return text; }
            set { text = value; this.Invalidate(); }
        }

        

        //Constructor
        public RJButton()
        {
            this.Size = new Size(150, 40);
            this.Animated = true;
            text = this.Text;
            anim = this.Animated;
        }

       

        //Methods
        

        protected override void OnPaint(PaintEventArgs pevent)
        {
            // Calling the base class OnPaint
            base.OnPaint(pevent);

            // Create two colors
            Color c1 = m_color1;
            Color c2 = m_color2;
            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush
                (ClientRectangle, c1, c2, 10);
            pevent.Graphics.FillRectangle(b, ClientRectangle);
            b.Dispose();
            //base.OnPaint(pevent);
            
        }
        /*protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }*/
    }
}
