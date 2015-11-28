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
            xAxisTextBox.KeyPress += Utility.TextBox_KeyPress_Filte_Number_Only;
            yAxisTextBox.KeyPress += Utility.TextBox_KeyPress_Filte_Number_Only;
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

        private string XAxisText
        {
            get
            {
                return xAxisTextBox.Text;
            }
        }

        private string YAxisText
        {
            get
            {
                return yAxisTextBox.Text;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(XAxisText.Count() == 0 || YAxisText.Count() == 0)
            {
                MessageBox.Show("You need to fill Axis fields first");
                return;
            }
            try
            {
                Int32 XAxis, YAxis;
                Int32.TryParse(XAxisText, out XAxis);
                Int32.TryParse(YAxisText, out YAxis);
                
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
