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
        private Store<Carrier> CarrierStore = Carrier.store;
        private string originalSCAC;
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

        public EditCarrierForm(string carrierSCAC)
        {
            InitializeComponent();
            originalSCAC = carrierSCAC;
            carrier = CarrierStore.Items.Where(x => x.SCAC == carrierSCAC).First();

            updateButton.Click += UpdateButton_Click;

            sCACTextBox.Text = carrier.SCAC;
            nameTextBox.Text = carrier.Name;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (editedName == carrier.Name && editedSCAC == carrier.SCAC)
            {
                MessageBox.Show("Nothing to update");
                return;
            }

            if (editedSCAC != originalSCAC)
            {
                if (CarrierStore.Items.Where(x => x.SCAC == editedSCAC).Count() > 0)
                {
                    MessageBox.Show("Duplicated SCAC");
                    return;
                }
            }

            try
            {
                carrier.Name = editedName;
                carrier.SCAC = editedSCAC;
                carrier.UpdateValidation();
                Carrier.store.SaveToDisk();
                MessageBox.Show("Carrier has been updated");
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                Carrier.store.readFromDisk();
            }
        }
    }
}
