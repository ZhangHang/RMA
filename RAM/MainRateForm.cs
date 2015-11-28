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
        }

        #region Carrier
        private MenuItem editMenuItem;
        private MenuItem deleteMenuItem;

        private void Setup_CarrierList()
        {
            rateListView.ContextMenu = new ContextMenu();
            rateListView.ContextMenu.MenuItems.Add(new MenuItem("Create Rate", createRate));

            editMenuItem = new MenuItem("Edit", editRate);
            deleteMenuItem = new MenuItem("Delete", deleteRate);

            rateListView.MouseDown += RarrierListView_MouseDown;
            Load_Demo_Data();
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
            CreateCarrierForm createForm = new CreateCarrierForm();
            createForm.FormClosed += CreateForm_FormClosed;
            createForm.ShowDialog();
        }

        private string FocusedCarrierSCAC
        {
            get
            {
                return rateListView.FocusedItem.Text;
            }
        }

        private void deleteRate(object sender, EventArgs e)
        {
            Carrier itemToDelete = CarrierStore.Items.Where(x => x.SCAC == FocusedCarrierSCAC).First();
            CarrierStore.Items.Remove(itemToDelete);
            CarrierStore.SaveToDisk();
            Reload_Rate_Data();
            MessageBox.Show("Carrier has been deleted");
        }

        private void editRate(object sender, EventArgs e)
        {
            EditCarrierForm editForm = new EditCarrierForm(FocusedCarrierSCAC);
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

        private void Load_Demo_Data()
        {
            if (CarrierStore.Items.Count == 0)
            {
                CarrierStore.Items.Add(new Carrier { SCAC = "SC_1", Name = "Beijing" });
                CarrierStore.Items.Add(new Carrier { SCAC = "SC_2", Name = "ShangHai" });
                CarrierStore.SaveToDisk();
            }
        }

        private void Reload_Rate_Data()
        {
            rateListView.Items.Clear();

            foreach (Carrier item in CarrierStore.Items)
            {
                ListViewItem listViewItem = new ListViewItem(item.SCAC);
                listViewItem.SubItems.Add(item.Name);
                rateListView.Items.Add(listViewItem);
            }
        }

        #endregion

    }
}
