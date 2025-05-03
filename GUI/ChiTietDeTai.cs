using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ChiTietDeTaiForm : Form
    {
        public ChiTietDeTaiForm(
            string maDeTai,
            string tenDeTai,
            string tenGiangVien,
            string maKhoa,
            DateTime ngayBatDau,
            DateTime ngayKetThuc,
            string kinhPhi,
            DataTable dkTbl)
        {
            InitializeComponent();

            // Gán nội dung vào các label
            lblMaDeTai.Text = $"Mã đề tài: {maDeTai}";
            lblTenDeTai.Text = $"Tên đề tài: {tenDeTai}";
            lblGiangVien.Text = $"Giảng viên: {tenGiangVien}";
            lblKhoa.Text = $"Mã khoa: {maKhoa}";
            lblThoiGian.Text = $"Thời gian: {ngayBatDau:yyyy-MM-dd} đến {ngayKetThuc:yyyy-MM-dd}";
            lblKinhPhi.Text = $"Kinh phí: {kinhPhi}";

            // Lọc sinh viên đã duyệt
            DataView view = new DataView(dkTbl);
            view.RowFilter = "TrangThai = 'Đã duyệt'";
            DataTable filteredTable = view.ToTable();

            dgvChiTiet.AutoGenerateColumns = true;
            dgvChiTiet.DataSource = filteredTable;

            // Đổi tiêu đề cột
            dgvChiTiet.Columns["MaDangKy"].HeaderText = "Mã ĐK";
            dgvChiTiet.Columns["MaSV"].HeaderText = "Mã SV";
            dgvChiTiet.Columns["TenSinhVien"].HeaderText = "Tên SV";

            // Ẩn cột không cần
            if (dgvChiTiet.Columns.Contains("TrangThai"))
                dgvChiTiet.Columns["TrangThai"].Visible = false;

            // Cập nhật số lượng
            lblSoLuong.Text = $"Số lượng sinh viên đã duyệt: {filteredTable.Rows.Count}";

            // Điều chỉnh chiều cao DataGridView
            int rowHeight = dgvChiTiet.RowTemplate.Height;
            int headerHeight = dgvChiTiet.ColumnHeadersHeight;
            int visibleRows = Math.Min(filteredTable.Rows.Count, 10);
            dgvChiTiet.Height = headerHeight + visibleRows * rowHeight + 5;
        }

        private void InitializeComponent()
        {
            this.Text = "Chi tiết đề tài";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(700, 500);
            this.MinimumSize = new Size(700, 500);

            // Tiêu đề
            lblTieuDe = new Label()
            {
                Text = "Chi tiết đề tài",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 50
            };

            // Thông tin chi tiết
            lblMaDeTai = CreateInfoLabel();
            lblTenDeTai = CreateInfoLabel();
            lblGiangVien = CreateInfoLabel();
            lblKhoa = CreateInfoLabel();
            lblThoiGian = CreateInfoLabel();
            lblKinhPhi = CreateInfoLabel();
            lblSoLuong = CreateInfoLabel();

            // Layout thông tin
            var infoLayout = new TableLayoutPanel()
            {
                Dock = DockStyle.Top,
                ColumnCount = 1,
                AutoSize = true,
                Padding = new Padding(20),
            };

            infoLayout.Controls.Add(lblMaDeTai);
            infoLayout.Controls.Add(lblTenDeTai);
            infoLayout.Controls.Add(lblGiangVien);
            infoLayout.Controls.Add(lblKhoa);
            infoLayout.Controls.Add(lblThoiGian);
            infoLayout.Controls.Add(lblKinhPhi);
            infoLayout.Controls.Add(lblSoLuong);

            // DataGridView
            dgvChiTiet = new DataGridView()
            {
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                Dock = DockStyle.Fill,
                Margin = new Padding(20),
            };

            // Main container
            var mainPanel = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 1,
            };

            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));    // Tiêu đề
            mainPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));        // Thông tin
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));   // DGV

            mainPanel.Controls.Add(lblTieuDe, 0, 0);
            mainPanel.Controls.Add(infoLayout, 0, 1);
            mainPanel.Controls.Add(dgvChiTiet, 0, 2);

            this.Controls.Add(mainPanel);
        }

        private Label CreateInfoLabel()
        {
            return new Label()
            {
                Font = new Font("Segoe UI", 10F),
                AutoSize = true,
                Margin = new Padding(5),
                Dock = DockStyle.Top
            };
        }

        // Controls
        private Label lblTieuDe;
        private Label lblMaDeTai;
        private Label lblTenDeTai;
        private Label lblGiangVien;
        private Label lblKhoa;
        private Label lblThoiGian;
        private Label lblKinhPhi;
        private Label lblSoLuong;
        private DataGridView dgvChiTiet;
    }
}
