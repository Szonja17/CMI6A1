using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMI6A_6.Entities
{
    internal class Ball : Label
    {
        public Ball()
        {
            AutoSize = false;
            Height = 50;
            Width = 50;
            Paint += Ball_Paint;
        }

        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        private void DrawImage(Graphics g)
        {
            //kör kirajzolása
            g.FillEllipse(new SolidBrush(Color.HotPink), 0, 0, Width, Height);
            int valami;
        }
    }
}
