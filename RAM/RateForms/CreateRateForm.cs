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
    public partial class CreateRateForm : Form
    {
        private Carrier _carrier;
        private enum RateType { Flat, Unflat };
        public CreateRateForm(Carrier carrier)
        {
            InitializeComponent();
            _carrier = carrier;

            costTextBox.KeyPress += Utility.TextBox_KeyPress_Filte_Positive_Number_Only;

            foreach (var item in RAM.Model.Region.Store.Items)
            {
                originComboBox.Items.Add(item.ShortName);
                destinationComboBox.Items.Add(item.ShortName);
            }

            if (RAM.Model.Region.Store.Items.Count > 0)
            {
                originComboBox.SelectedIndex = 0;
                destinationComboBox.SelectedIndex = 0;
            }

            typeComboBox.Items.Add(RateType.Flat.ToString());
            typeComboBox.Items.Add(RateType.Unflat.ToString());

            typeComboBox.SelectedIndex = 0;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string originShortName = originComboBox.SelectedItem.ToString();
            string destinationShortName = destinationComboBox.SelectedItem.ToString();
            string costString = costTextBox.Text;
            RateType rateType;
            Int32 rateCost;
            if (costTextBox.Text.Count() == 0)
            {
                MessageBox.Show("You need fill cost field first");
                return;
            }
            if (originShortName == null || destinationShortName == null)
            {
                MessageBox.Show("Not enough infomation");
                return;
            }

            Enum.TryParse<RateType>(typeComboBox.SelectedItem.ToString(), out rateType);
            Int32.TryParse(costTextBox.Text, out rateCost);

            try
            {
                Rate newRate = null;
                switch (rateType)
                {
                    case RateType.Flat:
                        newRate = new FlatRate(originShortName, destinationShortName, rateCost);
                        break;
                    case RateType.Unflat:
                        newRate = new UnflatRate(originShortName, destinationShortName, rateCost);
                        break;
                }

                _carrier.AddRate(newRate);
                Carrier.Store.SaveToDisk();
                MessageBox.Show("Rate has been saved");
                this.Hide();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }
    }
}
