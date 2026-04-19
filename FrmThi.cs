using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    public partial class FrmThi : Form
    {
        private int demLuu = 0; // đếm giây để lưu tạm mỗi 30s


        public static string MaMon = "";
        public static string TrinhDo = "";
        public static string MaLop = "";
        public static string TenLop = "";
        public static int Lan = 0;
        public static int ThoiGian = 0;
        public static int SoCau = 0;
        public static DateTime NgayThi;

        private CauHoi[] danhSachCauHoi;
        private int phut;
        private int giay = 59;

        // ← Panel chứa các ô số câu (thay ListBox)
        private Panel pnlSoCau;

        public FrmThi()
        {
            InitializeComponent();
            UIHelper.ApplyFormStyle(this);

            Panel pnlHeader = new Panel();
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 50;
            pnlHeader.Paint += (s, e) => UIHelper.PaintHeader(s, e, "LÀM BÀI THI");
            this.Controls.Add(pnlHeader);
            pnlHeader.BringToFront();

            // ← Ẩn ListBox cũ, không cần nữa
            lstDaChon.Visible = false;
        }

        private void FrmThi_Load(object sender, EventArgs e)
        {
            lblMaMon.Text = "Môn: " + MaMon;
            lblTrinhDo.Text = "Trình độ: " + TrinhDo;
            lblLan.Text = "Lần thi: " + Lan;
            lblNgay.Text = "Ngày thi: " + NgayThi.ToString("dd/MM/yyyy");
            phut = ThoiGian;
            lblTimer.Text = phut.ToString("00") + " : " + giay.ToString("00");

            LoadCauHoi();

            lblTimer.Font = UIHelper.FontTimer;
            lblTimer.ForeColor = UIHelper.RedDelete;
            lblTimer.AutoSize = true;

            UIHelper.StyleButtonOutline(btnNop, UIHelper.GreenSave);
            UIHelper.StyleButtonOutline(btnThoat, UIHelper.GrayCancel);

            flpDeThi.BackColor = Color.WhiteSmoke;
            flpDeThi.Padding = new Padding(10);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl && lbl != lblTimer)
                {
                    lbl.Font = UIHelper.FontLabel;
                    lbl.ForeColor = UIHelper.PrimaryBlue;
                }
            }
        }

        private void LoadCauHoi()
        {
            DataTable dt;

            // ← Nếu tiếp tục bài dở → load câu cũ từ BAITHI_TAM
            if (FrmChuanBiThiSV.TiepTucBaiDo)
            {
                dt = Program.LayDuLieu(
                    "EXEC SP_GET_BAITHI_TAM N'" + Program.username.Trim() +
                    "', N'" + MaMon.Trim() + "', " + Lan);
            }
            else
            {
                // Bình thường → random câu mới
                dt = Program.LayDuLieu(
                    "EXEC SP_GET_CauHoi N'" + MaMon +
                    "', '" + TrinhDo + "', " + SoCau);
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không lấy được câu hỏi!");
                this.Close(); return;
            }

            danhSachCauHoi = new CauHoi[dt.Rows.Count];
            flpDeThi.Controls.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                danhSachCauHoi[i] = new CauHoi();
                danhSachCauHoi[i].HienThiCauHoi(
                    i + 1,
                    (int)dt.Rows[i]["CAUHOI"],
                    dt.Rows[i]["NOIDUNG"].ToString(),
                    dt.Rows[i]["A"].ToString(),
                    dt.Rows[i]["B"].ToString(),
                    dt.Rows[i]["C"].ToString(),
                    dt.Rows[i]["D"].ToString(),
                    dt.Rows[i]["DAP_AN"].ToString()
                );
                flpDeThi.Controls.Add(danhSachCauHoi[i]);

                int index = i;
                danhSachCauHoi[i].DaChonChanged += (s, ev) =>
                { CapNhatMauO(index, true); };

                // ← Nếu khôi phục → gán lại đáp án cũ
                if (FrmChuanBiThiSV.TiepTucBaiDo)
                {
                    string dapAnCu = dt.Rows[i]["DAP_AN_CHON"].ToString().Trim();
                    if (!string.IsNullOrWhiteSpace(dapAnCu))
                    {
                        danhSachCauHoi[i].KhoiPhucDapAn(dapAnCu);
                        CapNhatMauO(i, true);
                    }
                }
            }

            TaoOSoCau();

            // ← Nếu khôi phục → lấy lại thời gian còn lại
            if (FrmChuanBiThiSV.TiepTucBaiDo && dt.Rows.Count > 0)
            {
                phut = int.Parse(dt.Rows[0]["THOIGIAN_CON"].ToString());
                giay = 0;
                lblTimer.Text = phut.ToString("00") + " : 00";
            }

            timer1.Start();
            btnNop.Enabled = true;
        }

        // ================================================
        // TẠO PANEL Ô SỐ CÂU
        // ================================================
        private void TaoOSoCau()
        {
            // 1. Dùng FlowLayoutPanel thay vì Panel thường
            FlowLayoutPanel flpSoCau = new FlowLayoutPanel();
            flpSoCau.Location = lstDaChon.Location;
            flpSoCau.Size = new Size(lstDaChon.Width, lstDaChon.Height);

            // 2. Thiết lập tự động xuống dòng và có thanh cuộn nếu quá nhiều câu
            flpSoCau.FlowDirection = FlowDirection.LeftToRight;
            flpSoCau.WrapContents = true; // Tự động xuống hàng khi hết chiều rộng
            flpSoCau.AutoScroll = true;   // Hiện thanh cuộn nếu có 100-200 câu

            flpSoCau.Padding = new Padding(5);
            flpSoCau.BackColor = Color.WhiteSmoke;
            flpSoCau.BorderStyle = BorderStyle.FixedSingle;

            this.Controls.Add(flpSoCau);
            flpSoCau.BringToFront();

            // 3. Tạo các nút bấm
            for (int i = 0; i < danhSachCauHoi.Length; i++)
            {
                Button btn = new Button();
                btn.Size = new Size(40, 40); // Kích thước ô cố định
                btn.Text = (i + 1).ToString();
                btn.Margin = new Padding(3); // Khoảng cách giữa các ô

                // --- Giữ nguyên các phần Style và Event cũ của bạn ---
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.White;
                btn.Tag = i;

                int index = i;
                btn.Click += (s, ev) => {
                    flpDeThi.ScrollControlIntoView(danhSachCauHoi[index]);
                };
                // ---------------------------------------------------

                flpSoCau.Controls.Add(btn);
            }

            // Gán lại biến pnlSoCau để hàm CapNhatMauO vẫn chạy được
            pnlSoCau = flpSoCau;
        }
        // ← Cập nhật màu ô: xanh = đã chọn, trắng = chưa chọn
        private void CapNhatMauO(int index, bool daChon)
        {
            if (pnlSoCau == null) return;
            foreach (Control ctrl in pnlSoCau.Controls)
            {
                if (ctrl is Button btn && (int)btn.Tag == index)
                {
                    btn.BackColor = daChon
                        ? UIHelper.PrimaryBlue   // xanh = đã chọn
                        : Color.White;            // trắng = chưa chọn
                    btn.ForeColor = daChon
                        ? Color.White
                        : UIHelper.PrimaryBlue;
                    break;
                }
            }
        }

        // ================================================
        // TIMER
        // ================================================
        private void timer1_Tick(object sender, EventArgs e)
        {
            giay--;
            if (giay < 0) { giay = 59; phut--; }
            lblTimer.Text = phut.ToString("00") + " : " + giay.ToString("00");

            // ← Lưu tạm mỗi 30 giây
            demLuu++;
            if (demLuu >= 30)
            {
                demLuu = 0;
                LuuBaiThiTam();
            }

            if (phut == 0 && giay == 0)
            {
                timer1.Stop();
                MessageBox.Show("Hết giờ! Bài thi tự động nộp.");
                NopBai();
            }
        }
        private void NopBai()
        {
            timer1.Stop();
            btnNop.Enabled = false;

            double diem = TinhDiem();
            int soDung = DemCauDung();

            if (Program.nhom == "SINHVIEN")
            {
                // Ghi điểm
                Program.ThucThi(
                    "EXEC SP_GHI_DIEM N'" + Program.username.Trim() +
                    "', N'" + MaMon.Trim() +
                    "', " + Lan +
                    ", '" + NgayThi.ToString("yyyy-MM-dd") +
                    "', " + diem.ToString().Replace(",", "."));

                // Ghi chi tiết bài thi
                GhiChiTietBaiThi();

                // ← Xóa bài tạm sau khi nộp xong
                Program.ThucThi(
                    "EXEC SP_XOA_BAITHI_TAM N'" + Program.username.Trim() +
                    "', N'" + MaMon.Trim() + "', " + Lan);
            }

            // Hiện điểm
            MessageBox.Show(
                "🎉 Kết quả thi\n\n" +
                "Môn: " + MaMon + "\n" +
                "Số câu đúng: " + soDung + "/" + SoCau + "\n" +
                "Điểm: " + diem + "/10",
                "Kết quả", MessageBoxButtons.OK);

            // ← Hỏi xem chi tiết không
            if (MessageBox.Show(
                "Bạn có muốn xem lại chi tiết bài thi không?",
                "Xem chi tiết",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Truyền thông số vào FrmXemChiTiet
                FrmXemChiTiet.MaSV = Program.username;
                FrmXemChiTiet.MaMon = MaMon;
                FrmXemChiTiet.Lan = Lan;
                FrmXemChiTiet.Diem = diem;
                FrmXemChiTiet.SoCauDung = soDung;
                FrmXemChiTiet.TongSoCau = SoCau;

                this.Hide();
                new FrmXemChiTiet().ShowDialog();
            }

            this.Close();
        }

        // Thêm hàm này
        private void GhiChiTietBaiThi()
        {
            for (int i = 0; i < danhSachCauHoi.Length; i++)
            {
                string dapAnChon = string.IsNullOrEmpty(danhSachCauHoi[i].DaChon)
                                 ? " "
                                 : danhSachCauHoi[i].DaChon;
                Program.ThucThi(
                    "EXEC SP_GHI_CT_BAITHI " +
                    "N'" + Program.username.Trim() + "', " +
                    "N'" + MaMon.Trim() + "', " +
                    Lan + ", " +
                    (i + 1) + ", " +
                    danhSachCauHoi[i].IdCauHoi + ", " +
                    "N'" + dapAnChon + "'");
            }
        }

        private int DemCauDung()
        {
            int dem = 0;
            foreach (var cau in danhSachCauHoi)
                if (cau.DaChon.Trim() == cau.DapAn.Trim())
                    dem++;
            return dem;
        }

        private double TinhDiem()
        {
            int dung = DemCauDung();
            if (dung == 0) return 0;
            return Math.Round((double)(10 * dung) / SoCau, 2);
        }

        private void btnNop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn nộp bài?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                NopBai();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Bạn chưa nộp bài! Thoát sẽ tự động nộp bài.\nBạn có chắc không?",
                "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                NopBai();
        }

        private void lblLan_Click(object sender, EventArgs e) { }
        private void lblMaMon_Click(object sender, EventArgs e) { }
        // Lưu toàn bộ bài thi vào bảng tạm
        private void LuuBaiThiTam()
        {
            if (danhSachCauHoi == null) return;
            for (int i = 0; i < danhSachCauHoi.Length; i++)
            {
                string dapAn = string.IsNullOrEmpty(danhSachCauHoi[i].DaChon)
                             ? " " : danhSachCauHoi[i].DaChon;
                Program.ThucThi(
                    "EXEC SP_LUU_BAITHI_TAM " +
                    "N'" + Program.username.Trim() + "', " +
                    "N'" + MaMon.Trim() + "', " +
                    Lan + ", " + phut + ", " +
                    (i + 1) + ", " +          // ← thêm STT
                    danhSachCauHoi[i].IdCauHoi + ", " +
                    "N'" + dapAn + "'");
            }
        }

        
    }
}