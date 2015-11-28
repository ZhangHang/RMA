using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RMA.Model;

namespace RMA
{
    public partial class EditRateForm : Form
    {
        private Carrier _carrier;
        private Rate _rateToEdit;
        private string _originalOriginRegionShortName;
        private string _originalOriginDestinationShortName;
        private enum RateType { Flat, Increase };

        public EditRateForm(Carrier carrier, Rate rateToEdit)
        {
            InitializeComponent();
            _carrier = carrier;
            _rateToEdit = rateToEdit;

            _originalOriginRegionShortName = _rateToEdit.OriginRegionShortName;
            _originalOriginDestinationShortName = _rateToEdit.DestinationRegionShortName;

            costTextBox.KeyPress += Utility.TextBox_KeyPress_Filte_Positive_Number_Only;

            foreach (var item in RMA.Model.Region.Store.Items)
            {
                originComboBox.Items.Add(item.ShortName);
                destinationComboBox.Items.Add(item.ShortName);
            }

            originComboBox.SelectedItem = _rateToEdit.OriginRegionShortName;
            destinationComboBox.SelectedItem = _rateToEdit.DestinationRegionShortName;


            typeComboBox.Items.Add(RateType.Flat.ToString());
            typeComboBox.Items.Add(RateType.Increase.ToString());

            if (_rateToEdit is FlatRate)
            {
                typeComboBox.SelectedIndex = 0;
                costTextBox.Text = (_rateToEdit as FlatRate).Totalcost.ToString();
            }
            else if (_rateToEdit is IncreaseRate)
            {
                typeComboBox.SelectedIndex = 1;
                costTextBox.Text = (_rateToEdit as IncreaseRate).CostPerMile.ToString();
            }
            else
            {
                throw new Exception("fatal error");
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (originComboBox.SelectedItem == null || destinationComboBox.SelectedItem == null)
            {
                MessageBox.Show("Not enough infomation");
                return;
            }

            if (costTextBox.Text.Count() == 0)
            {
                MessageBox.Show("You need fill cost field first");
                return;
            }

            string originShortName = originComboBox.SelectedItem.ToString();
            string destinationShortName = destinationComboBox.SelectedItem.ToString();
            string costString = costTextBox.Text;
            RateType rateType;
            Int32 rateCost;
            Enum.TryParse<RateType>(typeComboBox.SelectedItem.ToString(), out rateType);
            Int32.TryParse(costTextBox.Text, out rateCost);

            if (_originalOriginDestinationShortName != _originalOriginRegionShortName || _originalOriginDestinationShortName != destinationShortName)
            {
                if (_carrier.HasRate(originShortName, destinationShortName))
                {
                    MessageBox.Show("Each carrier can only have one rate per lane");
                    return;
                }
            }
            
            try
            {
                Rate newRate = null;
                switch (rateType)
                {
                    case RateType.Flat:
                        newRate = new FlatRate(originShortName, destinationShortName, rateCost);
                        break;
                    case RateType.Increase:
                        newRate = new IncreaseRate(originShortName, destinationShortName, rateCost);
                        break;
                }

                _carrier.RemoveRate(_rateToEdit);
                _carrier.AddRate(newRate);
                Carrier.Store.SaveToDisk();
                MessageBox.Show("Rate has been saved");
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }

    }
}
