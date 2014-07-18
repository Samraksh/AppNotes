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
            this.FileType = new System.Windows.Forms.Panel();
            this.BlockSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FileName = new System.Windows.Forms.TextBox();
            this.Run = new System.Windows.Forms.Button();
            this.ChooseFile = new System.Windows.Forms.Button();
            this.NumSamples = new System.Windows.Forms.Label();
            this.FileType.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 3);
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
            this.Interleaved.Location = new System.Drawing.Point(94, 3);
            this.Interleaved.Name = "Interleaved";
            this.Interleaved.Size = new System.Drawing.Size(108, 21);
            this.Interleaved.TabIndex = 1;
            this.Interleaved.Tag = "IQIQIQ";
            this.Interleaved.Text = "I Q I Q I Q ...";
            this.Interleaved.UseVisualStyleBackColor = true;
            this.Interleaved.CheckedChanged += new System.EventHandler(this.FileType_CheckedChanged);
            // 
            // Block
            // 
            this.Block.AutoSize = true;
            this.Block.Location = new System.Drawing.Point(218, 3);
            this.Block.Name = "Block";
            this.Block.Size = new System.Drawing.Size(124, 21);
            this.Block.TabIndex = 2;
            this.Block.Tag = "IIIQQQ";
            this.Block.Text = "I I I ... Q Q Q ...";
            this.Block.UseVisualStyleBackColor = true;
            this.Block.CheckedChanged += new System.EventHandler(this.FileType_CheckedChanged);
            // 
            // FileType
            // 
            this.FileType.AutoSize = true;
            this.FileType.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FileType.Controls.Add(this.BlockSize);
            this.FileType.Controls.Add(this.label2);
            this.FileType.Controls.Add(this.Interleaved);
            this.FileType.Controls.Add(this.Block);
            this.FileType.Controls.Add(this.label1);
            this.FileType.Location = new System.Drawing.Point(32, 32);
            this.FileType.Name = "FileType";
            this.FileType.Size = new System.Drawing.Size(397, 57);
            this.FileType.TabIndex = 3;
            // 
            // BlockSize
            // 
            this.BlockSize.Location = new System.Drawing.Point(294, 32);
            this.BlockSize.Name = "BlockSize";
            this.BlockSize.Size = new System.Drawing.Size(100, 22);
            this.BlockSize.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Block Size";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Data Files (*.data|*.data|All Files (*.*)|*.*";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(131, 115);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(291, 22);
            this.FileName.TabIndex = 5;
            this.FileName.TextChanged += new System.EventHandler(this.FileName_TextChanged);
            this.FileName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FileName_KeyUp);
            // 
            // Run
            // 
            this.Run.Enabled = false;
            this.Run.Location = new System.Drawing.Point(20, 166);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(75, 23);
            this.Run.TabIndex = 6;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // ChooseFile
            // 
            this.ChooseFile.Location = new System.Drawing.Point(20, 115);
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
            this.NumSamples.Location = new System.Drawing.Point(450, 119);
            this.NumSamples.Name = "NumSamples";
            this.NumSamples.Size = new System.Drawing.Size(0, 17);
            this.NumSamples.TabIndex = 8;
            // 
            // RadarEmulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(578, 250);
            this.Controls.Add(this.NumSamples);
            this.Controls.Add(this.ChooseFile);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.FileType);
            this.Name = "RadarEmulator";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Radar Emulator";
            this.Load += new System.EventHandler(this.RadarEmulator_Load);
            this.FileType.ResumeLayout(false);
            this.FileType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Interleaved;
        private System.Windows.Forms.CheckBox Block;
        private System.Windows.Forms.Panel FileType;
        private System.Windows.Forms.TextBox BlockSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox FileName;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Button ChooseFile;
        private System.Windows.Forms.Label NumSamples;
    }
}

