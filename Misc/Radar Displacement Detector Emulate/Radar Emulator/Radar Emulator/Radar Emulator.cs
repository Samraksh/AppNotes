using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radar_Emulator {
    public partial class RadarEmulator : Form {
        public RadarEmulator() {
            InitializeComponent();
        }

        private void RadarEmulator_Load(object sender, EventArgs e) {

        }

        private void FileType_CheckedChanged(object sender, EventArgs e) {
            var checkBox = sender as CheckBox;
            Debug.Assert(checkBox != null, "checkBox != null");
            if (!checkBox.Checked) {
                return;
            }
            //Debug.Assert(checkBox != null, "checkBox != null");
            //var isChecked = checkBox.Checked;
            foreach (var ctl in FileType.Controls.OfType<CheckBox>()) {
                if (ctl != checkBox) {
                    ctl.Checked = false;
                }
            }
        }
    }
}
