using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Markup;
using Samraksh.PhysicalModel;

namespace Samraksh.eMote.Radar.Emulator {
    public partial class RadarEmulator : Form {

        private readonly PhysicalModelEmulatorComm _emulatorComm = new PhysicalModelEmulatorComm();
        private const int SampleTime = 4000; // Interval between samples, in microseconds
        private int _blockSize;

        public RadarEmulator() {
            InitializeComponent();
        }

        private void RadarEmulator_Load(object sender, EventArgs e) {

            // Get last values
            foreach (var ctl in FileType.Controls) {
                if (!(ctl is CheckBox)) continue;
                var tbCtl = (CheckBox)ctl;
                tbCtl.Checked = tbCtl.Tag.ToString() == Properties.Settings.Default.FileFormat;
            }
            BlockSize.Text = Properties.Settings.Default.BlockSize;
            FileName.Text = Properties.Settings.Default.FileName;

            if (_emulatorComm.ConnectToEmulator()) return;
            MessageBox.Show("Cannot connect to emulator\nBe sure the emulated program is running");
            Application.Exit();
        }

        private void RunEmulation() {
            try {
                using (var binRdr = new BinaryReader(File.Open(FileName.Text, FileMode.Open))) {

                    // Save user settings
                    foreach (var ctl in FileType.Controls.Cast<object>().Where(ctl => ctl is CheckBox && (ctl as CheckBox).Checked)) {
                        Properties.Settings.Default.FileFormat = (string)(ctl as CheckBox).Tag;
                    }
                    Properties.Settings.Default.FileName = FileName.Text;
                    Properties.Settings.Default.Save();

                    // Show the number of samples in the data file
                    var m = new MethodInvoker(() => {
                        NumSamples.Text = (binRdr.BaseStream.Length / (2 * sizeof(UInt16))) + " Samples";
                        Refresh();
                    });
                    if (InvokeRequired) { Invoke(m); }
                    else { m(); }
                    Debug.Print(NumSamples.Text);

                    if (Interleaved.Checked) {
                        RunEmulationInterleaved(binRdr);
                    }
                    else if (Block.Checked) {
                        RunEmulationBlock(binRdr);
                    }
                    else {
                        MessageBox.Show("Internal error: No file storage mode selected");
                    }
                    Debug.Print("Finished processing file");
                }
            }
            catch (ArgumentException) { MessageBox.Show(FileName.Text + " is invalid"); }
            catch (PathTooLongException) { MessageBox.Show(FileName.Text + " has too long a path"); }
            catch (DirectoryNotFoundException) { MessageBox.Show(FileName.Text + ": path doesn't exist"); }
            catch (IOException) { MessageBox.Show(FileName.Text + " can't be opened"); }
            catch (NotSupportedException) { MessageBox.Show(FileName.Text + ": path is invalid"); }
        }

        private void RunEmulationInterleaved(BinaryReader binRdr) {
            var pos = 0;
            var vals = new ushort[2];
            while (true) {
                for (var i = 0; i < vals.Length; i++) {
                    if (!ReadNext(binRdr, ref pos, out vals[i])) {
                        return;
                    }
                }
                _emulatorComm.SendToADC(vals, 2);
                PrintVals(vals, 25);
                Thread.Sleep(SampleTime / 1000);
            }
            //while (pos < binRdr.BaseStream.Length) {
            //    vals[0] = binRdr.ReadUInt16();
            //    pos += sizeof(UInt16);
            //    vals[1] = binRdr.ReadUInt16();
            //    pos += sizeof(UInt16);
            //}
        }


        private static bool ReadNext(BinaryReader binRdr, ref int pos, out ushort outval) {
            outval = ushort.MaxValue;
            if (pos + 1 > binRdr.BaseStream.Length) {
                return false;
            }
            outval = binRdr.ReadUInt16();
            pos += sizeof(UInt16);
            return true;
        }

        private void RunEmulationBlock(BinaryReader binRdr) {
            var logicalPos = 0;
            var vals = new ushort[2];
            while (true) {
                if (!ReadAtPos(binRdr, logicalPos, out vals[0])) {
                    return;
                }

                if (!ReadAtPos(binRdr, logicalPos + _blockSize, out vals[1])) {
                    return;
                }

                logicalPos++;
                if (logicalPos % _blockSize == 0) {
                    logicalPos += _blockSize;
                }

                _emulatorComm.SendToADC(vals, 2);
                PrintVals(vals, 100);
                Thread.Sleep(SampleTime / 1000);

            }
        }

        private static bool ReadAtPos(BinaryReader binRdr, int logicalPos, out ushort outval) {
            var seekPos = logicalPos * sizeof(UInt16);
            if (seekPos + 1 > binRdr.BaseStream.Length) {
                outval = 0;
                return false;
            }
            binRdr.BaseStream.Seek(seekPos, SeekOrigin.Begin);
            outval = binRdr.ReadUInt16();
            return true;
        }

        private void PrintVals(ushort[] vals, int interval) {
            if ((_sampleNum % interval) == 0) {
                Debug.Write("* " + _sampleNum + " ");
                foreach (var val in vals) {
                    Debug.Write(val + " ");
                }
                Debug.WriteLine("");
            }
            _sampleNum++;
        }
        private int _sampleNum;

        private void FileType_CheckedChanged(object sender, EventArgs e) {
            var checkBox = sender as CheckBox;
            Debug.Assert(checkBox != null, "checkBox != null");
            if (!checkBox.Checked) {
                return;
            }
            //Debug.Assert(checkBox != null, "checkBox != null");
            //var isChecked = checkBox.Checked;
            foreach (var ctl in FileType.Controls.OfType<CheckBox>().Where(ctl => ctl != checkBox)) {
                ctl.Checked = false;
            }
        }

        private void ChooseFile_Click(object sender, EventArgs e) {
            var result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) {
                return;
            }
            FileName.Text = openFileDialog1.FileName;
        }

        private void Run_Click(object sender, EventArgs e) {
            // If Block, be sure block size is positive integer
            if (Block.Checked) {
                if (int.TryParse(BlockSize.Text, out _blockSize) || _blockSize < 1) {
                    MessageBox.Show("Block size must be a positive integer");
                    return;
                }
            }
            //if (FileName.Text.Trim() == String.Empty || FileName.Text.IndexOfAny(Path.GetInvalidPathChars()) >= 0 || !(new FileInfo(FileName.Text)).Exists) {
            //    MessageBox.Show("File does not exist");
            //    return;
            //}

            // Run in a separate thread to avoid tying up the GUI
            var t = new Thread(RunEmulation) { IsBackground = true };
            t.Start();
        }

        private void FileName_TextChanged(object sender, EventArgs e) {
            // Enable/disable Run button depending on whether there's something there
            Run.Enabled = FileName.Text.Trim() != string.Empty;

            // Adjust the size to the text
            var size = TextRenderer.MeasureText(FileName.Text, FileName.Font);
            FileName.Width = Math.Max(size.Width+5, 20);  // Leave some space in case there's no text
            FileName.Height = size.Height;
        }

        private void FileName_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyData != (Keys.Control | Keys.V)) return;
            //FileName.Paste();
            FileName.Select(0,0);
        }
    }
}
