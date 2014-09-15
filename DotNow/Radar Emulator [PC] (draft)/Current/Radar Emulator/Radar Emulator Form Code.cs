using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samraksh.eMote.Radar.Emulator {
    public partial class RadarEmulator {
        private void DoRun_Click() {
            // If Block, be sure block size is non-negative integer
            if (Block.Checked && !CheckNonNegativeInteger(BlockSize, out _blockSize, "Block size must be non-negative")) {
                return;
            }

            // Be sure padding value is non-negative integer
            if (!CheckNonNegativeInteger(AmountOfEndPadding, out _amountOfPadding, "Amount of end padding must be non-negative")) {
                return;
            }

            // Be sure sample interval is non-negative integer
            if (
                !CheckNonNegativeInteger(SampleIntervalMicroSec, out _sampleIntervalMicroSec,
                    "Sample interval size must be non-negative")) {
                return;
            }

            // Save user settings
            SaveCheckBox(pnlFileType);
            Properties.Settings.Default.FileName = FileName.Text;
            Properties.Settings.Default.BlockSize = BlockSize.Text;
            Properties.Settings.Default.AmountOfEndPadding = AmountOfEndPadding.Text;
            SaveCheckBox(pnlPadding);
            Properties.Settings.Default.SampleIntervalMicroSec = SampleIntervalMicroSec.Text;

            Properties.Settings.Default.Save();

            // Run the rest in a separate thread to avoid tying up the GUI
            var t = new Thread(RunEmulation) { IsBackground = true };
            t.Start();
        }



        private static void DoPanelCheckBox_CheckedChanged(object sender) {
            var checkBox = sender as CheckBox;
            Debug.Assert(checkBox != null, "checkBox != null");
            if (!checkBox.Checked) {
                return;
            }
            foreach (var ctl in checkBox.Parent.Controls.OfType<CheckBox>().Where(ctl => ctl != checkBox)) {
                ctl.Checked = false;
            }
        }

        private void RunEmulation() {
            try {
                using (var binRdr = new BinaryReader(File.Open(FileName.Text, FileMode.Open))) {

                    // Show the number of samples in the data file
                    var m = new MethodInvoker(() => {
                        var numSamples = (binRdr.BaseStream.Length / (2 * sizeof(UInt16)));
                        var emulationTime = numSamples / (1000000 / _sampleIntervalMicroSec);
                        NumSamples.Text = numSamples.ToString("N0") + " samples (" + binRdr.BaseStream.Length.ToString("N0") + " bytes); approx " + emulationTime.ToString("N0") + " seconds";
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
                        MessageBox.Show("Radar Emulator internal error: No file storage mode (interleaved, block) selected");
                    }

                    // Done with data. Initialize padding values
                    var vals = new ushort[2];
                    for (var i = 0; i < vals.Length; i++) {
                        if (PaddingMinValue.Checked) { vals[i] = ushort.MinValue; }
                        if (PaddingMaxValue.Checked) { vals[i] = ushort.MaxValue; }
                    }
                    // Send padding values
                    Debug.Print("Sending" + AmountOfEndPadding + " padding values");
                    for (var i = 0; i < _amountOfPadding; i++) {
                        _emulatorComm.SendToADC(vals, 2);
                        Thread.Sleep(_sampleIntervalMicroSec / 1000);
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
                Thread.Sleep(_sampleIntervalMicroSec / 1000);
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
                if (!ReadAtPos(binRdr, logicalPos, out vals[0])) { return; }

                if (!ReadAtPos(binRdr, logicalPos + _blockSize, out vals[1])) { return; }

                logicalPos++;
                if (logicalPos % _blockSize == 0) {
                    logicalPos += _blockSize;
                }

                _emulatorComm.SendToADC(vals, 2);
                PrintVals(vals, 100);
                Thread.Sleep(_sampleIntervalMicroSec / 1000);

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

        private static bool CheckNonNegativeInteger(Control ctl, out int parameter, string errorMsg) {
            if (int.TryParse(ctl.Text, out parameter) && parameter >= 1) { return true; }
            MessageBox.Show(errorMsg);
            return false;
        }

    
    }
}
