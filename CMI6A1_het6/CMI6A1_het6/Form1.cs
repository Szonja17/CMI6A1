using CMI6A1_het6.Entities;
using CMI6A1_het6.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CMI6A1_het6
{
    public partial class Form1 : Form
    {
        BindingList<RateDate> bs = new BindingList<RateDate>();
        BindingList<string> Currency = new BindingList<string>();
        public Form1()
        {
            InitializeComponent();
            
            comboBox1.DataSource = Currency;
            
            RefreshData();
            

        }

        private string getcurrencies()
        {
            var mnbServuce = new MNBArfolyamServiceSoapClient();

            var request = new GetCurrenciesRequestBody();
           

            var response = mnbServuce.GetCurrencies(request);

            var result = response.GetCurrenciesResult;
            return result;
        }

        private void RefreshData()
        {
            bs.Clear(); 
            dataGridView1.DataSource = bs;
            xmlfeld(webszhivasa());
            diagram();
            chart1.DataSource = bs;
            nyolcadikfeladat(getcurrencies());

        }

        private void nyolcadikfeladat(string result)
        {
            var xml = new XmlDocument();
            xml.LoadXml(result);

                foreach (XmlElement element in xml.DocumentElement)
                {
                    var rate = new RateDate();
                    bs.Add(rate);
                    rate.Date = DateTime.Parse(element.GetAttribute("date"));

                    var childElement = (XmlElement)element.ChildNodes[0];
                    rate.Currency = childElement.GetAttribute("curr");

                    var unit = decimal.Parse(childElement.GetAttribute("unit"));
                    var value = decimal.Parse(childElement.InnerText);
                    if (childElement == null) continue;
                }
            
        }

        private void diagram()
        {
            var series = chart1.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            series.BorderWidth = 2;

            var legend = chart1.Legends[0];
            legend.Enabled = false;

            var chartArea = chart1.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }

        private string webszhivasa()
        {
            var mnbServuce = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = (string)comboBox1.SelectedItem,
                startDate = dateTimePicker1.Value.ToString(),
                endDate = dateTimePicker2.Value.ToString()
            };

            var response = mnbServuce.GetExchangeRates(request);

            var result = response.GetExchangeRatesResult;

            return result;
        }
        private void xmlfeld(string result)
        {

            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new RateDate();
                bs.Add(rate);
                rate.Date = DateTime.Parse(element.GetAttribute("date"));

                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childElement.GetAttribute("curr");

                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
