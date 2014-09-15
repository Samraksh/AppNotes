using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Samraksh.AppNote.Utility.Radar.DisplacementAnalysis;

namespace Samraksh.AppNote.PC.Radar.DisplacementDetector {
    public partial class RadarDisplacementDetector {

        private static readonly List<SnippetRange> DispList = new List<SnippetRange>();
        private static readonly List<SnippetRange> ConfList = new List<SnippetRange>();

        private void DoRun_Click() {
            // If Block, be sure block size is non-negative integer
            if (Block.Checked && !CheckNonNegativeInteger(BlockSize, out _blockSize, "Block size must be non-negative")) {
                return;
            }

            // Be sure sample interval is non-negative integer
            if (!CheckNonNegativeInteger(SampleIntervalMicroSec, out _sampleIntervalMicroSec, "Sample interval size must be non-negative")) {
                return;
            }

            // Be sure confirming parameters are non-negative integers
            if (!CheckNonNegativeInteger(ConfM, out _confM, "M value must be non-negative")) {
                return;
            }
            if (!CheckNonNegativeInteger(ConfN, out _confN, "N value must be non-negative")) {
                return;
            }
            if (!CheckNonNegativeInteger(MinCutsPerDisplacement, out _minCumCutsPerDisplacement, "Min Cum Cuts per Displacement value must be non-negative")) {
                return;
            }

            // Save user settings
            SaveCheckBox(pnlFileType);
            Properties.Settings.Default.FileName = DataFilePathName.Text;
            Properties.Settings.Default.BlockSize = BlockSize.Text;
            Properties.Settings.Default.SampleIntervalMicroSec = SampleIntervalMicroSec.Text;
            Properties.Settings.Default.ConfM = ConfM.Text;
            Properties.Settings.Default.ConfN = ConfN.Text;
            Properties.Settings.Default.MinCumCutsPerDisplacement = MinCutsPerDisplacement.Text;
            Properties.Settings.Default.Save();

            _samplesPerSecond = 1000000 / _sampleIntervalMicroSec;
            _samplesPerSnippet = _samplesPerSecond;

            DisplacementAnalysis.Initialize(_samplesPerSecond, _confM, _confN, _minCumCutsPerDisplacement
                , DisplacementCallback, ConfirmationCallback);

            // Run the rest in a separate thread to avoid tying up the GUI
            var t = new Thread(RunDisplacementDetection) { IsBackground = true, Name = "DisplacementDetector" };
            t.Start();
        }


        private void RunDisplacementDetection() {
            var runResult = "Error processing file";
            try {
                using (var radarDataReader = new BinaryReader(File.Open(DataFilePathName.Text, FileMode.Open))) {

                    var fileName = Path.GetFileNameWithoutExtension(DataFilePathName.Text);
                    var filePath = Path.GetDirectoryName(DataFilePathName.Text);
                    var csvFilePathName = filePath + "\\" + fileName + "_disp.csv";

                    //Debug.Print(csvFilePathName);
                    //csvFilePathName = @"C:\temp\Radar Displacement Test\r46-human-radial";
                    //Debug.Print(csvFilePathName);

                    //using (var analysisOutputWriter = new StreamWriter(new FileStream(csvFilePathName, FileMode.Create, FileAccess.Write))) {
                    using (
                        var analysisOutputWriter =
                            new StreamWriter(File.Open(csvFilePathName, FileMode.Create, FileAccess.Write,
                                FileShare.Read))) {

                        // Show the number of samples in the data file
                        var fileSize = radarDataReader.BaseStream.Length;
                        var numSamples = (fileSize / (2 * sizeof(UInt16)));
                        MethodInvoker m = () => {
                            var emulationTime = numSamples / (1000000 / _sampleIntervalMicroSec);
                            NumSamples.Text = numSamples.ToString("N0") + " samples (" + fileSize.ToString("N0") +
                                              " bytes); approx " + emulationTime.ToString("N0") + " seconds";
                            Refresh();
                        };
                        if (InvokeRequired) { Invoke(m); }
                        else { m(); }
                        Debug.Print(NumSamples.Text);

                        if (Interleaved.Checked) {
                            RunEmulationInterleaved(radarDataReader);
                        }
                        else if (Block.Checked) {
                            RunEmulationBlock(radarDataReader);
                        }
                        else {
                            MessageBox.Show( "Radar Displacement Analyzer internal error: No file storage mode (interleaved, block) selected");
                        }

                        // Write the analysis header
                        analysisOutputWriter.WriteLine("Displacement analysis for " + fileName);
                        analysisOutputWriter.WriteLine("Run at " + DateTime.Now.ToString("G"));
                        analysisOutputWriter.WriteLine();
                        analysisOutputWriter.WriteLine("Samples Per Second," + _samplesPerSecond
                            + ",Samples Per Snippet," + _samplesPerSnippet
                            + ",Seconds Per Snippet," +
                            (float)_samplesPerSnippet / _samplesPerSecond);
                        analysisOutputWriter.WriteLine("Confirmation: M," + _confM + ",N," + _confN);
                        analysisOutputWriter.WriteLine("Displacement Snippet,,,Confirmation Snippet");
                        analysisOutputWriter.WriteLine("Begin,End,,Begin,End");

                        // Finalize and merge displacement and confirmation lists
                        var lastSnippetNum = numSamples / _samplesPerSnippet;
                        if (DispList.Count > 0) {
                            var lastSnippet = DispList[DispList.Count - 1];
                            if (lastSnippet.EndSnippet < 0) {
                                lastSnippet.EndSnippet = lastSnippetNum;
                            }
                        }
                        if (ConfList.Count > 0) {
                            var lastSnippet = ConfList[ConfList.Count - 1];
                            if (lastSnippet.EndSnippet < 0) {
                                lastSnippet.EndSnippet = lastSnippetNum;
                            }
                        }
                        for (var i = 0; i < Math.Max(DispList.Count, ConfList.Count); i++) {
                            if (i < DispList.Count) {
                                analysisOutputWriter.Write(DispList[i].BeginSnippet + "," + DispList[i].EndSnippet +
                                                           ",,");
                            }
                            else {
                                analysisOutputWriter.Write(",,,");
                            }
                            if (i < ConfList.Count) {
                                analysisOutputWriter.Write(ConfList[i].BeginSnippet + "," + ConfList[i].EndSnippet);
                            }
                            analysisOutputWriter.WriteLine();
                        }
                    }
                }
                runResult = "Finished processing file";
            }
            catch (ArgumentException ex) {
                MessageBox.Show(ex.Message);
            }
            catch (PathTooLongException ex) {
                MessageBox.Show(ex.Message);
            }
            catch (DirectoryNotFoundException ex) {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex) {
                MessageBox.Show(ex.Message);
            }
            catch (NotSupportedException ex) {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex) {
                MessageBox.Show("Error running analysis\n" + ex);
            }
            finally {
                Debug.Print(runResult);
                MethodInvoker m = () => { RunResult.Text = runResult; };
                if (InvokeRequired) { Invoke(m); }
                else m();
            }
        }

