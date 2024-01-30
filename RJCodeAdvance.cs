using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyApp
{
    public class RJCodeAdvance : CheckBox
    {
        private Color onBackColor = Color.MediumBlue;
        private Color onToggleColor = Color.White; // Color del toggle cuando está encendido
        private Color offBackColor = Color.Gray; // Color de fondo cuando está apagado
        private Color offToggleColor = Color.White; // Color del toggle cuando está apagado

        public RJCodeAdvance()
        {
            MinimumSize = new Size(45, 22);
        }

        public GraphicsPath GetFigurePath()
        {
            int arcSize = Height - 2;
            Rectangle leftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle rightArc = new Rectangle(Width - 2 - arcSize, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(Parent.BackColor);

            if (Checked) // Encendido
            {
                pevent.Graphics.FillPath(new SolidBrush(onBackColor), GetFigurePath());
                pevent.Graphics.FillEllipse(new SolidBrush(onToggleColor),
                    new Rectangle(Width - Height + 1, 2, toggleSize, toggleSize));
            }
            else // Apagado
            {
                pevent.Graphics.FillPath(new SolidBrush(offBackColor), GetFigurePath());
                pevent.Graphics.FillEllipse(new SolidBrush(offToggleColor),
                    new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
    }
}

