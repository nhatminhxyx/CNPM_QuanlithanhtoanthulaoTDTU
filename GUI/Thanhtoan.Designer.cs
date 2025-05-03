namespace GUI
{
    partial class Thanhtoan
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
            label1 = new Label();
            txtMaDeTai = new TextBox();
            groupBox1 = new GroupBox();
            label4 = new Label();
            dtpDenNgay = new DateTimePicker();
            label3 = new Label();
            dtpTuNgay = new DateTimePicker();
            txtMaGV = new TextBox();
            label2 = new Label();
            btnThanhToan = new Button();
            btnIn = new Button();
            btnXuatBaoCao = new Button();
            dgvThanhToan = new DataGridView();
            btnTimKiem = new Button();
            btnHuy = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThanhToan).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 40);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã đề tài";
            // 
            // txtMaDeTai
            // 
            txtMaDeTai.Location = new Point(117, 33);
            txtMaDeTai.Name = "txtMaDeTai";
            txtMaDeTai.Size = new Size(239, 27);
            txtMaDeTai.TabIndex = 1;
            txtMaDeTai.TextChanged += txtMaDeTai_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dtpDenNgay);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dtpTuNgay);
            groupBox1.Controls.Add(txtMaGV);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtMaDeTai);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(748, 137);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thanh toán";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(372, 84);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 7;
            label4.Text = "Đến ngày";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Location = new Point(490, 79);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(239, 27);
            dtpDenNgay.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 86);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 5;
            label3.Text = "Ngày bắt đầu";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Location = new Point(117, 81);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(239, 27);
            dtpTuNgay.TabIndex = 3;
            // 
            // txtMaGV
            // 
            txtMaGV.Location = new Point(488, 33);
            txtMaGV.Name = "txtMaGV";
            txtMaGV.Size = new Size(241, 27);
            txtMaGV.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(372, 40);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 2;
            label2.Text = "Mã giảng viên";
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(166, 155);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(137, 51);
            btnThanhToan.TabIndex = 6;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = true;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // btnIn
            // 
            btnIn.Location = new Point(319, 155);
            btnIn.Name = "btnIn";
            btnIn.Size = new Size(137, 51);
            btnIn.TabIndex = 7;
            btnIn.Text = "In bảng thanh toán";
            btnIn.UseVisualStyleBackColor = true;
            btnIn.Click += btnIn_Click;
            // 
            // btnXuatBaoCao
            // 
            btnXuatBaoCao.Location = new Point(471, 155);
            btnXuatBaoCao.Name = "btnXuatBaoCao";
            btnXuatBaoCao.Size = new Size(137, 51);
            btnXuatBaoCao.TabIndex = 8;
            btnXuatBaoCao.Text = "Xuất báo cáo";
            btnXuatBaoCao.UseVisualStyleBackColor = true;
            btnXuatBaoCao.Click += btnXuatBaoCao_Click;
            // 
            // dgvThanhToan
            // 
            dgvThanhToan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThanhToan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThanhToan.Location = new Point(8, 224);
            dgvThanhToan.Name = "dgvThanhToan";
            dgvThanhToan.RowHeadersWidth = 51;
            dgvThanhToan.Size = new Size(758, 228);
            dgvThanhToan.TabIndex = 6;
            dgvThanhToan.CellClick += dgvThanhToan_CellClick;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(12, 155);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(137, 51);
            btnTimKiem.TabIndex = 5;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(623, 155);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(137, 51);
            btnHuy.TabIndex = 9;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // Thanhtoan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 453);
            Controls.Add(btnHuy);
            Controls.Add(btnTimKiem);
            Controls.Add(dgvThanhToan);
            Controls.Add(btnXuatBaoCao);
            Controls.Add(btnIn);
            Controls.Add(btnThanhToan);
            Controls.Add(groupBox1);
            Name = "Thanhtoan";
            Text = "Thanhtoan";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThanhToan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtMaDeTai;
        private GroupBox groupBox1;
        private TextBox txtMaGV;
        private Label label2;
        private DateTimePicker dtpTuNgay;
        private Label label4;
        private DateTimePicker dtpDenNgay;
        private Label label3;
        private Button btnThanhToan;
        private Button btnIn;
        private Button btnXuatBaoCao;
        private DataGridView dgvThanhToan;
        private Button btnTimKiem;
        private Button btnHuy;
    }
}