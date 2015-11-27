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
    public partial class MainForm : Form
    {
        private Store<Carrier> CarrierStore = new Store<Carrier>("MainStore");

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Setup_CarrierList();
            Reload_Carrier_Data();
        }

        #region Carrier
        private MenuItem editCarrierMenuItem;
        private MenuItem deleteCarrierMenuItem;

        private void Setup_CarrierList()
        {
            carrierListView.DoubleClick += CarrierListView_DoubleClick;

            carrierListView.ContextMenu = new ContextMenu();
            carrierListView.ContextMenu.MenuItems.Add(new MenuItem("Create Carrier", createCarrier));

            editCarrierMenuItem = new MenuItem("Edit", editCarrier);
            deleteCarrierMenuItem = new MenuItem("Delete", deleteCarrier);

            carrierListView.MouseDown += CarrierListView_MouseDown;
            Load_Demo_Data();
        }

        private void CarrierListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            if (carrierListView.FocusedItem.Bounds.Contains(e.Location))
            {
                carrierListView.ContextMenu.MenuItems.Add(editCarrierMenuItem);
                carrierListView.ContextMenu.MenuItems.Add(deleteCarrierMenuItem);
            }
            else
            {
                carrierListView.ContextMenu.MenuItems.Remove(editCarrierMenuItem);
                carrierListView.ContextMenu.MenuItems.Remove(deleteCarrierMenuItem);
            }
        }

        private void createCarrier(object sender, EventArgs e)
        {
            CreateCarrierForm createForm = new CreateCarrierForm(CarrierStore);
            createForm.FormClosed += CreateForm_FormClosed;
            createForm.ShowDialog();
        }

        private string FocusedCarrierSCAC
        {
            get
            {
                return carrierListView.FocusedItem.Text;
            }
        }

        private void deleteCarrier(object sender, EventArgs e)
        {
            Carrier itemToDelete = CarrierStore.Collection.Where(x => x.SCAC == FocusedCarrierSCAC).First();
            CarrierStore.Collection.Remove(itemToDelete);
            CarrierStore.SaveToDisk();
            Reload_Carrier_Data();
            MessageBox.Show("Carrier has been deleted");
        }

        private void editCarrier(object sender, EventArgs e)
        {
            EditCarrierForm editForm = new EditCarrierForm(CarrierStore, FocusedCarrierSCAC);
            editForm.FormClosed += EditForm_FormClosed;
            editForm.ShowDialog();
        }

        private void CreateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Reload_Carrier_Data();
        }

        private void CarrierListView_DoubleClick(object sender, EventArgs e)
        {
            if (carrierListView.SelectedItems.Count == 0) return;

            string carrierSCAC = carrierListView.SelectedItems[0].Text;
            EditCarrierForm editForm = new EditCarrierForm(CarrierStore, carrierSCAC);
            editForm.FormClosed += EditForm_FormClosed;
            editForm.ShowDialog();
        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Reload_Carrier_Data();
        }

        private void Load_Demo_Data()
        {
            if (CarrierStore.Collection.Count == 0)
            {
                CarrierStore.Collection.Add(new Carrier { SCAC = "SC_1", Name = "Beijing" });
                CarrierStore.Collection.Add(new Carrier { SCAC = "SC_2", Name = "ShangHai" });
                CarrierStore.SaveToDisk();
            }
        }

        private void Reload_Carrier_Data()
        {
            carrierListView.Items.Clear();

            foreach (Carrier item in CarrierStore.Collection)
            {
                ListViewItem listViewItem = new ListViewItem(item.SCAC);
                listViewItem.SubItems.Add(item.Name);
                carrierListView.Items.Add(listViewItem);
            }
        }

        #endregion

        #region Region

        #endregion
    }
}
