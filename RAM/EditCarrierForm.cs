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
    public partial class EditCarrierForm : Form
    {
        private Store<Carrier> CarrierStore;
        private Carrier carrier;

        private string editedSCAC
        {
            get
            {
                return sCACTextBox.Text;
            }
        }

        private string editedName
        {
            get
            {
                return nameTextBox.Text;
            }
        }

        public EditCarrierForm(Store<Carrier> carrierStore, string carrierSCAC)
        {
            InitializeComponent();
            CarrierStore = carrierStore;
            carrier = carrierStore.Collection.Where(x=> x.SCAC == carrierSCAC).First();
            
            updateButton.Click += UpdateButton_Click;

            sCACTextBox.Text = carrier.SCAC;
            nameTextBox.Text = carrier.Name;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if(editedName == carrier.Name && editedSCAC == carrier.SCAC)
            {
                MessageBox.Show("Nothing to update");
                return;
            }

            if(editedName.Length == 0 || editedName.Length == 0)
            {
                MessageBox.Show("Name & SCAC can't be empty");
                return;
            }

            if(editedSCAC != carrier.SCAC)
            {
                if (CarrierStore.Collection.Where(x => x.SCAC == editedSCAC).Count() > 0)
                {
                    MessageBox.Show("Duplicated SCAC");
                    return;
                }
            }

            if(editedSCAC.Length != 4)
            {
                MessageBox.Show("SCAC has to be 4 character long");
                return;
            }

            carrier.Name = editedName;
            carrier.SCAC = editedSCAC;
            CarrierStore.SaveToDisk();

            MessageBox.Show("Carrier has been updated");
            this.Close();
        }
    }
}
