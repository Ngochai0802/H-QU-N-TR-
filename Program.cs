using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ThiTracNghiem
{
    internal static class Program
    {
        // =============================================
        // THÔNG TIN KẾT NỐI DB
        // =============================================
        public static SqlConnection conn = new SqlConnection();
        public static string connStr = "";

        // =============================================
        // THÔNG TIN NGƯỜI ĐANG ĐĂNG NHẬP
        // =============================================
        public static string username = "";  // MASV hoặc MAGV
        public static string hoTen = "";
        public static string nhom = "";  // "SINHVIEN" hoặc "GIANGVIEN"



      
        // =============================================
        // HÀM KẾT NỐI DATABASE
        // Gọi 1 lần duy nhất lúc đăng nhập
        // =============================================
        public static bool KetNoi(string server, string db)
        {
            try
            {
                connStr = "Data Source=" + server
                        + ";Initial Catalog=" + db
                        + ";Integrated Security=True";  // Windows Auth
                conn.ConnectionString = connStr;
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
                return false;
            }
        }

        // =============================================
        // HÀM LẤY DỮ LIỆU → TRẢ VỀ DATATABLE
        // Dùng khi cần load danh sách vào Grid/ComboBox
        // =============================================
        public static DataTable LayDuLieu(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        // =============================================
        // HÀM ĐỌC TỪNG DÒNG → TRẢ VỀ SQLDATAREADER
        // Dùng khi chỉ cần đọc 1-2 giá trị trả về
        // ⚠ Nhớ: sau khi dùng xong phải gọi
        //        rd.Close(); conn.Close();
        // =============================================
        public static SqlDataReader DocTungDong(string sql)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandTimeout = 60;
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc dữ liệu: " + ex.Message);
                conn.Close();
                return null;
            }
        }

        // =============================================
        // HÀM THỰC THI INSERT / UPDATE / DELETE
        // Trả về true nếu thành công
        // =============================================
        public static bool ThucThi(string sql)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandTimeout = 60;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        // =============================================
        // MAIN — điểm khởi động app
        // =============================================
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // 🔥 KẾT NỐI DB (QUAN TRỌNG)
            Program.KetNoi("MSI", "THITRACNGHIEM");

            // 🔥 THÊM 2 DÒNG NÀY
            Program.username = "PGV";
            Program.nhom = "PGV";

            //Application.Run(new FrmGVDK()); // chạy thẳng form đăng ký
            Application.Run(new Form1());


        }
    }
}