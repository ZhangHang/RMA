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
    public partial class CreateRateForm : Form
    {
        private Carrier Carrier;
        enum RateType { Flat, Unflat };
        public CreateRateForm(Carrier carrier)
        {
            InitializeComponent();
            Carrier = carrier;

            costTextBox.KeyPress += Utility.TextBox_KeyPress_Filte_Positive_Number_Only;

            foreach (var item in RAM.Region.store.Items)
            {
                originComboBox.Items.Add(item.ShortName);
                destinationComboBox.Items.Add(item.ShortName);
            }

            if (RAM.Region.store.Items.Count > 0)
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
            string OriginShortName = originComboBox.SelectedItem.ToString();
            string DestinationShortName = destinationComboBox.SelectedItem.ToString();
            string CostString = costTextBox.Text;
            RateType Type;
            Int32 Cost;
            if(costTextBox.Text.Count() == 0)
            {
                MessageBox.Show("You need fill cost field first");
                return;
            }
            if (OriginShortName == null || DestinationShortName == null)
            {
                MessageBox.Show("Not enough infomation");
                return;
            }

            Enum.TryParse<RateType>(typeComboBox.SelectedItem.ToString(), out Type);
            Int32.TryParse(costTextBox.Text, out Cost);

            try
            {
                Rate newRate = null;
                switch (Type)
                {
                    case RateType.Flat:
                        newRate = new FlatRate(OriginShortName, DestinationShortName, Cost);
                        break;
                    case RateType.Unflat:
                        newRate = new UnflatRate(OriginShortName, DestinationShortName, Cost);
                        break;
                }

                Carrier.AddRate(newRate);
                Carrier.store.SaveToDisk();
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
