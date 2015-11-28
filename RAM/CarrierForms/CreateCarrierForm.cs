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
    public partial class CreateCarrierForm : Form
    {
        private Store<Carrier> _carrierStore = Carrier.Store;

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

        public CreateCarrierForm()
        {
            InitializeComponent();

            saveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Carrier newCarrier = new Carrier { SCAC = _editedSCAC, Name = _editedName };
                newCarrier.Insert();
                _carrierStore.SaveToDisk();
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
