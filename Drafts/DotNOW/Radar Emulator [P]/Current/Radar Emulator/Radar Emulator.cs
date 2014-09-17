using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Samraksh.PhysicalModel;

namespace Samraksh.eMote.Radar.Emulator {
    public partial class RadarEmulator : Form {

        private readonly PhysicalModelEmulatorComm _emulatorComm = new PhysicalModelEmulatorComm();
        //private const int SampleTime = 4000; // Interval between samples, in microseconds
        private int _blockSize;
        private int _amountOfPadding;
        private int _sampleIntervalMicroSec;

        public RadarEmulator() {
            InitializeComponent();
        }

        private void RadarEmulator_Load(object sender, EventArgs e) {

            // Get last values
            SetCheckBox(pnlFileType, Properties.Settings.Default.FileFormat);
            BlockSize.Text = Properties.Settings.Default.BlockSize;
            FileName.Text = Properties.Settings.Default.FileName;
            AmountOfEndPadding.Text = Properties.Settings.Default.AmountOfEndPadding;
            SetCheckBox(pnlPadding, Properties.Settings.Default.PaddingType);
            SampleIntervalMicroSec.Text = Properties.Settings.Default.SampleIntervalMicroSec;

            if (_emulatorComm.ConnectToEmulator()) return;
            MessageBox.Show("Cannot connect to emulator\nBe sure the emulated program is running");
            Application.Exit();
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
            foreach (var theCtl in ctl.Controls.Cast<object>().Where(theCtl => theCtl is CheckBox && (theCtl as CheckBox).Checked)) {
                var checkBox = theCtl as CheckBox;
                if (checkBox != null)
                    Properties.Settings.Default.FileFormat = (string)checkBox.Tag;
            }
        }


        /// <summary>
        /// For a checkbox in a control container, ensure that at most is checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelCheckBox_CheckedChanged(object sender, EventArgs e) {
            DoPanelCheckBox_CheckedChanged(sender);
        }


        private void ChooseFile_Click(object sender, EventArgs e) {
            var result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) {
                return;
            }
            FileName.Text = openFileDialog1.FileName;
        }


        private void Run_Click(object sender, EventArgs e) {
            DoRun_Click();
        }

        
        private void FileName_TextChanged(object sender, EventArgs e) {
            // Enable/disable Run button depending on whether there's something there
            Run.Enabled = FileName.Text.Trim() != string.Empty;

            // Adjust the size to the text
            var size = TextRenderer.MeasureText(FileName.Text, FileName.Font);
            FileName.Width = Math.Max(size.Width + 5, 20);  // Leave some space in case there's no text
            FileName.Height = size.Height;
        }

        private void FileName_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyData != (Keys.Control | Keys.V)) return;
            //FileName.Paste();
            FileName.Select(0, 0);
        }
    }
}
