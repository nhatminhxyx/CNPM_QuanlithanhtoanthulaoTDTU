using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DeTaiDTO
    {
        public string MaDeTai { get; set; }       // Mã đề tài (PK)
        public string TenDeTai { get; set; }      // Tên đề tài
        public string MaKhoa { get; set; }        // Mã khoa (FK)
        public string MaGV { get; set; }          // Mã giảng viên (FK)
        public float KinhPhi { get; set; }        // Kinh phí đề tài
        public DateTime ThoiGianBatDau { get; set; } // Thời gian bắt đầu
        public DateTime ThoiGianKetThuc { get; set; } // Thời gian kết thúc

        // Constructor mặc định
        public DeTaiDTO() { }

        // Constructor có tham số
        public DeTaiDTO(string maDeTai, string tenDeTai, string maKhoa, string maGV, float kinhPhi, DateTime thoiGianBatDau, DateTime thoiGianKetThuc)
        {
            MaDeTai = maDeTai;
            TenDeTai = tenDeTai;
            MaKhoa = maKhoa;
            MaGV = maGV;
            KinhPhi = kinhPhi;
            ThoiGianBatDau = thoiGianBatDau;
            ThoiGianKetThuc = thoiGianKetThuc;
        }

    }
}
