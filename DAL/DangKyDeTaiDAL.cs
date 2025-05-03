using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class DangKyDeTaiDAL
    {
        // Tìm kiếm đề tài theo mã
        public DataTable TimKiemDeTai(string maDeTai)
        {
            using var conn = SqlConnectionData.Connect();
            using var cmd = new SqlCommand("SELECT * FROM DeTai WHERE MaDeTai = @maDeTai", conn);
            cmd.Parameters.AddWithValue("@maDeTai", maDeTai);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Kiểm tra sinh viên đã đăng ký đề tài này chưa
        public bool KiemTraTrungDangKy(string maSV, string maDeTai)
        {
            using var conn = SqlConnectionData.Connect();
            using var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM DangKyDeTai WHERE MaSV = @maSV AND MaDeTai = @maDeTai", conn);
            cmd.Parameters.AddWithValue("@maSV", maSV);
            cmd.Parameters.AddWithValue("@maDeTai", maDeTai);
            conn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }

        // Đăng ký đề tài mới
        public bool DangKyDeTai(DangKyDeTaiDTO dk)
        {
            using var conn = SqlConnectionData.Connect();
            using var cmd = new SqlCommand(
                "INSERT INTO DangKyDeTai (MaSV, MaDeTai, TrangThai) VALUES (@maSV, @maDT, @trangThai)", conn);
            cmd.Parameters.AddWithValue("@maSV", dk.MaSV);
            cmd.Parameters.AddWithValue("@maDT", dk.MaDeTai);
            cmd.Parameters.AddWithValue("@trangThai", dk.TrangThai);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        // Cập nhật trạng thái
        public bool CapNhatTrangThai(string maDangKy, string trangThai)
        {
            using var conn = SqlConnectionData.Connect();
            using var cmd = new SqlCommand(
                "UPDATE DangKyDeTai SET TrangThai = @trangThai WHERE MaDangKy = @maDangKy", conn);
            cmd.Parameters.AddWithValue("@maDangKy", maDangKy);
            cmd.Parameters.AddWithValue("@trangThai", trangThai);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        // Lấy danh sách đề tài đang chờ duyệt (Admin/GV)
        public DataTable LayDanhSachDeTaiChuaDuyet(string role, string maGV = null)
        {
            var dtb = new DataTable();
            using var conn = SqlConnectionData.Connect();
            using var cmd = conn.CreateCommand();
            conn.Open();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT dk.MaDangKy, dk.MaSV, sv.HoTen AS TenSinhVien, dt.MaDeTai, dt.TenDeTai, dk.TrangThai");
            sb.AppendLine("FROM DangKyDeTai dk");
            sb.AppendLine("JOIN SinhVien sv ON dk.MaSV = sv.MaSV");
            sb.AppendLine("JOIN DeTai dt ON dk.MaDeTai = dt.MaDeTai");
            sb.AppendLine("WHERE dk.TrangThai = @trangThai");
            cmd.Parameters.Add("@trangThai", SqlDbType.NVarChar, 50).Value = "Chờ duyệt";
            if (role == "GV" && !string.IsNullOrEmpty(maGV))
            {
                sb.AppendLine("  AND dt.MaGV = @maGV");
                cmd.Parameters.Add("@maGV", SqlDbType.NVarChar, 20).Value = maGV;
            }
            cmd.CommandText = sb.ToString();
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dtb);
            return dtb;
        }

        // Lấy danh sách đăng ký đề tài của sinh viên (SV) bao gồm trạng thái
        public DataTable LayDanhSachDangKyTheoSV(string maSV)
        {
            var dtb = new DataTable();
            using var conn = SqlConnectionData.Connect();
            using var cmd = new SqlCommand(
                "SELECT dk.MaDangKy, dk.MaDeTai, dt.TenDeTai, dk.TrangThai " +
                "FROM DangKyDeTai dk " +
                "JOIN DeTai dt ON dk.MaDeTai = dt.MaDeTai " +
                "WHERE dk.MaSV = @maSV", conn);
            cmd.Parameters.AddWithValue("@maSV", maSV);
            var da = new SqlDataAdapter(cmd);
            da.Fill(dtb);
            return dtb;
        }
    }
}
