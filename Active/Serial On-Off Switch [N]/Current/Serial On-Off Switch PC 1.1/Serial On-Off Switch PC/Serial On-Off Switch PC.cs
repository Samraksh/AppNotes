/*--------------------------------------------------------------------
See Program.cs for release info.
---------------------------------------------------------------------*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_On_Off_Switch_PC {

   /// <summary>
   /// This PC client program interacts with an eMote .NOW server via the serial port.
   /// Communication is bi-directional:
   ///      The mote server sends messages about switch state to the PC client, which are displayed in a text box.
   ///      The user can make the PC client turn the message transmission on or off.
   /// </summary>
    public partial class SerialOnOffPC : Form {

        private SerialComm serialComm = null;   // The serial comm object
        private bool serialStarted = false;     // True iff serial port has been opened and thread started
        private bool moteSwitchEnabled = true;  // True iff the mote switch is enabled

        /// <summary>
        /// Initializer
        /// </summary>
        public SerialOnOffPC() {
            InitializeComponent();
        }

        /// <summary>
        /// Load the form
        /// </summary>
        private void SerialOnOffPC_Load(object sender, EventArgs e) {
            // Get the list of serial ports
            RefreshSerialPortList_Click(new object(), new EventArgs());
        }

        /// <summary>
        /// A call-back method that's called by SerialComm whenever serial data has been received from the mote
        /// </summary>
        /// <param name="input">The data received</param>
        private void ProcessInput(string input) {
            // We have to use a method invoker to avoid cross-thread issues
            MethodInvoker m = new MethodInvoker(() => {
                // Append the received data to the textbox
                FromMote.AppendText(input);
            });
            if (FromMote.InvokeRequired) {
                FromMote.Invoke(m);
            }
            else {
                m();
            }
        }

        /// <summary>
        /// Start or stop the serial comm
        /// </summary>
        private void StartStop_Click(object sender, EventArgs e) {
            StartStop.Enabled = false;
            // If serial started, stop it
            if (serialStarted) {
                // Note that stopped
                serialStarted = false;
                // Stop serial
                if (serialComm != null) {
                    serialComm.Stop();
                }
                // Change control
                StartStop.Text = "Click to Enable Serial";
                StartStop.BackColor = Color.LightCoral;
            }
            // If serial stopped, start it
            else {
                string portName = SerialPortList.SelectedItem.ToString();
                serialComm = new SerialComm(portName, ProcessInput);
                // Try to start. If cannot open, give error message.
                if (!serialComm.Start()) {
                    ErrorMessages.AppendText("Cannot open serial port " + portName + "\n");
	                StartStop.Enabled = true;
                    return;
                }
                // Note that started and change control
                serialStarted = true;
                StartStop.Text = "Click to Disable Serial";
                StartStop.BackColor = Color.YellowGreen;
            }
            StartStop.Enabled = true;
        }

        /// <summary>
        /// Enable or disable mote switch
        /// </summary>
        /// <remarks>
        /// This sends messages to the mote instructing it to send or not send switch input
        /// </remarks>
        private void EnableDisableMoteSwitch_Click(object sender, EventArgs e) {
            if (!serialStarted || serialComm == null) {
                return;
            }
            EnableDisableMoteSwitch.Enabled = false;
            // If mote switch is enabled then disable (send "0") and change control
            if (moteSwitchEnabled) {
                moteSwitchEnabled = false;
                serialComm.Write("0");
                EnableDisableMoteSwitch.Text = "Click to Enable Mote Switch";
                EnableDisableMoteSwitch.BackColor = Color.LightCoral;
            }
            // if mote switch is disabled then enable (send "1") and change control
            else {
                moteSwitchEnabled = true;
                serialComm.Write("1");
                EnableDisableMoteSwitch.Text = "Click to Disable Mote Switch";
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
            SerialPortList.DataSource = SerialPort.GetPortNames();
        }
    }
}
