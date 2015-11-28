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
    public partial class EditRateForm : Form
    {
        private Carrier Carrier;
        private Rate Rate;
        private string originalOriginRegionShortName;
        private string originalOriginDestinationShortName;
        enum RateType { Flat, Unflat };
        public EditRateForm(Carrier carrier, Rate rateToEdit)
        {
            InitializeComponent();
            Carrier = carrier;
            Rate = rateToEdit;

            originalOriginRegionShortName = Rate.OriginRegionShortName;
            originalOriginDestinationShortName = Rate.DestinationRegionShortName;

            costTextBox.KeyPress += Utility.TextBox_KeyPress_Filte_Positive_Number_Only;

            foreach (var item in RAM.Region.store.Items)
            {
                originComboBox.Items.Add(item.ShortName);
                destinationComboBox.Items.Add(item.ShortName);
            }

            originComboBox.SelectedItem = Rate.OriginRegionShortName;
            destinationComboBox.SelectedItem = Rate.DestinationRegionShortName;


            typeComboBox.Items.Add(RateType.Flat.ToString());
            typeComboBox.Items.Add(RateType.Unflat.ToString());

            if (Rate is FlatRate)
            {
                typeComboBox.SelectedIndex = 0;
                costTextBox.Text = (Rate as FlatRate).Totalcost.ToString();
            }
            else if (Rate is UnflatRate)
            {
                typeComboBox.SelectedIndex = 1;
                costTextBox.Text = (Rate as UnflatRate).CostPerMile.ToString();
            }
            else
            {
                throw new Exception("fatal error");
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string OriginShortName = originComboBox.SelectedItem.ToString();
            string DestinationShortName = destinationComboBox.SelectedItem.ToString();
            string CostString = costTextBox.Text;
            RateType Type;
            Int32 Cost;
            if (costTextBox.Text.Count() == 0)
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

            if (originalOriginDestinationShortName != originalOriginRegionShortName || originalOriginDestinationShortName != DestinationShortName)
            {
                if (Carrier.HasRate(OriginShortName, DestinationShortName))
                {
                    MessageBox.Show("Each carrier can only have one rate per lane");
                    return;
                }
            }
            
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

                Carrier.RemoveRate(Rate);
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
