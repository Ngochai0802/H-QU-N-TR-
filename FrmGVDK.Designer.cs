namespace ThiTracNghiem
{
    partial class FrmGVDK
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
            this.label8 = new System.Windows.Forms.Label();
            this.cboGV = new System.Windows.Forms.ComboBox();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.cboMon = new System.Windows.Forms.ComboBox();
            this.cboTrinhDo = new System.Windows.Forms.ComboBox();
            this.cboLan = new System.Windows.Forms.ComboBox();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.nudSoCau = new System.Windows.Forms.NumericUpDown();
            this.nudThoiGian = new System.Windows.Forms.NumericUpDown();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.dgvDangKy = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoCau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThoiGian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Giáo viên:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 43);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lớp :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(257, 43);
            this.label3.TabIndex = 2;
            this.label3.Text = "Môn học :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "Trình độ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(243, 41);
            this.label5.TabIndex = 4;
            this.label5.Text = "Lần thi :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(257, 59);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ngày thi";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(50, 425);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(257, 46);
            this.label7.TabIndex = 6;
            this.label7.Text = "Số câu :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(77, 488);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(216, 29);
            this.label8.TabIndex = 7;
            this.label8.Text = "Thời gian :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cboGV
            // 
            this.cboGV.FormattingEnabled = true;
            this.cboGV.Location = new System.Drawing.Point(402, 101);
            this.cboGV.Name = "cboGV";
            this.cboGV.Size = new System.Drawing.Size(224, 24);
            this.cboGV.TabIndex = 8;
            // 
            // cboLop
            // 
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(402, 141);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(224, 24);
            this.cboLop.TabIndex = 9;
            // 
            // cboMon
            // 
            this.cboMon.FormattingEnabled = true;
            this.cboMon.Location = new System.Drawing.Point(402, 186);
            this.cboMon.Name = "cboMon";
            this.cboMon.Size = new System.Drawing.Size(224, 24);
            this.cboMon.TabIndex = 10;
            // 
            // cboTrinhDo
            // 
            this.cboTrinhDo.FormattingEnabled = true;
            this.cboTrinhDo.Location = new System.Drawing.Point(402, 246);
            this.cboTrinhDo.Name = "cboTrinhDo";
            this.cboTrinhDo.Size = new System.Drawing.Size(224, 24);
            this.cboTrinhDo.TabIndex = 11;
            // 
            // cboLan
            // 
            this.cboLan.FormattingEnabled = true;
            this.cboLan.Location = new System.Drawing.Point(402, 316);
            this.cboLan.Name = "cboLan";
            this.cboLan.Size = new System.Drawing.Size(224, 24);
            this.cboLan.TabIndex = 12;
            // 
            // dtpNgay
            // 
            this.dtpNgay.Location = new System.Drawing.Point(402, 374);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(224, 22);
            this.dtpNgay.TabIndex = 13;
            // 
            // nudSoCau
            // 
            this.nudSoCau.Location = new System.Drawing.Point(402, 433);
            this.nudSoCau.Name = "nudSoCau";
            this.nudSoCau.Size = new System.Drawing.Size(224, 22);
            this.nudSoCau.TabIndex = 14;
            // 
            // nudThoiGian
            // 
            this.nudThoiGian.Location = new System.Drawing.Point(402, 488);
            this.nudThoiGian.Name = "nudThoiGian";
            this.nudThoiGian.Size = new System.Drawing.Size(224, 22);
            this.nudThoiGian.TabIndex = 15;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(100, 520);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(102, 39);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "THÊM";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(237, 520);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(102, 39);
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "SỬA";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click_1);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(374, 520);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(102, 39);
            this.btnXoa.TabIndex = 18;
            this.btnXoa.Text = "XÓA";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click_1);
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(524, 520);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(102, 39);
            this.btnGhi.TabIndex = 19;
            this.btnGhi.Text = "GHI";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click_1);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(656, 520);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(102, 39);
            this.btnHuy.TabIndex = 20;
            this.btnHuy.Text = "HỦY";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click_1);
            // 
            // dgvDangKy
            // 
            this.dgvDangKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDangKy.Location = new System.Drawing.Point(-3, 565);
            this.dgvDangKy.Name = "dgvDangKy";
            this.dgvDangKy.RowHeadersWidth = 51;
            this.dgvDangKy.RowTemplate.Height = 24;
            this.dgvDangKy.Size = new System.Drawing.Size(991, 191);
            this.dgvDangKy.TabIndex = 21;
            // 
            // FrmGVDK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(990, 776);
            this.Controls.Add(this.dgvDangKy);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.nudThoiGian);
            this.Controls.Add(this.nudSoCau);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.cboLan);
            this.Controls.Add(this.cboTrinhDo);
            this.Controls.Add(this.cboMon);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.cboGV);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmGVDK";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.FrmGVDK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudSoCau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThoiGian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboGV;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.ComboBox cboMon;
        private System.Windows.Forms.ComboBox cboTrinhDo;
        private System.Windows.Forms.ComboBox cboLan;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.NumericUpDown nudSoCau;
        private System.Windows.Forms.NumericUpDown nudThoiGian;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridView dgvDangKy;
    }
}