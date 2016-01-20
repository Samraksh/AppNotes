using System;
using System.Linq;
using System.Windows.Forms;

namespace Samraksh.AppNote.PC.Radar.DisplacementDetector {
    public partial class RadarDisplacementDetector : Form {

        private int _blockSize;
        private int _sampleIntervalMicroSec;
        private int _samplesPerSecond;
        private int _samplesPerSnippet;

        private int _confM; //  M of N confirmation
        private int _confN; //  M of N confirmation
        private int _minCumCutsPerDisplacement; // Min number of cuts per snippet for displacement

        public RadarDisplacementDetector() {
            InitializeComponent();
        }

        private void RadarEmulator_Load(object sender, EventArgs e) {

            RunResult.Text = string.Empty;
            NumSamples.Text = string.Empty;

            // Get last values
            SetCheckBox(pnlFileType, Properties.Settings.Default.FileFormat);
            BlockSize.Text = Properties.Settings.Default.BlockSize;
            DataFilePathName.Text = Properties.Settings.Default.FileName;
            SampleIntervalMicroSec.Text = Properties.Settings.Default.SampleIntervalMicroSec;
            ConfM.Text = Properties.Settings.Default.ConfM;
            ConfN.Text = Properties.Settings.Default.ConfN;
            MinCutsPerDisplacement.Text = Properties.Settings.Default.MinCumCutsPerDisplacement;
        }

        private static void SetCheckBox(Control ctl, string value) {
            // Enable the check box that corresponds to the last value, if any
            if (ctl.Controls.OfType<CheckBox>().Any(tbCtl => tbCtl.Checked = (tbCtl.Tag.ToString() == value))) {
                return;
            }
            // If not, set the first check box
            foreach (var theCtl in ctl.Controls.OfType<CheckBox>()) {
                (theCtl).Checked = true;
                break;
            }
        }

        private static void SaveCheckBox(Control ctl) {
            foreach (var checkBox in ctl.Controls.Cast<object>().Where(theCtl => theCtl is CheckBox && (theCtl as CheckBox).Checked).OfType<CheckBox>()) {
                Properties.Settings.Default.FileFormat = (string)checkBox.Tag;
            }
        }

        private void ChooseFile_Click(object sender, EventArgs e) {
            var result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) {
                return;
            }
            DataFilePathName.Text = openFileDialog1.FileName;
        }

        private void Run_Click(object sender, EventArgs e) {

            // Save user settings
            SaveCheckBox(pnlFileType);
            Properties.Settings.Default.FileName = DataFilePathName.Text;
            Properties.Settings.Default.BlockSize = BlockSize.Text;
            Properties.Settings.Default.SampleIntervalMicroSec = SampleIntervalMicroSec.Text;
            Properties.Settings.Default.ConfM = ConfM.Text;
            Properties.Settings.Default.ConfN = ConfN.Text;
            Properties.Settings.Default.MinCumCutsPerDisplacement = MinCutsPerDisplacement.Text;
            Properties.Settings.Default.Save();

            // Run the analysis, disabling the Run button while executing
            Run.Enabled = false;
            DoRun_Click();
            Run.Enabled = true;
        }
        
        private void FileName_TextChanged(object sender, EventArgs e) {
            // Enable/disable Run button depending on whether there's something there
            Run.Enabled = DataFilePathName.Text.Trim() != string.Empty;

            // Adjust the size to the text
            var size = TextRenderer.MeasureText(DataFilePathName.Text, DataFilePathName.Font);
            DataFilePathName.Width = Math.Max(size.Width + 5, 20);  // Leave some space in case there's no text
            DataFilePathName.Height = size.Height;
        }

        private void FileName_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyData != (Keys.Control | Keys.V)) return;
            DataFilePathName.Select(0, 0);
        }

        private void Interleaved_Click(object sender, EventArgs e) {
            if (!Interleaved.Checked) { return; }
            Interleaved.Checked = true;
            Block.Checked = false;
            BlockSizeLabel.Enabled = BlockSize.Enabled = false;
        }

        private void Block_CheckedChanged(object sender, EventArgs e) {
            if (!Block.Checked) { return; }
            Block.Checked = true;
            BlockSizeLabel.Enabled = BlockSize.Enabled = true;
            Interleaved.Checked = false;
        }

        private void OpenCsvFile_Click(object sender, EventArgs e) {
            DoOpenCsvFile_Click();
        }
    }
}
