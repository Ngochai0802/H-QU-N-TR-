using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    public partial class FrmXemChiTiet : Form
    {
        public static string MaSV = "";
        public static string MaMon = "";
        public static int Lan = 0;
        public static double Diem = 0;
        public static int SoCauDung = 0;
        public static int TongSoCau = 0;

        public FrmXemChiTiet()
        {
            InitializeComponent();
            UIHelper.ApplyFormStyle(this);

            Panel pnlHeader = new Panel();
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 50;
            pnlHeader.Paint += (s, e) =>
                UIHelper.PaintHeader(s, e, "XEM CHI TIẾT BÀI THI");
            this.Controls.Add(pnlHeader);
            pnlHeader.BringToFront();
        }

        private void FrmXemChiTiet_Load(object sender, EventArgs e)
        {
            // Thông tin tổng quan
            lblHoTen.Text = "Họ tên: " + Program.hoTen.Trim();
            lblMaMon.Text = "Môn: " + MaMon.Trim();
            lblLan.Text = "Lần thi: " + Lan;
            lblDiem.Text = "Điểm: " + Diem + "/10" +
                            "  (" + SoCauDung + "/" + TongSoCau + " câu đúng)";
            lblDiem.ForeColor = Diem >= 5
                ? Color.FromArgb(0, 128, 0)
                : Color.Red;

            UIHelper.StyleButtonOutline(btnDong, UIHelper.GrayCancel);

            // Load chi tiết
            DataTable dt = Program.LayDuLieu(
                "EXEC SP_GET_CT_BAITHI N'" + MaSV.Trim() +
                "', N'" + MaMon.Trim() +
                "', " + Lan);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu chi tiết bài thi!");
                return;
            }

            // Tạo từng CauHoiXem và thêm vào FlowLayoutPanel
            flpChiTiet.Controls.Clear();
            foreach (DataRow row in dt.Rows)
            {
                CauHoiXem cau = new CauHoiXem();
                cau.Width = flpChiTiet.ClientSize.Width - 5;

                cau.HienThiCauHoi(
                    int.Parse(row["STT"].ToString()),
                    row["NOIDUNG"].ToString(),
                    row["A"].ToString(),
                    row["B"].ToString(),
                    row["C"].ToString(),
                    row["D"].ToString(),
                    row["DAP_AN_CHON"].ToString(),
                    row["DAP_AN"].ToString()
                );

                flpChiTiet.Controls.Add(cau);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}