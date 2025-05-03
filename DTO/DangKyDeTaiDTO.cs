using System;

namespace DTO
{
    public class DangKyDeTaiDTO
    {
        public string? MaDangKy { get; set; }
        public string MaSV { get; set; }
        public string MaDeTai { get; set; }
        public string TrangThai { get; set; }

        public DangKyDeTaiDTO() { }

        public DangKyDeTaiDTO(string maSV, string maDeTai, string trangThai = "Chờ duyệt")
        {
            MaSV = maSV;
            MaDeTai = maDeTai;
            TrangThai = trangThai;
        }

        public DangKyDeTaiDTO(string maDangKy, string maSV, string maDeTai, string trangThai = "Chờ duyệt")
        {
            MaDangKy = maDangKy;
            MaSV = maSV;
            MaDeTai = maDeTai;
            TrangThai = trangThai;
        }
    }
}
