using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DeTaiDAL
    {
        // Lấy danh sách đề tài theo mã khoa
        public DataTable GetDeTaiByKhoa(string maKhoa)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT MaDeTai FROM DeTai WHERE MaKhoa = @MaKhoa ORDER BY MaDeTai ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        // Thêm đề tài mới
        public void AddDeTai(DeTaiDTO deTai)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "INSERT INTO DeTai (MaDeTai, TenDeTai, MaKhoa, MaGV, KinhPhi, ThoiGianBatDau, ThoiGianKetThuc) VALUES (@MaDeTai, @TenDeTai, @MaKhoa, @MaGV, @KinhPhi, @ThoiGianBatDau, @ThoiGianKetThuc)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDeTai", deTai.MaDeTai);
                    cmd.Parameters.AddWithValue("@TenDeTai", deTai.TenDeTai);
                    cmd.Parameters.AddWithValue("@MaKhoa", deTai.MaKhoa);
                    cmd.Parameters.AddWithValue("@MaGV", deTai.MaGV);
                    cmd.Parameters.AddWithValue("@KinhPhi", deTai.KinhPhi);
                    cmd.Parameters.AddWithValue("@ThoiGianBatDau", deTai.ThoiGianBatDau);
                    cmd.Parameters.AddWithValue("@ThoiGianKetThuc", deTai.ThoiGianKetThuc);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Xóa đề tài
        public void DeleteDeTai(string maDT)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "DELETE FROM DeTai WHERE MaDeTai = @MaDeTai";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDeTai", maDT);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Cập nhật đề tài
        public bool UpdateDeTai(DeTaiDTO deTai)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "UPDATE DeTai SET TenDeTai = @TenDeTai, MaKhoa = @MaKhoa, MaGV = @MaGV, KinhPhi = @KinhPhi, ThoiGianBatDau = @ThoiGianBatDau, ThoiGianKetThuc = @ThoiGianKetThuc WHERE MaDeTai = @MaDeTai";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDeTai", deTai.MaDeTai);
                    cmd.Parameters.AddWithValue("@TenDeTai", deTai.TenDeTai);
                    cmd.Parameters.AddWithValue("@MaKhoa", deTai.MaKhoa);
                    cmd.Parameters.AddWithValue("@MaGV", deTai.MaGV);
                    cmd.Parameters.AddWithValue("@KinhPhi", deTai.KinhPhi);
                    cmd.Parameters.AddWithValue("@ThoiGianBatDau", deTai.ThoiGianBatDau);
                    cmd.Parameters.AddWithValue("@ThoiGianKetThuc", deTai.ThoiGianKetThuc);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Tìm kiếm đề tài theo mã hoặc tên
        public DataTable SearchDeTai(string searchValue)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT MaDeTai, TenDeTai, MaKhoa, MaGV, KinhPhi, ThoiGianBatDau, ThoiGianKetThuc FROM DeTai WHERE MaDeTai = @SearchValue OR TenDeTai LIKE '%' + @SearchValue + '%' ORDER BY TenDeTai ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchValue", searchValue);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        // Kiểm tra mã đề tài trước khi thêm
        public bool CheckMaDTBeforeAdding(string maDT)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM DeTai WHERE MaDeTai = @MaDeTai";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDeTai", maDT);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        // Kiểm tra mã đề tài trước khi xóa
        public bool CheckMaDTBeforeDeleting(string maDT)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM DeTai WHERE MaDeTai = @MaDeTai";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDeTai", maDT);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        // Lấy danh sách khoa
        public DataTable GetAllKhoa()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT MaKhoa, TenKhoa FROM Khoa ORDER BY TenKhoa ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        // Lấy danh sách giảng viên hướng dẫn
        public DataTable GetAllGiangVien()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT MaGV, HoTen FROM GiangVien ORDER BY HoTen ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable GetGiangVienByMa(string maGV)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT HoTen FROM GiangVien WHERE MaGV = @MaGV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaGV", maGV);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public bool CheckMaGVExists(string maGV)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM GiangVien WHERE MaGV = @MaGV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaGV", maGV);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
        public DataTable GetDeTaiByKhoaAndDate(string maKhoa, DateTime ngayBatDau)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT * FROM DeTai WHERE MaKhoa = @MaKhoa AND ThoiGianBatDau = @NgayBatDau";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                    cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public DataTable GetDangKyTheoDeTai(string maDeTai)
        {
            var dt = new DataTable();
            using var conn = SqlConnectionData.Connect();
            using var cmd = new SqlCommand(
                "SELECT dk.MaDangKy, dk.MaSV, sv.HoTen AS TenSinhVien, dk.TrangThai " +
                "FROM DangKyDeTai dk " +
                "JOIN SinhVien sv ON dk.MaSV = sv.MaSV " +
                "WHERE dk.MaDeTai = @maDeTai", conn);
            cmd.Parameters.AddWithValue("@maDeTai", maDeTai);
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
