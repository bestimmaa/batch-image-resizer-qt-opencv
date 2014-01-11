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
            this.listViewImages = new System.Windows.Forms.ListView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelCurrentDir = new System.Windows.Forms.Label();
            this.buttonSelectScanDirectory = new System.Windows.Forms.Button();
            this.checkBoxRecursiveScan = new System.Windows.Forms.CheckBox();
            this.buttonScan = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxAlgorithm = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonResizeImages = new System.Windows.Forms.Button();
            this.checkBoxKeepFolderStructure = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewImages
            // 
            this.listViewImages.Location = new System.Drawing.Point(195, 10);
            this.listViewImages.Name = "listViewImages";
            this.listViewImages.Size = new System.Drawing.Size(432, 249);
            this.listViewImages.TabIndex = 5;
            this.listViewImages.UseCompatibleStateImageBehavior = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelCurrentDir);
            this.flowLayoutPanel1.Controls.Add(this.buttonSelectScanDirectory);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxRecursiveScan);
            this.flowLayoutPanel1.Controls.Add(this.buttonScan);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 10);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(163, 249);
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
            this.buttonSelectScanDirectory.Size = new System.Drawing.Size(160, 23);
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
            this.buttonScan.Size = new System.Drawing.Size(160, 23);
            this.buttonScan.TabIndex = 4;
            this.buttonScan.Text = "Scan Directory";
            this.buttonScan.UseVisualStyleBackColor = true;
            this.buttonScan.Click += new System.EventHandler(this.startScan);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.55062F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.44938F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listViewImages, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.739726F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 97.26028F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(630, 381);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.numericUpDownWidth);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.numericUpDownHeight);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.comboBoxAlgorithm);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(195, 279);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(432, 99);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(44, 3);
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(72, 20);
            this.numericUpDownWidth.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height";
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(166, 3);
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownHeight.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Algorithm";
            // 
            // comboBoxAlgorithm
            // 
            this.comboBoxAlgorithm.FormattingEnabled = true;
            this.comboBoxAlgorithm.Location = new System.Drawing.Point(284, 3);
            this.comboBoxAlgorithm.Name = "comboBoxAlgorithm";
            this.comboBoxAlgorithm.Size = new System.Drawing.Size(139, 21);
            this.comboBoxAlgorithm.TabIndex = 5;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.buttonResizeImages);
            this.flowLayoutPanel3.Controls.Add(this.checkBoxKeepFolderStructure);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 279);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(163, 99);
            this.flowLayoutPanel3.TabIndex = 7;
            // 
            // buttonResizeImages
            // 
            this.buttonResizeImages.Location = new System.Drawing.Point(3, 3);
            this.buttonResizeImages.Name = "buttonResizeImages";
            this.buttonResizeImages.Size = new System.Drawing.Size(160, 23);
            this.buttonResizeImages.TabIndex = 7;
            this.buttonResizeImages.Text = "Resize Images";
            this.buttonResizeImages.UseVisualStyleBackColor = true;
            this.buttonResizeImages.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxKeepFolderStructure
            // 
            this.checkBoxKeepFolderStructure.AutoSize = true;
            this.checkBoxKeepFolderStructure.Location = new System.Drawing.Point(3, 32);
            this.checkBoxKeepFolderStructure.Name = "checkBoxKeepFolderStructure";
            this.checkBoxKeepFolderStructure.Size = new System.Drawing.Size(160, 17);
            this.checkBoxKeepFolderStructure.TabIndex = 6;
            this.checkBoxKeepFolderStructure.Text = "Keep original folder structure";
            this.checkBoxKeepFolderStructure.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 406);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "BBP";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewImages;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelCurrentDir;
        private System.Windows.Forms.Button buttonSelectScanDirectory;
        private System.Windows.Forms.CheckBox checkBoxRecursiveScan;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxAlgorithm;
        private System.Windows.Forms.CheckBox checkBoxKeepFolderStructure;
        private System.Windows.Forms.Button buttonResizeImages;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;


    }
}

