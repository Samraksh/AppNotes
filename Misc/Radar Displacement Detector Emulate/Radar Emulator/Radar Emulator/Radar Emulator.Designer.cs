namespace Radar_Emulator {
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
            this.Composite = new System.Windows.Forms.CheckBox();
            this.Separate = new System.Windows.Forms.CheckBox();
            this.FileType = new System.Windows.Forms.Panel();
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
            // Composite
            // 
            this.Composite.AutoSize = true;
            this.Composite.Checked = true;
            this.Composite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Composite.Location = new System.Drawing.Point(94, 3);
            this.Composite.Name = "Composite";
            this.Composite.Size = new System.Drawing.Size(96, 21);
            this.Composite.TabIndex = 1;
            this.Composite.Text = "Composite";
            this.Composite.UseVisualStyleBackColor = true;
            this.Composite.CheckedChanged += new System.EventHandler(this.FileType_CheckedChanged);
            // 
            // Separate
            // 
            this.Separate.AutoSize = true;
            this.Separate.Location = new System.Drawing.Point(196, 3);
            this.Separate.Name = "Separate";
            this.Separate.Size = new System.Drawing.Size(88, 21);
            this.Separate.TabIndex = 2;
            this.Separate.Text = "Separate";
            this.Separate.UseVisualStyleBackColor = true;
            this.Separate.CheckedChanged += new System.EventHandler(this.FileType_CheckedChanged);
            // 
            // FileType
            // 
            this.FileType.Controls.Add(this.Composite);
            this.FileType.Controls.Add(this.Separate);
            this.FileType.Controls.Add(this.label1);
            this.FileType.Location = new System.Drawing.Point(12, 12);
            this.FileType.Name = "FileType";
            this.FileType.Size = new System.Drawing.Size(289, 29);
            this.FileType.TabIndex = 3;
            // 
            // RadarEmulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 439);
            this.Controls.Add(this.FileType);
            this.Name = "RadarEmulator";
            this.Text = "RadarEmulator";
            this.Load += new System.EventHandler(this.RadarEmulator_Load);
            this.FileType.ResumeLayout(false);
            this.FileType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Composite;
        private System.Windows.Forms.CheckBox Separate;
        private System.Windows.Forms.Panel FileType;
    }
}

