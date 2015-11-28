namespace RAM
{
    partial class CreateRegionForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.shortNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.xAxisTextBox = new System.Windows.Forms.TextBox();
            this.yAxisTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Short Name";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.descriptionTextBox.Location = new System.Drawing.Point(156, 109);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 10, 100);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(301, 31);
            this.descriptionTextBox.TabIndex = 5;
            // 
            // shortNameTextBox
            // 
            this.shortNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.shortNameTextBox.Location = new System.Drawing.Point(155, 40);
            this.shortNameTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 10, 100);
            this.shortNameTextBox.MaxLength = 4;
            this.shortNameTextBox.Name = "shortNameTextBox";
            this.shortNameTextBox.Size = new System.Drawing.Size(301, 31);
            this.shortNameTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Y Axis";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "X Axis";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(237, 346);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(110, 54);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // xAxisTextBox
            // 
            this.xAxisTextBox.Location = new System.Drawing.Point(155, 191);
            this.xAxisTextBox.Name = "xAxisTextBox";
            this.xAxisTextBox.Size = new System.Drawing.Size(301, 31);
            this.xAxisTextBox.TabIndex = 15;
            // 
            // yAxisTextBox
            // 
            this.yAxisTextBox.Location = new System.Drawing.Point(156, 260);
            this.yAxisTextBox.Name = "yAxisTextBox";
            this.yAxisTextBox.Size = new System.Drawing.Size(301, 31);
            this.yAxisTextBox.TabIndex = 16;
            // 
            // CreateRegionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 595);
            this.Controls.Add(this.yAxisTextBox);
            this.Controls.Add(this.xAxisTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.shortNameTextBox);
            this.Name = "CreateRegionForm";
            this.Text = "CreateRegionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox shortNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox xAxisTextBox;
        private System.Windows.Forms.TextBox yAxisTextBox;
    }
}