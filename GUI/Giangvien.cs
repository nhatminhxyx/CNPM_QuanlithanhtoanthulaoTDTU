using System;
using System.Data;
using System.Windows.Forms;
using DTO;
using BUS;
using GUI.Common;

namespace GUI
{
    public partial class Giangvien : Form
    {
        // Đối tượng BUS toàn cục: xử lý nghiệp vụ Giảng viên
        private GiangVienBUS bus = new GiangVienBUS();
        // Cờ xác định trạng thái chỉnh sửa
        private bool isEditMode = false;

        public Giangvien()
        {
            InitializeComponent();
        }

        // Khi form load, khởi tạo giao diện ở chế độ thêm mới (Add Mode)
        private void Giangvien_Load(object sender, EventArgs e)
        {
            LoadKhoa();
            LoadHocVi();
            ClearForm();
            dgvGiangVien.DataSource = null;
            ApplyRolePermissions();
            if (Session.Role == "GV")
            {
                txtMaGV.Text = Session.Username;
                txtMaGV.Enabled = false;
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
            txtMaGV.Enabled = true;
            txtHoTen.Enabled = true;
            cbKhoa.Enabled = true;
            cbHocVi.Enabled = true;
            txtSdt.Enabled = true;
            txtQueQuan.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void SetViewMode()
        {
            isEditMode = false;
            txtMaGV.Enabled = false;
            txtHoTen.Enabled = false;
            cbKhoa.Enabled = false;
            txtSdt.Enabled = false;
            cbHocVi.Enabled = false;
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
            txtMaGV.Clear();
            txtHoTen.Clear();
            txtSdt.Clear();
            txtQueQuan.Clear();
            cbKhoa.SelectedIndex = -1;
            cbHocVi.SelectedIndex = -1;
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
                MessageBox.Show("Không tìm thấy dữ liệu khoa trong CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadHocVi()
        {
            cbHocVi.Items.Clear();
            cbHocVi.Items.Add("Thạc sĩ");
            cbHocVi.Items.Add("Tiến sĩ");
            cbHocVi.SelectedIndex = -1;
        }

  

        private void cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKhoa.SelectedIndex >= 0 && !isEditMode)
            {
                txtMaGV.Text = bus.GenerateMaGV(cbKhoa.SelectedValue.ToString());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Validation
            if (cbKhoa.SelectedIndex == -1 || cbHocVi.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtSdt.Text) ||
                string.IsNullOrWhiteSpace(txtQueQuan.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!bus.IsValidPhoneNumber(txtSdt.Text.Trim()))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập chỉ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maGV = bus.GenerateMaGV(cbKhoa.SelectedValue.ToString());
            txtMaGV.Text = maGV;
            if (bus.CheckMaGVBeforeAdding(maGV))
            {
                MessageBox.Show("Mã giảng viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xác nhận thêm
            if (MessageBox.Show("Bạn có chắc chắn muốn thêm giảng viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var gv = new GiangVienDTO
            {
                MaGV = maGV,
                HoTen = txtHoTen.Text.Trim(),
                MaKhoa = cbKhoa.SelectedValue.ToString(),
                HocVi = cbHocVi.Text,
                SoDienThoai = txtSdt.Text,
                QueQuan = txtQueQuan.Text.Trim()
            };
            bus.AddGiangVien(gv);
            MessageBox.Show("Thêm giảng viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            dgvGiangVien.DataSource = null;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string key = !string.IsNullOrEmpty(txtMaGV.Text.Trim()) ? txtMaGV.Text.Trim() : txtHoTen.Text.Trim();
            if (string.IsNullOrWhiteSpace(key))
            {
                MessageBox.Show("Vui lòng nhập mã hoặc tên giảng viên để tìm kiếm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var dt = bus.SearchGiangVien(key);
            if (dt.Rows.Count > 0)
            {
                dgvGiangVien.DataSource = dt;
                SetViewMode();
            }
            else
            {
                MessageBox.Show("Không tìm thấy giảng viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvGiangVien.DataSource = null;
                SetAddMode();
            }
        }

        private void dgvGiangVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            isEditMode = true;
            var row = dgvGiangVien.Rows[e.RowIndex];
            txtMaGV.Text = row.Cells["MaGV"].Value.ToString();
            txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
            cbKhoa.SelectedValue = row.Cells["MaKhoa"].Value.ToString();
            cbHocVi.SelectedItem = row.Cells["HocVi"].Value.ToString();
            txtSdt.Text = row.Cells["SoDienThoai"].Value.ToString();
            txtQueQuan.Text = row.Cells["QueQuan"].Value.ToString();
            SetViewMode();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaGV.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn giảng viên cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Xác nhận xóa
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa giảng viên này?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            bus.DeleteGiangVien(txtMaGV.Text.Trim());
            MessageBox.Show("Xóa giảng viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            dgvGiangVien.DataSource = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaGV.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn giảng viên cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isEditMode = true;
            txtMaGV.Enabled = false;
            txtHoTen.Enabled = true;
            cbKhoa.Enabled = true;
            cbHocVi.Enabled = true;
            txtSdt.Enabled = true;
            txtQueQuan.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            // Validation
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || cbKhoa.SelectedIndex == -1 || cbHocVi.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtSdt.Text) || string.IsNullOrWhiteSpace(txtQueQuan.Text) )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!bus.IsValidPhoneNumber(txtSdt.Text.Trim()))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập chỉ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Xác nhận lưu
            if (MessageBox.Show("Bạn có chắc chắn muốn lưu thay đổi?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            var gv = new GiangVienDTO
            {
                MaGV = txtMaGV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                MaKhoa = cbKhoa.SelectedValue.ToString(),
                HocVi = cbHocVi.Text,
                SoDienThoai = txtSdt.Text,
                QueQuan = txtQueQuan.Text.Trim()
            };
            bool updated = bus.UpdateGiangVien(gv);
            if (updated)
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ClearForm();
            dgvGiangVien.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
            dgvGiangVien.DataSource = null;
        }
    }
}
