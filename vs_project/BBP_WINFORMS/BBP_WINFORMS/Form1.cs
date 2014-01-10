using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BBP_WINFORMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setupUI();
            updateUI();
        }

        private void setupUI()
        {
            var algorithms = new[] { "Bikubisch" };
            ComboBox tbx = this.Controls.Find("comboBoxAlgorithm", true).FirstOrDefault() as ComboBox;
            tbx.DataSource = algorithms;
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

        static IEnumerable<string> GetFiles(string path)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                path = queue.Dequeue();
                try
                {
                    foreach (string subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                string[] files = null;
                try
                {
                    files = Directory.GetFiles(path);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex);
                }
                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        yield return files[i];
                    }
                }
            }
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
            foreach (string file in GetFiles("C:/"))
            {
                Console.WriteLine(file);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
