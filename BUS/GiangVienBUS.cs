using System.Data;
using DTO;
using DAL;
using System.Text.RegularExpressions;
namespace BUS
{
    public class GiangVienBUS
    {
        private GiangVienDAL dal = new GiangVienDAL();

        public string GenerateMaGV(string maKhoa)
        {
            // Retrieve all existing codes for this faculty
            DataTable dt = dal.GetGiangVienByKhoa(maKhoa);
            int maxSuffix = 0;
            foreach (DataRow row in dt.Rows)
            {
                string code = row["MaGV"].ToString();
                if (code.StartsWith(maKhoa))
                {
                    string suffix = code.Substring(maKhoa.Length).TrimStart('G');
                    if (int.TryParse(suffix, out int number))
                    {
                        maxSuffix = Math.Max(maxSuffix, number);
                    }
                }
            }
            // Next number
            int next = maxSuffix + 1;
            // Format: G + 3-digit number
            string soThuTu = "G" + next.ToString("D3");
            return maKhoa + soThuTu;
        }
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^\d+$"); // Chỉ chấp nhận số
        }

        public bool CheckMaGVBeforeAdding(string maGV)
        {
            return dal.CheckMaGVBeforeAdding(maGV);
        }

        public bool CheckMaGVBeforeDeleting(string maGV)
        {
            return dal.CheckMaGVBeforeDeleting(maGV);
        }

        public void AddGiangVien(GiangVienDTO giangVien)
        {
            dal.AddGiangVien(giangVien);
        }

        public void DeleteGiangVien(string maGV)
        {
            dal.DeleteGiangVien(maGV);
        }

        public DataTable SearchGiangVien(string maGV, string hoTen, string maKhoa)
        {
            return dal.SearchGiangVien(maGV, hoTen, maKhoa);
        }


        public bool UpdateGiangVien(GiangVienDTO giangVien)
        {
            return dal.UpdateGiangVien(giangVien);
        }

        public DataTable GetAllKhoa()
        {
            return dal.GetAllKhoa();
        }
        public DataTable LayTatCaGiangVien()
        {
            return dal.LayTatCaGiangVien();
        }

        public DataTable TimGiangVienTheoKhoa(string maKhoa)
        {
            return dal.TimGiangVienTheoKhoa(maKhoa);
        }

    }
}
