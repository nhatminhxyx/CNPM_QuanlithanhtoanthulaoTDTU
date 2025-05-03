using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ThanhToanDAL
    {
        // 1. Lấy tất cả đề tài (cho phép thanh toán nhiều lần)
        public DataTable GetAllDeTai()
        {
            using var conn = SqlConnectionData.Connect();
            conn.Open();
            string sql = "SELECT MaDeTai, TenDeTai, MaGV, KinhPhi FROM DeTai";
            using var da = new SqlDataAdapter(sql, conn);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // 2. Lấy MaGV theo MaDeTai
        public string GetMaGVByMaDeTai(string maDeTai)
        {
            using var conn = SqlConnectionData.Connect();
            conn.Open();
            string sql = "SELECT MaGV FROM DeTai WHERE MaDeTai = @MaDeTai";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaDeTai", maDeTai);
            return cmd.ExecuteScalar() as string;
        }

        // 3. Lấy kinh phí theo MaDeTai
        public double? GetKinhPhiByMaDeTai(string maDeTai)
        {
            using var conn = SqlConnectionData.Connect();
            conn.Open();
            string sql = "SELECT KinhPhi FROM DeTai WHERE MaDeTai = @MaDeTai";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaDeTai", maDeTai);
            var obj = cmd.ExecuteScalar();
            return obj == null ? (double?)null : Convert.ToDouble(obj);
        }

        // 4. Lưu thanh toán
        public bool InsertThanhToan(ThanhToanDTO tt)
        {
            using var conn = SqlConnectionData.Connect();
            conn.Open();
            const string sql = @"
                INSERT INTO ThanhToan
                  (MaThanhToan, MaGV, MaDeTai, SoTien, NgayThanhToan, TrangThai)
                VALUES
                  (@MaThanhToan, @MaGV, @MaDeTai, @SoTien, @NgayThanhToan, @TrangThai)";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaThanhToan", tt.MaThanhToan);
            cmd.Parameters.AddWithValue("@MaGV", tt.MaGV);
            cmd.Parameters.AddWithValue("@MaDeTai", tt.MaDeTai);
            cmd.Parameters.AddWithValue("@SoTien", tt.SoTien);
            cmd.Parameters.AddWithValue("@NgayThanhToan", tt.NgayThanhToan);
            cmd.Parameters.AddWithValue("@TrangThai", tt.TrangThai);
            return cmd.ExecuteNonQuery() > 0;
        }

        // 5. Lấy các bản ghi thanh toán theo khoảng ngày
        public DataTable GetThanhToanByDateRange(DateTime tuNgay, DateTime denNgay)
        {
            using var conn = SqlConnectionData.Connect();
            conn.Open();
            const string sql = @"
        SELECT *
        FROM ThanhToan
        WHERE TrangThai = N'Đã thanh toán'
          AND NgayThanhToan BETWEEN @TuNgay AND @DenNgay";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
            cmd.Parameters.AddWithValue("@DenNgay", denNgay);
            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // 6. Tìm thanh toán theo MaDeTai
        public DataTable GetThanhToanByMaDeTai(string maDeTai)
        {
            using var conn = SqlConnectionData.Connect();
            conn.Open();
            const string sql = "SELECT * FROM ThanhToan WHERE MaDeTai = @MaDeTai";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaDeTai", maDeTai);
            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // 7. Sinh MaThanhToan
        public string GenerateMaThanhToan(string maDeTai)
        {
            return $"TT_{maDeTai}";
        }

            // Lấy danh sách Đề tài chưa thanh toán
            public DataTable GetDeTaiChuaThanhToan()
            {
                using var conn = SqlConnectionData.Connect();
                conn.Open();
                const string sql = @"
            SELECT dt.MaDeTai, dt.TenDeTai, dt.MaGV, dt.KinhPhi
            FROM DeTai dt
            WHERE NOT EXISTS (
                SELECT 1 FROM ThanhToan tt
                 WHERE tt.MaDeTai = dt.MaDeTai
                   AND tt.TrangThai = N'Đã thanh toán'
            )";
                using var da = new SqlDataAdapter(sql, conn);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

            // Kiểm tra xem Đề tài đã được thanh toán chưa
            public bool HasBeenPaid(string maDeTai)
            {
                using var conn = SqlConnectionData.Connect();
                conn.Open();
                const string sql = @"
            SELECT COUNT(*) 
            FROM ThanhToan 
            WHERE MaDeTai = @MaDeTai
              AND TrangThai = N'Đã thanh toán'";
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaDeTai", maDeTai);
                return (int)cmd.ExecuteScalar() > 0;
            }
        
    }
}
