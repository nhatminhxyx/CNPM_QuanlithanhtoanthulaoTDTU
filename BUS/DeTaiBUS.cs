using System.Data;
using DTO;
using DAL;

namespace BUS
{
    public class DeTaiBUS
    {
        private DeTaiDAL dal = new DeTaiDAL();

        // Tạo mã đề tài theo định dạng MaKhoa_DTxxx
        public string GenerateMaDT(string maKhoa)
        {
            DataTable dt = dal.GetDeTaiByKhoa(maKhoa);
            int maxSuffix = 0;

            foreach (DataRow row in dt.Rows)
            {
                string code = row["MaDeTai"].ToString();
                if (code.StartsWith(maKhoa + "_DT"))
                {
                    string suffix = code.Substring((maKhoa + "_DT").Length);
                    if (int.TryParse(suffix, out int number))
                    {
                        maxSuffix = Math.Max(maxSuffix, number);
                    }
                }
            }

            return $"{maKhoa}_DT{(maxSuffix + 1):D3}"; // Định dạng IT_DT001, IT_DT002...
        }

        public bool CheckMaDTBeforeAdding(string maDT)
        {
            return dal.CheckMaDTBeforeAdding(maDT);
        }

        public bool CheckMaDTBeforeDeleting(string maDT)
        {
            return dal.CheckMaDTBeforeDeleting(maDT);
        }

        public void AddDeTai(DeTaiDTO deTai)
        {
            dal.AddDeTai(deTai);
        }

        public void DeleteDeTai(string maDT)
        {
            dal.DeleteDeTai(maDT);
        }

        public bool UpdateDeTai(DeTaiDTO deTai)
        {
            return dal.UpdateDeTai(deTai);
        }

        public DataTable SearchDeTai(string searchValue)
        {
            return dal.SearchDeTai(searchValue);
        }

        public DataTable GetAllKhoa()
        {
            return dal.GetAllKhoa();
        }
        public string GetTenGiangVien(string maGV)
        {
            DataTable dt = dal.GetGiangVienByMa(maGV);
            return dt.Rows.Count > 0 ? dt.Rows[0]["HoTen"].ToString() : "";
        }
        public bool CheckMaGVExists(string maGV)
        {
            return dal.CheckMaGVExists(maGV);
        }
        public DataTable GetDeTaiByKhoaAndDate(string maKhoa, DateTime ngayBatDau)
        {
            return dal.GetDeTaiByKhoaAndDate(maKhoa, ngayBatDau);
        }
        public DataTable GetDangKyTheoDeTai(string maDeTai)
        {
            return dal.GetDangKyTheoDeTai(maDeTai);
        }
    }
}
