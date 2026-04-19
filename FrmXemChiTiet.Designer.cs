namespace ThiTracNghiem
{
    partial class FrmXemChiTiet
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
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblMaMon = new System.Windows.Forms.Label();
            this.lblLan = new System.Windows.Forms.Label();
            this.lblDiem = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.flpChiTiet = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHoTen
            // 
            this.lblHoTen.Location = new System.Drawing.Point(50, 11);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(170, 43);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "label1";
            // 
            // lblMaMon
            // 
            this.lblMaMon.Location = new System.Drawing.Point(315, 11);
            this.lblMaMon.Name = "lblMaMon";
            this.lblMaMon.Size = new System.Drawing.Size(170, 43);
            this.lblMaMon.TabIndex = 1;
            this.lblMaMon.Text = "label2";
            // 
            // lblLan
            // 
            this.lblLan.Location = new System.Drawing.Point(50, 88);
            this.lblLan.Name = "lblLan";
            this.lblLan.Size = new System.Drawing.Size(170, 33);
            this.lblLan.TabIndex = 2;
            this.lblLan.Text = "label3";
            // 
            // lblDiem
            // 
            this.lblDiem.Location = new System.Drawing.Point(315, 78);
            this.lblDiem.Name = "lblDiem";
            this.lblDiem.Size = new System.Drawing.Size(170, 43);
            this.lblDiem.TabIndex = 3;
            this.lblDiem.Text = "label4";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(534, 542);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(115, 50);
            this.btnDong.TabIndex = 5;
            this.btnDong.Text = "ĐÓNG";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.flpChiTiet);
            this.pnlInfo.Controls.Add(this.lblHoTen);
            this.pnlInfo.Controls.Add(this.lblMaMon);
            this.pnlInfo.Controls.Add(this.lblLan);
            this.pnlInfo.Controls.Add(this.lblDiem);
            this.pnlInfo.Location = new System.Drawing.Point(12, 63);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(755, 462);
            this.pnlInfo.TabIndex = 6;
            // 
            // flpChiTiet
            // 
            this.flpChiTiet.AutoScroll = true;
            this.flpChiTiet.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpChiTiet.Location = new System.Drawing.Point(13, 155);
            this.flpChiTiet.Name = "flpChiTiet";
            this.flpChiTiet.Size = new System.Drawing.Size(725, 289);
            this.flpChiTiet.TabIndex = 8;
            this.flpChiTiet.WrapContents = false;
            // 
            // FrmXemChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 604);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.btnDong);
            this.Name = "FrmXemChiTiet";
            this.Text = "FrmXemChiTiet";
            this.Load += new System.EventHandler(this.FrmXemChiTiet_Load);
            this.pnlInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblMaMon;
        private System.Windows.Forms.Label lblLan;
        private System.Windows.Forms.Label lblDiem;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.FlowLayoutPanel flpChiTiet;
    }
}