namespace GUI
{
    partial class Detai
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnTimKiem = new Button();
            btnXoa = new Button();
            label6 = new Label();
            label5 = new Label();
            cbKhoa = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            btnHuy = new Button();
            btnLuu = new Button();
            groupBox2 = new GroupBox();
            btnSua = new Button();
            btnThem = new Button();
            dgvDeTai = new DataGridView();
            txtTenDeTai = new TextBox();
            label1 = new Label();
            txtMaDeTai = new TextBox();
            groupBox1 = new GroupBox();
            dtpNgayKetThuc = new DateTimePicker();
            dtpNgayBatDau = new DateTimePicker();
            txtMaGiangVien = new TextBox();
            label8 = new Label();
            txtKinhPhi = new TextBox();
            label2 = new Label();
            btnXemChiTietDK = new Button();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDeTai).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(430, 18);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(95, 42);
            btnTimKiem.TabIndex = 11;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(118, 18);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(95, 42);
            btnXoa.TabIndex = 8;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(383, 145);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 13;
            label6.Text = "Ngày kết thúc";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(383, 69);
            label5.Name = "label5";
            label5.Size = new Size(63, 20);
            label5.TabIndex = 11;
            label5.Text = "Kinh phí";
            // 
            // cbKhoa
            // 
            cbKhoa.FormattingEnabled = true;
            cbKhoa.Location = new Point(142, 67);
            cbKhoa.Name = "cbKhoa";
            cbKhoa.Size = new Size(227, 28);
            cbKhoa.TabIndex = 3;
            cbKhoa.SelectedIndexChanged += cbKhoa_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 69);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 9;
            label4.Text = "Khoa";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(383, 107);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 7;
            label3.Text = "Ngày bắt đầu";
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(632, 18);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(95, 42);
            btnHuy.TabIndex = 13;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(325, 18);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(95, 42);
            btnLuu.TabIndex = 10;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnXemChiTietDK);
            groupBox2.Controls.Add(btnHuy);
            groupBox2.Controls.Add(btnLuu);
            groupBox2.Controls.Add(btnTimKiem);
            groupBox2.Controls.Add(btnSua);
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnThem);
            groupBox2.Location = new Point(16, 194);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(744, 68);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chức năng";
            // 
            // btnSua
            // 
            btnSua.Location = new Point(221, 18);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(95, 42);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(16, 18);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(95, 42);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dgvDeTai
            // 
            dgvDeTai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeTai.Location = new Point(16, 268);
            dgvDeTai.Name = "dgvDeTai";
            dgvDeTai.RowHeadersWidth = 51;
            dgvDeTai.Size = new Size(744, 176);
            dgvDeTai.TabIndex = 4;
            dgvDeTai.CellClick += dgvDeTai_CellClick;
            // 
            // txtTenDeTai
            // 
            txtTenDeTai.Location = new Point(499, 26);
            txtTenDeTai.Name = "txtTenDeTai";
            txtTenDeTai.Size = new Size(228, 27);
            txtTenDeTai.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(383, 33);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 5;
            label1.Text = "Tên đề tài";
            // 
            // txtMaDeTai
            // 
            txtMaDeTai.Location = new Point(142, 26);
            txtMaDeTai.Name = "txtMaDeTai";
            txtMaDeTai.Size = new Size(227, 27);
            txtMaDeTai.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpNgayKetThuc);
            groupBox1.Controls.Add(dtpNgayBatDau);
            groupBox1.Controls.Add(txtMaGiangVien);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtKinhPhi);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cbKhoa);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtTenDeTai);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtMaDeTai);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(748, 180);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Đề tài";
            // 
            // dtpNgayKetThuc
            // 
            dtpNgayKetThuc.Location = new Point(499, 140);
            dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            dtpNgayKetThuc.Size = new Size(227, 27);
            dtpNgayKetThuc.TabIndex = 20;
            // 
            // dtpNgayBatDau
            // 
            dtpNgayBatDau.Location = new Point(499, 100);
            dtpNgayBatDau.Name = "dtpNgayBatDau";
            dtpNgayBatDau.Size = new Size(227, 27);
            dtpNgayBatDau.TabIndex = 19;
            dtpNgayBatDau.ValueChanged += dtpNgayBatDau_ValueChanged;
            // 
            // txtMaGiangVien
            // 
            txtMaGiangVien.Location = new Point(142, 111);
            txtMaGiangVien.Name = "txtMaGiangVien";
            txtMaGiangVien.Size = new Size(227, 27);
            txtMaGiangVien.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(26, 107);
            label8.Name = "label8";
            label8.Size = new Size(104, 40);
            label8.TabIndex = 17;
            label8.Text = "Mã Giảng viên\r\nhướng dẫn";
            // 
            // txtKinhPhi
            // 
            txtKinhPhi.Location = new Point(499, 61);
            txtKinhPhi.Name = "txtKinhPhi";
            txtKinhPhi.Size = new Size(228, 27);
            txtKinhPhi.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 33);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 3;
            label2.Text = "Mã đề tài";
            // 
            // btnXemChiTietDK
            // 
            btnXemChiTietDK.Location = new Point(531, 18);
            btnXemChiTietDK.Name = "btnXemChiTietDK";
            btnXemChiTietDK.Size = new Size(95, 42);
            btnXemChiTietDK.TabIndex = 12;
            btnXemChiTietDK.Text = "Chi tiết";
            btnXemChiTietDK.UseVisualStyleBackColor = true;
            btnXemChiTietDK.Click += btnXemChiTietDK_Click;
            // 
            // Detai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 453);
            Controls.Add(groupBox2);
            Controls.Add(dgvDeTai);
            Controls.Add(groupBox1);
            Name = "Detai";
            Text = "Detai";
            Load += Detai_Load;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDeTai).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnTimKiem;
        private Button btnXoa;
        private Label label6;
        private Label label5;
        private ComboBox cbKhoa;
        private Label label4;
        private Label label3;
        private Button btnHuy;
        private Button btnLuu;
        private GroupBox groupBox2;
        private Button btnSua;
        private Button btnThem;
        private DataGridView dgvDeTai;
        private TextBox txtTenDeTai;
        private Label label1;
        private TextBox txtMaDeTai;
        private GroupBox groupBox1;
        private TextBox txtKinhPhi;
        private Label label2;
        private TextBox txtMaGiangVien;
        private Label label8;
        private DateTimePicker dtpNgayKetThuc;
        private DateTimePicker dtpNgayBatDau;
        private Button btnXemChiTietDK;
    }
}