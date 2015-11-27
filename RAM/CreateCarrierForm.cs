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
    public partial class CreateCarrierForm : Form
    {
        private Store<Carrier> CarrierStore;

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

        public CreateCarrierForm(Store<Carrier> carrierStore)
        {
            InitializeComponent();
            CarrierStore = carrierStore;

            saveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            if (editedName.Length == 0 || editedName.Length == 0)
            {
                MessageBox.Show("Name & SCAC can't be empty");
                return;
            }

            if (CarrierStore.Collection.Where(x => x.SCAC == editedSCAC).Count() > 0)
            {
                MessageBox.Show("Duplicated SCAC");
                return;
            }

            if (editedSCAC.Length != 4)
            {
                MessageBox.Show("SCAC has to be 4 character long");
                return;
            }

            Carrier newCarrier = new Carrier { SCAC = editedSCAC, Name = editedName };
            CarrierStore.Collection.Add(newCarrier);
            CarrierStore.SaveToDisk();

            MessageBox.Show("Carrier has been saved");

            this.Close();
        }
    }
}
