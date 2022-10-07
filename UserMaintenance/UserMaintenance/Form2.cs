using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace UserMaintenance
{
    public partial class Form2 : Form
    {
        //Nem tudok csatlakozni az adatbázishoz valamiért errort ír ki a laptopom, ezért nem jött létre a Model1-em és az Entities se.
        List<Flat> Flats;
        RealEstateEntities context = new RealEstateEntities();

        public Form2()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            Flats = context.Flats.ToList();
        }
    }
}
