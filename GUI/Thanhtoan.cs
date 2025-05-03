using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Drawing;
using System.Drawing.Printing;

namespace GUI
{
    public partial class Thanhtoan : Form
    {
        private readonly ThanhToanBUS bus = new ThanhToanBUS();
        private ThanhToanDTO lastPrintedVoucher;
        public Thanhtoan()
        {
            InitializeComponent();
            this.Load += Thanhtoan_Load;
        }

        private void Thanhtoan_Load(object sender, EventArgs e)
        {
            // chỉ lấy đề tài chưa thanh toán
            dgvThanhToan.DataSource = bus.GetDeTaiChuaThanhToan();
            txtMaGV.ReadOnly = true;
        }


        // Khi gõ MaDeTai trực tiếp → đổ MaGV
        private void txtMaDeTai_TextChanged(object s, EventArgs e)
        {
            var md = txtMaDeTai.Text.Trim();
            txtMaGV.Text = string.IsNullOrEmpty(md)
                ? ""
                : bus.GetMaGVByMaDeTai(md) ?? "";
        }

        // Thanh toán
        private void btnThanhToan_Click(object s, EventArgs e)
        {
            var maDT = txtMaDeTai.Text.Trim();
            var maGV = txtMaGV.Text.Trim();
            if (string.IsNullOrEmpty(maDT) || string.IsNullOrEmpty(maGV))
            {
                MessageBox.Show("Vui lòng chọn đề tài!");
                return;
            }

            if (bus.HasBeenPaid(maDT))
            {
                MessageBox.Show("Đề tài này đã được thanh toán rồi!");
                return;
            }

            var kp = bus.GetKinhPhiByMaDeTai(maDT);
            if (kp == null)
            {
                MessageBox.Show("Không xác định được kinh phí!");
                return;
            }

            var maTT = bus.TaoMaThanhToan(maDT);
            var dto = new ThanhToanDTO
            {
                MaThanhToan = maTT,
                MaGV = maGV,
                MaDeTai = maDT,
                SoTien = kp.Value,
                NgayThanhToan = DateTime.Now,
                TrangThai = "Đã thanh toán"
            };

            if (!bus.ThanhToan(dto))
            {
                MessageBox.Show("Thanh toán thất bại!");
                return;
            }

            MessageBox.Show("Thanh toán thành công!");

            // lưu lại voucher để in khi cần
            lastPrintedVoucher = dto;

            // hỏi in phiếu
            var ans = MessageBox.Show("Bạn có muốn in phiếu thanh toán không?",
                        "In phiếu thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
                PrintVoucher(dto);

            // reload danh sách đề tài chưa thanh toán
            dgvThanhToan.DataSource = bus.GetDeTaiChuaThanhToan();
            txtMaDeTai.Clear();
            txtMaGV.Clear();
        }



        private void PrintVoucher(ThanhToanDTO dto)
        {
            var lines = new List<string>
    {
        "======= PHIẾU THANH TOÁN =======",
        $"Mã thanh toán   : {dto.MaThanhToan}",
        $"Giảng viên      : {dto.MaGV}",
        $"Đề tài          : {dto.MaDeTai}",
        $"Số tiền         : {dto.SoTien:N0} VND",
        $"Ngày thanh toán : {dto.NgayThanhToan:dd/MM/yyyy HH:mm}",
        $"Tình trạng      : {dto.TrangThai}",
        "==============================="
    };

            var pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                float y = ev.MarginBounds.Top;
                using var font = new Font("Consolas", 10);
                foreach (var line in lines)
                {
                    ev.Graphics.DrawString(line, font, Brushes.Black, ev.MarginBounds.Left, y);
                    y += font.GetHeight(ev.Graphics) + 4;
                }
            };

            try
            {
                using var dlg = new PrintDialog
                {
                    Document = pd,
                    UseEXDialog = true
                };

                // Kiểm tra nếu không có máy in nào khả dụng
                if (PrinterSettings.InstalledPrinters.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy máy in nào trên hệ thống.");
                    return;
                }

                var result = dlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pd.PrinterSettings = dlg.PrinterSettings;

                    // Kiểm tra tên máy in
                    var printerName = pd.PrinterSettings.PrinterName;
                    if (string.IsNullOrEmpty(printerName) || !pd.PrinterSettings.IsValid)
                    {
                        MessageBox.Show("Không thể in vì máy in không hợp lệ.");
                        return;
                    }

                    pd.Print();
                }
                else
                {
                    MessageBox.Show("Bạn đã hủy in.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in: " + ex.Message);
            }
        }

