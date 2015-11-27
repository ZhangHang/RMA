namespace RAM
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.CarrierPage = new System.Windows.Forms.TabPage();
            this.carrierListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.CarrierPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.CarrierPage);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1160, 716);
            this.tabControl.TabIndex = 0;
            // 
            // CarrierPage
            // 
            this.CarrierPage.Controls.Add(this.carrierListView);
            this.CarrierPage.Location = new System.Drawing.Point(8, 39);
            this.CarrierPage.Name = "CarrierPage";
            this.CarrierPage.Padding = new System.Windows.Forms.Padding(3);
            this.CarrierPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CarrierPage.Size = new System.Drawing.Size(1144, 669);
            this.CarrierPage.TabIndex = 0;
            this.CarrierPage.Text = "Carrier";
            this.CarrierPage.UseVisualStyleBackColor = true;
            // 
            // carrierListView
            // 
            this.carrierListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.carrierListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.carrierListView.FullRowSelect = true;
            this.carrierListView.GridLines = true;
            this.carrierListView.Location = new System.Drawing.Point(3, 3);
            this.carrierListView.Name = "carrierListView";
            this.carrierListView.Size = new System.Drawing.Size(1138, 663);
            this.carrierListView.TabIndex = 0;
            this.carrierListView.UseCompatibleStateImageBehavior = false;
            this.carrierListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "SCAC";
            this.columnHeader1.Width = 103;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 450;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1144, 669);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 716);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.CarrierPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage CarrierPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView carrierListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

