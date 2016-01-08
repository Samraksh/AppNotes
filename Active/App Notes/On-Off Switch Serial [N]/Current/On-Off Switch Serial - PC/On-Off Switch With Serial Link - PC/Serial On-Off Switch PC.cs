﻿/*--------------------------------------------------------------------
See Program.cs for release info.
---------------------------------------------------------------------*/


using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace Serial_On_Off_Switch_PC {

	/// <summary>
	/// This PC client program interacts with an eMote .NOW server via the serial port.
	/// Communication is bi-directional:
	///      The mote server sends messages about switch state to the PC client, which are displayed in a text box.
	///      The user can make the PC client turn the message transmission on or off.
	/// </summary>
	public partial class SerialOnOffPc : Form {

		private const int MaxSerialPortNumber = 8;

		private SerialComm _serialComm;   // The serial comm object
		private bool _serialStarted;     // True iff serial port has been opened and thread started
		private bool _moteSwitchEnabled = true;  // True iff the mote switch is enabled

		/// <summary>
		/// Initializer
		/// </summary>
		public SerialOnOffPc() {
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
			MethodInvoker m = () => {
				// Append the received data to the textbox
				FromMote.AppendText(input);
			};
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
			if (_serialStarted) {
				// Note that stopped
				_serialStarted = false;
				// Stop serial
				if (_serialComm != null) {
					_serialComm.Stop();
				}
				// Change control
				StartStop.Text = "Click to Enable Serial";
				StartStop.BackColor = Color.LightCoral;
			}
			// If serial stopped, start it
			else {
				var selectedComPort = SerialPortList.SelectedItem.ToString().ToUpper();
				var comPortNumberStr = selectedComPort.Replace("COM", string.Empty);
				int comPortNumber;
				var retVal = int.TryParse(comPortNumberStr, out comPortNumber);
				if (!retVal) {
					MessageBox.Show(string.Format("Cannot get port number from selected item {0}", selectedComPort), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (comPortNumber > MaxSerialPortNumber) {
					MessageBox.Show(string.Format("Port numbers above {0} probably can't be opened", MaxSerialPortNumber), "Warning", MessageBoxButtons.OK,
						MessageBoxIcon.Warning);
				}
				var portName = selectedComPort;
				_serialComm = new SerialComm(portName, ProcessInput);
				// Try to start. If cannot open, give error message.
				if (!_serialComm.Start()) {
					ErrorMessages.AppendText("Cannot open serial port " + portName + "\n");
					StartStop.Enabled = true;
					return;
				}
				// Note that started and change control
				_serialStarted = true;
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
			if (!_serialStarted || _serialComm == null) {
				return;
			}
			EnableDisableMoteSwitch.Enabled = false;
			// If mote switch is enabled then disable (send "0") and change control
			if (_moteSwitchEnabled) {
				_moteSwitchEnabled = false;
				_serialComm.Write("0");
				EnableDisableMoteSwitch.Text = "Click to Enable Mote Switch";
				EnableDisableMoteSwitch.BackColor = Color.LightCoral;
			}
			// if mote switch is disabled then enable (send "1") and change control
			else {
				_moteSwitchEnabled = true;
				_serialComm.Write("1");
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
