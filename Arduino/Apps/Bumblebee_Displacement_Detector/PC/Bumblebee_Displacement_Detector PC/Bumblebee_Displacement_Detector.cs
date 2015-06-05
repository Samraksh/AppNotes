using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Samraksh.AppNote.Utility;

namespace Samraksh.AppNotes.Arduino.DisplacementDetection {

	public partial class DisplacementDetection : Form {

		//private const int SerialBitRate = 230400;
		private const int SerialBitRate = 400000;

		private static class InMsg {
			public static class ColumnNames {
				public const string Prefix = "#1";
			}

			public static class Detects {
				public const string Prefix = "#2";
				public const int Length = 5;
			}

			public static class ParamMsg {
				public const string Prefix = "#3";
				public const int Length = 3;
			}

			public static class ValidationInputs {
				public const string Prefix = "#4";
				public const int Length = 12;
			}

			public static class InputsDetects {
				public const string Prefix = "#5";
				public const int Length = 7;
			}
		}

		private static class OutMsgPrefix {
			public const string ReqParam = "*1";
		}

		private static class MsgParamName {
			public const string SampRate = "SampRate";
			public const string MinCumCuts = "MinCumCuts";
			public const string ConfM = "M";
			public const string ConfN = "N";
		}

		private SerialComm _serialComm;   // The serial comm object
		private bool _serialStarted;     // True iff serial port has been opened and thread started

		private readonly SystemSound _playDisp = SystemSounds.Hand;
		private readonly SystemSound _playConf = SystemSounds.Exclamation;

		private TextWriter _logFile;


		public DisplacementDetection() {
			InitializeComponent();
		}

		private void DisplacementDetection_Load(object sender, EventArgs e) {
			SerialPortList.Text = string.Empty;
			SerialPortList.DataSource = SerialPort.GetPortNames();

			LogToFileButton.Tag = false;
			//LogToFileFolder.Text =  Settings.Default.LogFolder;

			// Redundant qualifier: http://www.codeproject.com/Articles/17659/How-To-Use-the-Settings-Class-in-C
			// ReSharper disable once RedundantNameQualifier
			LogToFileFolder.Text = Samraksh.AppNotes.Arduino.DisplacementDetection.Properties.Settings.Default.LogFolder;

			_playDisp.Play();
			Thread.Sleep(1000);
			_playConf.Play();

		}


		/// <summary>
		/// Refresh the list of serial port names
		/// </summary>
		private void RefreshSerialPortList_Click(object sender, EventArgs e) {
			SerialPortList.Text = string.Empty;
			SerialPortList.DataSource = SerialPort.GetPortNames();
		}

		/// <summary>
		/// Start or stop the serial comm
		/// </summary>
		private void StartStop_Click(object sender, EventArgs e) {
			StartStop.Enabled = false;
			// Hide Disp & Conf (using MethodInvoker to avoid cross-thread issues)
			MethodInvoker m = () => Disp.Visible = Conf.Visible = false;
			if (InvokeRequired) { m.Invoke(); }
			else { m(); }
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
				RefreshParams.Enabled = false;
			}
			// If serial stopped, start it
			else {
				var portName = SerialPortList.SelectedItem.ToString();
				_serialComm = new SerialComm(ProcessInput, portName, SerialBitRate);
				// Try to start. If cannot open, give error message.
				Exception ex;
				if ((ex = _serialComm.Start()) != null) {
					MessagesTextBox.AppendText("Cannot open serial port " + portName + "\n" + ex + "\n");
					StartStop.Enabled = true;
					RefreshParams.Enabled = false;
					return;
				}
				// Note that started and change control
				_serialStarted = true;
				StartStop.Text = "Click to Disable Serial";
				StartStop.BackColor = Color.YellowGreen;
				RefreshParams.Enabled = true;
				// Request parameters
				_serialComm.Write(OutMsgPrefix.ReqParam + "\n");
			}
			StartStop.Enabled = true;
		}

