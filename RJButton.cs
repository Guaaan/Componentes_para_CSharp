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
        private int angle = 90;
        private Color m_color1 = Color.FromArgb(0, 120, 215); // first color
        private Color m_color2 = Color.FromArgb(0, 80, 143);
        //animaciones 
        private Boolean anim = true;
        //texto 
        public Boolean showButtonText = true;
        private int textX = 100;
        private int textY = 25;

        private String text = "";


        [Category("Modificadores Personalizados")]
        public enum ButtonsThemes
        {
            Primary,
            Azul,
            Aceptar
        }
        ButtonsThemes buttonTheme;
        public ButtonsThemes ButtonTheme
        {
            get { return buttonTheme; }
            set
            {
                buttonTheme = value; Invalidate();
            }
        }

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

        //[Category("Modificadores Personalizados")]
        //public Boolean Animated
        //{
        //    get { return anim; }
        //    set { anim = value; this.Invalidate(); }
        //}


        [Category("Modificadores Personalizados")]
        public int TextLocation_X
        {
            get { return textX; }
            set { textX = value; Invalidate(); }
        }
        [Category("Modificadores Personalizados")]
        public int TextLocation_Y
        {
            get { return textY; }
            set { textY = value; Invalidate(); }
        }
        [Category("Modificadores Personalizados")]
        public int GradientAngle
        {
            get { return angle; }
            set { angle = value; Invalidate(); }
        }

        //Constructor
        public RJButton()
        {
            this.Size = new Size(150, 40);
            this.Animated = true;
            text = this.Text;
        }

       //draw primary button
       void DrawPrimaryButton(Graphics g)
        {
            Color c1 = m_color1;
            Color c2 = m_color2;

            if (showButtonText)
            {
                Point p = new Point(textX, textY);
                SolidBrush frcolor = new SolidBrush(this.ForeColor);
                g.DrawString(text, this.Font, frcolor, p);
            }

            

        }

        void DrawAzulButton(Graphics g)
        {
            Color c1 = m_color1;
            Color c2 = m_color2;

            if (showButtonText)
            {
                Point p = new Point(textX, textY);
                SolidBrush frcolor = new SolidBrush(this.ForeColor);
                g.DrawString(text, this.Font, frcolor, p);
            }
        }
        void DrawAceptarButton(Graphics g)
        {
            Color c1 = m_color1;
            Color c2 = m_color2;


            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush(ClientRectangle, c1, c2, angle);
            g.FillRectangle(b, 0, 0, this.Width, this.Height);


            if (showButtonText)
            {
                Point p = new Point(textX, textY);
                SolidBrush frcolor = new SolidBrush(this.ForeColor);
                g.DrawString(text, this.Font, frcolor, p);
            }
            b.Dispose();
        }

        //Methods


        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            switch (buttonTheme)
            {
                case ButtonsThemes.Primary:
                    this.DrawPrimaryButton(pevent.Graphics);
                    break;

                case ButtonsThemes.Azul:
                    this.DrawAzulButton(pevent.Graphics);
                    break;

                case ButtonsThemes.Aceptar:
                    this.DrawAceptarButton(pevent.Graphics);
                    break;
            }
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
