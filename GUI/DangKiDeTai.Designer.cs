namespace GUI
{
    partial class DangKiDeTai
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
            lbMaDeTai = new Label();
            txtMaDeTai = new TextBox();
            btnTimKiem = new Button();
            btnDangKy = new Button();
            btnDuyet = new Button();
            btnTuChoi = new Button();
            dgvDangKyDeTai = new DataGridView();
            btnHuy = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDangKyDeTai).BeginInit();
            SuspendLayout();
            // 
            // lbMaDeTai
            // 
            lbMaDeTai.AutoSize = true;
            lbMaDeTai.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbMaDeTai.Location = new Point(69, 34);
            lbMaDeTai.Name = "lbMaDeTai";
            lbMaDeTai.Size = new Size(111, 31);
            lbMaDeTai.TabIndex = 0;
            lbMaDeTai.Text = "Mã đề tài";
            // 
            // txtMaDeTai
            // 
            txtMaDeTai.Location = new Point(186, 34);
            txtMaDeTai.Multiline = true;
            txtMaDeTai.Name = "txtMaDeTai";
            txtMaDeTai.Size = new Size(497, 38);
            txtMaDeTai.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(24, 105);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(140, 46);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnDangKy
            // 
            btnDangKy.Location = new Point(170, 105);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(140, 46);
            btnDangKy.TabIndex = 3;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            // 
            // btnDuyet
            // 
            btnDuyet.Location = new Point(316, 105);
            btnDuyet.Name = "btnDuyet";
            btnDuyet.Size = new Size(140, 46);
            btnDuyet.TabIndex = 4;
            btnDuyet.Text = "Duyệt";
            btnDuyet.UseVisualStyleBackColor = true;
            btnDuyet.Click += btnDuyet_Click;
            // 
            // btnTuChoi
            // 
            btnTuChoi.Location = new Point(462, 105);
            btnTuChoi.Name = "btnTuChoi";
            btnTuChoi.Size = new Size(140, 46);
            btnTuChoi.TabIndex = 5;
            btnTuChoi.Text = "Từ chối";
            btnTuChoi.UseVisualStyleBackColor = true;
            btnTuChoi.Click += btnTuChoi_Click;
            // 
            // dgvDangKyDeTai
            // 
            dgvDangKyDeTai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDangKyDeTai.Location = new Point(12, 167);
            dgvDangKyDeTai.Name = "dgvDangKyDeTai";
            dgvDangKyDeTai.RowHeadersWidth = 51;
            dgvDangKyDeTai.Size = new Size(748, 244);
            dgvDangKyDeTai.TabIndex = 6;
            dgvDangKyDeTai.CellClick += dgvDangKyDeTai_CellClick;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(608, 105);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(140, 46);
            btnHuy.TabIndex = 6;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // DangKiDeTai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 418);
            Controls.Add(btnHuy);
            Controls.Add(dgvDangKyDeTai);
            Controls.Add(btnTuChoi);
            Controls.Add(btnDuyet);
            Controls.Add(btnDangKy);
            Controls.Add(btnTimKiem);
            Controls.Add(txtMaDeTai);
            Controls.Add(lbMaDeTai);
            Name = "DangKiDeTai";
            Text = "DangKiDeTai";
            Load += DangKiDeTai_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDangKyDeTai).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbMaDeTai;
        private TextBox txtMaDeTai;
        private Button btnTimKiem;
        private Button btnDangKy;
        private Button btnDuyet;
        private Button btnTuChoi;
        private DataGridView dgvDangKyDeTai;
        private Button btnHuy;
    }
}