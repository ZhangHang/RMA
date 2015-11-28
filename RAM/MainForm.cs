using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAM
{
    public partial class MainForm : Form
    {
        private Store<Carrier> CarrierStore = RAM.Carrier.store;
        private Store<Region> RegionStore = RAM.Region.store;

        public MainForm()
        {
            InitializeComponent();
            Load_DemoData();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Setup_CarrierList();
            Setup_RegionList();
            Reload_Carrier_Data();
            Reload_Region_Data();
        }

        private void Load_DemoData()
        {
            if (RegionStore.Items.Count == 0)
            {
                RegionStore.Items.Clear();
                CarrierStore.Items.Clear();
                RegionStore.SaveToDisk();
                CarrierStore.SaveToDisk();

                Carrier MasterCarrier = new Carrier { SCAC = "MAST", Name = "Master Carrier" };
                Carrier SlaveCarrier = new Carrier { SCAC = "SLAV", Name = "Slave Carrier" };

                Region OriginCityRegion = new RAM.Region { XAxis = 0, YAxis = 0, ShortName = "OC", Description = "Origin City" };
                Region DestinationCityRegion = new RAM.Region { XAxis = 13, YAxis = 13, ShortName = "DC", Description = "Destination City" };
                Region ChaosLandRegion = new RAM.Region { XAxis = 100, YAxis = 100, ShortName = "CL", Description = "Chaos Land" };
                Region VoidWorldRegion = new RAM.Region { XAxis = -100, YAxis = -100, ShortName = "VW", Description = "Void World" };

                FlatRate flatRateForMasterCarrier = new FlatRate(OriginCityRegion, DestinationCityRegion, 1000);
                UnflatRate unflatRateForMasterCarrier = new UnflatRate(DestinationCityRegion, ChaosLandRegion, 10);

                FlatRate flatRateForSlaveCarrier = new FlatRate(OriginCityRegion, DestinationCityRegion, 800);
                UnflatRate unflatRateForSlaveCarrier = new UnflatRate(DestinationCityRegion, ChaosLandRegion, 19);

                MasterCarrier.AddRate(flatRateForMasterCarrier);
                MasterCarrier.AddRate(unflatRateForMasterCarrier);
                SlaveCarrier.AddRate(flatRateForSlaveCarrier);
                SlaveCarrier.AddRate(unflatRateForMasterCarrier);

                MasterCarrier.Insert();
                SlaveCarrier.Insert();

                OriginCityRegion.Insert();
                DestinationCityRegion.Insert();
                ChaosLandRegion.Insert();
                VoidWorldRegion.Insert();

                CarrierStore.SaveToDisk();
                RegionStore.SaveToDisk();
            }
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
            CreateCarrierForm createForm = new CreateCarrierForm();
            createForm.FormClosed += CreateCarrierForm_FormClosed;
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
            Carrier itemToDelete = CarrierStore.Items.Where(x => x.SCAC == FocusedCarrierSCAC).First();
            CarrierStore.Items.Remove(itemToDelete);
            CarrierStore.SaveToDisk();
            Reload_Carrier_Data();
            MessageBox.Show("Carrier has been deleted");
        }

        private void editCarrier(object sender, EventArgs e)
        {
            EditCarrierForm editForm = new EditCarrierForm(FocusedCarrierSCAC);
            editForm.FormClosed += EditCarrierForm_FormClosed;
            editForm.ShowDialog();
        }

        private void CreateCarrierForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Reload_Carrier_Data();
        }

        private void CarrierListView_DoubleClick(object sender, EventArgs e)
        {
            if (carrierListView.SelectedItems.Count == 0) return;

            string carrierSCAC = carrierListView.SelectedItems[0].Text;
            MainRateForm rateForm = new MainRateForm(CarrierStore, carrierSCAC);
            rateForm.ShowDialog();
        }

        private void EditCarrierForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Reload_Carrier_Data();
        }

        private void Reload_Carrier_Data()
        {
            carrierListView.Items.Clear();

            foreach (Carrier item in CarrierStore.Items)
            {
                ListViewItem listViewItem = new ListViewItem(item.SCAC);
                listViewItem.SubItems.Add(item.Name);
                carrierListView.Items.Add(listViewItem);
            }
        }

        #endregion

        #region Region
        private MenuItem deleteRegionMenuItem;

        private void Setup_RegionList()
        {
            regionListView.ContextMenu = new ContextMenu();
            regionListView.ContextMenu.MenuItems.Add(new MenuItem("Create Region", createRegion));

            deleteRegionMenuItem = new MenuItem("Delete", deleteRegion);

            regionListView.MouseDown += RegionListView_MouseDown;
        }

        private void RegionListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            if (regionListView.FocusedItem.Bounds.Contains(e.Location))
            {
                regionListView.ContextMenu.MenuItems.Add(deleteRegionMenuItem);
            }
            else
            {
                regionListView.ContextMenu.MenuItems.Remove(deleteRegionMenuItem);
            }
        }

        private void createRegion(object sender, EventArgs e)
        {
            CreateRegionForm createForm = new CreateRegionForm();
            createForm.FormClosed += CreateRegionForm_FormClosed;
            createForm.ShowDialog();
        }

        private string FocusedRegionShortName
        {
            get
            {
                return regionListView.FocusedItem.Text;
            }
        }

        private void deleteRegion(object sender, EventArgs e)
        {
            Region itemToDelete = RegionStore.Items
                .Where(x => x.ShortName == FocusedRegionShortName).First();
            List<string> usedOriginRegionShortNames = Carrier.store.Items
                .SelectMany(x => x.Rates)
                .Select(x => x.OriginRegionShortName).Distinct().ToList();
            List<string> usedDestinationRegionShortNames = Carrier.store.Items
                .SelectMany(x => x.Rates)
                .Select(x => x.DestinationRegionShortName).Distinct().ToList();
            List<string> allUsedRegionShortNames = usedDestinationRegionShortNames
                .Union(usedOriginRegionShortNames)
                .Distinct()
                .ToList();

            if (allUsedRegionShortNames.Contains(itemToDelete.ShortName))
            {
                MessageBox.Show("Region is being used");
                return;
            }

            itemToDelete.Delete();
            RegionStore.SaveToDisk();
            Reload_Region_Data();

            MessageBox.Show("Region has been deleted");
        }

        private void CreateRegionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Reload_Region_Data();
        }

        private void RegionListView_DoubleClick(object sender, EventArgs e)
        {
            if (carrierListView.SelectedItems.Count == 0) return;

        }

        private void Reload_Region_Data()
        {
            regionListView.Items.Clear();

            foreach (Region item in RegionStore.Items)
            {
                ListViewItem listViewItem = new ListViewItem(item.ShortName);
                listViewItem.SubItems.Add(item.Description);
                listViewItem.SubItems.Add(item.XAxis.ToString());
                listViewItem.SubItems.Add(item.YAxis.ToString());
                regionListView.Items.Add(listViewItem);
            }
        }

        #endregion
    }
}
