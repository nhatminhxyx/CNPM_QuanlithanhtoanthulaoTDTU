using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using GUI.Common;
namespace GUI
{
    public partial class DangNhap : Form
    {
        TaiKhoan taikhoan = new TaiKhoan();
        TaiKhoanBus TKbus = new TaiKhoanBus();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            taikhoan.Username = txtTaikhoan.Text;
            taikhoan.Password = txtMatkhau.Text;
            string result = TKbus.CheckLogin(taikhoan);

            switch (result)
            {
                case "requeid_taikhoan":
                    MessageBox.Show("Tài khoản không được để trống!");
                    return;
                case "requeid_password":
                    MessageBox.Show("Mật khẩu không được để trống!");
                    return;
                case "Tài khoản hoặc mật khẩu không chính xác!":
                    MessageBox.Show(result);
                    return;
            }

            if (result == "Admin" || result == "GV" || result == "SV")
            {
                Session.Username = taikhoan.Username;
                Session.Role = result; // Lưu role vào session
                MessageBox.Show("Đăng nhập thành công với quyền: " + result);
                
            }


            FormMain mainForm = new FormMain();
            mainForm.FormClosed += (s, args) => this.Close(); // Khi form Main đóng, đóng luôn Form Login

            // Hiển thị Form Main
            mainForm.Show();

            // Ẩn Form Login hiện tại
            this.Hide();
        }

        private void txtTaikhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e); // gọi lại sự kiện click của nút đăng nhập
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // ẩn form đăng nhập

            DoiMatKhau form = new DoiMatKhau();
            form.ShowDialog(); // hiện form đổi mật khẩu dạng modal (chờ đóng)

            this.Show(); // hiện lại form đăng nhập sau khi form đổi mật khẩu đóng
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
