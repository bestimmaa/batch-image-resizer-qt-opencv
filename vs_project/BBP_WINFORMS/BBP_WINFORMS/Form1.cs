using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
    public partial class BBPMainWindow : Form
    {
        private string[] scanResults;
        private bool scanInProgress;
        private Image<Bgr, Byte> previewImage;

        public BBPMainWindow()
        {
            scanResults = new string[] { };
            scanInProgress = false;
            InitializeComponent();
            setupUI();
            updateUI();
        }

        private void setupUI()
        {
            var algorithms = new[] { "bilinear", "pixel area relation", "bicubic (4x4)", "Lanczos (8x8)" };
            ComboBox tbx = this.Controls.Find("comboBoxAlgorithm", true).FirstOrDefault() as ComboBox;
            tbx.DataSource = algorithms;
        }

        private void updateUI()
        {
            Label labelCurrentDir = this.Controls.Find("labelCurrentDir", true).FirstOrDefault() as Label;
            labelCurrentDir.Text = Properties.Settings.Default.ImageScanPath;

            Label labelOutputDir = this.Controls.Find("labelOutputDir", true).FirstOrDefault() as Label;
            labelOutputDir.Text = Properties.Settings.Default.ImageOutputPath;

            CheckBox box = this.Controls.Find("checkBoxRecursiveScan", true).FirstOrDefault() as CheckBox;
            box.Checked = Properties.Settings.Default.RecursiveScan;
            box.Enabled = !scanInProgress;

            box = this.Controls.Find("checkBoxKeepFolderStructure", true).FirstOrDefault() as CheckBox;
            box.Checked = Properties.Settings.Default.KeepDirectoryStructure;
            box.Enabled = !scanInProgress;

            Button buttonScan = this.Controls.Find("buttonScan", true).FirstOrDefault() as Button;
            buttonScan.Enabled = !scanInProgress;

            Button buttonScanDir = this.Controls.Find("buttonSelectScanDirectory", true).FirstOrDefault() as Button;
            buttonScanDir.Enabled = !scanInProgress;

            Button buttonResize = this.Controls.Find("buttonResizeImages", true).FirstOrDefault() as Button;
            buttonResize.Enabled = !scanInProgress;

            PictureBox pictureBoxPreview = this.Controls.Find("pictureBoxPreview", true).FirstOrDefault() as PictureBox;
            if (previewImage != null)
                pictureBoxPreview.Image = previewImage.ToBitmap();

            //update results view
            ListView list = this.Controls.Find("listViewImages", true).FirstOrDefault() as ListView;
            list.Enabled = !scanInProgress;


        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ResizeImages(string[] images, Emgu.CV.CvEnum.INTER algo)
        {
            NumericUpDown numericHeight = this.Controls.Find("numericUpDownHeight", true).FirstOrDefault() as NumericUpDown;
            NumericUpDown numericWidth = this.Controls.Find("numericUpDownWidth", true).FirstOrDefault() as NumericUpDown;

            for (int i = 0; i < images.Length; ++i)
            {
                FileInfo info = new FileInfo(images[i]);
                string outputPath = Properties.Settings.Default.ImageOutputPath;
                Image<Bgr, Byte> captureImage = new Image<Bgr, byte>(images[i]);
                Image<Bgr, byte> resizedImage = captureImage.Resize(Convert.ToInt32(numericWidth.Value), Convert.ToInt32(numericHeight.Value), algo);
                // Make sure you have the rights to write to the directory! 
                saveJpeg(outputPath + @"/" + info.Name, resizedImage.ToBitmap(), 100);
            }
        }

        private Task ResizeImagesAsync(string[] images, Emgu.CV.CvEnum.INTER algo)
        {
            return Task.Run(() => ResizeImages(images, algo));
        }

        private async void CallResizeImages()
        {
            await ResizeImagesAsync(scanResults, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            Console.WriteLine("Resizing did finish!");
        }

        private string[] GetFiles(string path)
        {
            Console.WriteLine("Starting scan in path " + path);
            Queue<string> queue = new Queue<string>();
            string[] results = { };
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

        private async void CallGetFiles()
        {
            scanInProgress = true;
            updateUI();
            var results = await GetFilesAsync(Properties.Settings.Default.ImageScanPath);
            scanResults = results;
            scanInProgress = false;

            ListView list = this.Controls.Find("listViewImages", true).FirstOrDefault() as ListView;
            list.Items.Clear();
            for (int i = 0; i < scanResults.Length; ++i)
            {
                ListViewItem itm = new ListViewItem(scanResults[i]);
                list.Items.Add(itm);
            }
            updateUI();
        }


        private void selectScanDir(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog objDialog = new FolderBrowserDialog();
            objDialog.Description = "Beschreibung";
            objDialog.SelectedPath = "C:/";       // Vorgabe Pfad (und danach der gewählte Pfad)
            DialogResult objResult = objDialog.ShowDialog(this);
            if (objResult == DialogResult.OK)
            {
                Properties.Settings.Default.ImageScanPath = objDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
            updateUI();
        }

        private void checkBoxRecursiveScan_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = sender as CheckBox;
            Properties.Settings.Default.RecursiveScan = box.Checked;
            Properties.Settings.Default.Save();
            updateUI();
        }

        private void startScan(object sender, EventArgs e)
        {
            CallGetFiles();
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

        private void startResize(object sender, EventArgs e)
        {
            CallResizeImages();
        }

        private void saveJpeg(string path, Bitmap img, long quality)
        {
            // Encoder parameter for image quality

            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            // Jpeg image codec
            ImageCodecInfo jpegCodec = this.getEncoderInfo("image/jpeg");

            if (jpegCodec == null)
                return;

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }

        private ImageCodecInfo getEncoderInfo(string mimeType)
        {
            // Get image codecs for all image formats
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            // Find the correct image codec
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void BBPMainWindow_Load(object sender, EventArgs e)
        {

        }

        private void selectOutputDir(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog objDialog = new FolderBrowserDialog();
            objDialog.Description = "Beschreibung";
            objDialog.SelectedPath = "C:/";       // Vorgabe Pfad (und danach der gewählte Pfad)
            DialogResult objResult = objDialog.ShowDialog(this);
            if (objResult == DialogResult.OK)
            {
                Properties.Settings.Default.ImageOutputPath = objDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
            updateUI();
        }

        private void checkBoxKeepFolderStructure_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = sender as CheckBox;
            Properties.Settings.Default.KeepDirectoryStructure = box.Checked;
            Properties.Settings.Default.Save();
            updateUI();
        }
    }
}
