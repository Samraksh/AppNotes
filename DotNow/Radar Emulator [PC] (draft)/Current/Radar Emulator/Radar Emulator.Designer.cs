namespace Samraksh.eMote.Radar.Emulator {
    partial class RadarEmulator {
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
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FileName = new System.Windows.Forms.TextBox();
            this.Run = new System.Windows.Forms.Button();
            this.ChooseFile = new System.Windows.Forms.Button();
            this.NumSamples = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AmountOfEndPadding = new System.Windows.Forms.TextBox();
            this.PaddingMinValue = new System.Windows.Forms.CheckBox();
            this.PaddingMaxValue = new System.Windows.Forms.CheckBox();
            this.pnlPadding = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SampleIntervalMicroSec = new System.Windows.Forms.TextBox();
            this.pnlFileType.SuspendLayout();
            this.pnlPadding.SuspendLayout();
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
            this.Interleaved.CheckedChanged += new System.EventHandler(this.PanelCheckBox_CheckedChanged);
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
            this.Block.CheckedChanged += new System.EventHandler(this.PanelCheckBox_CheckedChanged);
            // 
            // pnlFileType
            // 
            this.pnlFileType.AutoSize = true;
            this.pnlFileType.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlFileType.Controls.Add(this.BlockSize);
            this.pnlFileType.Controls.Add(this.label2);
            this.pnlFileType.Controls.Add(this.Interleaved);
            this.pnlFileType.Controls.Add(this.Block);
            this.pnlFileType.Controls.Add(this.label1);
            this.pnlFileType.Location = new System.Drawing.Point(52, 85);
            this.pnlFileType.Name = "pnlFileType";
            this.pnlFileType.Size = new System.Drawing.Size(446, 56);
            this.pnlFileType.TabIndex = 3;
            // 
            // BlockSize
            // 
            this.BlockSize.Location = new System.Drawing.Point(343, 31);
            this.BlockSize.Name = "BlockSize";
            this.BlockSize.Size = new System.Drawing.Size(100, 22);
            this.BlockSize.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Block Size (ushort)";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Data Files (Data|*.data;*.dat|All Files (*.*)|*.*";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(138, 22);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(291, 22);
            this.FileName.TabIndex = 5;
            this.FileName.TextChanged += new System.EventHandler(this.FileName_TextChanged);
            this.FileName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FileName_KeyUp);
            // 
            // Run
            // 
            this.Run.Enabled = false;
            this.Run.Location = new System.Drawing.Point(20, 205);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(75, 23);
            this.Run.TabIndex = 6;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // ChooseFile
            // 
            this.ChooseFile.Location = new System.Drawing.Point(27, 22);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Amount of End Padding";
            // 
            // AmountOfEndPadding
            // 
            this.AmountOfEndPadding.Location = new System.Drawing.Point(166, 6);
            this.AmountOfEndPadding.Name = "AmountOfEndPadding";
            this.AmountOfEndPadding.Size = new System.Drawing.Size(59, 22);
            this.AmountOfEndPadding.TabIndex = 10;
            // 
            // PaddingMinValue
            // 
            this.PaddingMinValue.AutoSize = true;
            this.PaddingMinValue.Checked = true;
            this.PaddingMinValue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PaddingMinValue.Location = new System.Drawing.Point(3, 31);
            this.PaddingMinValue.Name = "PaddingMinValue";
            this.PaddingMinValue.Size = new System.Drawing.Size(132, 21);
            this.PaddingMinValue.TabIndex = 5;
            this.PaddingMinValue.Tag = "MinValue";
            this.PaddingMinValue.Text = "ushort.MinValue";
            this.PaddingMinValue.UseVisualStyleBackColor = true;
            this.PaddingMinValue.CheckedChanged += new System.EventHandler(this.PanelCheckBox_CheckedChanged);
            // 
            // PaddingMaxValue
            // 
            this.PaddingMaxValue.AutoSize = true;
            this.PaddingMaxValue.Location = new System.Drawing.Point(141, 31);
            this.PaddingMaxValue.Name = "PaddingMaxValue";
            this.PaddingMaxValue.Size = new System.Drawing.Size(135, 21);
            this.PaddingMaxValue.TabIndex = 6;
            this.PaddingMaxValue.Tag = "MaxValue";
            this.PaddingMaxValue.Text = "ushort.MaxValue";
            this.PaddingMaxValue.UseVisualStyleBackColor = true;
            this.PaddingMaxValue.CheckedChanged += new System.EventHandler(this.PanelCheckBox_CheckedChanged);
            // 
            // pnlPadding
            // 
            this.pnlPadding.AllowDrop = true;
            this.pnlPadding.AutoSize = true;
            this.pnlPadding.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlPadding.Controls.Add(this.AmountOfEndPadding);
            this.pnlPadding.Controls.Add(this.PaddingMinValue);
            this.pnlPadding.Controls.Add(this.label3);
            this.pnlPadding.Controls.Add(this.PaddingMaxValue);
            this.pnlPadding.Location = new System.Drawing.Point(545, 86);
            this.pnlPadding.Name = "pnlPadding";
            this.pnlPadding.Size = new System.Drawing.Size(279, 55);
            this.pnlPadding.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Sample Interval (micro sec)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SampleIntervalMicroSec
            // 
            this.SampleIntervalMicroSec.Location = new System.Drawing.Point(240, 148);
            this.SampleIntervalMicroSec.Name = "SampleIntervalMicroSec";
            this.SampleIntervalMicroSec.Size = new System.Drawing.Size(69, 22);
            this.SampleIntervalMicroSec.TabIndex = 12;
            // 
            // RadarEmulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(824, 360);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SampleIntervalMicroSec);
            this.Controls.Add(this.pnlPadding);
            this.Controls.Add(this.NumSamples);
            this.Controls.Add(this.ChooseFile);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.pnlFileType);
            this.Name = "RadarEmulator";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Radar Emulator";
            this.Load += new System.EventHandler(this.RadarEmulator_Load);
            this.pnlFileType.ResumeLayout(false);
            this.pnlFileType.PerformLayout();
            this.pnlPadding.ResumeLayout(false);
            this.pnlPadding.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Interleaved;
        private System.Windows.Forms.CheckBox Block;
        private System.Windows.Forms.Panel pnlFileType;
        private System.Windows.Forms.TextBox BlockSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox FileName;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Button ChooseFile;
        private System.Windows.Forms.Label NumSamples;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AmountOfEndPadding;
        private System.Windows.Forms.CheckBox PaddingMinValue;
        private System.Windows.Forms.CheckBox PaddingMaxValue;
        private System.Windows.Forms.Panel pnlPadding;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox SampleIntervalMicroSec;
    }
}