		/// <summary>
		/// A call-back method that's called by SerialComm whenever serial data has been received from the mote
		/// </summary>
		/// <param name="input">The data received</param>
		private void ProcessInput(string input) {
			var isDisp = false;
			var isConf = false;
			MethodInvoker m;
			foreach (var theChar in input.ToCharArray()) {
				if (theChar == '\n') {
					var foundString = FoundStringB.ToString().Trim('\r').Trim('\n');
					var lineItems = foundString.Split(',');
					if (lineItems.Length == InMsg.Detects.Length && lineItems[0] == InMsg.Detects.Prefix) {
						isDisp = (lineItems[lineItems.Length - 2] == "1");
						isConf = (lineItems[lineItems.Length - 1] == "1");
					}
					// Process the message types
					switch (lineItems[0]) {
						case InMsg.ValidationInputs.Prefix:
							try {
								if (lineItems.Length == InMsg.ValidationInputs.Length) {
									//isDisp = (lineItems[lineItems.Length - 2] == "1");
									//isConf = (lineItems[lineItems.Length - 1] == "1");
									var sampleNo = Convert.ToInt32(lineItems[1]);
									var sampI = Convert.ToInt32(lineItems[6]);
									var sampQ = Convert.ToInt32(lineItems[7]);
									CheckSampleValue(sampI, sampQ, sampleNo);
								}
								else {
									throw new Exception(string.Format("{0} len: {1}; sb {2}", lineItems[0], lineItems.Length, InMsg.ValidationInputs.Length));
								}
							}
							catch (Exception ex) {
								m = () => MessagesTextBox.AppendText(string.Format("Error: {0}; {1}\n", ex.Message, foundString));
								if (InvokeRequired) { Invoke(m); }
								else { m(); }
							}
							break;

						case InMsg.InputsDetects.Prefix:
							try {
								if (lineItems.Length == InMsg.InputsDetects.Length) {
									//var sampleNo = Convert.ToInt32(lineItems[1]);
									//var sampI = Convert.ToInt32(lineItems[2]);
									//var sampQ = Convert.ToInt32(lineItems[3]);
									//CheckSampleValue(sampI, sampQ, sampleNo);
									isDisp = (lineItems[lineItems.Length - 2] == "1");
									isConf = (lineItems[lineItems.Length - 1] == "1");
								}
								else {
									throw new Exception(string.Format("{0} len: {1}; sb {2}", lineItems[0], lineItems.Length, InMsg.InputsDetects.Length));
								}
							}
							catch (Exception ex) {
								m = () => MessagesTextBox.AppendText(string.Format("Error: {0}; {1}\n", ex.Message, foundString));
								if (InvokeRequired) { Invoke(m); }
								else { m(); }
							}
							break;

						case InMsg.ParamMsg.Prefix:
							try {
								if (lineItems.Length == InMsg.ParamMsg.Length) {
									var label = lineItems[1];
									var val = lineItems[2];
									m = null;
									switch (label) {
										case MsgParamName.SampRate:
											m = () => { SampleRate.Text = val; };
											break;
										case MsgParamName.MinCumCuts:
											m = () => { MinCumCuts.Text = val; };
											break;
										case MsgParamName.ConfM:
											m = () => { ConfM.Text = val; };
											break;
										case MsgParamName.ConfN:
											m = () => { ConfN.Text = val; };
											break;
									}
									if (m != null) {
										if (InvokeRequired) {
											Invoke(m);
										}
										else {
											m();
										}
									}
								}
								else {
									throw new Exception(string.Format("{0} len: {1}; sb {2}", lineItems[0], lineItems.Length, InMsg.ValidationInputs.Length));
								}
							}
							catch (Exception ex) {
								m = () => MessagesTextBox.AppendText(string.Format("Error: {0}; {1}\n", ex.Message, foundString));
								if (InvokeRequired) {
									Invoke(m);
								}
								else {
									m();
								}
							}
							break;
					}


					// Give audio alerts
					//if (isDisp) {
					//	_playDisp.Play();
					//}
					//if (isConf) {
					//	_playConf.Play();
					//}

					// We use a method invoker to avoid cross-thread issues
					var disp = isDisp;
					var conf = isConf;
					m = () => {
						var logString = DateTime.Now.ToString("hh:mm:ss,") + foundString;
						// If detail message, only put to text box for the first sample of a snippet (assume 250 samples/snippet)
						//	This speeds things up and helps prevent data loss
						if (lineItems[0] == InMsg.ValidationInputs.Prefix || lineItems[0] == InMsg.InputsDetects.Prefix) {
							try {
								int sampNum;
								Int32.TryParse(lineItems[1], out sampNum);
								if (Int32.TryParse(lineItems[1], out sampNum) && sampNum % 250 == 1) {
									FromMoteTextBox.AppendText(logString + "\n");
								}
							}
							// ReSharper disable once EmptyGeneralCatchClause
							catch { }
						}
						else {
							FromMoteTextBox.AppendText(logString + "\n");
						}
						if ((bool)LogToFileButton.Tag) {
							_logFile.Write(logString + "\r\n");
						}
						Disp.Visible = disp;
						Conf.Visible = conf;
						//Debug.Print("{0}, {1}", Conf.Enabled, Conf.ForeColor);
					};
					if (FromMoteTextBox.InvokeRequired) { FromMoteTextBox.Invoke(m); }
					else { m(); }
					FoundStringB.Clear();
					return;
				}
				FoundStringB.Append(theChar);
			}
		}

