using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    public partial class FrmGVDK : Form
    {
        private bool dangThem = false;
        private bool dangSua = false;

        private string maLopDangSua = "";
        private string maMonDangSua = "";
        private int lanDangSua = 0;

        public FrmGVDK()
        {
            InitializeComponent();
            UIHelper.ApplyFormStyle(this);

            Panel pnlHeader = new Panel();
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 90;
            pnlHeader.Paint += (s, e) => UIHelper.PaintHeader(s, e, "ĐĂNG KÝ THI");
            this.Controls.Add(pnlHeader);
            pnlHeader.BringToFront();
        }

        private void FrmGVDK_Load(object sender, EventArgs e)
        {
            nudSoCau.Minimum = 10; nudSoCau.Maximum = 1000;
            nudThoiGian.Minimum = 15; nudThoiGian.Maximum = 60;

            cboTrinhDo.Items.AddRange(new object[] { "A", "B", "C" });
            cboLan.Items.Add(1);
            cboLan.Items.Add(2);

            // 🔥 LOAD DATA TRƯỚC
            LoadCboGV();
            LoadCboLop();
            LoadCboMon();

            // 🔥 FIX QUAN TRỌNG: phân quyền SAU khi load combobox
            if (Program.nhom.Trim() == "GV")
            {
                cboGV.SelectedValue = Program.username.Trim(); // 🔥 thêm Trim
                cboGV.Enabled = false;
            }
            else if (Program.nhom.Trim() == "PGV")
            {
                cboGV.Enabled = true;
            }

            // 🔥 GỌI GRID SAU CÙNG
            TaiLaiGrid();

            SetInputEnabled(false);
            btnGhi.Enabled = false;
            btnHuy.Enabled = false;

            UIHelper.StyleButtonOutline(btnThem, UIHelper.SecondaryBlue);
            UIHelper.StyleButtonOutline(btnSua, UIHelper.OrangeEdit);
            UIHelper.StyleButtonOutline(btnXoa, UIHelper.RedDelete);
            UIHelper.StyleButtonOutline(btnGhi, UIHelper.GreenSave);
            UIHelper.StyleButtonOutline(btnHuy, UIHelper.GrayCancel);
            UIHelper.StyleDataGridView(dgvDangKy);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.Font = UIHelper.FontLabel;
                    lbl.ForeColor = UIHelper.PrimaryBlue;
                }
                if (ctrl is GroupBox gb)
                {
                    UIHelper.StyleGroupBox(gb);
                }
            }
        }

        private void LoadCboGV()
        {
            DataTable dt = Program.LayDuLieu(
                "SELECT MAGV, HO + N' ' + TEN AS TENGV FROM GIAOVIEN ORDER BY TEN");
            cboGV.DataSource = null;
            cboGV.DisplayMember = "TENGV";
            cboGV.ValueMember = "MAGV";
            cboGV.DataSource = dt;
            cboGV.SelectedIndex = -1;
        }

        private void LoadCboLop()
        {
            DataTable dt = Program.LayDuLieu("SELECT MALOP, TENLOP FROM LOP ORDER BY TENLOP");
            cboLop.DataSource = dt; cboLop.DisplayMember = "TENLOP";
            cboLop.ValueMember = "MALOP"; cboLop.SelectedIndex = -1;
        }

        private void LoadCboMon()
        {
            DataTable dt = Program.LayDuLieu("SELECT MAMH, TENMH FROM MONHOC ORDER BY TENMH");
            cboMon.DataSource = dt; cboMon.DisplayMember = "TENMH";
            cboMon.ValueMember = "MAMH"; cboMon.SelectedIndex = -1;
        }

        // ← CHỈ HIỆN ĐĂNG KÝ CỦA GV ĐANG ĐĂNG NHẬP
        private void TaiLaiGrid()
        {
            string sql;

            if (Program.nhom == "PGV")
            {
                // 🔥 PGV thấy tất cả
                sql =
                    "SELECT GD.MAGV, GD.MALOP, L.TENLOP, " +
                    "GD.MAMH, M.TENMH, GD.TRINHDO, " +
                    "GD.LAN, GD.NGAYTHI, GD.SOCAUTHI, GD.THOIGIAN " +
                    "FROM GIAOVIEN_DANGKY GD " +
                    "JOIN LOP L ON GD.MALOP = L.MALOP " +
                    "JOIN MONHOC M ON GD.MAMH = M.MAMH " +
                    "ORDER BY GD.NGAYTHI DESC";
            }
            else
            {
                // 🔥 GV chỉ thấy của mình
                sql =
                    "SELECT GD.MAGV, GD.MALOP, L.TENLOP, " +
                    "GD.MAMH, M.TENMH, GD.TRINHDO, " +
                    "GD.LAN, GD.NGAYTHI, GD.SOCAUTHI, GD.THOIGIAN " +
                    "FROM GIAOVIEN_DANGKY GD " +
                    "JOIN LOP L ON GD.MALOP = L.MALOP " +
                    "JOIN MONHOC M ON GD.MAMH = M.MAMH " +
                    "WHERE GD.MAGV = N'" + Program.username + "' " +
                    "ORDER BY GD.NGAYTHI DESC";
            }

            dgvDangKy.DataSource = Program.LayDuLieu(sql);
        }
        private void SetInputEnabled(bool enable)
        {
            cboLop.Enabled = enable;
            cboMon.Enabled = enable; cboTrinhDo.Enabled = enable;
            cboLan.Enabled = enable; dtpNgay.Enabled = enable;
            nudSoCau.Enabled = enable; nudThoiGian.Enabled = enable;
            // 🔥 xử lý riêng cboGV
            if (Program.nhom.Trim() == "GV")
            {
                cboGV.Enabled = false;
            }
            else
            {
                cboGV.Enabled = enable;
            }
        }
        

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            dangThem = true; dangSua = false;
            SetInputEnabled(true);
            cboGV.SelectedIndex = cboLop.SelectedIndex =
            cboMon.SelectedIndex = cboTrinhDo.SelectedIndex =
            cboLan.SelectedIndex = -1;
            // ← Mặc định ngày mai
            dtpNgay.Value = DateTime.Today.AddDays(1);
            nudSoCau.Value = 10;
            nudThoiGian.Value = 15;
            btnGhi.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (dgvDangKy.CurrentRow == null)
            { MessageBox.Show("Chọn dòng muốn sửa!"); return; }

            dangSua = true; dangThem = false;
            maLopDangSua = dgvDangKy.CurrentRow.Cells["MALOP"].Value.ToString().Trim();
            maMonDangSua = dgvDangKy.CurrentRow.Cells["MAMH"].Value.ToString().Trim();
            lanDangSua = int.Parse(dgvDangKy.CurrentRow.Cells["LAN"].Value.ToString());

            SetInputEnabled(true);
            cboLop.Enabled = cboMon.Enabled = cboLan.Enabled = false;

            cboGV.SelectedValue = dgvDangKy.CurrentRow.Cells["MAGV"].Value.ToString().Trim();
            cboTrinhDo.Text = dgvDangKy.CurrentRow.Cells["TRINHDO"].Value.ToString().Trim();
            cboLan.Text = lanDangSua.ToString();
            dtpNgay.Value = Convert.ToDateTime(dgvDangKy.CurrentRow.Cells["NGAYTHI"].Value);
            nudSoCau.Value = Convert.ToDecimal(dgvDangKy.CurrentRow.Cells["SOCAUTHI"].Value);
            nudThoiGian.Value = Convert.ToDecimal(dgvDangKy.CurrentRow.Cells["THOIGIAN"].Value);

            btnGhi.Enabled = btnHuy.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
        }

        private void btnGhi_Click_1(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;

            // 🔥 LẤY MAGV CHUẨN THEO PHÂN QUYỀN
            string maGV = Program.nhom.Trim() == "GV"
                ? Program.username.Trim()
                : (cboGV.SelectedValue != null ? cboGV.SelectedValue.ToString().Trim() : "");

            if (string.IsNullOrEmpty(maGV))
            {
                MessageBox.Show("Chưa xác định được giáo viên!");
                return;
            }

            if (dangThem)
            {
                // 🔥 CHECK TRÙNG
                SqlDataReader rd = Program.DocTungDong(
                    "EXEC SP_KT_GVDK N'" + cboMon.SelectedValue.ToString().Trim() +
                    "', N'" + cboLop.SelectedValue.ToString().Trim() +
                    "', " + cboLan.SelectedItem);

                if (rd == null) return;

                string kq = "";
                if (rd.Read())
                {
                    kq = rd.GetString(0);
                }
                rd.Close(); Program.conn.Close();

                if (kq == "1")
                {
                    MessageBox.Show("Đã tồn tại đăng ký thi này rồi!");
                    return;
                }

                // 🔥 INSERT
                string sql =
                    "INSERT INTO GIAOVIEN_DANGKY(MAGV,MAMH,MALOP,TRINHDO,NGAYTHI,LAN,SOCAUTHI,THOIGIAN) " +
                    "VALUES (N'" + maGV + "', " +
                    "N'" + cboMon.SelectedValue.ToString().Trim() + "', " +
                    "N'" + cboLop.SelectedValue.ToString().Trim() + "', " +
                    "'" + cboTrinhDo.Text.Trim() + "', " +
                    "'" + dtpNgay.Value.ToString("yyyy-MM-dd") + "', " +
                    cboLan.SelectedItem + ", " +
                    nudSoCau.Value + ", " +
                    nudThoiGian.Value + ")";

                if (Program.ThucThi(sql))
                {
                    MessageBox.Show("Đăng ký thi thành công!");
                    TaiLaiGrid();
                    DatVeCheDoBinhThuong();
                }
            }
            else if (dangSua)
            {
                // 🔥 UPDATE
                string sql =
                    "UPDATE GIAOVIEN_DANGKY SET " +
                    "MAGV=N'" + maGV + "', " +
                    "TRINHDO='" + cboTrinhDo.Text.Trim() + "', " +
                    "NGAYTHI='" + dtpNgay.Value.ToString("yyyy-MM-dd") + "', " +
                    "SOCAUTHI=" + nudSoCau.Value + ", " +
                    "THOIGIAN=" + nudThoiGian.Value + " " +
                    "WHERE MAMH=N'" + maMonDangSua + "' " +
                    "AND MALOP=N'" + maLopDangSua + "' " +
                    "AND LAN=" + lanDangSua;

                if (Program.ThucThi(sql))
                {
                    MessageBox.Show("Sửa thành công!");
                    TaiLaiGrid();
                    DatVeCheDoBinhThuong();
                }
            }
        }
        private void btnHuy_Click_1(object sender, EventArgs e)
        { DatVeCheDoBinhThuong(); }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (dgvDangKy.CurrentRow == null)
            { MessageBox.Show("Chọn dòng muốn xóa!"); return; }

            string maLop = dgvDangKy.CurrentRow.Cells["MALOP"].Value.ToString().Trim();
            string maMon = dgvDangKy.CurrentRow.Cells["MAMH"].Value.ToString().Trim();
            int lan = int.Parse(dgvDangKy.CurrentRow.Cells["LAN"].Value.ToString());

            SqlDataReader rd = Program.DocTungDong(
                "EXEC SP_KT_Lop_Da_Thi N'" + maLop + "', N'" + maMon + "', " + lan);
            if (rd == null) return;
            rd.Read(); string kq = rd.GetString(0);
            rd.Close(); Program.conn.Close();

            if (kq == "1")
            { MessageBox.Show("Lớp này đã có sinh viên thi rồi, không được xóa!"); return; }

            if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Program.ThucThi("DELETE FROM GIAOVIEN_DANGKY WHERE MAMH=N'" +
                    maMon + "' AND MALOP=N'" + maLop + "' AND LAN=" + lan))
                { MessageBox.Show("Xóa thành công!"); TaiLaiGrid(); }
            }
        }

        private bool KiemTraHopLe()
        {
            // 🔥 CHECK INPUT CƠ BẢN
            if (dangThem && Program.nhom.Trim() == "PGV" && cboGV.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn giáo viên!");
                cboGV.Focus();
                return false;
            }

            if (dangThem && cboLop.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn lớp!");
                cboLop.Focus();
                return false;
            }

            if (dangThem && cboMon.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn môn học!");
                cboMon.Focus();
                return false;
            }

            if (cboTrinhDo.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn trình độ!");
                cboTrinhDo.Focus();
                return false;
            }

            if (dangThem && cboLan.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn lần thi!");
                cboLan.Focus();
                return false;
            }

            // 🔥 NGÀY THI
            if (dtpNgay.Value.Date < DateTime.Today.AddDays(1))
            {
                MessageBox.Show("Ngày thi phải từ ngày mai (" +
                    DateTime.Today.AddDays(1).ToString("dd/MM/yyyy") + ") trở đi!");
                dtpNgay.Focus();
                return false;
            }

            // 🔥 CHECK LẦN 2
            if (dangThem && cboLan.SelectedIndex >= 0 && (int)cboLan.SelectedItem == 2)
            {
                SqlDataReader rd = Program.DocTungDong(
                    "EXEC SP_KT_GVDK N'" + cboMon.SelectedValue.ToString().Trim() +
                    "', N'" + cboLop.SelectedValue.ToString().Trim() + "', 1");

                if (rd == null) return false;

                rd.Read();
                string kq = rd.GetString(0);
                rd.Close();
                Program.conn.Close();

                if (kq == "0")
                {
                    MessageBox.Show("Chưa đăng ký lần 1, không thể đăng ký lần 2!");
                    return false;
                }

                SqlDataReader rd2 = Program.DocTungDong(
                    "SELECT NGAYTHI FROM GIAOVIEN_DANGKY WHERE MAMH=N'" +
                    cboMon.SelectedValue.ToString().Trim() +
                    "' AND MALOP=N'" + cboLop.SelectedValue.ToString().Trim() + "' AND LAN=1");

                if (rd2 == null) return false;

                rd2.Read();
                DateTime ngayLan1 = rd2.GetDateTime(0);
                rd2.Close();
                Program.conn.Close();

                if (dtpNgay.Value.Date <= ngayLan1.Date)
                {
                    MessageBox.Show("Ngày thi lần 2 phải sau ngày thi lần 1 (" +
                        ngayLan1.ToString("dd/MM/yyyy") + ")!");
                    dtpNgay.Focus();
                    return false;
                }
            }

            // 🔥 CHECK ĐỦ CÂU (QUAN TRỌNG NHẤT)
            string maMon = dangSua ? maMonDangSua : cboMon.SelectedValue?.ToString().Trim();
            string trinhDo = cboTrinhDo.Text.Trim();

            if (string.IsNullOrEmpty(maMon) || string.IsNullOrEmpty(trinhDo))
            {
                MessageBox.Show("Thiếu thông tin môn học hoặc trình độ!");
                return false;
            }

            DataTable dtCheck = Program.LayDuLieu(
                "EXEC SP_KT_DU_CAU N'" + maMon +
                "', '" + trinhDo +
                "', " + nudSoCau.Value);

            MessageBox.Show(dtCheck.Rows[0][0].ToString());
            MessageBox.Show(Program.conn.Database);

            if (dtCheck.Rows.Count == 0 || dtCheck.Rows[0][0].ToString() == "0")
            {
                // 🔥 THÔNG BÁO CHI TIẾT
                DataTable dtDem = Program.LayDuLieu(
                    "SELECT COUNT(*) FROM BODE WHERE MAMH=N'" + maMon +
                    "' AND TRINHDO='" + trinhDo + "'");

                int coChinh = int.Parse(dtDem.Rows[0][0].ToString());
                int yeuChinh;

                if (trinhDo == "C")
                {
                    yeuChinh = (int)nudSoCau.Value;

                    MessageBox.Show(
                        "Không đủ câu hỏi!\n\n" +
                        "Trình độ C: có " + coChinh +
                        " câu, cần đủ " + yeuChinh + " câu (100%)\n\n" +
                        "Vui lòng giảm số câu hoặc bổ sung thêm!"
                    );
                }
                else
                {
                    yeuChinh = (int)Math.Ceiling((double)nudSoCau.Value * 0.7);

                    MessageBox.Show(
                        "Không đủ câu hỏi!\n\n" +
                        "Trình độ " + trinhDo + ": có " + coChinh +
                        " câu, cần tối thiểu " + yeuChinh + " câu (70%)\n\n" +
                        "Vui lòng giảm số câu hoặc bổ sung thêm!"
                    );
                }
                 
                nudSoCau.Focus();
                return false;
            }

            return true;
        }

        private void DatVeCheDoBinhThuong()
        {
            dangThem = dangSua = false;
            SetInputEnabled(false);
            btnGhi.Enabled = btnHuy.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e) { }
    }
}