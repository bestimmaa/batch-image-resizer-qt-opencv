namespace BBP_WINFORMS
{
    partial class BBPMainWindow
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
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.labelCurrentDir = new System.Windows.Forms.Label();
            this.buttonSelectScanDirectory = new System.Windows.Forms.Button();
            this.checkBoxRecursiveScan = new System.Windows.Forms.CheckBox();
            this.buttonScan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxAlgorithm = new System.Windows.Forms.ComboBox();
            this.buttonResizeImages = new System.Windows.Forms.Button();
            this.checkBoxKeepFolderStructure = new System.Windows.Forms.CheckBox();
            this.labelOutputDir = new System.Windows.Forms.Label();
            this.listViewImages = new System.Windows.Forms.ListView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSelectOutputDir = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPreview.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(390, 412);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 6;
            this.pictureBoxPreview.TabStop = false;
            // 
            // labelCurrentDir
            // 
            this.labelCurrentDir.AutoSize = true;
            this.labelCurrentDir.Location = new System.Drawing.Point(3, 0);
            this.labelCurrentDir.Name = "labelCurrentDir";
            this.labelCurrentDir.Size = new System.Drawing.Size(76, 13);
            this.labelCurrentDir.TabIndex = 0;
            this.labelCurrentDir.Text = "labelCurrentDir";
            this.labelCurrentDir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonSelectScanDirectory
            // 
            this.buttonSelectScanDirectory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonSelectScanDirectory.AutoSize = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width";
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(3, 149);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownWidth.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(160, 20);
            this.numericUpDownWidth.TabIndex = 0;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Height";
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(3, 110);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownHeight.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(160, 20);
            this.numericUpDownHeight.TabIndex = 1;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Algorithm";
            // 
            // comboBoxAlgorithm
            // 
            this.comboBoxAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAlgorithm.FormattingEnabled = true;
            this.comboBoxAlgorithm.Location = new System.Drawing.Point(3, 188);
            this.comboBoxAlgorithm.Name = "comboBoxAlgorithm";
            this.comboBoxAlgorithm.Size = new System.Drawing.Size(160, 21);
            this.comboBoxAlgorithm.TabIndex = 5;
            this.comboBoxAlgorithm.SelectedIndexChanged += new System.EventHandler(this.algorithmSelectionDidChange);
            // 
            // buttonResizeImages
            // 
            this.buttonResizeImages.Location = new System.Drawing.Point(3, 280);
            this.buttonResizeImages.Name = "buttonResizeImages";
            this.buttonResizeImages.Size = new System.Drawing.Size(160, 23);
            this.buttonResizeImages.TabIndex = 7;
            this.buttonResizeImages.Text = "Resize Images";
            this.buttonResizeImages.UseVisualStyleBackColor = true;
            this.buttonResizeImages.Click += new System.EventHandler(this.startResize);
            // 
            // checkBoxKeepFolderStructure
            // 
            this.checkBoxKeepFolderStructure.AutoSize = true;
            this.checkBoxKeepFolderStructure.Location = new System.Drawing.Point(3, 257);
            this.checkBoxKeepFolderStructure.Name = "checkBoxKeepFolderStructure";
            this.checkBoxKeepFolderStructure.Size = new System.Drawing.Size(160, 17);
            this.checkBoxKeepFolderStructure.TabIndex = 6;
            this.checkBoxKeepFolderStructure.Text = "Keep original folder structure";
            this.checkBoxKeepFolderStructure.UseVisualStyleBackColor = true;
            this.checkBoxKeepFolderStructure.CheckedChanged += new System.EventHandler(this.checkBoxKeepFolderStructure_CheckedChanged);
            // 
            // labelOutputDir
            // 
            this.labelOutputDir.AutoSize = true;
            this.labelOutputDir.Location = new System.Drawing.Point(3, 212);
            this.labelOutputDir.Name = "labelOutputDir";
            this.labelOutputDir.Size = new System.Drawing.Size(55, 13);
            this.labelOutputDir.TabIndex = 7;
            this.labelOutputDir.Text = "Output Dir";
            this.labelOutputDir.Click += new System.EventHandler(this.label4_Click);
            // 
            // listViewImages
            // 
            this.listViewImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewImages.Location = new System.Drawing.Point(0, 0);
            this.listViewImages.MultiSelect = false;
            this.listViewImages.Name = "listViewImages";
            this.listViewImages.Size = new System.Drawing.Size(545, 748);
            this.listViewImages.TabIndex = 5;
            this.listViewImages.UseCompatibleStateImageBehavior = false;
            this.listViewImages.View = System.Windows.Forms.View.List;
            this.listViewImages.SelectedIndexChanged += new System.EventHandler(this.didSelectImage);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelCurrentDir);
            this.flowLayoutPanel1.Controls.Add(this.buttonSelectScanDirectory);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxRecursiveScan);
            this.flowLayoutPanel1.Controls.Add(this.buttonScan);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDownHeight);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.numericUpDownWidth);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxAlgorithm);
            this.flowLayoutPanel1.Controls.Add(this.labelOutputDir);
            this.flowLayoutPanel1.Controls.Add(this.buttonSelectOutputDir);
            this.flowLayoutPanel1.Controls.Add(this.checkBoxKeepFolderStructure);
            this.flowLayoutPanel1.Controls.Add(this.buttonResizeImages);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 421);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(179, 324);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // buttonSelectOutputDir
            // 
            this.buttonSelectOutputDir.Location = new System.Drawing.Point(3, 228);
            this.buttonSelectOutputDir.Name = "buttonSelectOutputDir";
            this.buttonSelectOutputDir.Size = new System.Drawing.Size(160, 23);
            this.buttonSelectOutputDir.TabIndex = 8;
            this.buttonSelectOutputDir.Text = "Select Output Directory";
            this.buttonSelectOutputDir.UseVisualStyleBackColor = true;
            this.buttonSelectOutputDir.Click += new System.EventHandler(this.selectOutputDir);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxPreview, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(396, 748);
            this.tableLayoutPanel1.TabIndex = 9;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint_1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewImages);
            this.splitContainer1.Size = new System.Drawing.Size(945, 748);
            this.splitContainer1.SplitterDistance = 396;
            this.splitContainer1.TabIndex = 10;
            // 
            // BBPMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 748);
            this.Controls.Add(this.splitContainer1);
            this.Name = "BBPMainWindow";
            this.Text = "BBP";
            this.Load += new System.EventHandler(this.BBPMainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelCurrentDir;
        private System.Windows.Forms.Button buttonSelectScanDirectory;
        private System.Windows.Forms.CheckBox checkBoxRecursiveScan;
        private System.Windows.Forms.Button buttonScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxAlgorithm;
        private System.Windows.Forms.CheckBox checkBoxKeepFolderStructure;
        private System.Windows.Forms.Button buttonResizeImages;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Label labelOutputDir;
        private System.Windows.Forms.ListView listViewImages;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonSelectOutputDir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;


    }
}

