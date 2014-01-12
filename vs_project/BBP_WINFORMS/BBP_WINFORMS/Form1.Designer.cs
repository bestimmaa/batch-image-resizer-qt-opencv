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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Location = new System.Drawing.Point(505, 12);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(303, 303);
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
            this.comboBoxAlgorithm.FormattingEnabled = true;
            this.comboBoxAlgorithm.Location = new System.Drawing.Point(3, 188);
            this.comboBoxAlgorithm.Name = "comboBoxAlgorithm";
            this.comboBoxAlgorithm.Size = new System.Drawing.Size(160, 21);
            this.comboBoxAlgorithm.TabIndex = 5;
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
            this.listViewImages.Location = new System.Drawing.Point(196, 12);
            this.listViewImages.MultiSelect = false;
            this.listViewImages.Name = "listViewImages";
            this.listViewImages.Size = new System.Drawing.Size(303, 303);
            this.listViewImages.TabIndex = 5;
            this.listViewImages.UseCompatibleStateImageBehavior = false;
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
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(178, 315);
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
            // BBPMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 339);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.listViewImages);
            this.Controls.Add(this.pictureBoxPreview);
            this.Name = "BBPMainWindow";
            this.Text = "BBP";
            this.Load += new System.EventHandler(this.BBPMainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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


    }
}

