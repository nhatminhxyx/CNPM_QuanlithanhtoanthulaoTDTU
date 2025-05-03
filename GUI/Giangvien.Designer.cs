namespace GUI
{
    partial class Giangvien
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
            groupBox1 = new GroupBox();
            txtSdt = new TextBox();
            label6 = new Label();
            cbHocVi = new ComboBox();
            label5 = new Label();
            cbKhoa = new ComboBox();
            label4 = new Label();
            txtQueQuan = new TextBox();
            label3 = new Label();
            txtHoTen = new TextBox();
            label1 = new Label();
            txtMaGV = new TextBox();
            label2 = new Label();
            dgvGiangVien = new DataGridView();
            groupBox2 = new GroupBox();
            button1 = new Button();
            btnLuu = new Button();
            btnTimKiem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGiangVien).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtSdt);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(cbHocVi);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cbKhoa);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtQueQuan);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtHoTen);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtMaGV);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(748, 148);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giảng viên";
            // 
            // txtSdt
            // 
            txtSdt.Location = new Point(499, 114);
            txtSdt.Name = "txtSdt";
            txtSdt.Size = new Size(228, 27);
            txtSdt.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(383, 117);
            label6.Name = "label6";
            label6.Size = new Size(97, 20);
            label6.TabIndex = 13;
            label6.Text = "Số điện thoại";
            // 
            // cbHocVi
            // 
            cbHocVi.FormattingEnabled = true;
            cbHocVi.Location = new Point(499, 68);
            cbHocVi.Name = "cbHocVi";
            cbHocVi.Size = new Size(228, 28);
            cbHocVi.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(383, 76);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 11;
            label5.Text = "Học vị";
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
            // txtMaGV
            // 
            txtMaGV.Location = new Point(142, 26);
            txtMaGV.Name = "txtMaGV";
            txtMaGV.Size = new Size(227, 27);
            txtMaGV.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 33);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 3;
            label2.Text = "Mã giảng viên";
            // 
            // dgvGiangVien
            // 
            dgvGiangVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGiangVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGiangVien.Location = new Point(12, 258);
            dgvGiangVien.Name = "dgvGiangVien";
            dgvGiangVien.RowHeadersWidth = 51;
            dgvGiangVien.Size = new Size(748, 190);
            dgvGiangVien.TabIndex = 1;
            dgvGiangVien.CellClick += dgvGiangVien_CellClick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(btnLuu);
            groupBox2.Controls.Add(btnTimKiem);
            groupBox2.Controls.Add(btnSua);
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnThem);
            groupBox2.Location = new Point(16, 162);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(744, 92);
            groupBox2.TabIndex = 2;
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
            // Giangvien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 453);
            Controls.Add(groupBox2);
            Controls.Add(dgvGiangVien);
            Controls.Add(groupBox1);
            Name = "Giangvien";
            Text = "Giangvien";
            Load += Giangvien_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGiangVien).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtQueQuan;
        private Label label3;
        private TextBox txtHoTen;
        private Label label1;
        private TextBox txtMaGV;
        private Label label2;
        private ComboBox cbHocVi;
        private Label label5;
        private ComboBox cbKhoa;
        private Label label4;
        private DataGridView dgvGiangVien;
        private TextBox txtSdt;
        private Label label6;
        private GroupBox groupBox2;
        private Button btnTimKiem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
        private Button btnLuu;
        private Button button1;
    }
}