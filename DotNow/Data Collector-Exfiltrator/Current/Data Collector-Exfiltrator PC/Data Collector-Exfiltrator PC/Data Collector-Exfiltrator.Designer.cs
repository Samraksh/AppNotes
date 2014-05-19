
//namespace Serial_On_Off_Switch_PC {
    namespace Samraksh.AppNote.DotNow.DataCollectorExfiltrator{
    partial class ExfiltratePc {
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
            this.ClearFromMote = new System.Windows.Forms.Button();
            this.EnableDisableMoteSwitch = new System.Windows.Forms.Button();
            this.FromMote = new System.Windows.Forms.TextBox();
            this.ErrorMessages = new System.Windows.Forms.TextBox();
            this.ClearErrorMessages = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OutputFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BrowseForOutputFile = new System.Windows.Forms.Button();
            this.BtnStartPause = new System.Windows.Forms.PictureBox();
            this.RefreshSerialPortList = new System.Windows.Forms.PictureBox();
            this.BtnStop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BtnStartPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshSerialPortList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnStop)).BeginInit();
            this.SuspendLayout();
            // 
            // SerialPortList
            // 
            this.SerialPortList.FormattingEnabled = true;
            this.SerialPortList.Location = new System.Drawing.Point(64, 43);
            this.SerialPortList.Margin = new System.Windows.Forms.Padding(4);
            this.SerialPortList.Name = "SerialPortList";
            this.SerialPortList.Size = new System.Drawing.Size(160, 24);
            this.SerialPortList.TabIndex = 0;
            // 
            // ClearFromMote
            // 
            this.ClearFromMote.Location = new System.Drawing.Point(48, 471);
            this.ClearFromMote.Margin = new System.Windows.Forms.Padding(4);
            this.ClearFromMote.Name = "ClearFromMote";
            this.ClearFromMote.Size = new System.Drawing.Size(100, 28);
            this.ClearFromMote.TabIndex = 3;
            this.ClearFromMote.Text = "Clear";
            this.ClearFromMote.UseVisualStyleBackColor = true;
            this.ClearFromMote.Click += new System.EventHandler(this.ClearFromMote_Click);
            // 
            // EnableDisableMoteSwitch
            // 
            this.EnableDisableMoteSwitch.AutoSize = true;
            this.EnableDisableMoteSwitch.BackColor = System.Drawing.Color.GreenYellow;
            this.EnableDisableMoteSwitch.Location = new System.Drawing.Point(265, 47);
            this.EnableDisableMoteSwitch.Margin = new System.Windows.Forms.Padding(4);
            this.EnableDisableMoteSwitch.Name = "EnableDisableMoteSwitch";
            this.EnableDisableMoteSwitch.Size = new System.Drawing.Size(203, 28);
            this.EnableDisableMoteSwitch.TabIndex = 4;
            this.EnableDisableMoteSwitch.Text = "Click to Disable Input";
            this.EnableDisableMoteSwitch.UseVisualStyleBackColor = false;
            this.EnableDisableMoteSwitch.Click += new System.EventHandler(this.EnableDisableMoteSwitch_Click);
            // 
            // FromMote
            // 
            this.FromMote.Location = new System.Drawing.Point(48, 212);
            this.FromMote.Margin = new System.Windows.Forms.Padding(4);
            this.FromMote.Multiline = true;
            this.FromMote.Name = "FromMote";
            this.FromMote.ReadOnly = true;
            this.FromMote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.FromMote.Size = new System.Drawing.Size(356, 233);
            this.FromMote.TabIndex = 5;
            // 
            // ErrorMessages
            // 
            this.ErrorMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorMessages.Location = new System.Drawing.Point(445, 215);
            this.ErrorMessages.Margin = new System.Windows.Forms.Padding(4);
            this.ErrorMessages.Multiline = true;
            this.ErrorMessages.Name = "ErrorMessages";
            this.ErrorMessages.ReadOnly = true;
            this.ErrorMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ErrorMessages.Size = new System.Drawing.Size(269, 233);
            this.ErrorMessages.TabIndex = 6;
            // 
            // ClearErrorMessages
            // 
            this.ClearErrorMessages.Location = new System.Drawing.Point(445, 471);
            this.ClearErrorMessages.Margin = new System.Windows.Forms.Padding(4);
            this.ClearErrorMessages.Name = "ClearErrorMessages";
            this.ClearErrorMessages.Size = new System.Drawing.Size(100, 28);
            this.ClearErrorMessages.TabIndex = 7;
            this.ClearErrorMessages.Text = "Clear";
            this.ClearErrorMessages.UseVisualStyleBackColor = true;
            this.ClearErrorMessages.Click += new System.EventHandler(this.ClearErrorMessages_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 191);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Received from Mote";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 191);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Errors";
            // 
            // OutputFile
            // 
            this.OutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputFile.Location = new System.Drawing.Point(152, 94);
            this.OutputFile.Name = "OutputFile";
            this.OutputFile.Size = new System.Drawing.Size(422, 22);
            this.OutputFile.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Output File";
            // 
            // BrowseForOutputFile
            // 
            this.BrowseForOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseForOutputFile.Location = new System.Drawing.Point(617, 92);
            this.BrowseForOutputFile.Name = "BrowseForOutputFile";
            this.BrowseForOutputFile.Size = new System.Drawing.Size(75, 23);
            this.BrowseForOutputFile.TabIndex = 13;
            this.BrowseForOutputFile.Text = "Browse";
            this.BrowseForOutputFile.UseVisualStyleBackColor = true;
            this.BrowseForOutputFile.Click += new System.EventHandler(this.BrowseForOutputFile_Click);
            // 
            // BtnStartPause
            // 
            this.BtnStartPause.Image = global::Samraksh.AppNote.DotNow.DataCollectorExfiltrator.Properties.Resources.Play_Normal;
            this.BtnStartPause.InitialImage = null;
            this.BtnStartPause.Location = new System.Drawing.Point(193, 134);
            this.BtnStartPause.Name = "BtnStartPause";
            this.BtnStartPause.Size = new System.Drawing.Size(50, 50);
            this.BtnStartPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnStartPause.TabIndex = 14;
            this.BtnStartPause.TabStop = false;
            this.BtnStartPause.Tag = "Start";
            this.BtnStartPause.Click += new System.EventHandler(this.BtnStartPause_Click);
            // 
            // RefreshSerialPortList
            // 
            this.RefreshSerialPortList.Image = global::Samraksh.AppNote.DotNow.DataCollectorExfiltrator.Properties.Resources.ButtonRefreshicon;
            this.RefreshSerialPortList.Location = new System.Drawing.Point(16, 33);
            this.RefreshSerialPortList.Margin = new System.Windows.Forms.Padding(4);
            this.RefreshSerialPortList.Name = "RefreshSerialPortList";
            this.RefreshSerialPortList.Size = new System.Drawing.Size(33, 42);
            this.RefreshSerialPortList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RefreshSerialPortList.TabIndex = 10;
            this.RefreshSerialPortList.TabStop = false;
            this.RefreshSerialPortList.Click += new System.EventHandler(this.RefreshSerialPortList_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.Enabled = false;
            this.BtnStop.Image = global::Samraksh.AppNote.DotNow.DataCollectorExfiltrator.Properties.Resources.Stop_Disabled;
            this.BtnStop.InitialImage = null;
            this.BtnStop.Location = new System.Drawing.Point(265, 134);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(50, 50);
            this.BtnStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnStop.TabIndex = 16;
            this.BtnStop.TabStop = false;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // ExfiltratePc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 562);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStartPause);
            this.Controls.Add(this.BrowseForOutputFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OutputFile);
            this.Controls.Add(this.RefreshSerialPortList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClearErrorMessages);
            this.Controls.Add(this.ErrorMessages);
            this.Controls.Add(this.FromMote);
            this.Controls.Add(this.EnableDisableMoteSwitch);
            this.Controls.Add(this.ClearFromMote);
            this.Controls.Add(this.SerialPortList);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ExfiltratePc";
            this.Text = "Serial On-Off - PC";
            this.Load += new System.EventHandler(this.ExfiltratePc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BtnStartPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshSerialPortList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnStop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SerialPortList;
        private System.Windows.Forms.Button ClearFromMote;
        private System.Windows.Forms.Button EnableDisableMoteSwitch;
        private System.Windows.Forms.TextBox FromMote;
        private System.Windows.Forms.TextBox ErrorMessages;
        private System.Windows.Forms.Button ClearErrorMessages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox RefreshSerialPortList;
        private System.Windows.Forms.TextBox OutputFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BrowseForOutputFile;
        private System.Windows.Forms.PictureBox BtnStartPause;
        private System.Windows.Forms.PictureBox BtnStop;
    }
}

