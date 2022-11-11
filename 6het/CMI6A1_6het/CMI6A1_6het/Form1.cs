using CMI6A1_6het.Abstract;
using CMI6A1_6het.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMI6A1_6het
{
    public partial class Form1 : Form
    {
        private Toy _nextToy;
        List<Toy> _toys = new List<Toy>();
        private ToyFactory _factory;
        public ToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value;
                DisplayNext();
            }
        
        }

        private void DisplayNext()
        {
            if (_nextToy != null)
            {
                Controls.Remove(_nextToy);
            }
            _nextToy = Factory.CreateNew();
            _nextToy.Top = label1.Top + label1.Height + 20;
            _nextToy.Left = label1.Left;
            Controls.Add(_nextToy);
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new ToyFactory();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var toy = Factory.CreateNew();
            _toys.Add(toy);
            //képernyőn kívül létrejön és beúszik
            toy.Left = -toy.Width;
            panel1.Controls.Add(toy);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var toy in _toys)
            {
                
                toy.MoveToy();
                if (toy.Left > maxPosition)
                {
                    maxPosition = toy.Left;
                }

            }
            if (maxPosition > 1000)
            {
                var oldestToy = _toys[0];
                panel1.Controls.Remove(oldestToy);
                _toys.Remove(oldestToy);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorPicker = new ColorDialog();

            colorPicker.Color = button.BackColor; ;
            if (colorPicker.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            button.BackColor = colorPicker.Color;
        }
    }
}
