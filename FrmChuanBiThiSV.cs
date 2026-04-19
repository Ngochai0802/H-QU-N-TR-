using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    public partial class FrmChuanBiThiSV : Form
    {
        public static bool TiepTucBaiDo = false;
        public FrmChuanBiThiSV()
        {
            InitializeComponent();
            UIHelper.ApplyFormStyle(this);

            Panel pnlHeader = new Panel();
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 50;
            pnlHeader.Paint += (s, e) => UIHelper.PaintHeader(s, e, "CHUẨN BỊ THI");
            this.Controls.Add(pnlHeader);
            pnlHeader.BringToFront();
        }

        private void FrmChuanBiThiSV_Load(object sender, EventArgs e)
        {
            txtMaSV.Text = Program.username;
            txtHoTen.Text = Program.hoTen;

            // Lấy lớp của SV
            SqlDataReader rd = Program.DocTungDong(
                "SELECT L.MALOP, L.TENLOP FROM LOP L " +
                "JOIN SINHVIEN SV ON SV.MALOP = L.MALOP " +
                "WHERE SV.MASV = N'" + Program.username.Trim() + "'");

            if (rd != null && rd.Read())
            {
                txtMaLop.Text = rd.GetString(0).Trim();
                txtTenLop.Text = rd.GetString(1).Trim();
            }
            if (rd != null) rd.Close();
            Program.conn.Close();

            // ← Load môn chưa thi của lớp này
            LoadMonChuaThi();

            cboLan.Items.Add(1);
            cboLan.Items.Add(2);
            cboLan.SelectedIndex = -1;
            btnThi.Enabled = false;

            UIHelper.StyleButtonOutline(btnLoc, UIHelper.SecondaryBlue);
            UIHelper.StyleButtonOutline(btnThi, UIHelper.GreenSave);
            UIHelper.StyleDataGridView(dgvLichThi);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                { lbl.Font = UIHelper.FontLabel; lbl.ForeColor = UIHelper.PrimaryBlue; }
                if (ctrl is GroupBox gb)
                    UIHelper.StyleGroupBox(gb);
            }

            UIHelper.StyleInput(txtMaSV);
            UIHelper.StyleInput(cboMon);
            UIHelper.StyleInput(dtpNgay);
            UIHelper.StyleInput(cboLan);
        }

        // ← Chỉ load môn + lần chưa thi của lớp SV
        private void LoadMonChuaThi()
        {
            DataTable dtMon = Program.LayDuLieu(
                "SELECT DISTINCT GD.MAMH, MH.TENMH " +
                "FROM GIAOVIEN_DANGKY GD " +
                "JOIN MONHOC MH ON GD.MAMH = MH.MAMH " +
                "WHERE GD.MALOP = N'" + txtMaLop.Text.Trim() + "' " +
                // ← Chỉ ẩn môn khi lần đó SV đã thi rồi
                "AND NOT EXISTS (" +
                "   SELECT 1 FROM BANGDIEM BD " +
                "   WHERE BD.MASV = N'" + Program.username.Trim() + "' " +
                "   AND BD.MAMH = GD.MAMH " +
                "   AND BD.LAN  = GD.LAN" +  // ← giữ điều kiện LAN
                ")");

            cboMon.DataSource = dtMon;
            cboMon.DisplayMember = "TENMH";
            cboMon.ValueMember = "MAMH";
            cboMon.SelectedIndex = -1;

            if (dtMon.Rows.Count == 0)
                MessageBox.Show("Bạn đã thi hết các môn được đăng ký!");
        }
        private void btnLoc_Click_1(object sender, EventArgs e)
        {
            if (cboMon.SelectedValue == null)
            { MessageBox.Show("Chưa chọn môn học!"); return; }

            if (cboLan.SelectedIndex < 0)
            { MessageBox.Show("Chưa chọn lần thi!"); return; }

            string maMon = cboMon.SelectedValue.ToString().Trim();
            int lan = (int)cboLan.SelectedItem;

            // ← THÊM: kiểm tra SV đã thi lần này chưa
            SqlDataReader rd = Program.DocTungDong(
                "EXEC SP_KT_Lan_Thi N'" + Program.username.Trim() +
                "', N'" + maMon + "', " + lan);
            if (rd == null) return;
            rd.Read();
            string kq = rd.GetString(0);
            rd.Close(); Program.conn.Close();

            if (kq == "1")
            {
                MessageBox.Show("Bạn đã thi lần " + lan + " môn này rồi!");
                dgvLichThi.DataSource = null; // xóa grid
                btnThi.Enabled = false;
                return; // ← dừng, không xuống grid
            }

            // Chưa thi → lọc lịch thi bình thường
            DataTable dt = Program.LayDuLieu(
                "EXEC SP_GET_GVDK N'" + txtMaLop.Text.Trim() +
                "', N'" + maMon +
                "', '" + dtpNgay.Value.ToString("yyyy-MM-dd") +
                "', " + lan);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy lịch thi theo điều kiện đã chọn!");
                btnThi.Enabled = false;
                return;
            }

            dgvLichThi.DataSource = dt;
            btnThi.Enabled = true;
        }

        private void btnThi_Click_1(object sender, EventArgs e)
        {
            if (dgvLichThi.CurrentRow == null) return;

            string maMon = dgvLichThi.CurrentRow.Cells["MAMH"].Value.ToString().Trim();
            int lan = int.Parse(dgvLichThi.CurrentRow.Cells["LAN"].Value.ToString());

            // Nếu lần 2: kiểm tra đã thi lần 1 chưa
            if (lan == 2)
            {
                SqlDataReader rd1 = Program.DocTungDong(
                    "EXEC SP_KT_Lan_Thi N'" + Program.username.Trim() +
                    "', N'" + maMon + "', 1");
                if (rd1 == null) return;
                rd1.Read();
                string kq1 = rd1.GetString(0);
                rd1.Close(); Program.conn.Close();

                if (kq1 == "0")
                { MessageBox.Show("Bạn chưa thi lần 1, không thể thi lần 2!"); return; }
            }

            // Kiểm tra đã thi lần này chưa
            SqlDataReader rd = Program.DocTungDong(
                "EXEC SP_KT_Lan_Thi N'" + Program.username.Trim() +
                "', N'" + maMon + "', " + lan);
            if (rd == null) return;
            rd.Read();
            string kq = rd.GetString(0);
            rd.Close(); Program.conn.Close();

            if (kq == "1")
            { MessageBox.Show("Bạn đã thi lần này rồi, không được thi lại!"); return; }

            // ← THÊM: Kiểm tra có bài thi dở không
            TiepTucBaiDo = false;
            SqlDataReader rdTam = Program.DocTungDong(
                "EXEC SP_KT_BAITHI_TAM N'" + Program.username.Trim() +
                "', N'" + maMon + "', " + lan);
            if (rdTam != null)
            {
                rdTam.Read();
                string kqTam = rdTam.GetString(0);
                rdTam.Close(); Program.conn.Close();

                if (kqTam == "1")
                {
                    DialogResult dr = MessageBox.Show(
                        "Bạn có bài thi chưa hoàn thành!\n" +
                        "Bấm YES để tiếp tục bài cũ\n" +
                        "Bấm NO để bắt đầu bài mới",
                        "Phát hiện bài thi dở",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    TiepTucBaiDo = (dr == DialogResult.Yes);

                    // Nếu bắt đầu mới → xóa bài tạm cũ
                    if (!TiepTucBaiDo)
                        Program.ThucThi(
                            "EXEC SP_XOA_BAITHI_TAM N'" + Program.username.Trim() +
                            "', N'" + maMon + "', " + lan);
                }
            }

            // Truyền thông số vào FrmThi
            FrmThi.MaMon = maMon;
            FrmThi.TrinhDo = dgvLichThi.CurrentRow.Cells["TRINHDO"].Value.ToString().Trim();
            FrmThi.Lan = lan;
            FrmThi.MaLop = txtMaLop.Text.Trim();
            FrmThi.TenLop = txtTenLop.Text.Trim();
            FrmThi.ThoiGian = int.Parse(dgvLichThi.CurrentRow.Cells["THOIGIAN"].Value.ToString());
            FrmThi.SoCau = int.Parse(dgvLichThi.CurrentRow.Cells["SOCAUTHI"].Value.ToString());
            FrmThi.NgayThi = Convert.ToDateTime(dgvLichThi.CurrentRow.Cells["NGAYTHI"].Value);

            this.Hide();
            new FrmThi().Show();
        }

        private void label1_Click(object sender, EventArgs e) { }
    }
}