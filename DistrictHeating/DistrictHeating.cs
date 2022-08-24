using System.Globalization;
using System.Windows.Forms;

namespace DistrictHeating
{
    public partial class DistrictHeating : Form
    {
        public Plant Plant { get; set; } = new Plant();
        public DistrictHeating()
        {
            InitializeComponent();
        }

        private void readTemperatureData_Click(object sender, EventArgs e)
        {
            openTemperaturFile.Filter = "txt Dateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*";
            openTemperaturFile.FilterIndex = 2;
            openTemperaturFile.RestoreDirectory = true;
            if (DialogResult.OK == openTemperaturFile.ShowDialog())
            {
                Dictionary<int, double[]> yearToTemp = new Dictionary<int, double[]>();
                var fileStream = openTemperaturFile.OpenFile();
                using (StreamReader reader = new StreamReader(fileStream))
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Plant.CheckSolarHeatConsitency();
            Plant.CheckBoreHoleFieldAndSolarConsistency();
        }
    }
}