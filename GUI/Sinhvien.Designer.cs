namespace GUI
{
    partial class Sinhvien
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
            groupBox2 = new GroupBox();
            button1 = new Button();
            btnLuu = new Button();
            btnTimKiem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            dgvSinhVien = new DataGridView();
            groupBox1 = new GroupBox();
            label6 = new Label();
            dtpNgaySinh = new DateTimePicker();
            txtLop = new TextBox();
            label5 = new Label();
            cbKhoa = new ComboBox();
            label4 = new Label();
            txtQueQuan = new TextBox();
            label3 = new Label();
            txtHoTen = new TextBox();
            label1 = new Label();
            txtMaSV = new TextBox();
            label2 = new Label();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(btnLuu);
            groupBox2.Controls.Add(btnTimKiem);
            groupBox2.Controls.Add(btnSua);
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnThem);
            groupBox2.Location = new Point(16, 158);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(744, 92);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chức năng";
            // 
            // button1
            // 
            button1.Location = new Point(622, 31);
            button1.Name = "button1";
            button1.Size = new Size(101, 42);
            button1.TabIndex = 12;
            button1.Text = "Hủy";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(383, 31);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(101, 42);
            btnLuu.TabIndex = 10;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(504, 31);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(101, 42);
            btnTimKiem.TabIndex = 11;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(264, 31);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(101, 42);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(143, 31);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(101, 42);
            btnXoa.TabIndex = 8;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(22, 31);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(101, 42);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Location = new Point(12, 254);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.Size = new Size(748, 190);
            dgvSinhVien.TabIndex = 4;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(dtpNgaySinh);
            groupBox1.Controls.Add(txtLop);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cbKhoa);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtQueQuan);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtHoTen);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtMaSV);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(748, 148);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giảng viên";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(387, 79);
            label6.Name = "label6";
            label6.Size = new Size(34, 20);
            label6.TabIndex = 15;
            label6.Text = "Lớp";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(499, 117);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(228, 27);
            dtpNgaySinh.TabIndex = 6;
            // 
            // txtLop
            // 
            txtLop.Location = new Point(499, 71);
            txtLop.Name = "txtLop";
            txtLop.Size = new Size(228, 27);
            txtLop.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(383, 121);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 11;
            label5.Text = "Ngày sinh";
            // 
            // cbKhoa
            // 
            cbKhoa.FormattingEnabled = true;
            cbKhoa.Location = new Point(142, 71);
            cbKhoa.Name = "cbKhoa";
            cbKhoa.Size = new Size(227, 28);
            cbKhoa.TabIndex = 3;
            cbKhoa.SelectedIndexChanged += cbKhoa_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 76);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 9;
            label4.Text = "Khoa";
            // 
            // txtQueQuan
            // 
            txtQueQuan.Location = new Point(142, 116);
            txtQueQuan.Name = "txtQueQuan";
            txtQueQuan.Size = new Size(227, 27);
            txtQueQuan.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 117);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 7;
            label3.Text = "Quê quán";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(499, 26);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(228, 27);
            txtHoTen.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(383, 33);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 5;
            label1.Text = "Họ tên";
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(142, 26);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(227, 27);
            txtMaSV.TabIndex = 1;
            txtMaSV.TextChanged += txtMaSV_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 33);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 3;
            label2.Text = "Mã Sinh viên";
            // 
            // Sinhvien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 453);
            Controls.Add(groupBox2);
            Controls.Add(dgvSinhVien);
            Controls.Add(groupBox1);
            Name = "Sinhvien";
            Text = "Sinhvien";
            Load += Sinhvien_Load;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Button button1;
        private Button btnLuu;
        private Button btnTimKiem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private DataGridView dgvSinhVien;
        private GroupBox groupBox1;
        private Label label6;
        private DateTimePicker dtpNgaySinh;
        private TextBox txtLop;
        private Label label5;
        private ComboBox cbKhoa;
        private Label label4;
        private TextBox txtQueQuan;
        private Label label3;
        private TextBox txtHoTen;
        private Label label1;
        private TextBox txtMaSV;
        private Label label2;
    }
}