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

        #region CarrierListView
        private void Setup_CarrierList()
        {
            carrierListView.DoubleClick += CarrierListView_DoubleClick;
            Load_Demo_Data();
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
    }
}
