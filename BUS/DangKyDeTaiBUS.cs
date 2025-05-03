using System.Data;
using DAL;
using DTO;

namespace BUS
{
    public class DangKyDeTaiBUS
    {
        private readonly DangKyDeTaiDAL dal = new DangKyDeTaiDAL();

        public DataTable TimKiemDeTai(string keyword)
        {
            return dal.TimKiemDeTai(keyword);
        }

        public bool KiemTraTrungDangKy(string maSV, string maDeTai)
        {
            return dal.KiemTraTrungDangKy(maSV, maDeTai);
        }

        public bool DangKyDeTai(DangKyDeTaiDTO dk)
        {
            return dal.DangKyDeTai(dk);
        }

        public bool CapNhatTrangThai(string maDangKy, string trangThai)
        {
            return dal.CapNhatTrangThai(maDangKy, trangThai);
        }

        public DataTable LayDanhSachDeTaiChuaDuyet(string role, string maGV = null)
        {
            return dal.LayDanhSachDeTaiChuaDuyet(role, maGV);
        }

        public DataTable LayDanhSachDangKyTheoSV(string maSV)
        {
            return dal.LayDanhSachDangKyTheoSV(maSV);
        }
    }
}