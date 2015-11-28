using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAM
{
    public partial class CreateRegionForm : Form
    {
        public CreateRegionForm()
        {
            InitializeComponent();
            xAxisTextBox.KeyPress += AxisTextBox_KeyPress;
            yAxisTextBox.KeyPress += AxisTextBox_KeyPress;
        }

        private void AxisTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = false;
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private string ShortName
        {
            get
            {
                return shortNameTextBox.Text;
            }
        }

        private string Description
        {
            get
            {
                return descriptionTextBox.Text;
            }
        }

        private double XAxis
        {
            get
            {
                return Double.Parse(xAxisTextBox.Text);
            }
        }

        private double YAxis
        {
            get
            {
                return Double.Parse(yAxisTextBox.Text);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Region newRegion = new RAM.Region { ShortName = ShortName, Description = Description, XAxis = XAxis, YAxis = YAxis };
                newRegion.Insert();
                RAM.Region.store.SaveToDisk();
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
