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
        Excel.Application xlApp; 
        Excel.Workbook xlWB; 
        Excel.Worksheet xlSheet; 
        public Form2()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();
        }

        private void CreateExcel()
        {
            try
            {
                
                xlApp = new Excel.Application();

              
                xlWB = xlApp.Workbooks.Add(Missing.Value);

                
                xlSheet = xlWB.ActiveSheet;

                //CreateTable(); 

                
                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex) 
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

               
                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }

        private void LoadData()
        {
            Flats = context.Flats.ToList();
        }
    }
}
