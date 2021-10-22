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
        private Color borderColor = Color.PaleVioletRed;
        //colores
        private Color m_color1 = Color.FromArgb(0, 120, 215); // first color
        private Color m_color2 = Color.FromArgb(0, 80, 143);
        //animaciones 
        private Boolean anim = true;

        //Properties
        [Category("RJ Code Advance")]
        public new Color BaseColor1
        {
            get { return m_color1; }
            set { m_color1 = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public new Color BaseColor2
        {
            get { return m_color2; }
            set { m_color2 = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public new bool Animated
        {
            get { return anim; }
            set { anim = value; this.Invalidate(); }
        }

        

        //Constructor
        public RJButton()
        {
            this.Size = new Size(150, 40);
            this.Resize += new EventHandler(Button_Resize);
            this.Animated = true;
        }

        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
                borderRadius = this.Height;
        }

        //Methods
        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

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
            base.OnPaint(pevent);
            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;
            if (borderSize > 0)
                smoothSize = borderSize;
            if (borderRadius > 2) //Rounded button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    //Button surface
                    this.Region = new Region(pathSurface);
                    //Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);
                    //Button border                    
                    if (borderSize >= 1)
                        //Draw control border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else //Normal button
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                //Button surface
                this.Region = new Region(rectSurface);
                //Button border
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
