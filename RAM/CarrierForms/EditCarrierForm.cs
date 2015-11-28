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
    public partial class EditCarrierForm : Form
    {
        private Store<Carrier> _carrierStore = Carrier.Store;
        private string _originalSCAC;
        private Carrier _carrier;

        private string _editedSCAC
        {
            get
            {
                return sCACTextBox.Text;
            }
        }

        private string _editedName
        {
            get
            {
                return nameTextBox.Text;
            }
        }

        public EditCarrierForm(string carrierSCAC)
        {
            InitializeComponent();
            _originalSCAC = carrierSCAC;
            _carrier = _carrierStore.Items.Where(x => x.SCAC == carrierSCAC).First();

            updateButton.Click += UpdateButton_Click;

            sCACTextBox.Text = _carrier.SCAC;
            nameTextBox.Text = _carrier.Name;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (_editedName == _carrier.Name && _editedSCAC == _carrier.SCAC)
            {
                MessageBox.Show("Nothing to update");
                return;
            }

            if (_editedSCAC != _originalSCAC)
            {
                if (_carrierStore.Items.Where(x => x.SCAC == _editedSCAC).Count() > 0)
                {
                    MessageBox.Show("Duplicated SCAC");
                    return;
                }
            }

            try
            {
                _carrier.Name = _editedName;
                _carrier.SCAC = _editedSCAC;
                _carrier.UpdateValidation();
                Carrier.Store.SaveToDisk();
                MessageBox.Show("Carrier has been updated");
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                Carrier.Store.ReadFromDisk();
            }
        }
    }
}
