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
            this.carrierPage = new System.Windows.Forms.TabPage();
            this.carrierListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.regionPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.regionListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.settingTabPage = new System.Windows.Forms.TabPage();
            this.eraseButton = new System.Windows.Forms.Button();
            this.demoDataButton = new System.Windows.Forms.Button();
            this.ratePage = new System.Windows.Forms.TabPage();
            this.rateListView = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl.SuspendLayout();
            this.carrierPage.SuspendLayout();
            this.regionPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.settingTabPage.SuspendLayout();
            this.ratePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.carrierPage);
            this.tabControl.Controls.Add(this.regionPage);
            this.tabControl.Controls.Add(this.ratePage);
            this.tabControl.Controls.Add(this.settingTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1160, 716);
            this.tabControl.TabIndex = 0;
            // 
            // carrierPage
            // 
            this.carrierPage.Controls.Add(this.carrierListView);
            this.carrierPage.Location = new System.Drawing.Point(8, 39);
            this.carrierPage.Name = "carrierPage";
            this.carrierPage.Padding = new System.Windows.Forms.Padding(3);
            this.carrierPage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.carrierPage.Size = new System.Drawing.Size(1144, 669);
            this.carrierPage.TabIndex = 0;
            this.carrierPage.Text = "Carrier";
            this.carrierPage.UseVisualStyleBackColor = true;
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
            // regionPage
            // 
            this.regionPage.Controls.Add(this.panel1);
            this.regionPage.Location = new System.Drawing.Point(8, 39);
            this.regionPage.Name = "regionPage";
            this.regionPage.Padding = new System.Windows.Forms.Padding(3);
            this.regionPage.Size = new System.Drawing.Size(1144, 669);
            this.regionPage.TabIndex = 1;
            this.regionPage.Text = "Region";
            this.regionPage.UseVisualStyleBackColor = true;
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
            this.columnHeader4.Width = 221;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "XAxis";
            this.columnHeader5.Width = 85;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "YAxis";
            this.columnHeader6.Width = 86;
            // 
            // settingTabPage
            // 
            this.settingTabPage.Controls.Add(this.eraseButton);
            this.settingTabPage.Controls.Add(this.demoDataButton);
            this.settingTabPage.Location = new System.Drawing.Point(8, 39);
            this.settingTabPage.Name = "settingTabPage";
            this.settingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingTabPage.Size = new System.Drawing.Size(1144, 669);
            this.settingTabPage.TabIndex = 2;
            this.settingTabPage.Text = "Setting";
            this.settingTabPage.UseVisualStyleBackColor = true;
            // 
            // eraseButton
            // 
            this.eraseButton.Location = new System.Drawing.Point(37, 147);
            this.eraseButton.Name = "eraseButton";
            this.eraseButton.Size = new System.Drawing.Size(206, 52);
            this.eraseButton.TabIndex = 1;
            this.eraseButton.Text = "Erase All Data";
            this.eraseButton.UseVisualStyleBackColor = true;
            this.eraseButton.Click += new System.EventHandler(this.eraseButton_Click);
            // 
            // demoDataButton
            // 
            this.demoDataButton.Location = new System.Drawing.Point(37, 52);
            this.demoDataButton.Name = "demoDataButton";
            this.demoDataButton.Size = new System.Drawing.Size(206, 52);
            this.demoDataButton.TabIndex = 0;
            this.demoDataButton.Text = "Load Demo Data";
            this.demoDataButton.UseVisualStyleBackColor = true;
            this.demoDataButton.Click += new System.EventHandler(this.demoDataButton_Click);
            // 
            // ratePage
            // 
            this.ratePage.Controls.Add(this.rateListView);
            this.ratePage.Location = new System.Drawing.Point(8, 39);
            this.ratePage.Name = "ratePage";
            this.ratePage.Padding = new System.Windows.Forms.Padding(3);
            this.ratePage.Size = new System.Drawing.Size(1144, 669);
            this.ratePage.TabIndex = 3;
            this.ratePage.Text = "Rate (View Only)";
            this.ratePage.UseVisualStyleBackColor = true;
            // 
            // rateListView
            // 
            this.rateListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.rateListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rateListView.FullRowSelect = true;
            this.rateListView.GridLines = true;
            this.rateListView.Location = new System.Drawing.Point(3, 3);
            this.rateListView.Name = "rateListView";
            this.rateListView.Size = new System.Drawing.Size(1138, 663);
            this.rateListView.TabIndex = 0;
            this.rateListView.UseCompatibleStateImageBehavior = false;
            this.rateListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Owner Carrier";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Origin Region";
            this.columnHeader8.Width = 150;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Destination Region";
            this.columnHeader9.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Description";
            this.columnHeader10.Width = 142;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 716);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Rate Management";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.carrierPage.ResumeLayout(false);
            this.regionPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.settingTabPage.ResumeLayout(false);
            this.ratePage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage carrierPage;
        private System.Windows.Forms.TabPage regionPage;
        private System.Windows.Forms.ListView carrierListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView regionListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TabPage settingTabPage;
        private System.Windows.Forms.Button eraseButton;
        private System.Windows.Forms.Button demoDataButton;
        private System.Windows.Forms.TabPage ratePage;
        private System.Windows.Forms.ListView rateListView;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}

