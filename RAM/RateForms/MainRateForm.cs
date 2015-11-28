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
    public partial class MainRateForm : Form
    {
        private Store<Carrier> CarrierStore;
        private Carrier carrier;

        public MainRateForm(Store<Carrier> carrierStore, string carrierSCAC)
        {
            InitializeComponent();
            CarrierStore = carrierStore;
            carrier = carrierStore.Items.Where(x => x.SCAC == carrierSCAC).First();
            Setup_RateList();
            Reload_Rate_Data();
        }

        #region Rage
        private MenuItem editMenuItem;
        private MenuItem deleteMenuItem;

        private void Setup_RateList()
        {
            rateListView.ContextMenu = new ContextMenu();
            rateListView.ContextMenu.MenuItems.Add(new MenuItem("Create Rate", createRate));

            editMenuItem = new MenuItem("Edit", editRate);
            deleteMenuItem = new MenuItem("Delete", deleteRate);

            rateListView.MouseDown += RarrierListView_MouseDown;
        }

        private void RarrierListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            if (rateListView.FocusedItem.Bounds.Contains(e.Location))
            {
                rateListView.ContextMenu.MenuItems.Add(editMenuItem);
                rateListView.ContextMenu.MenuItems.Add(deleteMenuItem);
            }
            else
            {
                rateListView.ContextMenu.MenuItems.Remove(editMenuItem);
                rateListView.ContextMenu.MenuItems.Remove(deleteMenuItem);
            }
        }

        private void createRate(object sender, EventArgs e)
        {
            CreateRateForm createForm = new CreateRateForm(carrier);
            createForm.FormClosed += CreateForm_FormClosed;
            createForm.ShowDialog();
        }

        private Rate FocusedRate
        {
            get
            {
                string FocusedRateDestinationShortName = rateListView.FocusedItem.SubItems[1].Text;
                string FocusedRateOriginShortName = rateListView.FocusedItem.Text;
                return carrier.Rates.Where(x => 
                        x.OriginRegionShortName == FocusedRateOriginShortName 
                        && x.DestinationRegionShortName == FocusedRateDestinationShortName).First();
            }
        }

        private void deleteRate(object sender, EventArgs e)
        {
            try
            {
                carrier.RemoveRate(FocusedRate);
                CarrierStore.SaveToDisk();
                Reload_Rate_Data();
                MessageBox.Show("Carrier has been deleted");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);

            }
        }

        private void editRate(object sender, EventArgs e)
        {
           EditRateForm editForm = new EditRateForm(carrier,FocusedRate);
           editForm.FormClosed += EditForm_FormClosed;
           editForm.ShowDialog();
        }

        private void CreateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Reload_Rate_Data();
        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Reload_Rate_Data();
        }

        private void Reload_Rate_Data()
        {
            rateListView.Items.Clear();

            foreach (Rate item in carrier.Rates)
            {
                ListViewItem listViewItem = new ListViewItem(item.OriginRegionShortName);
                listViewItem.SubItems.Add(item.DestinationRegionShortName);
                listViewItem.SubItems.Add(item.Description);
                rateListView.Items.Add(listViewItem);
            }
        }

        #endregion

    }
}
