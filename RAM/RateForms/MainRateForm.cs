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
    public partial class MainRateForm : Form
    {
        private Store<Carrier> _carrierStore = Carrier.Store;
        private Carrier _carrier;

        public MainRateForm(string carrierSCAC)
        {
            InitializeComponent();
            _carrier = _carrierStore.Items.Where(x => x.SCAC == carrierSCAC).First();
            Setup_RateList();
            Reload_RateData();
        }

        #region Rage
        private MenuItem _editMenuItem;
        private MenuItem _deleteMenuItem;

        private void Setup_RateList()
        {
            rateListView.ContextMenu = new ContextMenu();
            rateListView.ContextMenu.MenuItems.Add(new MenuItem("Create Rate", Create_Rate));

            _editMenuItem = new MenuItem("Edit", Edit_Rate);
            _deleteMenuItem = new MenuItem("Delete", Delete_Rate);

            rateListView.MouseDown += RarrierListView_MouseDown;
        }

        private void RarrierListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            if (rateListView.FocusedItem != null && 
                rateListView.FocusedItem.Bounds.Contains(e.Location))
            {
                rateListView.ContextMenu.MenuItems.Add(_editMenuItem);
                rateListView.ContextMenu.MenuItems.Add(_deleteMenuItem);
            }
            else
            {
                rateListView.ContextMenu.MenuItems.Remove(_editMenuItem);
                rateListView.ContextMenu.MenuItems.Remove(_deleteMenuItem);
            }
        }

        private void Create_Rate(object sender, EventArgs e)
        {
            CreateRateForm createForm = new CreateRateForm(_carrier);
            createForm.FormClosed += CreateForm_FormClosed;
            createForm.ShowDialog();
        }

        private Rate FocusedRate
        {
            get
            {
                string destinationRegionShortName = rateListView.FocusedItem.SubItems[1].Text;
                string originRegionShortName = rateListView.FocusedItem.Text;
                return _carrier.Rates.Where(x => 
                        x.OriginRegionShortName == originRegionShortName 
                        && x.DestinationRegionShortName == destinationRegionShortName).First();
            }
        }

        private void Delete_Rate(object sender, EventArgs e)
        {
            try
            {
                _carrier.RemoveRate(FocusedRate);
                _carrierStore.SaveToDisk();
                Reload_RateData();
                MessageBox.Show("Carrier has been deleted");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);

            }
        }

        private void Edit_Rate(object sender, EventArgs e)
        {
           EditRateForm editForm = new EditRateForm(_carrier,FocusedRate);
           editForm.FormClosed += EditForm_FormClosed;
           editForm.ShowDialog();
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

        #endregion

    }
}
