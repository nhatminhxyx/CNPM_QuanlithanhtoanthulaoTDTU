using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAL
{
    public class SinhVienDAL
    {
        // Lấy danh sách sinh viên theo mã khoa
        public DataTable GetSinhVienByKhoa(string maKhoa)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT MaSV FROM SinhVien WHERE MaKhoa = @MaKhoa ORDER BY MaSV ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        // Thêm sinh viên mới
        public void AddSinhVien(SinhVienDTO sinhVien)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "INSERT INTO SinhVien (MaSV, HoTen, MaKhoa, Lop, NgaySinh, QueQuan) VALUES (@MaSV, @HoTen, @MaKhoa, @Lop, @NgaySinh, @QueQuan)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", sinhVien.MaSV);
                    cmd.Parameters.AddWithValue("@HoTen", sinhVien.HoTen);
                    cmd.Parameters.AddWithValue("@MaKhoa", sinhVien.MaKhoa);
                    cmd.Parameters.AddWithValue("@Lop", sinhVien.Lop);
                    cmd.Parameters.AddWithValue("@NgaySinh", sinhVien.NgaySinh);
                    cmd.Parameters.AddWithValue("@QueQuan", sinhVien.QueQuan);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Xóa sinh viên
        public void DeleteSinhVien(string maSV)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "DELETE FROM SinhVien WHERE MaSV = @MaSV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Cập nhật sinh viên
        public bool UpdateSinhVien(SinhVienDTO sinhVien)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "UPDATE SinhVien SET HoTen = @HoTen, MaKhoa = @MaKhoa, Lop = @Lop, NgaySinh = @NgaySinh, QueQuan = @QueQuan WHERE MaSV = @MaSV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", sinhVien.MaSV);
                    cmd.Parameters.AddWithValue("@HoTen", sinhVien.HoTen);
                    cmd.Parameters.AddWithValue("@MaKhoa", sinhVien.MaKhoa);
                    cmd.Parameters.AddWithValue("@Lop", sinhVien.Lop);
                    cmd.Parameters.AddWithValue("@NgaySinh", sinhVien.NgaySinh);
                    cmd.Parameters.AddWithValue("@QueQuan", sinhVien.QueQuan);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Tìm kiếm sinh viên theo mã hoặc tên
        public DataTable SearchSinhVien(string searchValue)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT MaSV, HoTen, MaKhoa, Lop, NgaySinh, QueQuan FROM SinhVien WHERE MaSV = @SearchValue OR HoTen LIKE '%' + @SearchValue + '%' ORDER BY HoTen ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchValue", searchValue);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        // Kiểm tra mã sinh viên trước khi thêm
        public bool CheckMaSVBeforeAdding(string maSV)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM SinhVien WHERE MaSV = @MaSV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        // Kiểm tra mã sinh viên trước khi xóa
        public bool CheckMaSVBeforeDeleting(string maSV)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM SinhVien WHERE MaSV = @MaSV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSV", maSV);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        // Lấy tất cả khoa
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
    }
}
