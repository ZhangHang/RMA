using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RMA.Model;

namespace RMA
{
    public partial class MainForm : Form
    {
        private Store<Carrier> _carrierStore = Carrier.Store;
        private Store<Region> _regionStore = RMA.Model.Region.Store;

        public MainForm()
        {
            InitializeComponent();
            tabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Reload_CarrierData();
            Reload_RegionData();
            Reload_RateData();
        }

        #region Menu
        private void ActionToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if(sender == regionActionToolStripMenuItem)
            {
                bool hasSelectedItem = regionListView.SelectedItems.Count > 0;
                deleteSelectedRegionToolStripMenuItem.Enabled = hasSelectedItem;
            }
            else if(sender == carrierActionToolStripMenuItem)
            {
                bool hasSelectedItem = carrierListView.SelectedItems.Count > 0;

                editSelectedCarrierToolStripMenuItem.Enabled = hasSelectedItem;
                deleteSelectedCarrierToolStripMenuItem.Enabled = hasSelectedItem;
                viewRatesForSelectedCarrierToolStripMenuItem.Enabled = hasSelectedItem;
            }
        }
        #endregion

        #region TabControl
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reload_CarrierData();
            Reload_RegionData();
            Reload_RateData();
        }
        #endregion

        #region Carrier
        private void Create_Carrier(object sender, EventArgs e)
        {
            CreateCarrierForm createForm = new CreateCarrierForm();
            createForm.FormClosed += CreateCarrierForm_FormClosed;
            createForm.ShowDialog();
        }

        private string _selectedCarrierSCAC
        {
            get
            {
                return carrierListView.SelectedItems[0].Text;
            }
        }

        private void Delete_Carrier(object sender, EventArgs e)
        {
            Carrier itemToDelete = _carrierStore.Items.Where(x => x.SCAC == _selectedCarrierSCAC).First();
            _carrierStore.Items.Remove(itemToDelete);
            _carrierStore.SaveToDisk();
            Reload_CarrierData();
            MessageBox.Show("Carrier has been deleted");
        }

        private void Edit_Carrier(object sender, EventArgs e)
        {
            EditCarrierForm editForm = new EditCarrierForm(_selectedCarrierSCAC);
            editForm.FormClosed += EditCarrierForm_FormClosed;
            editForm.ShowDialog();
        }

        private void CreateCarrierForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Reload_CarrierData();
        }
        
        private void View_Rate_in_Selected_Carrier(object sender, EventArgs e)
        {
            MainRateForm rateForm = new MainRateForm(_selectedCarrierSCAC);
            rateForm.ShowDialog();
        }

        private void EditCarrierForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Reload_CarrierData();
        }

        private void Reload_CarrierData()
        {
            carrierListView.Items.Clear();

            foreach (Carrier item in _carrierStore.Items)
            {
                ListViewItem listViewItem = new ListViewItem(item.SCAC);
                listViewItem.SubItems.Add(item.Name);
                carrierListView.Items.Add(listViewItem);
            }
        }

        #endregion

        #region Region
        private void Create_Region(object sender, EventArgs e)
        {
            CreateRegionForm createForm = new CreateRegionForm();
            createForm.FormClosed += CreateRegionForm_FormClosed;
            createForm.ShowDialog();
        }

        private string _selectedRegionShortName
        {
            get
            {
                return regionListView.SelectedItems[0].Text;
            }
        }

        private void Delete_Region(object sender, EventArgs e)
        {
            Region itemToDelete = _regionStore.Items
                .Where(x => x.ShortName == _selectedRegionShortName).First();
            List<string> usedOriginRegionShortNames = Carrier.Store.Items
                .SelectMany(x => x.Rates)
                .Select(x => x.OriginRegionShortName).Distinct().ToList();
            List<string> usedDestinationRegionShortNames = Carrier.Store.Items
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
            _regionStore.SaveToDisk();
            Reload_RegionData();

            MessageBox.Show("Region has been deleted");
        }

        private void CreateRegionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Reload_RegionData();
        }
        
        private void Reload_RegionData()
        {
            regionListView.Items.Clear();

            foreach (Region item in _regionStore.Items)
            {
                ListViewItem listViewItem = new ListViewItem(item.ShortName);
                listViewItem.SubItems.Add(item.Description);
                listViewItem.SubItems.Add(item.XAxis.ToString());
                listViewItem.SubItems.Add(item.YAxis.ToString());
                regionListView.Items.Add(listViewItem);
            }
        }

        #endregion

        #region Rate
        
        private void Reload_RateData()
        {
            rateListView.Items.Clear();

            foreach (Carrier carrier in _carrierStore.Items)
            {
                foreach (Rate item in carrier.Rates)
                {
                    ListViewItem listViewItem = new ListViewItem(carrier.SCAC);
                    listViewItem.SubItems.Add(item.OriginRegionShortName);
                    listViewItem.SubItems.Add(item.DestinationRegionShortName);
                    listViewItem.SubItems.Add(item.Description);
                    rateListView.Items.Add(listViewItem);
                }
            }
        }
        #endregion

        #region Setting
        private void demoDataButton_Click(object sender, EventArgs e)
        {
            _regionStore.Erase();
            _carrierStore.Erase();

            Carrier MasterCarrier = new Carrier { SCAC = "MAST", Name = "Master Carrier" };
            Carrier SlaveCarrier = new Carrier { SCAC = "SLAV", Name = "Slave Carrier" };

            Region OriginCityRegion = new RMA.Model.Region { XAxis = 0, YAxis = 0, ShortName = "OC", Description = "Origin City" };
            Region DestinationCityRegion = new RMA.Model.Region { XAxis = 13, YAxis = 13, ShortName = "DC", Description = "Destination City" };
            Region ChaosLandRegion = new RMA.Model.Region { XAxis = 100, YAxis = 100, ShortName = "CL", Description = "Chaos Land" };
            Region VoidWorldRegion = new RMA.Model.Region { XAxis = -100, YAxis = -100, ShortName = "VW", Description = "Void World" };

            FlatRate flatRateForMasterCarrier = new FlatRate(OriginCityRegion, DestinationCityRegion, 1000);
            IncreaseRate increaseRateForMasterCarrier = new IncreaseRate(DestinationCityRegion, ChaosLandRegion, 10);

            FlatRate flatRateForSlaveCarrier = new FlatRate(OriginCityRegion, DestinationCityRegion, 800);
            IncreaseRate increaseRateForSlaveCarrier = new IncreaseRate(DestinationCityRegion, ChaosLandRegion, 9);

            MasterCarrier.AddRate(flatRateForMasterCarrier);
            MasterCarrier.AddRate(increaseRateForMasterCarrier);
            SlaveCarrier.AddRate(flatRateForSlaveCarrier);
            SlaveCarrier.AddRate(increaseRateForMasterCarrier);

            MasterCarrier.Insert();
            SlaveCarrier.Insert();

            OriginCityRegion.Insert();
            DestinationCityRegion.Insert();
            ChaosLandRegion.Insert();
            VoidWorldRegion.Insert();

            _carrierStore.SaveToDisk();
            _regionStore.SaveToDisk();

            MessageBox.Show("load demo data task complete");
        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            _regionStore.Erase();
            _carrierStore.Erase();

            MessageBox.Show("erase all data task complete");
        }
        #endregion
    }
}
