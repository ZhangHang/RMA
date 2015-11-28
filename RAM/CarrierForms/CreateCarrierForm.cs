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
        private Store<Carrier> CarrierStore = Carrier.store;

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

        public CreateCarrierForm()
        {
            InitializeComponent();

            saveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Carrier newCarrier = new Carrier { SCAC = editedSCAC, Name = editedName };
                newCarrier.Insert();
                CarrierStore.SaveToDisk();
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
