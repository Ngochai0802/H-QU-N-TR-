namespace ThiTracNghiem
{
    partial class FrmChuanBiThiSV
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.cboMon = new System.Windows.Forms.ComboBox();
            this.cboLan = new System.Windows.Forms.ComboBox();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.btnLoc = new System.Windows.Forms.Button();
            this.dgvLichThi = new System.Windows.Forms.DataGridView();
            this.btnThi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichThi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã SV   :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = " Họ tên  :";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 36);
            this.label3.TabIndex = 2;
            this.label3.Text = " Mã lớp  :";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 36);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên lớp :";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 36);
            this.label5.TabIndex = 4;
            this.label5.Text = "Môn học :";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 36);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ngày thi:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 343);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 36);
            this.label7.TabIndex = 6;
            this.label7.Text = " Lần thi :";
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(184, 12);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.ReadOnly = true;
            this.txtMaSV.Size = new System.Drawing.Size(196, 22);
            this.txtMaSV.TabIndex = 7;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(185, 59);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(195, 22);
            this.txtHoTen.TabIndex = 8;
            // 
            // txtMaLop
            // 
            this.txtMaLop.Location = new System.Drawing.Point(184, 113);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.ReadOnly = true;
            this.txtMaLop.Size = new System.Drawing.Size(196, 22);
            this.txtMaLop.TabIndex = 9;
            // 
            // txtTenLop
            // 
            this.txtTenLop.Location = new System.Drawing.Point(184, 166);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.ReadOnly = true;
            this.txtTenLop.Size = new System.Drawing.Size(196, 22);
            this.txtTenLop.TabIndex = 10;
            // 
            // cboMon
            // 
            this.cboMon.FormattingEnabled = true;
            this.cboMon.Location = new System.Drawing.Point(185, 235);
            this.cboMon.Name = "cboMon";
            this.cboMon.Size = new System.Drawing.Size(195, 24);
            this.cboMon.TabIndex = 11;
            // 
            // cboLan
            // 
            this.cboLan.FormattingEnabled = true;
            this.cboLan.Location = new System.Drawing.Point(184, 343);
            this.cboLan.Name = "cboLan";
            this.cboLan.Size = new System.Drawing.Size(200, 24);
            this.cboLan.TabIndex = 12;
            // 
            // dtpNgay
            // 
            this.dtpNgay.Location = new System.Drawing.Point(185, 295);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(200, 22);
            this.dtpNgay.TabIndex = 14;
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(583, 328);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(153, 51);
            this.btnLoc.TabIndex = 15;
            this.btnLoc.Text = "Loc";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click_1);
            // 
            // dgvLichThi
            // 
            this.dgvLichThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichThi.Location = new System.Drawing.Point(0, 401);
            this.dgvLichThi.Name = "dgvLichThi";
            this.dgvLichThi.RowHeadersWidth = 51;
            this.dgvLichThi.RowTemplate.Height = 24;
            this.dgvLichThi.Size = new System.Drawing.Size(800, 219);
            this.dgvLichThi.TabIndex = 16;
            // 
            // btnThi
            // 
            this.btnThi.Location = new System.Drawing.Point(317, 643);
            this.btnThi.Name = "btnThi";
            this.btnThi.Size = new System.Drawing.Size(172, 39);
            this.btnThi.TabIndex = 17;
            this.btnThi.Text = "THI";
            this.btnThi.UseVisualStyleBackColor = true;
            this.btnThi.Click += new System.EventHandler(this.btnThi_Click_1);
            // 
            // FrmChuanBiThiSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 732);
            this.Controls.Add(this.btnThi);
            this.Controls.Add(this.dgvLichThi);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.cboLan);
            this.Controls.Add(this.cboMon);
            this.Controls.Add(this.txtTenLop);
            this.Controls.Add(this.txtMaLop);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtMaSV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmChuanBiThiSV";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.FrmChuanBiThiSV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.ComboBox cboMon;
        private System.Windows.Forms.ComboBox cboLan;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.DataGridView dgvLichThi;
        private System.Windows.Forms.Button btnThi;
    }
}