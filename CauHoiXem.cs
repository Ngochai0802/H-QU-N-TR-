using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    public partial class CauHoiXem : UserControl
    {
        public CauHoiXem()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            this.Padding = new Padding(10);
            this.Margin = new Padding(0, 0, 0, 8);

            // Viền xanh nhạt
            this.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                    UIHelper.BorderGray, ButtonBorderStyle.Solid);
            };
        }

        public void HienThiCauHoi(int soCau, string noiDung,
            string a, string b, string c, string d,
            string dapAnChon, string dapAnDung)
        {
            // Số câu
            lblSoCau.Text = "Câu " + soCau + ":";
            lblSoCau.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            lblSoCau.ForeColor = UIHelper.PrimaryBlue;

            // Nội dung
            lblNoiDung.Text = noiDung;
            lblNoiDung.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            lblNoiDung.ForeColor = Color.FromArgb(40, 40, 40);

            // 4 đáp án
            lblA.Text = "A. " + a;
            lblB.Text = "B. " + b;
            lblC.Text = "C. " + c;
            lblD.Text = "D. " + d;

            // Font mặc định cho 4 đáp án
            foreach (Label lbl in new[] { lblA, lblB, lblC, lblD })
            {
                lbl.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
                lbl.ForeColor = Color.FromArgb(60, 60, 60);
            }

            // Xác định label tương ứng đáp án SV chọn
            Label lblChon = null;
            switch (dapAnChon.Trim())
            {
                case "A": lblChon = lblA; break;
                case "B": lblChon = lblB; break;
                case "C": lblChon = lblC; break;
                case "D": lblChon = lblD; break;
            }

            bool dung = dapAnChon.Trim() == dapAnDung.Trim();

            if (lblChon != null)
            {
                if (dung)
                {
                    // Đúng → xanh lá
                    lblChon.ForeColor = Color.FromArgb(0, 150, 0);
                    lblChon.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                    lblChon.Text = "✓ " + lblChon.Text;
                    lblDapAnDung.Visible = false;
                }
                else
                {
                    // Sai → đỏ
                    lblChon.ForeColor = Color.Red;
                    lblChon.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                    lblChon.Text = "✗ " + lblChon.Text;

                    // Hiện đáp án đúng bên dưới
                    lblDapAnDung.Visible = true;
                    lblDapAnDung.Text = "✓ Đáp án đúng: " + dapAnDung.Trim();
                    lblDapAnDung.ForeColor = Color.FromArgb(0, 150, 0);
                    lblDapAnDung.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                }
            }
            else
            {
                // SV không chọn → hiện đáp án đúng
                lblDapAnDung.Visible = true;
                lblDapAnDung.Text = "⚠ Chưa chọn — Đáp án đúng: " + dapAnDung.Trim();
                lblDapAnDung.ForeColor = Color.Orange;
                lblDapAnDung.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            }
        }
    }
}