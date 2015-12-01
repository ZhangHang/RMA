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
    public partial class MainRateForm : Form
    {
        private Store<Carrier> _carrierStore = Carrier.Store;
        private Carrier _carrier;

        public MainRateForm(string carrierSCAC)
        {
            InitializeComponent();
            _carrier = _carrierStore.Items.Where(x => x.SCAC == carrierSCAC).First();
            Reload_RateData();
        }

        private void ActionToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            bool hasSelectedItem = rateListView.SelectedItems.Count > 0;
            editSelectedRateToolStripMenuItem.Enabled = hasSelectedItem;
            deleteSelectedRateToolStripMenuItem.Enabled = hasSelectedItem;
        }
        
        private Rate SelectedRate
        {
            get
            {
                string destinationRegionShortName = rateListView.SelectedItems[0].SubItems[1].Text;
                string originRegionShortName = rateListView.FocusedItem.Text;
                return _carrier.Rates.Where(x => 
                        x.OriginRegionShortName == originRegionShortName 
                        && x.DestinationRegionShortName == destinationRegionShortName).First();
            }
        }

        private void CreateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Reload_RateData();
        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Reload_RateData();
        }

        private void Reload_RateData()
        {
            rateListView.Items.Clear();

            foreach (Rate item in _carrier.Rates)
            {
                ListViewItem listViewItem = new ListViewItem(item.OriginRegionShortName);
                listViewItem.SubItems.Add(item.DestinationRegionShortName);
                listViewItem.SubItems.Add(item.Description);
                rateListView.Items.Add(listViewItem);
            }
        }

        private void createRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateRateForm createForm = new CreateRateForm(_carrier);
            createForm.FormClosed += CreateForm_FormClosed;
            createForm.ShowDialog();
        }

        private void editSelectedRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditRateForm editForm = new EditRateForm(_carrier, SelectedRate);
            editForm.FormClosed += EditForm_FormClosed;
            editForm.ShowDialog();
        }

        private void deleteSelectedRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _carrier.RemoveRate(SelectedRate);
                _carrierStore.SaveToDisk();
                Reload_RateData();
                MessageBox.Show("Carrier has been deleted");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
