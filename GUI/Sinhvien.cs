using System;
using System.Data;
using System.Windows.Forms;
using DTO;
using BUS;
using GUI.Common;

namespace GUI
{
    public partial class Sinhvien : Form
    {
        private SinhVienBUS bus = new SinhVienBUS();
        private bool isEditMode = false;

        public Sinhvien()
        {
            InitializeComponent();
        }

        private void Sinhvien_Load(object sender, EventArgs e)
        {
            LoadKhoa();
            ClearForm();
            dgvSinhVien.DataSource = null;
            ApplyRolePermissions();

            if (Session.Role == "SV")
            {
                txtMaSV.Text = Session.Username;
                txtMaSV.Enabled = false;
                btnTimKiem.PerformClick();
            }
        }

        private void ApplyRolePermissions()
        {
            switch (Session.Role)
            {
                case "Admin":
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnTimKiem.Enabled = true;
                    break;
                case "GV":
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnTimKiem.Enabled = true;
                    break;
                case "SV":
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnLuu.Enabled = false;
                    btnTimKiem.Enabled = true;
                    break;
            }
        }

        private void SetAddMode()
        {
            isEditMode = false;
            txtMaSV.Enabled = true;
            txtHoTen.Enabled = true;
            cbKhoa.Enabled = true;
            txtLop.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtQueQuan.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void SetViewMode()
        {
            isEditMode = false;
            txtMaSV.Enabled = false;
            txtHoTen.Enabled = false;
            cbKhoa.Enabled = false;
            txtLop.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtQueQuan.Enabled = false;

            if (Session.Role == "Admin")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
            }
            else
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = false;
            }
        }

        private void ClearForm()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtLop.Clear();
            txtQueQuan.Clear();
            cbKhoa.SelectedIndex = -1;
            dtpNgaySinh.Value = DateTime.Now;
            SetAddMode();
            ApplyRolePermissions();
        }

        private void LoadKhoa()
        {
            DataTable dtKhoa = bus.GetAllKhoa();
            if (dtKhoa.Rows.Count > 0)
            {
                cbKhoa.DataSource = dtKhoa;
                cbKhoa.DisplayMember = "TenKhoa";
                cbKhoa.ValueMember = "MaKhoa";
                cbKhoa.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu khoa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKhoa.SelectedIndex >= 0 && !isEditMode && Session.Role == "Admin")
            {
                txtMaSV.Text = bus.GenerateMaSV(cbKhoa.SelectedValue.ToString());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbKhoa.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtLop.Text) || string.IsNullOrWhiteSpace(txtQueQuan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSV = bus.GenerateMaSV(cbKhoa.SelectedValue.ToString());
            txtMaSV.Text = maSV;
            if (bus.CheckMaSVBeforeAdding(maSV))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn thêm sinh viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var sv = new SinhVienDTO
            {
                MaSV = maSV,
                HoTen = txtHoTen.Text.Trim(),
                MaKhoa = cbKhoa.SelectedValue.ToString(),
                Lop = txtLop.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                QueQuan = txtQueQuan.Text.Trim()
            };
            bus.AddSinhVien(sv);
            MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            dgvSinhVien.DataSource = null;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = !string.IsNullOrEmpty(txtMaSV.Text.Trim()) ? txtMaSV.Text.Trim() : txtHoTen.Text.Trim();
            if (string.IsNullOrWhiteSpace(key))
            {
                MessageBox.Show("Vui lòng nhập mã hoặc tên sinh viên để tìm kiếm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dt = bus.SearchSinhVien(key);
            if (dt.Rows.Count > 0)
            {
                dgvSinhVien.DataSource = dt;
                SetViewMode();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvSinhVien.DataSource = null;
                if (Session.Role == "Admin")
                    SetAddMode();
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua khi click header hoặc vùng trống
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var row = dgvSinhVien.Rows[e.RowIndex];

            // Lấy giá trị an toàn với DBNull
            string maSV = row.Cells["MaSV"].Value as string;
            if (string.IsNullOrEmpty(maSV)) return;

            isEditMode = true;

            txtMaSV.Text = maSV;
            txtHoTen.Text = row.Cells["HoTen"].Value?.ToString() ?? string.Empty;
            cbKhoa.SelectedValue = row.Cells["MaKhoa"].Value?.ToString() ?? cbKhoa.SelectedValue;
            txtLop.Text = row.Cells["Lop"].Value?.ToString() ?? string.Empty;

            // Ngày sinh
            var ngaySinhObj = row.Cells["NgaySinh"].Value;
            if (ngaySinhObj != null && ngaySinhObj != DBNull.Value)
                dtpNgaySinh.Value = Convert.ToDateTime(ngaySinhObj);
            else
                dtpNgaySinh.Value = DateTime.Now;

            txtQueQuan.Text = row.Cells["QueQuan"].Value?.ToString() ?? string.Empty;

            SetViewMode();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            bus.DeleteSinhVien(txtMaSV.Text.Trim());
            MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            dgvSinhVien.DataSource = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isEditMode = true;
            txtMaSV.Enabled = false;
            txtHoTen.Enabled = true;
            cbKhoa.Enabled = true;
            txtLop.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtQueQuan.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || cbKhoa.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtLop.Text) || string.IsNullOrWhiteSpace(txtQueQuan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn lưu thay đổi?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var sv = new SinhVienDTO
            {
                MaSV = txtMaSV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                MaKhoa = cbKhoa.SelectedValue.ToString(),
                Lop = txtLop.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                QueQuan = txtQueQuan.Text.Trim()
            };
            bool updated = bus.UpdateSinhVien(sv);

            if (updated)
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            ClearForm();
            dgvSinhVien.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
            dgvSinhVien.DataSource = null;
        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
