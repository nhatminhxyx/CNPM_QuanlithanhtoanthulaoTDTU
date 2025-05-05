using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using GUI.Common;

namespace GUI
{
    public partial class Detai : Form
    {
        private DeTaiBUS bus = new DeTaiBUS();
        private bool isEditMode = false;
        private bool isFormInitializing = false;
        private bool suppressAutoGen = false; // Flag ngăn tự động sinh mã khi tìm kiếm
        public Detai()
        {
            InitializeComponent();
        }

        private void Detai_Load(object sender, EventArgs e)
        {
            LoadKhoa();
            dgvDeTai.DataSource = null;
            cbKhoa.SelectedIndexChanged += cbKhoa_SelectedIndexChanged;
            dtpNgayBatDau.ValueChanged += dtpNgayBatDau_ValueChanged;
            ClearForm(); // Gọi sau khi đăng ký sự kiện
            ApplyRolePermissions(); // Gọi cuối cùng để thiết lập quyền đúng
        }
        private void ApplyRolePermissions()
        {
            switch (Session.Role)
            {
                case "Admin":
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnLuu.Enabled = true;
                    btnTimKiem.Enabled = true;
                    break;
                case "GV":
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
            suppressAutoGen = false; // cho phép auto gen khi chọn khoa

            txtMaDeTai.Enabled = true;
            txtTenDeTai.Enabled = true;
            cbKhoa.Enabled = true;
            txtMaGiangVien.Enabled = true;
            txtKinhPhi.Enabled = true;
            dtpNgayBatDau.Enabled = true;
            dtpNgayKetThuc.Enabled = true;

            btnThem.Enabled = Session.Role == "Admin";
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void SetViewMode()
        {
            isEditMode = false;
            suppressAutoGen = true; // ngăn auto gen khi xem

            txtMaDeTai.Enabled = false;
            txtTenDeTai.Enabled = false;
            cbKhoa.Enabled = false;
            txtMaGiangVien.Enabled = false;
            txtKinhPhi.Enabled = false;
            dtpNgayBatDau.Enabled = false;
            dtpNgayKetThuc.Enabled = false;

            btnThem.Enabled = false;
            btnSua.Enabled = Session.Role == "Admin";
            btnXoa.Enabled = Session.Role == "Admin";
            btnLuu.Enabled = false;
        }

        private void ClearForm()
        {
            txtMaDeTai.Clear();
            txtTenDeTai.Clear();
            txtMaGiangVien.Clear();
            txtKinhPhi.Clear();
            cbKhoa.SelectedIndex = -1;
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbKhoa.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtTenDeTai.Text) ||
                string.IsNullOrWhiteSpace(txtMaGiangVien.Text) || string.IsNullOrWhiteSpace(txtKinhPhi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(txtKinhPhi.Text, out float kinhPhi) || kinhPhi <= 0)
            {
                MessageBox.Show("Kinh phí phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!bus.CheckMaGVExists(txtMaGiangVien.Text.Trim()))
            {
                MessageBox.Show("Mã giảng viên không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtpNgayKetThuc.Value <= dtpNgayBatDau.Value)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn thêm đề tài này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string maDT = bus.GenerateMaDT(cbKhoa.SelectedValue.ToString());
            txtMaDeTai.Text = maDT;
            if (bus.CheckMaDTBeforeAdding(maDT))
            {
                MessageBox.Show("Mã đề tài đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dt = new DeTaiDTO
            {
                MaDeTai = maDT,
                TenDeTai = txtTenDeTai.Text.Trim(),
                MaKhoa = cbKhoa.SelectedValue.ToString(),
                MaGV = txtMaGiangVien.Text.Trim(),
                KinhPhi = kinhPhi,
                ThoiGianBatDau = dtpNgayBatDau.Value,
                ThoiGianKetThuc = dtpNgayKetThuc.Value
            };

            bus.AddDeTai(dt);
            MessageBox.Show("Thêm đề tài thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            dgvDeTai.DataSource = null;
        }





        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDeTai.Text))
            {
                MessageBox.Show("Vui lòng chọn đề tài cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa đề tài này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            bus.DeleteDeTai(txtMaDeTai.Text.Trim());
            MessageBox.Show("Xóa đề tài thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
            dgvDeTai.DataSource = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDeTai.Text))
            {
                MessageBox.Show("Vui lòng chọn đề tài cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isEditMode = true;
            txtTenDeTai.Enabled = true;
            cbKhoa.Enabled = true;
            txtMaGiangVien.Enabled = true;
            txtKinhPhi.Enabled = true;
            dtpNgayBatDau.Enabled = true;
            dtpNgayKetThuc.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDeTai.Text) || cbKhoa.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtMaGiangVien.Text) || string.IsNullOrWhiteSpace(txtKinhPhi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(txtKinhPhi.Text, out float kinhPhi) || kinhPhi <= 0)
            {
                MessageBox.Show("Kinh phí phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!bus.CheckMaGVExists(txtMaGiangVien.Text.Trim()))
            {
                MessageBox.Show("Mã giảng viên không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtpNgayKetThuc.Value <= dtpNgayBatDau.Value)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn lưu thay đổi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var dt = new DeTaiDTO
            {
                MaDeTai = txtMaDeTai.Text.Trim(),
                TenDeTai = txtTenDeTai.Text.Trim(),
                MaKhoa = cbKhoa.SelectedValue.ToString(),
                MaGV = txtMaGiangVien.Text.Trim(),
                KinhPhi = kinhPhi,
                ThoiGianBatDau = dtpNgayBatDau.Value,
                ThoiGianKetThuc = dtpNgayKetThuc.Value
            };

            bool updated = bus.UpdateDeTai(dt);
            MessageBox.Show(updated ? "Cập nhật thành công!" : "Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, updated ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            ClearForm();
            dgvDeTai.DataSource = null;
        }



        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            suppressAutoGen = true; // tắt tạo mã khi thay đổi cbKhoa trong search
            DataTable dt;
            if (cbKhoa.SelectedIndex >= 0)
                dt = bus.GetDeTaiByKhoaAndDate(cbKhoa.SelectedValue.ToString(), dtpNgayBatDau.Value.Date);
            else
            {
                string key = !string.IsNullOrWhiteSpace(txtMaDeTai.Text) ? txtMaDeTai.Text : txtTenDeTai.Text;
                dt = bus.SearchDeTai(key);
            }
            dgvDeTai.DataSource = dt;
            ApplyRolePermissions();
            if (dt.Rows.Count == 1)
                FillFormFromRow(dt.Rows[0]);
            suppressAutoGen = false; // bật lại cho trường hợp add mới
        }
        private void FillFormFromRow(DataRow row)
        {
            txtMaDeTai.Text = row.Field<string>("MaDeTai");
            txtTenDeTai.Text = row.Field<string>("TenDeTai");
            cbKhoa.SelectedValue = row.Field<string>("MaKhoa");
            txtMaGiangVien.Text = row.Field<string>("MaGV");
            txtKinhPhi.Text = row["KinhPhi"].ToString();
            dtpNgayBatDau.Value = row.Field<DateTime>("ThoiGianBatDau");
            dtpNgayKetThuc.Value = row.Field<DateTime>("ThoiGianKetThuc");
            if (Session.Role == "Admin") SetViewMode();
            else ClearReadOnly();
        }
        private void ClearReadOnly()
        {
            txtMaDeTai.Enabled = false;
            txtTenDeTai.Enabled = false;
            cbKhoa.Enabled = false;
            txtMaGiangVien.Enabled = false;
            txtKinhPhi.Enabled = false;
            dtpNgayBatDau.Enabled = false;
            dtpNgayKetThuc.Enabled = false;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearForm();
            dgvDeTai.DataSource = null;
        }

        private void dgvDeTai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = ((DataTable)dgvDeTai.DataSource).Rows[e.RowIndex];
            FillFormFromRow(row); 
        }

        private void cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFormInitializing || suppressAutoGen) return;
            if (Session.Role == "Admin" && !isEditMode && cbKhoa.SelectedIndex >= 0)
                txtMaDeTai.Text = bus.GenerateMaDT(cbKhoa.SelectedValue.ToString());

        }
        private void dtpNgayBatDau_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnXemChiTietDK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDeTai.Text))
            {
                MessageBox.Show("Vui lòng chọn đề tài để xem chi tiết!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maDeTai = txtMaDeTai.Text.Trim();
            string tenDeTai = txtTenDeTai.Text.Trim();
            string maGV = txtMaGiangVien.Text.Trim();
            string tenGV = bus.GetTenGiangVien(maGV);
            string maKhoa = cbKhoa.SelectedValue.ToString();
            DateTime bd = dtpNgayBatDau.Value;
            DateTime kt = dtpNgayKetThuc.Value;
            string kinhPhi = txtKinhPhi.Text.Trim();

            DataTable dkTbl = bus.GetDangKyTheoDeTai(maDeTai);

            var frm = new ChiTietDeTaiForm(
                maDeTai, tenDeTai,
                tenGV, maKhoa,
                bd, kt,
                kinhPhi,
                dkTbl);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
}}
