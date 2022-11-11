using CMI6A1_6het.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Label = System.Windows.Forms.Label;

namespace CMI6A1_6het.Entities
{
    public class Ball : Toy
    {
        protected override void DrawImage(Graphics g)
        {
            //kör rajzolása
            g.FillEllipse(new SolidBrush(Color.HotPink), 0, 0, Width, Height);
        }
        

    }
}
