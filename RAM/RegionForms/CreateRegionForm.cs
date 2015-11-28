using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RAM.Model;

namespace RAM
{
    public partial class CreateRegionForm : Form
    {
        public CreateRegionForm()
        {
            InitializeComponent();
            xAxisTextBox.KeyPress += Utility.TextBox_KeyPress_Filte_Number_Only;
            yAxisTextBox.KeyPress += Utility.TextBox_KeyPress_Filte_Number_Only;
        }

        private string _shortName
        {
            get
            {
                return shortNameTextBox.Text;
            }
        }

        private string _description
        {
            get
            {
                return descriptionTextBox.Text;
            }
        }

        private string _xAxisText
        {
            get
            {
                return xAxisTextBox.Text;
            }
        }

        private string _yAxisText
        {
            get
            {
                return yAxisTextBox.Text;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(_xAxisText.Count() == 0 || _yAxisText.Count() == 0)
            {
                MessageBox.Show("You need to fill Axis fields first");
                return;
            }
            try
            {
                Int32 xAxis, yAxis;
                Int32.TryParse(_xAxisText, out xAxis);
                Int32.TryParse(_yAxisText, out yAxis);

                RAM.Model.Region newRegion = new RAM.Model.Region { ShortName = _shortName, Description = _description, XAxis = xAxis, YAxis = yAxis };
                newRegion.Insert();
                RAM.Model.Region.Store.SaveToDisk();
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
