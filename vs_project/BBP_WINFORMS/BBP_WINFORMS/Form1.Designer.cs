namespace BBP_WINFORMS
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelCurrentDir = new System.Windows.Forms.Label();
            this.buttonSelectScanDirectory = new System.Windows.Forms.Button();
            this.checkBoxRecursiveScan = new System.Windows.Forms.CheckBox();
            this.buttonScan = new System.Windows.Forms.Button();
            this.listViewImages = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.51155F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.48846F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listViewImages, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.77778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(563, 381);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelCurrentDir);
            this.flowLayoutPanel1.Controls.Add(this.buttonSelectScanDirectory);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxRecursiveScan);
            this.flowLayoutPanel1.Controls.Add(this.buttonScan);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 40);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(131, 249);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // labelCurrentDir
            // 
            this.labelCurrentDir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCurrentDir.AutoSize = true;
            this.labelCurrentDir.Location = new System.Drawing.Point(3, 0);
            this.labelCurrentDir.Name = "labelCurrentDir";
            this.labelCurrentDir.Size = new System.Drawing.Size(76, 13);
            this.labelCurrentDir.TabIndex = 0;
            this.labelCurrentDir.Text = "labelCurrentDir";
            this.labelCurrentDir.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonSelectScanDirectory
            // 
            this.buttonSelectScanDirectory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSelectScanDirectory.Location = new System.Drawing.Point(3, 16);
            this.buttonSelectScanDirectory.Name = "buttonSelectScanDirectory";
            this.buttonSelectScanDirectory.Size = new System.Drawing.Size(125, 23);
            this.buttonSelectScanDirectory.TabIndex = 1;
            this.buttonSelectScanDirectory.Text = "Select Directory";
            this.buttonSelectScanDirectory.UseVisualStyleBackColor = true;
            this.buttonSelectScanDirectory.Click += new System.EventHandler(this.selectScanDir);
            // 
            // checkBoxRecursiveScan
            // 
            this.checkBoxRecursiveScan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxRecursiveScan.AutoSize = true;
            this.checkBoxRecursiveScan.Location = new System.Drawing.Point(3, 45);
            this.checkBoxRecursiveScan.Name = "checkBoxRecursiveScan";
            this.checkBoxRecursiveScan.Size = new System.Drawing.Size(122, 17);
            this.checkBoxRecursiveScan.TabIndex = 3;
            this.checkBoxRecursiveScan.Text = "Recursive Scanning";
            this.checkBoxRecursiveScan.UseVisualStyleBackColor = true;
            this.checkBoxRecursiveScan.CheckedChanged += new System.EventHandler(this.checkBoxRecursiveScan_CheckedChanged);
            // 
            // buttonScan
            // 
            this.buttonScan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonScan.Location = new System.Drawing.Point(3, 68);
            this.buttonScan.Name = "buttonScan";
            this.buttonScan.Size = new System.Drawing.Size(125, 23);
            this.buttonScan.TabIndex = 4;
            this.buttonScan.Text = "Scan Directory";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.startScan);
            // 
            // listViewImages
            // 
            this.listViewImages.Location = new System.Drawing.Point(141, 40);
            this.listViewImages.Name = "listViewImages";
            this.listViewImages.Size = new System.Drawing.Size(419, 249);
            this.listViewImages.TabIndex = 5;
            this.listViewImages.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 405);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelCurrentDir;
        private System.Windows.Forms.Button buttonSelectScanDirectory;
        private System.Windows.Forms.CheckBox checkBoxRecursiveScan;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.ListView listViewImages;

    }
}

