namespace ThiTracNghiem
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnMoDangKy = new System.Windows.Forms.Button();
            this.btnMoThiSV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMoDangKy
            // 
            this.btnMoDangKy.Location = new System.Drawing.Point(198, 82);
            this.btnMoDangKy.Name = "btnMoDangKy";
            this.btnMoDangKy.Size = new System.Drawing.Size(203, 49);
            this.btnMoDangKy.TabIndex = 1;
            this.btnMoDangKy.Text = "ĐĂNG KÝ THI";
            this.btnMoDangKy.UseVisualStyleBackColor = true;
            this.btnMoDangKy.Click += new System.EventHandler(this.btnMoDangKy_Click);
            // 
            // btnMoThiSV
            // 
            this.btnMoThiSV.Location = new System.Drawing.Point(198, 172);
            this.btnMoThiSV.Name = "btnMoThiSV";
            this.btnMoThiSV.Size = new System.Drawing.Size(203, 54);
            this.btnMoThiSV.TabIndex = 2;
            this.btnMoThiSV.Text = "THI";
            this.btnMoThiSV.UseVisualStyleBackColor = true;
            this.btnMoThiSV.Click += new System.EventHandler(this.btnMoThiSV_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMoThiSV);
            this.Controls.Add(this.btnMoDangKy);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMoDangKy;
        private System.Windows.Forms.Button btnMoThiSV;
    }
}

