namespace Samraksh.AppNotes.Arduino.DisplacementDetection {
	partial class DisplacementDetection {
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
			this.RefreshSerialPortList = new System.Windows.Forms.PictureBox();
			this.StartStop = new System.Windows.Forms.Button();
			this.SerialPortList = new System.Windows.Forms.ComboBox();
			this.Messages = new System.Windows.Forms.TextBox();
			this.ClearMessages = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.FromMote = new System.Windows.Forms.TextBox();
			this.ClearFromMote = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.Disp = new System.Windows.Forms.Label();
			this.Conf = new System.Windows.Forms.Label();
			this.Parameters = new System.Windows.Forms.Panel();
			this.RefreshParams = new System.Windows.Forms.PictureBox();
			this.Confirmation = new System.Windows.Forms.Panel();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.ConfN = new System.Windows.Forms.TextBox();
			this.ConfM = new System.Windows.Forms.TextBox();
			this.Displacement = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.MinCumCuts = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SampleRate = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.LogToFileFolder = new System.Windows.Forms.TextBox();
			this.LogToFileButton = new System.Windows.Forms.Button();
			this.LogToFileBrowse = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.RefreshSerialPortList)).BeginInit();
			this.Parameters.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RefreshParams)).BeginInit();
			this.Confirmation.SuspendLayout();
			this.Displacement.SuspendLayout();
			this.SuspendLayout();
			// 
			// RefreshSerialPortList
			// 
			this.RefreshSerialPortList.BackColor = System.Drawing.Color.Transparent;
			this.RefreshSerialPortList.Image = global::Samraksh.AppNotes.Arduino.DisplacementDetection.Properties.Resources.RefreshButton;
			this.RefreshSerialPortList.Location = new System.Drawing.Point(196, 7);
			this.RefreshSerialPortList.Margin = new System.Windows.Forms.Padding(4);
			this.RefreshSerialPortList.Name = "RefreshSerialPortList";
			this.RefreshSerialPortList.Size = new System.Drawing.Size(33, 42);
			this.RefreshSerialPortList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.RefreshSerialPortList.TabIndex = 13;
			this.RefreshSerialPortList.TabStop = false;
			this.RefreshSerialPortList.Click += new System.EventHandler(this.RefreshSerialPortList_Click);
			// 
			// StartStop
			// 
			this.StartStop.AutoSize = true;
			this.StartStop.BackColor = System.Drawing.Color.LightCoral;
			this.StartStop.Location = new System.Drawing.Point(267, 15);
			this.StartStop.Margin = new System.Windows.Forms.Padding(4);
			this.StartStop.Name = "StartStop";
			this.StartStop.Size = new System.Drawing.Size(156, 28);
			this.StartStop.TabIndex = 12;
			this.StartStop.Text = "Click to Enable Serial";
			this.StartStop.UseVisualStyleBackColor = false;
			this.StartStop.Click += new System.EventHandler(this.StartStop_Click);
			// 
			// SerialPortList
			// 
			this.SerialPortList.FormattingEnabled = true;
			this.SerialPortList.Location = new System.Drawing.Point(28, 15);
			this.SerialPortList.Margin = new System.Windows.Forms.Padding(4);
			this.SerialPortList.Name = "SerialPortList";
			this.SerialPortList.Size = new System.Drawing.Size(160, 24);
			this.SerialPortList.TabIndex = 11;
			// 
			// Messages
			// 
			this.Messages.Location = new System.Drawing.Point(499, 251);
			this.Messages.Margin = new System.Windows.Forms.Padding(4);
			this.Messages.Multiline = true;
			this.Messages.Name = "Messages";
			this.Messages.ReadOnly = true;
			this.Messages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.Messages.Size = new System.Drawing.Size(269, 233);
			this.Messages.TabIndex = 14;
			// 
			// ClearMessages
			// 
			this.ClearMessages.Location = new System.Drawing.Point(499, 502);
			this.ClearMessages.Margin = new System.Windows.Forms.Padding(4);
			this.ClearMessages.Name = "ClearMessages";
			this.ClearMessages.Size = new System.Drawing.Size(100, 28);
			this.ClearMessages.TabIndex = 15;
			this.ClearMessages.Text = "Clear";
			this.ClearMessages.UseVisualStyleBackColor = true;
			this.ClearMessages.Click += new System.EventHandler(this.ClearMessages_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(92, 228);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 17);
			this.label1.TabIndex = 18;
			this.label1.Text = "Received from Mote";
			// 
			// FromMote
			// 
			this.FromMote.Location = new System.Drawing.Point(96, 252);
			this.FromMote.Margin = new System.Windows.Forms.Padding(4);
			this.FromMote.Multiline = true;
			this.FromMote.Name = "FromMote";
			this.FromMote.ReadOnly = true;
			this.FromMote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.FromMote.Size = new System.Drawing.Size(356, 233);
			this.FromMote.TabIndex = 17;
			// 
			// ClearFromMote
			// 
			this.ClearFromMote.Location = new System.Drawing.Point(96, 508);
			this.ClearFromMote.Margin = new System.Windows.Forms.Padding(4);
			this.ClearFromMote.Name = "ClearFromMote";
			this.ClearFromMote.Size = new System.Drawing.Size(100, 28);
			this.ClearFromMote.TabIndex = 16;
			this.ClearFromMote.Text = "Clear";
			this.ClearFromMote.UseVisualStyleBackColor = true;
			this.ClearFromMote.Click += new System.EventHandler(this.ClearFromMote_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(496, 228);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 17);
			this.label2.TabIndex = 19;
			this.label2.Text = "Messages";
			// 
			// Disp
			// 
			this.Disp.AutoSize = true;
			this.Disp.Enabled = false;
			this.Disp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Disp.Location = new System.Drawing.Point(96, 68);
			this.Disp.Name = "Disp";
			this.Disp.Size = new System.Drawing.Size(64, 29);
			this.Disp.TabIndex = 20;
			this.Disp.Text = "Disp";
			// 
			// Conf
			// 
			this.Conf.AutoSize = true;
			this.Conf.Enabled = false;
			this.Conf.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Conf.Location = new System.Drawing.Point(206, 68);
			this.Conf.Name = "Conf";
			this.Conf.Size = new System.Drawing.Size(66, 29);
			this.Conf.TabIndex = 21;
			this.Conf.Text = "Conf";
			// 
			// Parameters
			// 
			this.Parameters.BackColor = System.Drawing.SystemColors.ControlLight;
			this.Parameters.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Parameters.Controls.Add(this.RefreshParams);
			this.Parameters.Controls.Add(this.Confirmation);
			this.Parameters.Controls.Add(this.Displacement);
			this.Parameters.Controls.Add(this.label4);
			this.Parameters.Controls.Add(this.SampleRate);
			this.Parameters.Controls.Add(this.label3);
			this.Parameters.Location = new System.Drawing.Point(366, 59);
			this.Parameters.Name = "Parameters";
			this.Parameters.Size = new System.Drawing.Size(423, 150);
			this.Parameters.TabIndex = 31;
			// 
			// RefreshParams
			// 
			this.RefreshParams.BackColor = System.Drawing.Color.Transparent;
			this.RefreshParams.Enabled = false;
			this.RefreshParams.Image = global::Samraksh.AppNotes.Arduino.DisplacementDetection.Properties.Resources.RefreshButton;
			this.RefreshParams.Location = new System.Drawing.Point(382, -2);
			this.RefreshParams.Margin = new System.Windows.Forms.Padding(4);
			this.RefreshParams.Name = "RefreshParams";
			this.RefreshParams.Size = new System.Drawing.Size(33, 42);
			this.RefreshParams.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.RefreshParams.TabIndex = 33;
			this.RefreshParams.TabStop = false;
			this.RefreshParams.Click += new System.EventHandler(this.RefreshParams_Click);
			// 
			// Confirmation
			// 
			this.Confirmation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Confirmation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Confirmation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Confirmation.Controls.Add(this.label9);
			this.Confirmation.Controls.Add(this.label7);
			this.Confirmation.Controls.Add(this.label6);
			this.Confirmation.Controls.Add(this.ConfN);
			this.Confirmation.Controls.Add(this.ConfM);
			this.Confirmation.Location = new System.Drawing.Point(244, 35);
			this.Confirmation.Name = "Confirmation";
			this.Confirmation.Size = new System.Drawing.Size(119, 96);
			this.Confirmation.TabIndex = 40;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(3, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(99, 17);
			this.label9.TabIndex = 42;
			this.label9.Text = "Confirmation";
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(80, 29);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(18, 17);
			this.label7.TabIndex = 43;
			this.label7.Text = "N";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(14, 29);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(19, 17);
			this.label6.TabIndex = 42;
			this.label6.Text = "M";
			// 
			// ConfN
			// 
			this.ConfN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ConfN.Location = new System.Drawing.Point(69, 59);
			this.ConfN.Name = "ConfN";
			this.ConfN.Size = new System.Drawing.Size(41, 22);
			this.ConfN.TabIndex = 41;
			this.ConfN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ConfM
			// 
			this.ConfM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ConfM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ConfM.Location = new System.Drawing.Point(3, 59);
			this.ConfM.Name = "ConfM";
			this.ConfM.Size = new System.Drawing.Size(41, 22);
			this.ConfM.TabIndex = 40;
			this.ConfM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Displacement
			// 
			this.Displacement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Displacement.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Displacement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Displacement.Controls.Add(this.label8);
			this.Displacement.Controls.Add(this.label5);
			this.Displacement.Controls.Add(this.MinCumCuts);
			this.Displacement.Location = new System.Drawing.Point(101, 34);
			this.Displacement.Name = "Displacement";
			this.Displacement.Size = new System.Drawing.Size(116, 97);
			this.Displacement.TabIndex = 32;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(-3, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(105, 17);
			this.label8.TabIndex = 41;
			this.label8.Text = "Displacement";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(4, 29);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(109, 17);
			this.label5.TabIndex = 39;
			this.label5.Text = "MinCumCuts";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// MinCumCuts
			// 
			this.MinCumCuts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MinCumCuts.Location = new System.Drawing.Point(28, 59);
			this.MinCumCuts.Name = "MinCumCuts";
			this.MinCumCuts.Size = new System.Drawing.Size(64, 22);
			this.MinCumCuts.TabIndex = 38;
			this.MinCumCuts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 63);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 17);
			this.label4.TabIndex = 36;
			this.label4.Text = "SampRate";
			// 
			// SampleRate
			// 
			this.SampleRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.SampleRate.Location = new System.Drawing.Point(28, 93);
			this.SampleRate.Name = "SampleRate";
			this.SampleRate.Size = new System.Drawing.Size(41, 22);
			this.SampleRate.TabIndex = 32;
			this.SampleRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(91, 17);
			this.label3.TabIndex = 31;
			this.label3.Text = "Parameters";
			// 
			// LogToFileFolder
			// 
			this.LogToFileFolder.Location = new System.Drawing.Point(538, 17);
			this.LogToFileFolder.Name = "LogToFileFolder";
			this.LogToFileFolder.Size = new System.Drawing.Size(180, 22);
			this.LogToFileFolder.TabIndex = 32;
			// 
			// LogToFileButton
			// 
			this.LogToFileButton.Location = new System.Drawing.Point(446, 17);
			this.LogToFileButton.Name = "LogToFileButton";
			this.LogToFileButton.Size = new System.Drawing.Size(83, 26);
			this.LogToFileButton.TabIndex = 33;
			this.LogToFileButton.Text = "Log to file";
			this.LogToFileButton.UseVisualStyleBackColor = true;
			this.LogToFileButton.Click += new System.EventHandler(this.LogToFileButton_Click);
			// 
			// LogToFileBrowse
			// 
			this.LogToFileBrowse.Location = new System.Drawing.Point(735, 15);
			this.LogToFileBrowse.Name = "LogToFileBrowse";
			this.LogToFileBrowse.Size = new System.Drawing.Size(54, 28);
			this.LogToFileBrowse.TabIndex = 34;
			this.LogToFileBrowse.Text = ". . .";
			this.LogToFileBrowse.UseVisualStyleBackColor = true;
			this.LogToFileBrowse.Click += new System.EventHandler(this.LogToFileBrowse_Click);
			// 
			// DisplacementDetection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(834, 613);
			this.Controls.Add(this.LogToFileBrowse);
			this.Controls.Add(this.LogToFileButton);
			this.Controls.Add(this.LogToFileFolder);
			this.Controls.Add(this.Conf);
			this.Controls.Add(this.Disp);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.FromMote);
			this.Controls.Add(this.ClearFromMote);
			this.Controls.Add(this.ClearMessages);
			this.Controls.Add(this.Messages);
			this.Controls.Add(this.RefreshSerialPortList);
			this.Controls.Add(this.StartStop);
			this.Controls.Add(this.SerialPortList);
			this.Controls.Add(this.Parameters);
			this.Name = "DisplacementDetection";
			this.Text = "Displacement Detection";
			this.Load += new System.EventHandler(this.DisplacementDetection_Load);
			((System.ComponentModel.ISupportInitialize)(this.RefreshSerialPortList)).EndInit();
			this.Parameters.ResumeLayout(false);
			this.Parameters.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.RefreshParams)).EndInit();
			this.Confirmation.ResumeLayout(false);
			this.Confirmation.PerformLayout();
			this.Displacement.ResumeLayout(false);
			this.Displacement.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox RefreshSerialPortList;
		private System.Windows.Forms.Button StartStop;
		private System.Windows.Forms.ComboBox SerialPortList;
		private System.Windows.Forms.TextBox Messages;
		private System.Windows.Forms.Button ClearMessages;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox FromMote;
		private System.Windows.Forms.Button ClearFromMote;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label Disp;
		private System.Windows.Forms.Label Conf;
		private System.Windows.Forms.Panel Parameters;
		private System.Windows.Forms.Panel Confirmation;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox ConfN;
		private System.Windows.Forms.TextBox ConfM;
		private System.Windows.Forms.Panel Displacement;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox MinCumCuts;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox SampleRate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox RefreshParams;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox LogToFileFolder;
		private System.Windows.Forms.Button LogToFileButton;
		private System.Windows.Forms.Button LogToFileBrowse;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
	}
}

