using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BUS
{
    public class TaiKhoanBus
    {
        TaiKhoanAccess tkAccess = new TaiKhoanAccess();
        public string CheckLogin(TaiKhoan taikhoan)
        {
            //ktra nghiep vu
            if (string.IsNullOrEmpty(taikhoan.Username))
                return "requeid_taikhoan";

            if (string.IsNullOrEmpty(taikhoan.Password))
                return "requeid_password";

            string role = DatabaseAccess.CheckLoginDTO(taikhoan);

            if (role == "Sai" || role == null)
                return "Tài khoản hoặc mật khẩu không chính xác!";

            return role;
        }
        public string ChangePassword(string username, string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
                return "Thông tin không hợp lệ!";

            bool isUpdated = DatabaseAccess.ChangePassword(username, oldPassword, newPassword);

            return isUpdated ? "Success" : "Mật khẩu cũ không chính xác!";
        }
    }
}
