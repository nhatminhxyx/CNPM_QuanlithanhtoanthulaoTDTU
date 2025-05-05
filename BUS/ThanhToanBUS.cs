using System;
using System.Data;
using DTO;
using DAL;

namespace BUS
{
    public class ThanhToanBUS
    {
        private readonly ThanhToanDAL dal = new ThanhToanDAL();

        // Lấy tất cả đề tài để show form
        public DataTable GetAllDeTai() =>
            dal.GetAllDeTai();

        // Lấy MaGV, KinhPhi
       

        public double? GetKinhPhiByMaDeTai(string maDeTai) =>
            dal.GetKinhPhiByMaDeTai(maDeTai);

        // Sinh MaThanhToan
        public string TaoMaThanhToan(string maDeTai) =>
            dal.GenerateMaThanhToan(maDeTai);

        // Thực hiện lưu thanh toán
        public bool ThanhToan(ThanhToanDTO tt) =>
            dal.InsertThanhToan(tt);

        // Lấy lịch sử thanh toán
        public DataTable GetThanhToanByDateRange(DateTime tuNgay, DateTime denNgay) =>
            dal.GetThanhToanByDateRange(tuNgay, denNgay);

        public DataTable GetThanhToanByMaDeTai(string maDeTai) =>
            dal.GetThanhToanByMaDeTai(maDeTai);
        public DataTable GetDeTaiChuaThanhToan() =>
            dal.GetDeTaiChuaThanhToan();

        public bool HasBeenPaid(string maDeTai) =>
            dal.HasBeenPaid(maDeTai);
        public DataTable GetDeTaiByMaDeTai(string maDeTai)
        => dal.GetDeTaiByMaDeTai(maDeTai);
        public DataTable GetDeTaiByMaGV(string maGV)
          => dal.GetDeTaiByMaGV(maGV);
    }   
}
