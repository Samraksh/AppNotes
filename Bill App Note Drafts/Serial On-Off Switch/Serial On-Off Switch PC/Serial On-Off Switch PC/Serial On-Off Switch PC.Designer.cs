namespace Serial_On_Off_Switch_PC {
    partial class SerialOnOffPC {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.SerialPortList = new System.Windows.Forms.ComboBox();
            this.StartStop = new System.Windows.Forms.Button();
            this.ClearFromMote = new System.Windows.Forms.Button();
            this.EnableDisableMote = new System.Windows.Forms.Button();
            this.FromMote = new System.Windows.Forms.TextBox();
            this.ErrorMessages = new System.Windows.Forms.TextBox();
            this.ClearErrorMessages = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SerialPortName
            // 
            this.SerialPortList.FormattingEnabled = true;
            this.SerialPortList.Location = new System.Drawing.Point(36, 35);
            this.SerialPortList.Name = "SerialPortName";
            this.SerialPortList.Size = new System.Drawing.Size(121, 21);
            this.SerialPortList.TabIndex = 0;
            // 
            // StartStop
            // 
            this.StartStop.AutoSize = true;
            this.StartStop.BackColor = System.Drawing.Color.LightCoral;
            this.StartStop.Location = new System.Drawing.Point(187, 35);
            this.StartStop.Name = "StartStop";
            this.StartStop.Size = new System.Drawing.Size(117, 23);
            this.StartStop.TabIndex = 1;
            this.StartStop.Text = "Click to Enable Serial";
            this.StartStop.UseVisualStyleBackColor = false;
            this.StartStop.Click += new System.EventHandler(this.StartStop_Click);
            // 
            // ClearFromMote
            // 
            this.ClearFromMote.Location = new System.Drawing.Point(36, 287);
            this.ClearFromMote.Name = "ClearFromMote";
            this.ClearFromMote.Size = new System.Drawing.Size(75, 23);
            this.ClearFromMote.TabIndex = 3;
            this.ClearFromMote.Text = "Clear";
            this.ClearFromMote.UseVisualStyleBackColor = true;
            this.ClearFromMote.Click += new System.EventHandler(this.ClearFromMote_Click);
            // 
            // EnableDisableMote
            // 
            this.EnableDisableMote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EnableDisableMote.AutoSize = true;
            this.EnableDisableMote.BackColor = System.Drawing.Color.GreenYellow;
            this.EnableDisableMote.Location = new System.Drawing.Point(385, 35);
            this.EnableDisableMote.Name = "EnableDisableMote";
            this.EnableDisableMote.Size = new System.Drawing.Size(152, 23);
            this.EnableDisableMote.TabIndex = 4;
            this.EnableDisableMote.Text = "Click to Disable Mote Switch";
            this.EnableDisableMote.UseVisualStyleBackColor = false;
            this.EnableDisableMote.Click += new System.EventHandler(this.EnableDisableMote_Click);
            // 
            // FromMote
            // 
            this.FromMote.Location = new System.Drawing.Point(36, 79);
            this.FromMote.Multiline = true;
            this.FromMote.Name = "FromMote";
            this.FromMote.ReadOnly = true;
            this.FromMote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FromMote.Size = new System.Drawing.Size(268, 190);
            this.FromMote.TabIndex = 5;
            // 
            // ErrorMessages
            // 
            this.ErrorMessages.Location = new System.Drawing.Point(334, 79);
            this.ErrorMessages.Multiline = true;
            this.ErrorMessages.Name = "ErrorMessages";
            this.ErrorMessages.ReadOnly = true;
            this.ErrorMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ErrorMessages.Size = new System.Drawing.Size(203, 190);
            this.ErrorMessages.TabIndex = 6;
            // 
            // ClearErrorMessages
            // 
            this.ClearErrorMessages.Location = new System.Drawing.Point(334, 287);
            this.ClearErrorMessages.Name = "ClearErrorMessages";
            this.ClearErrorMessages.Size = new System.Drawing.Size(75, 23);
            this.ClearErrorMessages.TabIndex = 7;
            this.ClearErrorMessages.Text = "Clear";
            this.ClearErrorMessages.UseVisualStyleBackColor = true;
            this.ClearErrorMessages.Click += new System.EventHandler(this.ClearErrorMessages_Click);
            // 
            // SerialOnOffPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 335);
            this.Controls.Add(this.ClearErrorMessages);
            this.Controls.Add(this.ErrorMessages);
            this.Controls.Add(this.FromMote);
            this.Controls.Add(this.EnableDisableMote);
            this.Controls.Add(this.ClearFromMote);
            this.Controls.Add(this.StartStop);
            this.Controls.Add(this.SerialPortList);
            this.Name = "SerialOnOffPC";
            this.Text = "Serial On-Off - PC";
            this.Load += new System.EventHandler(this.SerialOnOffPC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SerialPortList;
        private System.Windows.Forms.Button StartStop;
        private System.Windows.Forms.Button ClearFromMote;
        private System.Windows.Forms.Button EnableDisableMote;
        private System.Windows.Forms.TextBox FromMote;
        private System.Windows.Forms.TextBox ErrorMessages;
        private System.Windows.Forms.Button ClearErrorMessages;
    }
}

