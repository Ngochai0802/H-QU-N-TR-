using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    public partial class CauHoi : UserControl
    {
        public int SoCau { get; set; }
        public int IdCauHoi { get; set; }
        public string DapAn { get; set; }
        public string DaChon { get; set; } = "";

        // ← Thêm event này để FrmThi biết khi SV chọn đáp án
        public event EventHandler DaChonChanged;
        private void OnDaChonChanged()
        {
            DaChonChanged?.Invoke(this, EventArgs.Empty);
        }

        public CauHoi()
        {
            InitializeComponent();

            this.BackColor = Color.White;
            this.Padding = new Padding(10);
            this.Margin = new Padding(0, 0, 0, 10);

            this.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                    UIHelper.BorderGray, ButtonBorderStyle.Solid);
            };

            lblNoiDung.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            lblNoiDung.ForeColor = UIHelper.PrimaryBlue;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is RadioButton rb)
                {
                    rb.Font = UIHelper.FontLabel;
                    rb.ForeColor = Color.FromArgb(50, 50, 50);
                    rb.Cursor = Cursors.Hand;
                }
            }
        }

        public void HienThiCauHoi(int soCau, int id, string noiDung,
                                   string a, string b, string c, string d,
                                   string dapAn)
        {
            SoCau = soCau;
            IdCauHoi = id;
            DapAn = dapAn;
            DaChon = "";

            lblSoCau.Text = "Câu " + soCau + ":";
            lblNoiDung.Text = noiDung;
            rdoA.Text = "A. " + a;
            rdoB.Text = "B. " + b;
            rdoC.Text = "C. " + c;
            rdoD.Text = "D. " + d;

            rdoA.Checked = false;
            rdoB.Checked = false;
            rdoC.Checked = false;
            rdoD.Checked = false;
        }

        // ← Gọi OnDaChonChanged() khi chọn đáp án
        private void rdoA_CheckedChanged_1(object sender, EventArgs e)
        { if (rdoA.Checked) { DaChon = "A"; OnDaChonChanged(); } }

        private void rdoB_CheckedChanged_1(object sender, EventArgs e)
        { if (rdoB.Checked) { DaChon = "B"; OnDaChonChanged(); } }

        private void rdoC_CheckedChanged_1(object sender, EventArgs e)
        { if (rdoC.Checked) { DaChon = "C"; OnDaChonChanged(); } }

        private void rdoD_CheckedChanged_1(object sender, EventArgs e)
        { if (rdoD.Checked) { DaChon = "D"; OnDaChonChanged(); } }
        // Khôi phục đáp án đã chọn trước đó
        public void KhoiPhucDapAn(string dapAn)
        {
            DaChon = dapAn.Trim();
            rdoA.Checked = (DaChon == "A");
            rdoB.Checked = (DaChon == "B");
            rdoC.Checked = (DaChon == "C");
            rdoD.Checked = (DaChon == "D");
        }

    }
}