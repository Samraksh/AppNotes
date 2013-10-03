using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_On_Off_Switch_PC {
    public partial class SerialOnOffPC : Form {

        SerialComm serialComm = null;

        public SerialOnOffPC() {
            InitializeComponent();
        }

        private void SerialOnOffPC_Load(object sender, EventArgs e) {

            // Get the list of serial ports
            SerialPortList.DataSource = SerialPort.GetPortNames();

        }

        private void ProcessInput(string input) {
            FromMote.AppendText(input);
        }

        private bool started = false;
        private void StartStop_Click(object sender, EventArgs e) {
            if (started) {
            }
            else {
                string portName = SerialPortList.SelectedItem.ToString();
            }
        }

        private void EnableDisableMote_Click(object sender, EventArgs e) {

        }

        private void ClearFromMote_Click(object sender, EventArgs e) {
            FromMote.Clear();
        }

        private void ClearErrorMessages_Click(object sender, EventArgs e) {
            ErrorMessages.Clear();
        }
    }
}
