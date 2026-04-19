namespace ThiTracNghiem
{
    partial class CauHoi
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSoCau = new System.Windows.Forms.Label();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.rdoA = new System.Windows.Forms.RadioButton();
            this.rdoB = new System.Windows.Forms.RadioButton();
            this.rdoC = new System.Windows.Forms.RadioButton();
            this.rdoD = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblSoCau
            // 
            this.lblSoCau.Location = new System.Drawing.Point(23, 10);
            this.lblSoCau.Name = "lblSoCau";
            this.lblSoCau.Size = new System.Drawing.Size(100, 41);
            this.lblSoCau.TabIndex = 0;
            this.lblSoCau.Text = "Câu 1:";
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.Location = new System.Drawing.Point(23, 51);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(710, 60);
            this.lblNoiDung.TabIndex = 1;
            this.lblNoiDung.Text = "Nội dung câu hỏi...";
            // 
            // rdoA
            // 
            this.rdoA.AutoSize = true;
            this.rdoA.Location = new System.Drawing.Point(26, 114);
            this.rdoA.Name = "rdoA";
            this.rdoA.Size = new System.Drawing.Size(40, 20);
            this.rdoA.TabIndex = 2;
            this.rdoA.TabStop = true;
            this.rdoA.Text = "A.";
            this.rdoA.UseVisualStyleBackColor = true;
            this.rdoA.CheckedChanged += new System.EventHandler(this.rdoA_CheckedChanged_1);
            // 
            // rdoB
            // 
            this.rdoB.AutoSize = true;
            this.rdoB.Location = new System.Drawing.Point(26, 157);
            this.rdoB.Name = "rdoB";
            this.rdoB.Size = new System.Drawing.Size(40, 20);
            this.rdoB.TabIndex = 3;
            this.rdoB.TabStop = true;
            this.rdoB.Text = "B.";
            this.rdoB.UseVisualStyleBackColor = true;
            this.rdoB.CheckedChanged += new System.EventHandler(this.rdoB_CheckedChanged_1);
            // 
            // rdoC
            // 
            this.rdoC.AutoSize = true;
            this.rdoC.Location = new System.Drawing.Point(26, 210);
            this.rdoC.Name = "rdoC";
            this.rdoC.Size = new System.Drawing.Size(40, 20);
            this.rdoC.TabIndex = 4;
            this.rdoC.TabStop = true;
            this.rdoC.Text = "C.";
            this.rdoC.UseVisualStyleBackColor = true;
            this.rdoC.CheckedChanged += new System.EventHandler(this.rdoC_CheckedChanged_1);
            // 
            // rdoD
            // 
            this.rdoD.AutoSize = true;
            this.rdoD.Location = new System.Drawing.Point(26, 269);
            this.rdoD.Name = "rdoD";
            this.rdoD.Size = new System.Drawing.Size(41, 20);
            this.rdoD.TabIndex = 5;
            this.rdoD.TabStop = true;
            this.rdoD.Text = "D.";
            this.rdoD.UseVisualStyleBackColor = true;
            this.rdoD.CheckedChanged += new System.EventHandler(this.rdoD_CheckedChanged_1);
            // 
            // CauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.rdoD);
            this.Controls.Add(this.rdoC);
            this.Controls.Add(this.rdoB);
            this.Controls.Add(this.rdoA);
            this.Controls.Add(this.lblNoiDung);
            this.Controls.Add(this.lblSoCau);
            this.Name = "CauHoi";
            this.Size = new System.Drawing.Size(750, 320);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSoCau;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.RadioButton rdoA;
        private System.Windows.Forms.RadioButton rdoB;
        private System.Windows.Forms.RadioButton rdoC;
        private System.Windows.Forms.RadioButton rdoD;
    }
}
