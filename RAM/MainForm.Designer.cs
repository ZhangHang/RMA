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
            this.panel1 = new System.Windows.Forms.Panel();
            this.regionListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl.SuspendLayout();
            this.CarrierPage.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1144, 669);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Region";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.regionListView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1138, 663);
            this.panel1.TabIndex = 0;
            // 
            // regionListView
            // 
            this.regionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.regionListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regionListView.FullRowSelect = true;
            this.regionListView.GridLines = true;
            this.regionListView.Location = new System.Drawing.Point(0, 0);
            this.regionListView.Name = "regionListView";
            this.regionListView.Size = new System.Drawing.Size(1138, 663);
            this.regionListView.TabIndex = 0;
            this.regionListView.UseCompatibleStateImageBehavior = false;
            this.regionListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ShortName";
            this.columnHeader3.Width = 159;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Description";
            this.columnHeader4.Width = 345;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "XAxis";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "YAxis";
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
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage CarrierPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView carrierListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView regionListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

