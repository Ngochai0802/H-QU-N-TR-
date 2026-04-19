using System;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string server = ".";
            string db = "THITRACNGHIEM";

            bool ok = Program.KetNoi(server, db);

            if (ok)
                MessageBox.Show("✅ Kết nối thành công!");
            else
                MessageBox.Show("❌ Kết nối thất bại!");
        }

        private void btnMoDangKy_Click(object sender, EventArgs e)
        {
            // Kết nối trước
            Program.KetNoi(".", "THITRACNGHIEM");
            new FrmGVDK().Show();
        }

        private void btnMoThiSV_Click_1(object sender, EventArgs e)
        {
            // Giả lập SV đăng nhập
            Program.username = "008";
            Program.hoTen = "TRINH PHONG";
            Program.nhom = "SINHVIEN";

            Program.KetNoi(".", "THITRACNGHIEM");
            new FrmChuanBiThiSV().Show();
        }

        
    }  // ← đóng class ở đây
}      // ← đóng namespace ở đây  