/*--------------------------------------------------------------------
See Program.cs for release info.
---------------------------------------------------------------------*/


using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

//namespace Serial_On_Off_Switch_PC {
using Utility;

namespace Samraksh.AppNote.DotNow.DataCollectorExfiltrator {

    /// <summary>
    /// This PC client program interacts with an eMote .NOW server via the serial port.
    /// Communication is bi-directional:
    ///      The mote server sends messages about switch state to the PC client, which are displayed in a text box.
    ///      The user can make the PC client turn the message transmission on or off.
    /// </summary>
    public partial class ExfiltratePc : Form {

        //private SerialPort _serialComm;   // The serial comm object
        private SerialReadLineeMote _serial;
        //private bool _serialStarted;     // True iff serial port has been opened and thread started
        private bool _moteSwitchEnabled = true;  // True iff the mote switch is enabled
        private StreamWriter _outputFile;
        private bool _writingToFile;
        private const string DataPrefix = "#$ ";


        /// <summary>
        /// Initializer
        /// </summary>
        public ExfiltratePc() {
            InitializeComponent();
        }

        /// <summary>
        /// Load the form
        /// </summary>
        private void ExfiltratePc_Load(object sender, EventArgs e) {
            // Get the list of serial ports
            RefreshSerialPortList_Click(new object(), new EventArgs());
        }

        /// <summary>
        /// A call-back method that's called by SerialComm whenever serial data has been received from the mote
        /// </summary>
        private void ProcessInput(string lineReadIn) {
            if (lineReadIn == null) {
                return;
            }

            if (!lineReadIn.StartsWith(DataPrefix)) {
                return;
            }

            var lineRead = lineReadIn.Substring(DataPrefix.Length, lineReadIn.Length - DataPrefix.Length);

            // We have to use a method invoker to avoid cross-thread issues
            var m = new MethodInvoker(() => FromMote.AppendText(lineRead + "\n"));
            if (FromMote.InvokeRequired) { FromMote.Invoke(m); } else { m(); }

            // Race condition can cause the object to be disposed
            try {
                _outputFile.WriteLine(lineRead);
            }
            catch (ObjectDisposedException) { 
            }

        }

        ///// <summary>
        ///// Start or stop the serial comm
        ///// </summary>
        //private void SerialStartStop_Click(object sender, EventArgs e) {
        //    try {
        //        SerialStartStop.Enabled = false;
        //        // If serial started, stop it
        //        if (_serialStarted) {
        //            // Note that stopped
        //            _serialStarted = false;
        //            // Stop serial
        //            _serial.Stop();
        //            // Change control
        //            SerialStartStop.Text = "Connect";
        //            SerialStartStop.BackColor = Color.LightCoral;
        //        }
        //        // If serial stopped, start it
        //        else {
        //            var portName = SerialPortList.SelectedItem.ToString();
        //            _serial = new SerialReadLineeMote(portName, ProcessInput);
        //            // Try to start. If cannot open, give error message.
        //            if (!_serial.Start()) {
        //                ErrorMessages.AppendText("Cannot open serial port " + portName + "\n");
        //                return;
        //            }
        //            // Note that started and change control
        //            _serialStarted = true;
        //            SerialStartStop.Text = "Disconnect";
        //            SerialStartStop.BackColor = Color.YellowGreen;
        //        }
        //    }
        //    finally {
        //        SerialStartStop.Enabled = true;
        //    }
        //}

        /// <summary>
        /// Enable or disable mote switch
        /// </summary>
        /// <remarks>
        /// This sends messages to the mote instructing it to send or not send switch input
        /// </remarks>
        private void EnableDisableMoteSwitch_Click(object sender, EventArgs e) {
            //if (!_serialStarted || _serial == null) {
            //    return;
            //}
            EnableDisableMoteSwitch.Enabled = false;
            // If mote switch is enabled then disable (send "0") and change control
            if (_moteSwitchEnabled) {
                _moteSwitchEnabled = false;
                _serial.Write("0");
                EnableDisableMoteSwitch.Text = "Receive Input";
                EnableDisableMoteSwitch.BackColor = Color.LightCoral;
            }
            // if mote switch is disabled then enable (send "1") and change control
            else {
                _moteSwitchEnabled = true;
                _serial.Write("1");
                EnableDisableMoteSwitch.Text = "Stop Receiving Input";
                EnableDisableMoteSwitch.BackColor = Color.YellowGreen;
            }
            EnableDisableMoteSwitch.Enabled = true;
        }

        /// <summary>
        /// Clear the messages received from the mote
        /// </summary>
        private void ClearFromMote_Click(object sender, EventArgs e) {
            FromMote.Clear();
        }

        /// <summary>
        /// Clear the any error messages
        /// </summary>
        private void ClearErrorMessages_Click(object sender, EventArgs e) {
            ErrorMessages.Clear();
        }

        /// <summary>
        /// Refresh the list of serial port names
        /// </summary>
        private void RefreshSerialPortList_Click(object sender, EventArgs e) {
            SerialPortList.Text = string.Empty;
            var portNames = SerialPort.GetPortNames();
            Array.Sort<string>(portNames);
            SerialPortList.DataSource = portNames;
        }


        private void BtnStartPause_Click(object sender, EventArgs e) {
            switch ((string)BtnStartPause.Tag) {
                case "Start":
                    DoStart();
                    break;
                case "Pause":
                    DoPause();
                    break;
            }

        }


        private void DoStart() {
            BtnStartPause.Tag = "Pause";
            BtnStartPause.Image = Properties.Resources.Pause_Normal;
            BtnStop.Image = Properties.Resources.Stop_Normal;
            BtnStop.Enabled = true;

            if (!File.Exists(OutputFile.Text)) {
                MessageBox.Show("Output file does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            try {
                if (_outputFile == null) {
                    _outputFile = new StreamWriter(OutputFile.Text);
                }
                _writingToFile = true;
            }
            catch (Exception ex) {
                ErrorMessages.AppendText("Cannot write to file " + OutputFile.Text + "\n" + ex);
                System.Media.SystemSounds.Exclamation.Play();
                return;
            }

            if (_serial == null) {
                var portName = SerialPortList.SelectedItem.ToString();
                _serial = new SerialReadLineeMote(portName, ProcessInput);
                // Try to start. If cannot open, give error message.
                if (!_serial.Start()) {
                    ErrorMessages.AppendText("Cannot open serial port " + portName + "\n");
                    return;
                }
            }
        }

        private void DoPause() {
            BtnStartPause.Tag = "Start";
            _writingToFile = false;
            BtnStartPause.Image = Properties.Resources.Play_Normal;
        }

        private void BtnStop_Click(object sender, EventArgs e) {
            DoStop();
        }

        private void DoStop() {
            _serial.Stop();
            _writingToFile = false;
            _outputFile.Close();
            BtnStop.Image = Properties.Resources.Stop_Disabled;
            BtnStop.Enabled = false;
            BtnStartPause.Tag = "Start";
            BtnStartPause.Image = Properties.Resources.Play_Normal;
        }

        private void BrowseForOutputFile_Click(object sender, EventArgs e) {
            var browser = new SaveFileDialog {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                CreatePrompt = true,
                Title = "Output File",
                OverwritePrompt = true,
            };
            if (browser.ShowDialog() == DialogResult.OK) {
                OutputFile.Text = browser.FileName;
            }
        }
    }
}