        // Tìm kiếm theo MaDeTai hoặc theo ngày
        private void btnTimKiem_Click(object s, EventArgs e)
        {
            var md = txtMaDeTai.Text.Trim();
            if (!string.IsNullOrEmpty(md))
            {
                dgvThanhToan.DataSource = bus.GetThanhToanByMaDeTai(md);
                return;
            }

            var from = dtpTuNgay.Value.Date;
            var to = dtpDenNgay.Value.Date;
            dgvThanhToan.DataSource = bus.GetThanhToanByDateRange(from, to);
        }

        // Xuất CSV
        private void btnXuatBaoCao_Click(object s, EventArgs e)
        {
            // Lấy khoảng ngày
            var from = dtpTuNgay.Value.Date;
            var to = dtpDenNgay.Value.Date;

            // Lấy các bản ghi đã thanh toán trong khoảng thời gian
            var dt = bus.GetThanhToanByDateRange(from, to);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi đã thanh toán trong khoảng thời gian này.");
                return;
            }

            using var sfd = new SaveFileDialog() { Filter = "CSV Files (*.csv)|*.csv" };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            var sb = new StringBuilder();

            // Thêm BOM để Excel hiểu đúng UTF-8
            sb.Append('\uFEFF');

            // Ghi dòng tiêu đề
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append(dt.Columns[i].ColumnName);
                if (i < dt.Columns.Count - 1)
                    sb.Append(",");
            }
            sb.AppendLine();

            // Ghi dữ liệu từng dòng
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string text;
                    var value = row[i];

                    if (value is DateTime dtValue)
                    {
                        text = dtValue.ToString("yyyy-MM-dd"); // hoặc "dd/MM/yyyy" nếu muốn kiểu Việt
                    }
                    else
                    {
                        text = value?.ToString().Replace(",", " "); // loại dấu phẩy để tránh lỗi cột
                    }

                    sb.Append(text);
                    if (i < dt.Columns.Count - 1)
                        sb.Append(",");
                }
                sb.AppendLine();
            }

            // Ghi vào file
            File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
            MessageBox.Show("Xuất báo cáo thành công.");
        }


        private void dgvThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var r = dgvThanhToan.Rows[e.RowIndex];
            var maDeTai = r.Cells["MaDeTai"].Value?.ToString();
            txtMaDeTai.Text = maDeTai;
            txtMaGV.Text = r.Cells["MaGV"].Value?.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaDeTai.Clear();
            txtMaGV.Clear();
            dgvThanhToan.DataSource = bus.GetDeTaiChuaThanhToan();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // In lại phiếu vừa in hoặc phiếu của đề tài đang chọn
            if (lastPrintedVoucher != null && lastPrintedVoucher.MaThanhToan != null)
            {
                PrintVoucher(lastPrintedVoucher);
                return;
            }

            // nếu chưa có voucher lưu, cố gắng tạo lại theo txtMaDeTai
            var maDT = txtMaDeTai.Text.Trim();
            if (string.IsNullOrEmpty(maDT))
            {
                MessageBox.Show("Vui lòng chọn đề tài để in.");
                return;
            }

            // load bản ghi thanh toán cuối cùng của đề tài đó
            var dt = bus.GetThanhToanByMaDeTai(maDT);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Đề tài này chưa có phiếu thanh toán.");
                return;
            }

            // lấy bản ghi mới nhất
            var row = dt.Rows[dt.Rows.Count - 1];
            var dto = new ThanhToanDTO
            {
                MaThanhToan = row["MaThanhToan"].ToString() ?? "",
                MaGV = row["MaGV"].ToString() ?? "",
                MaDeTai = row["MaDeTai"].ToString() ?? "",
                SoTien = Convert.ToDouble(row["SoTien"]),
                NgayThanhToan = Convert.ToDateTime(row["NgayThanhToan"]),
                TrangThai = row["TrangThai"].ToString() ?? ""
            };
            lastPrintedVoucher = dto;
            PrintVoucher(dto);
        }
    }
}
