using System.Data;
using DTO;
using DAL;

namespace BUS
{
    public class SinhVienBUS
    {
        private SinhVienDAL dal = new SinhVienDAL();

        public string GenerateMaSV(string maKhoa)
        {
            DataTable dt = dal.GetSinhVienByKhoa(maKhoa);
            int maxSuffix = 0;
            foreach (DataRow row in dt.Rows)
            {
                string code = row["MaSV"].ToString();
                if (code.StartsWith(maKhoa))
                {
                    string suffix = code.Substring(maKhoa.Length);
                    if (int.TryParse(suffix, out int number))
                    {
                        maxSuffix = Math.Max(maxSuffix, number);
                    }
                }
            }
            int next = maxSuffix + 1;
            string soThuTu = next.ToString("D3"); // Không cần "G" vì Sinh viên
            return maKhoa + soThuTu;
        }

        public bool CheckMaSVBeforeAdding(string maSV)
        {
            return dal.CheckMaSVBeforeAdding(maSV);
        }

        public bool CheckMaSVBeforeDeleting(string maSV)
        {
            return dal.CheckMaSVBeforeDeleting(maSV);
        }

        public void AddSinhVien(SinhVienDTO sinhVien)
        {
            dal.AddSinhVien(sinhVien);
        }

        public void DeleteSinhVien(string maSV)
        {
            dal.DeleteSinhVien(maSV);
        }

        public bool UpdateSinhVien(SinhVienDTO sinhVien)
        {
            return dal.UpdateSinhVien(sinhVien);
        }

        public DataTable SearchSinhVien(string searchValue)
        {
            return dal.SearchSinhVien(searchValue);
        }

        public DataTable GetAllKhoa()
        {
            return dal.GetAllKhoa();
        }
    }
}
