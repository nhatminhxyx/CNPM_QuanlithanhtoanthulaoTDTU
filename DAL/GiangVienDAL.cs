using System;
using System.Data;
using Microsoft.Data.SqlClient;
using DTO;

namespace DAL
{
    public class GiangVienDAL
    {
        // Lấy danh sách giảng viên theo mã khoa
        public DataTable GetGiangVienByKhoa(string maKhoa)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT MaGV FROM GiangVien WHERE MaKhoa = @MaKhoa ORDER BY MaGV ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }


        // Thêm giảng viên mới vào cơ sở dữ liệu (có thêm QueQuan)
        public void AddGiangVien(GiangVienDTO giangVien)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "INSERT INTO GiangVien (MaGV, HoTen, MaKhoa, HocVi, SoDienThoai, QueQuan) VALUES (@MaGV, @HoTen, @MaKhoa, @HocVi, @SoDienThoai, @QueQuan)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaGV", giangVien.MaGV);
                    cmd.Parameters.AddWithValue("@HoTen", giangVien.HoTen);
                    cmd.Parameters.AddWithValue("@MaKhoa", giangVien.MaKhoa);
                    cmd.Parameters.AddWithValue("@HocVi", giangVien.HocVi);
                    cmd.Parameters.AddWithValue("@SoDienThoai", giangVien.SoDienThoai);
                    cmd.Parameters.AddWithValue("@QueQuan", giangVien.QueQuan);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        // Xóa giảng viên
        public void DeleteGiangVien(string maGV)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "DELETE FROM GiangVien WHERE MaGV = @MaGV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaGV", maGV);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // Kiểm tra mã giảng viên trước khi thêm
        public bool CheckMaGVBeforeAdding(string maGV)
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

        // Kiểm tra mã giảng viên trước khi xóa
        public bool CheckMaGVBeforeDeleting(string maGV)
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

        public DataTable SearchGiangVien(string searchValue)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "SELECT MaGV, HoTen, MaKhoa, HocVi, SoDienThoai, QueQuan FROM GiangVien WHERE MaGV = @SearchValue OR HoTen LIKE '%' + @SearchValue + '%' ORDER BY HoTen ASC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchValue", searchValue);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public bool UpdateGiangVien(GiangVienDTO giangVien)
        {
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                conn.Open();
                string query = "UPDATE GiangVien SET HoTen = @HoTen, MaKhoa = @MaKhoa, HocVi = @HocVi, SoDienThoai = @SoDienThoai, QueQuan = @QueQuan WHERE MaGV = @MaGV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaGV", giangVien.MaGV);
                    cmd.Parameters.AddWithValue("@HoTen", giangVien.HoTen);
                    cmd.Parameters.AddWithValue("@MaKhoa", giangVien.MaKhoa);
                    cmd.Parameters.AddWithValue("@HocVi", giangVien.HocVi);
                    cmd.Parameters.AddWithValue("@SoDienThoai", giangVien.SoDienThoai);
                    cmd.Parameters.AddWithValue("@QueQuan", giangVien.QueQuan);

                    int rowsAffected = cmd.ExecuteNonQuery(); // Kiểm tra số dòng bị ảnh hưởng
                    return rowsAffected > 0; // Trả về true nếu có dữ liệu được cập nhật
                }
            }
        }





    }
}