		private void CheckSampleValue(int sampI, int sampQ, int sampleNo) {
			if ((sampI >= 0 || sampQ >= 0) && (sampI < 0 || sampQ < 0)) { return; }
			MethodInvoker m =
				() =>
					MessagesTextBox.AppendText(string.Format("Error: Bad sample values. Sample No {0}, I = {1}, Q = {2}\n", sampleNo,
						sampI, sampQ));
			if (InvokeRequired) {
				Invoke(m);
			}
			else {
				m();
			}
		}

		private static readonly StringBuilder FoundStringB = new StringBuilder();


		/// <summary>
		/// Clear the messages
		/// </summary>
		private void ClearMessages_Click(object sender, EventArgs e) {
			MessagesTextBox.Clear();
		}

		/// <summary>
		/// Clear data received from mote
		/// </summary>
		private void ClearFromMote_Click(object sender, EventArgs e) {
			FromMoteTextBox.Clear();
		}

		private void RefreshParams_Click(object sender, EventArgs e) {
			_serialComm.Write(OutMsgPrefix.ReqParam + "\n");
		}

		private void LogToFileBrowse_Click(object sender, EventArgs e) {
			folderBrowserDialog1.SelectedPath = LogToFileFolder.Text;
			if (folderBrowserDialog1.ShowDialog() != DialogResult.OK) return;
			LogToFileFolder.Text = folderBrowserDialog1.SelectedPath;
			// ReSharper disable once RedundantNameQualifier
			Samraksh.AppNotes.Arduino.DisplacementDetection.Properties.Settings.Default.LogFolder = LogToFileFolder.Text;
			// ReSharper disable once RedundantNameQualifier
			Samraksh.AppNotes.Arduino.DisplacementDetection.Properties.Settings.Default.Save();
		}

		private void LogToFileButton_Click(object sender, EventArgs e) {
			if ((bool)LogToFileButton.Tag) {
				LogToFileButton.Tag = false;
				LogToFileButton.Text = "Log to file";
				_logFile.Close();
			}
			else {
				if (!Directory.Exists(LogToFileFolder.Text)) {
					MessageBox.Show("Folder is invalid");
					return;
				}
				// ReSharper disable once RedundantNameQualifier
				Samraksh.AppNotes.Arduino.DisplacementDetection.Properties.Settings.Default.LogFolder = LogToFileFolder.Text;
				// ReSharper disable once RedundantNameQualifier
				Samraksh.AppNotes.Arduino.DisplacementDetection.Properties.Settings.Default.Save();
				var newFile = Path.Combine(LogToFileFolder.Text, DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss") + " Arduino Displacement Detector.log");
				_logFile = new StreamWriter(newFile);

				LogToFileButton.Tag = true;
				LogToFileButton.Text = "Stop logging";
			}
		}

		///// <summary>
		///// Enable or disable mote switch
		///// </summary>
		///// <remarks>
		///// This sends messages to the mote instructing it to send or not send switch input
		///// </remarks>
		//private void EnableDisableMoteSwitch_Click(object sender, EventArgs e) {
		//	if (!_serialStarted || _serialComm == null) {
		//		return;
		//	}
		//	EnableDisableMoteSwitch.Enabled = false;
		//	// If mote switch is enabled then disable (send "0") and change control
		//	if (_moteSwitchEnabled) {
		//		_moteSwitchEnabled = false;
		//		_serialComm.Write("0");
		//		EnableDisableMoteSwitch.Text = "Click to Enable Mote Switch";
		//		EnableDisableMoteSwitch.BackColor = Color.LightCoral;
		//	}
		//	// if mote switch is disabled then enable (send "1") and change control
		//	else {
		//		_moteSwitchEnabled = true;
		//		_serialComm.Write("1");
		//		EnableDisableMoteSwitch.Text = "Click to Disable Mote Switch";
		//		EnableDisableMoteSwitch.BackColor = Color.YellowGreen;
		//	}
		//	EnableDisableMoteSwitch.Enabled = true;
		//}
	}
}