        private void RunEmulationInterleaved(BinaryReader binRdr) {
            var pos = 0;
            var vals = new ushort[2];
            while (true) {
                for (var i = 0; i < vals.Length; i++) {
                    if (!ReadNext(binRdr, ref pos, out vals[i])) { return; }
                }

                DisplacementAnalysis.Analyze(vals[0], vals[1]);
                //Thread.Sleep(_sampleIntervalMicroSec / 1000);
            }
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

                DisplacementAnalysis.Analyze(vals[0], vals[1]);
                //Thread.Sleep(_sampleIntervalMicroSec / 1000);
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


        private static bool ReadNext(BinaryReader binRdr, ref int pos, out ushort outval) {
            outval = ushort.MaxValue;
            if (pos + 1 > binRdr.BaseStream.Length) {
                return false;
            }
            outval = binRdr.ReadUInt16();
            pos += sizeof(UInt16);
            return true;
        }

        /// <summary>
        /// Called when displacing changes
        /// </summary>
        /// <remarks>The range for displacement extends from snippetNumber when displacing=True thru snippetNumber-1 when displacing=False</remarks>
        /// <param name="displacing">True iff displacing in snippet</param>
        /// <param name="snippetNumber">Snippet number</param>
        private static void DisplacementCallback(bool displacing, long snippetNumber) {
            switch (displacing) {
                case true:
                    _dispRange = new SnippetRange(snippetNumber);
                    DispList.Add(_dispRange);
                    break;
                case false:
                    if (_dispRange.EndSnippet >= 0) { return; }
                    _dispRange.EndSnippet = snippetNumber - 1;
                    break;
            }
        }
        private static SnippetRange _dispRange;

        /// <summary>
        /// Called when confirming changes
        /// </summary>
        /// <remarks>The range for confirming extends from snippetNumber when confirming=True thru snippetNumber-1 when confirming=False</remarks>
        /// <param name="confirming">True iff confirming in M of the last N snippets</param>
        /// <param name="snippetNumber">Snippet number</param>
        private static void ConfirmationCallback(bool confirming, long snippetNumber) {
            switch (confirming) {
                case true:
                    _confRange = new SnippetRange(snippetNumber);
                    ConfList.Add(_confRange);
                    break;
                case false:
                    if (_confRange.EndSnippet >= 0) { return; }
                    _confRange.EndSnippet = snippetNumber - 1;
                    break;
            }
        }
        private static SnippetRange _confRange;

        private class SnippetRange {
            public long BeginSnippet { get; private set; }
            public long EndSnippet { get; set; }
            public SnippetRange(long snippetNumber) {
                BeginSnippet = snippetNumber;
                EndSnippet = -1;
            }
        }


        private static bool CheckNonNegativeInteger(Control ctl, out int parameter, string errorMsg) {
            if (int.TryParse(ctl.Text, out parameter) && parameter >= 1) { return true; }
            MessageBox.Show(errorMsg);
            return false;
        }


    }
}
