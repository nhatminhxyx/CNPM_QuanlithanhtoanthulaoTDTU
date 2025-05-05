using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Common;

namespace GUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            thanhToánToolStripMenuItem.Enabled = (Session.Role == "Admin" || Session.Role == "GV");
        }

        // Hàm mở form con tái sử dụng
        private void OpenChildForm<T>() where T : Form, new()
        {
            // Đóng tất cả các form con khác
            foreach (Form child in this.MdiChildren)
            {
                child.Close();  // đóng form hiện tại
            }

            // Tạo và mở form con mới
            T form = new T
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };

            // Khi form con đóng thì hiện lại nút đăng xuất
            form.FormClosed += (s, args) =>
            {
                btnDangXuat.Visible = true;
            };

            // Ẩn nút đăng xuất trước khi mở form con
            btnDangXuat.Visible = false;

            form.Show();
        }

        private void đềTàiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<Detai>();
        }

        private void gIảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<Giangvien>();
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<Sinhvien>();
        }

        private void đăngKíĐềTàiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<DangKiDeTai>();
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<Thanhtoan>();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide(); // Ẩn form chính

                DangNhap loginForm = new DangNhap();
                loginForm.Show(); // Hiện form đăng nhập
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
