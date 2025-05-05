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

        public DataTable SearchGiangVien(string maGV, string hoTen, string maKhoa)
        {
            List<string> conditions = new List<string>();
            if (!string.IsNullOrWhiteSpace(maGV))
                conditions.Add("MaGV LIKE @MaGV");
            if (!string.IsNullOrWhiteSpace(hoTen))
                conditions.Add("HoTen LIKE @HoTen");
            if (!string.IsNullOrWhiteSpace(maKhoa))
                conditions.Add("MaKhoa = @MaKhoa");

            string whereClause = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";

            string query = $"SELECT * FROM GiangVien {whereClause}";

            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrWhiteSpace(maGV))
                    cmd.Parameters.AddWithValue("@MaGV", "%" + maGV + "%");
                if (!string.IsNullOrWhiteSpace(hoTen))
                    cmd.Parameters.AddWithValue("@HoTen", "%" + hoTen + "%");
                if (!string.IsNullOrWhiteSpace(maKhoa))
                    cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
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
        public DataTable LayTatCaGiangVien()
        {
            string query = "SELECT * FROM GiangVien";
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable TimGiangVienTheoKhoa(string maKhoa)
        {
            string query = "SELECT * FROM GiangVien WHERE MaKhoa = @MaKhoa";
            using (SqlConnection conn = SqlConnectionData.Connect())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }





    }
}
