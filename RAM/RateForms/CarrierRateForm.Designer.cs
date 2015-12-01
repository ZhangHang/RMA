namespace RMA
{
    partial class MainRateForm
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
            this.components = new System.ComponentModel.Container();
            this.rateListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectedRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rateListView
            // 
            this.rateListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.rateListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rateListView.FullRowSelect = true;
            this.rateListView.GridLines = true;
            this.rateListView.Location = new System.Drawing.Point(0, 0);
            this.rateListView.Name = "rateListView";
            this.rateListView.Size = new System.Drawing.Size(809, 557);
            this.rateListView.TabIndex = 0;
            this.rateListView.UseCompatibleStateImageBehavior = false;
            this.rateListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Origin";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Destination";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Cost";
            this.columnHeader3.Width = 476;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(86, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(809, 42);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createRateToolStripMenuItem,
            this.editSelectedRateToolStripMenuItem,
            this.deleteSelectedRateToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(64, 38);
            this.actionToolStripMenuItem.Text = "Action";
            this.actionToolStripMenuItem.DropDownOpening += ActionToolStripMenuItem_DropDownOpening;
            // 
            // createRateToolStripMenuItem
            // 
            this.createRateToolStripMenuItem.Name = "createRateToolStripMenuItem";
            this.createRateToolStripMenuItem.Size = new System.Drawing.Size(337, 38);
            this.createRateToolStripMenuItem.Text = "Create Rate";
            this.createRateToolStripMenuItem.Click += createRateToolStripMenuItem_Click;
            // 
            // editSelectedRateToolStripMenuItem
            // 
            this.editSelectedRateToolStripMenuItem.Name = "editSelectedRateToolStripMenuItem";
            this.editSelectedRateToolStripMenuItem.Size = new System.Drawing.Size(337, 38);
            this.editSelectedRateToolStripMenuItem.Text = "Edit Selected Rate";
            this.editSelectedRateToolStripMenuItem.Click += editSelectedRateToolStripMenuItem_Click;
            // 
            // deleteSelectedRateToolStripMenuItem
            // 
            this.deleteSelectedRateToolStripMenuItem.Name = "deleteSelectedRateToolStripMenuItem";
            this.deleteSelectedRateToolStripMenuItem.Size = new System.Drawing.Size(337, 38);
            this.deleteSelectedRateToolStripMenuItem.Text = "Delete Selected Rate";
            this.deleteSelectedRateToolStripMenuItem.Click += deleteSelectedRateToolStripMenuItem_Click;
            // 
            // MainRateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 557);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.rateListView);
            this.Name = "MainRateForm";
            this.Text = "Rates for Current Carrier";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView rateListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSelectedRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedRateToolStripMenuItem;
    }
}