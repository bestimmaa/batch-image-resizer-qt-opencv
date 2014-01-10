using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBP_WINFORMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            updateUI();
        }

        private void updateUI()
        {
            Label tbx = this.Controls.Find("labelCurrentDir", true).FirstOrDefault() as Label;
            tbx.Text = Properties.Settings.Default.ImageScanPath;
            CheckBox box = this.Controls.Find("checkBoxRecursiveScan", true).FirstOrDefault() as CheckBox;
            box.Checked = Properties.Settings.Default.RecursiveScan;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void selectScanDir(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog objDialog = new FolderBrowserDialog();
            objDialog.Description = "Beschreibung";
            objDialog.SelectedPath = @"C:/";       // Vorgabe Pfad (und danach der gewählte Pfad)
            DialogResult objResult = objDialog.ShowDialog(this);
            if (objResult == DialogResult.OK)
            {
                Properties.Settings.Default.ImageScanPath = objDialog.SelectedPath;
            }
            updateUI();
        }

        private void checkBoxRecursiveScan_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = sender as CheckBox;
            Properties.Settings.Default.RecursiveScan = box.Checked;
            updateUI();
        }

        private void startScan(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
