namespace ThiTracNghiem
{
    partial class FrmThi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblMaMon = new System.Windows.Forms.Label();
            this.lblTrinhDo = new System.Windows.Forms.Label();
            this.lblLan = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.flpDeThi = new System.Windows.Forms.FlowLayoutPanel();
            this.lstDaChon = new System.Windows.Forms.ListBox();
            this.btnNop = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblMaMon
            // 
            this.lblMaMon.Location = new System.Drawing.Point(77, 49);
            this.lblMaMon.Name = "lblMaMon";
            this.lblMaMon.Size = new System.Drawing.Size(203, 44);
            this.lblMaMon.TabIndex = 0;
            this.lblMaMon.Click += new System.EventHandler(this.lblMaMon_Click);
            // 
            // lblTrinhDo
            // 
            this.lblTrinhDo.Location = new System.Drawing.Point(319, 49);
            this.lblTrinhDo.Name = "lblTrinhDo";
            this.lblTrinhDo.Size = new System.Drawing.Size(199, 44);
            this.lblTrinhDo.TabIndex = 1;
            // 
            // lblLan
            // 
            this.lblLan.Location = new System.Drawing.Point(66, 105);
            this.lblLan.Name = "lblLan";
            this.lblLan.Size = new System.Drawing.Size(214, 48);
            this.lblLan.TabIndex = 2;
            this.lblLan.Click += new System.EventHandler(this.lblLan_Click);
            // 
            // lblNgay
            // 
            this.lblNgay.Location = new System.Drawing.Point(304, 109);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(214, 44);
            this.lblNgay.TabIndex = 3;
            // 
            // lblTimer
            // 
            this.lblTimer.ForeColor = System.Drawing.Color.Red;
            this.lblTimer.Location = new System.Drawing.Point(467, 162);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(166, 44);
            this.lblTimer.TabIndex = 4;
            // 
            // flpDeThi
            // 
            this.flpDeThi.AutoScroll = true;
            this.flpDeThi.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpDeThi.Location = new System.Drawing.Point(12, 271);
            this.flpDeThi.Name = "flpDeThi";
            this.flpDeThi.Size = new System.Drawing.Size(999, 402);
            this.flpDeThi.TabIndex = 6;
            this.flpDeThi.WrapContents = false;
            // 
            // lstDaChon
            // 
            this.lstDaChon.FormattingEnabled = true;
            this.lstDaChon.ItemHeight = 16;
            this.lstDaChon.Location = new System.Drawing.Point(1030, 269);
            this.lstDaChon.Name = "lstDaChon";
            this.lstDaChon.Size = new System.Drawing.Size(158, 404);
            this.lstDaChon.TabIndex = 7;
            // 
            // btnNop
            // 
            this.btnNop.Location = new System.Drawing.Point(307, 678);
            this.btnNop.Name = "btnNop";
            this.btnNop.Size = new System.Drawing.Size(152, 40);
            this.btnNop.TabIndex = 8;
            this.btnNop.Text = "NỘP";
            this.btnNop.UseVisualStyleBackColor = true;
            this.btnNop.Click += new System.EventHandler(this.btnNop_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(499, 679);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(118, 39);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 741);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnNop);
            this.Controls.Add(this.lstDaChon);
            this.Controls.Add(this.flpDeThi);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblNgay);
            this.Controls.Add(this.lblLan);
            this.Controls.Add(this.lblTrinhDo);
            this.Controls.Add(this.lblMaMon);
            this.Name = "FrmThi";
            this.Text = "Thi Trắc Nghiệm";
            this.Load += new System.EventHandler(this.FrmThi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMaMon;
        private System.Windows.Forms.Label lblTrinhDo;
        private System.Windows.Forms.Label lblLan;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.FlowLayoutPanel flpDeThi;
        private System.Windows.Forms.ListBox lstDaChon;
        private System.Windows.Forms.Button btnNop;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Timer timer1;
    }
}