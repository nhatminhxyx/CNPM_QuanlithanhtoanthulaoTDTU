namespace GUI
{
    partial class DangNhap
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
            label2 = new Label();
            txtTaikhoan = new TextBox();
            txtMatkhau = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            groupBox2 = new GroupBox();
            linkLabel1 = new LinkLabel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 43);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 0;
            label1.Text = "Tài khoản:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 95);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu:";
            // 
            // txtTaikhoan
            // 
            txtTaikhoan.Location = new Point(86, 40);
            txtTaikhoan.Name = "txtTaikhoan";
            txtTaikhoan.Size = new Size(254, 27);
            txtTaikhoan.TabIndex = 1;
            txtTaikhoan.TextChanged += txtTaikhoan_TextChanged;
            // 
            // txtMatkhau
            // 
            txtMatkhau.Location = new Point(86, 92);
            txtMatkhau.Name = "txtMatkhau";
            txtMatkhau.Size = new Size(254, 27);
            txtMatkhau.TabIndex = 2;
            txtMatkhau.UseSystemPasswordChar = true;
            txtMatkhau.KeyDown += txtMatkhau_KeyDown;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(86, 157);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(139, 44);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Đăng Nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            btnLogin.Enter += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(231, 157);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(109, 44);
            btnExit.TabIndex = 4;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Location = new Point(12, 51);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 259);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources._637497747751127360;
            pictureBox1.Location = new Point(3, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(244, 233);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(43, 21);
            label3.Name = "label3";
            label3.Size = new Size(537, 27);
            label3.TabIndex = 7;
            label3.Text = "Đăng nhập hệ thông Quản lí thanh toán thù lao";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(linkLabel1);
            groupBox2.Controls.Add(btnExit);
            groupBox2.Controls.Add(btnLogin);
            groupBox2.Controls.Add(txtMatkhau);
            groupBox2.Controls.Add(txtTaikhoan);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(265, 74);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(358, 236);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin đăng nhập";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(242, 129);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(98, 20);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Đổi mật khẩu";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // DangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 310);
            Controls.Add(groupBox2);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            Name = "DangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtTaikhoan;
        private TextBox txtMatkhau;
        private Button btnLogin;
        private Button btnExit;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private Label label3;
        private GroupBox groupBox2;
        private LinkLabel linkLabel1;
    }
}