using System;
using System.Data;
using System.Windows.Forms;
using BUS;
using DTO;
using GUI.Common;

namespace GUI
{
    public partial class DangKiDeTai : Form
    {
        private string selectedMaDeTai = null;
        private string selectedMaDangKy = null;

        private readonly DangKyDeTaiBUS bus = new DangKyDeTaiBUS();

        public DangKiDeTai()
        {
            InitializeComponent();
            txtMaDeTai.Multiline = true;


            // Nếu cần bấm chỉnh chiều cao của TextBox cho phù hợp  
            // (ví dụ bạn để Height = font.Height + padding):
            txtMaDeTai.Height = txtMaDeTai.Font.Height + 8;
        }

        private void DangKiDeTai_Load(object sender, EventArgs e)
        {
            ApplyRolePermissions();
            LoadData(); // Always load appropriate data based on role
        }

        private void ApplyRolePermissions()
        {
            bool isSV = Session.Role == "SV";
            bool isAdmin = Session.Role == "Admin";

            // Chỉ SV mới được đăng ký
            btnDangKy.Enabled = isSV;

            // Duyệt / từ chối thì không phải SV
            btnDuyet.Enabled = !isSV;
            btnTuChoi.Enabled = !isSV;

            // Cho phép SV và Admin  nhập và tìm đề tài
            txtMaDeTai.Enabled = isSV || isAdmin;
            btnTimKiem.Enabled = isSV || isAdmin;
            btnHuy.Enabled = true;
        }

        private void LoadData()
        {
            if (Session.Role == "SV")
                dgvDangKyDeTai.DataSource = bus.LayDanhSachDangKyTheoSV(Session.Username);
            else
            {
                string maGV = Session.Role == "GV" ? Session.Username : null;
                dgvDangKyDeTai.DataSource = bus.LayDanhSachDeTaiChuaDuyet(Session.Role, maGV);
            }
            dgvDangKyDeTai.ClearSelection();
            selectedMaDeTai = null;
            selectedMaDangKy = null;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maDeTai = txtMaDeTai.Text.Trim();
            if (string.IsNullOrEmpty(maDeTai))
            {
                MessageBox.Show("Vui lòng nhập mã đề tài để tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy kết quả tìm kiếm
            var dt = bus.TimKiemDeTai(maDeTai);
            dgvDangKyDeTai.DataSource = dt;
            dgvDangKyDeTai.ClearSelection();

            // Nếu là Admin → tắt hết các nút còn lại, chỉ để lại Hủy
            if (Session.Role == "Admin")
            {
                btnDangKy.Enabled = false;
                btnDuyet.Enabled = false;
                btnTuChoi.Enabled = false;
                btnTimKiem.Enabled = false;
                // txtMaDeTai vẫn bật để có thể gõ lại nếu muốn
            }

            // Gán selectedMaDeTai / selectedMaDangKy như trước
            if (dt.Rows.Count > 0)
            {
                selectedMaDeTai = dt.Rows[0]["MaDeTai"].ToString();
                if (dt.Columns.Contains("MaDangKy"))
                    selectedMaDangKy = dt.Rows[0]["MaDangKy"].ToString();
            }
            else
            {
                selectedMaDeTai = selectedMaDangKy = null;
                MessageBox.Show("Không tìm thấy đề tài.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaDeTai))
            {
                MessageBox.Show("Vui lòng chọn đề tài trước khi đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maSV = Session.Username;
            if (bus.KiemTraTrungDangKy(maSV, selectedMaDeTai))
            {
                MessageBox.Show("Bạn đã đăng ký đề tài này rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var dk = new DangKyDeTaiDTO { MaSV = maSV, MaDeTai = selectedMaDeTai, TrangThai = "Chờ duyệt" };
            if (bus.DangKyDeTai(dk))
            {
                MessageBox.Show("Đăng ký đề tài thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDeTai.Clear();
                LoadData();
            }
            else
                MessageBox.Show("Đăng ký thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaDangKy))
            {
                MessageBox.Show("Vui lòng chọn dòng để duyệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bus.CapNhatTrangThai(selectedMaDangKy, "Đã duyệt"))
            {
                MessageBox.Show("Đã duyệt đề tài.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
                MessageBox.Show("Duyệt thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaDangKy))
            {
                MessageBox.Show("Vui lòng chọn dòng để từ chối.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (bus.CapNhatTrangThai(selectedMaDangKy, "Từ chối"))
            {
                MessageBox.Show("Đã từ chối đề tài.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
                MessageBox.Show("Từ chối thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDangKyDeTai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgvDangKyDeTai.ClearSelection();
            dgvDangKyDeTai.Rows[e.RowIndex].Selected = true;

            // Lấy MaDangKy nếu tồn tại (Admin/GV view)
            if (dgvDangKyDeTai.Columns.Contains("MaDangKy"))
            {
                selectedMaDangKy = dgvDangKyDeTai.Rows[e.RowIndex]
                    .Cells["MaDangKy"].Value?.ToString();
            }
            else
            {
                selectedMaDangKy = null;
            }

            // Lấy MaDeTai nếu tồn tại (cả SV và Admin/GV khi duyệt)
            if (dgvDangKyDeTai.Columns.Contains("MaDeTai"))
            {
                selectedMaDeTai = dgvDangKyDeTai.Rows[e.RowIndex]
                    .Cells["MaDeTai"].Value?.ToString();
            }
            else
            {
                selectedMaDeTai = null;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaDeTai.Clear();
            selectedMaDeTai = selectedMaDangKy = null;

            // Nạp lại dữ liệu & permissions như lúc load form
            LoadData();
            ApplyRolePermissions();
        }
    }
}
