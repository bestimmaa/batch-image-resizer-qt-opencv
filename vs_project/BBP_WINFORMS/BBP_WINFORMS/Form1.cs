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
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace BBP_WINFORMS
{
    public partial class Form1 : Form
    {
        private string[] scanResults;
        private bool scanInProgress;
        Image<Bgr, Byte> previewImage;

        public Form1()
        {
            scanResults = new string[]{};
            scanInProgress = false;
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
            Label labelCurrentDir = this.Controls.Find("labelCurrentDir", true).FirstOrDefault() as Label;
            labelCurrentDir.Text = Properties.Settings.Default.ImageScanPath;

            CheckBox box = this.Controls.Find("checkBoxRecursiveScan", true).FirstOrDefault() as CheckBox;
            box.Checked = Properties.Settings.Default.RecursiveScan;
            box.Enabled = !scanInProgress;

            Button buttonScan = this.Controls.Find("buttonScan", true).FirstOrDefault() as Button;
            buttonScan.Enabled = !scanInProgress;

            Button buttonScanDir = this.Controls.Find("buttonSelectScanDirectory", true).FirstOrDefault() as Button;
            buttonScanDir.Enabled = !scanInProgress;

            Button buttonResize = this.Controls.Find("buttonResizeImages", true).FirstOrDefault() as Button;
            buttonResize.Enabled = !scanInProgress;

            PictureBox pictureBoxPreview = this.Controls.Find("pictureBoxPreview", true).FirstOrDefault() as PictureBox;
            if(previewImage != null)
                pictureBoxPreview.Image = previewImage.ToBitmap();    

            //update results view
            ListView list = this.Controls.Find("listViewImages", true).FirstOrDefault() as ListView;
            list.Enabled = !scanInProgress;
            list.Items.Clear();
            for (int i = 0; i < scanResults.Length; ++i )
            {
                ListViewItem itm = new ListViewItem(scanResults[i]);
                list.Items.Add(itm);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private string[] GetFiles(string path)
        {
            Console.WriteLine("Starting scan in path " + path);
            Queue<string> queue = new Queue<string>();
            string[] results = {};
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
                //TODO we might miss some very deep paths by swallowing 'System.IO.PathTooLongException'
                catch (Exception ex)
                {
                   // Console.Error.WriteLine(ex);
                }
                string[] files = null;
                try
                {
                    var filteredResults = Directory.GetFiles(path).Where(data => data.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) == true || data.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) == true);
                    files = filteredResults.ToArray();
                }
                catch (Exception ex)
                {
                    //Console.Error.WriteLine(ex);
                }
                if (files != null)
                {
                    results = results.Concat(files).ToArray();
                }
            }

            Console.WriteLine("Finished with {0:d} results", results.Length);

            return results;
        }
        private Task<string[]> GetFilesAsync(string path)
        {
            return Task.Run<string[]>(() => GetFiles(path));
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
            CallGetFiles();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void CallGetFiles()
        {
            scanInProgress = true;
            updateUI();
            var results = await GetFilesAsync(Properties.Settings.Default.ImageScanPath);
            scanResults = results;
            scanInProgress = false;
            updateUI();
        }

        private void didSelectImage(object sender, EventArgs e)
        {
            ListView list = sender as ListView;
            if (list.SelectedItems.Count > 0)
            {
                int index = list.SelectedItems[0].Index;
                string imagePath = scanResults[index];
                previewImage = new Image<Bgr, byte>(imagePath);
                updateUI();
            }
        }
    }
}
