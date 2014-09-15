namespace Samraksh.AppNote.PC.Radar.DisplacementDetector {
    partial class RadarDisplacementDetector {
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
            this.label1 = new System.Windows.Forms.Label();
            this.Interleaved = new System.Windows.Forms.CheckBox();
            this.Block = new System.Windows.Forms.CheckBox();
            this.pnlFileType = new System.Windows.Forms.Panel();
            this.BlockSize = new System.Windows.Forms.TextBox();
            this.BlockSizeLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.DataFilePathName = new System.Windows.Forms.TextBox();
            this.Run = new System.Windows.Forms.Button();
            this.ChooseFile = new System.Windows.Forms.Button();
            this.NumSamples = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SampleIntervalMicroSec = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ConfN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ConfM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MinCutsPerDisplacement = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RunResult = new System.Windows.Forms.Label();
            this.MasterPanel = new System.Windows.Forms.Panel();
            this.pnlFileType.SuspendLayout();
            this.panel1.SuspendLayout();
            this.MasterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Type";
            // 
            // Interleaved
            // 
            this.Interleaved.AutoSize = true;
            this.Interleaved.Checked = true;
            this.Interleaved.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Interleaved.Location = new System.Drawing.Point(94, 2);
            this.Interleaved.Name = "Interleaved";
            this.Interleaved.Size = new System.Drawing.Size(108, 21);
            this.Interleaved.TabIndex = 1;
            this.Interleaved.Tag = "Interleaved";
            this.Interleaved.Text = "I Q I Q I Q ...";
            this.Interleaved.UseVisualStyleBackColor = true;
            this.Interleaved.Click += new System.EventHandler(this.Interleaved_Click);
            // 
            // Block
            // 
            this.Block.AutoSize = true;
            this.Block.Location = new System.Drawing.Point(218, 2);
            this.Block.Name = "Block";
            this.Block.Size = new System.Drawing.Size(124, 21);
            this.Block.TabIndex = 2;
            this.Block.Tag = "Block";
            this.Block.Text = "I I I ... Q Q Q ...";
            this.Block.UseVisualStyleBackColor = true;
            this.Block.CheckedChanged += new System.EventHandler(this.Block_CheckedChanged);
            // 
            // pnlFileType
            // 
            this.pnlFileType.AutoSize = true;
            this.pnlFileType.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlFileType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFileType.Controls.Add(this.BlockSize);
            this.pnlFileType.Controls.Add(this.BlockSizeLabel);
            this.pnlFileType.Controls.Add(this.Interleaved);
            this.pnlFileType.Controls.Add(this.Block);
            this.pnlFileType.Controls.Add(this.label1);
            this.pnlFileType.Location = new System.Drawing.Point(52, 76);
            this.pnlFileType.Name = "pnlFileType";
            this.pnlFileType.Size = new System.Drawing.Size(400, 58);
            this.pnlFileType.TabIndex = 3;
            // 
            // BlockSize
            // 
            this.BlockSize.Enabled = false;
            this.BlockSize.Location = new System.Drawing.Point(343, 31);
            this.BlockSize.Name = "BlockSize";
            this.BlockSize.Size = new System.Drawing.Size(52, 22);
            this.BlockSize.TabIndex = 4;
            // 
            // BlockSizeLabel
            // 
            this.BlockSizeLabel.AutoSize = true;
            this.BlockSizeLabel.Enabled = false;
            this.BlockSizeLabel.Location = new System.Drawing.Point(216, 31);
            this.BlockSizeLabel.Name = "BlockSizeLabel";
            this.BlockSizeLabel.Size = new System.Drawing.Size(127, 17);
            this.BlockSizeLabel.TabIndex = 3;
            this.BlockSizeLabel.Text = "Block Size (ushort)";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Data Files (Data|*.data;*.dat|All Files (*.*)|*.*";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // DataFilePathName
            // 
            this.DataFilePathName.Location = new System.Drawing.Point(135, 11);
            this.DataFilePathName.Name = "DataFilePathName";
            this.DataFilePathName.Size = new System.Drawing.Size(291, 22);
            this.DataFilePathName.TabIndex = 5;
            this.DataFilePathName.TextChanged += new System.EventHandler(this.FileName_TextChanged);
            this.DataFilePathName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FileName_KeyUp);
            // 
            // Run
            // 
            this.Run.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Run.Enabled = false;
            this.Run.Location = new System.Drawing.Point(24, 193);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(75, 23);
            this.Run.TabIndex = 6;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // ChooseFile
            // 
            this.ChooseFile.Location = new System.Drawing.Point(27, 11);
            this.ChooseFile.Name = "ChooseFile";
            this.ChooseFile.Size = new System.Drawing.Size(102, 23);
            this.ChooseFile.TabIndex = 7;
            this.ChooseFile.Text = "Choose File";
            this.ChooseFile.UseVisualStyleBackColor = true;
            this.ChooseFile.Click += new System.EventHandler(this.ChooseFile_Click);
            // 
            // NumSamples
            // 
            this.NumSamples.AutoSize = true;
            this.NumSamples.Location = new System.Drawing.Point(141, 50);
            this.NumSamples.Name = "NumSamples";
            this.NumSamples.Size = new System.Drawing.Size(23, 17);
            this.NumSamples.TabIndex = 8;
            this.NumSamples.Text = "---";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Sample Interval (micro sec)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SampleIntervalMicroSec
            // 
            this.SampleIntervalMicroSec.Location = new System.Drawing.Point(264, 142);
            this.SampleIntervalMicroSec.Name = "SampleIntervalMicroSec";
            this.SampleIntervalMicroSec.Size = new System.Drawing.Size(54, 22);
            this.SampleIntervalMicroSec.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ConfN);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.ConfM);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.MinCutsPerDisplacement);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(475, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 58);
            this.panel1.TabIndex = 14;
            // 
            // ConfN
            // 
            this.ConfN.Location = new System.Drawing.Point(178, -3);
            this.ConfN.Name = "ConfN";
            this.ConfN.Size = new System.Drawing.Size(26, 22);
            this.ConfN.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "of N";
            // 
            // ConfM
            // 
            this.ConfM.Location = new System.Drawing.Point(106, -1);
            this.ConfM.Name = "ConfM";
            this.ConfM.Size = new System.Drawing.Size(26, 22);
            this.ConfM.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Confirmation: M";
            // 
            // MinCutsPerDisplacement
            // 
            this.MinCutsPerDisplacement.Location = new System.Drawing.Point(183, 28);
            this.MinCutsPerDisplacement.Name = "MinCutsPerDisplacement";
            this.MinCutsPerDisplacement.Size = new System.Drawing.Size(26, 22);
            this.MinCutsPerDisplacement.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Min Cuts per Displacement";
            // 
            // RunResult
            // 
            this.RunResult.AutoSize = true;
            this.RunResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunResult.Location = new System.Drawing.Point(144, 196);
            this.RunResult.Name = "RunResult";
            this.RunResult.Size = new System.Drawing.Size(26, 17);
            this.RunResult.TabIndex = 15;
            this.RunResult.Text = "---";
            // 
            // MasterPanel
            // 
            this.MasterPanel.AutoSize = true;
            this.MasterPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MasterPanel.Controls.Add(this.RunResult);
            this.MasterPanel.Controls.Add(this.Run);
            this.MasterPanel.Controls.Add(this.SampleIntervalMicroSec);
            this.MasterPanel.Controls.Add(this.button1);
            this.MasterPanel.Controls.Add(this.panel1);
            this.MasterPanel.Controls.Add(this.ChooseFile);
            this.MasterPanel.Controls.Add(this.DataFilePathName);
            this.MasterPanel.Controls.Add(this.pnlFileType);
            this.MasterPanel.Location = new System.Drawing.Point(2, 10);
            this.MasterPanel.Name = "MasterPanel";
            this.MasterPanel.Size = new System.Drawing.Size(715, 219);
            this.MasterPanel.TabIndex = 16;
            // 
            // RadarDisplacementDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1064, 360);
            this.Controls.Add(this.NumSamples);
            this.Controls.Add(this.MasterPanel);
            this.Name = "RadarDisplacementDetector";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Radar Displacement Analyzer";
            this.Load += new System.EventHandler(this.RadarEmulator_Load);
            this.pnlFileType.ResumeLayout(false);
            this.pnlFileType.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.MasterPanel.ResumeLayout(false);
            this.MasterPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Interleaved;
        private System.Windows.Forms.CheckBox Block;
        private System.Windows.Forms.Panel pnlFileType;
        private System.Windows.Forms.TextBox BlockSize;
        private System.Windows.Forms.Label BlockSizeLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox DataFilePathName;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Button ChooseFile;
        private System.Windows.Forms.Label NumSamples;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox SampleIntervalMicroSec;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox MinCutsPerDisplacement;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ConfN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ConfM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label RunResult;
        private System.Windows.Forms.Panel MasterPanel;
    }
}

