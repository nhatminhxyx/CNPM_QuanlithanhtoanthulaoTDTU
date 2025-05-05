namespace GUI
{
    partial class FormMain
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
            menuStrip1 = new MenuStrip();
            đềTàiToolStripMenuItem = new ToolStripMenuItem();
            sinhViênToolStripMenuItem = new ToolStripMenuItem();
            gIảngViênToolStripMenuItem = new ToolStripMenuItem();
            đăngKíĐềTàiToolStripMenuItem = new ToolStripMenuItem();
            thanhToánToolStripMenuItem = new ToolStripMenuItem();
            btnDangXuat = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { đềTàiToolStripMenuItem, sinhViênToolStripMenuItem, gIảngViênToolStripMenuItem, đăngKíĐềTàiToolStripMenuItem, thanhToánToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(774, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // đềTàiToolStripMenuItem
            // 
            đềTàiToolStripMenuItem.Name = "đềTàiToolStripMenuItem";
            đềTàiToolStripMenuItem.Size = new Size(63, 24);
            đềTàiToolStripMenuItem.Text = "Đề tài";
            đềTàiToolStripMenuItem.Click += đềTàiToolStripMenuItem_Click;
            // 
            // sinhViênToolStripMenuItem
            // 
            sinhViênToolStripMenuItem.Name = "sinhViênToolStripMenuItem";
            sinhViênToolStripMenuItem.Size = new Size(82, 24);
            sinhViênToolStripMenuItem.Text = "Sinh viên";
            sinhViênToolStripMenuItem.Click += sinhViênToolStripMenuItem_Click;
            // 
            // gIảngViênToolStripMenuItem
            // 
            gIảngViênToolStripMenuItem.Name = "gIảngViênToolStripMenuItem";
            gIảngViênToolStripMenuItem.Size = new Size(95, 24);
            gIảngViênToolStripMenuItem.Text = "Giảng Viên";
            gIảngViênToolStripMenuItem.Click += gIảngViênToolStripMenuItem_Click;
            // 
            // đăngKíĐềTàiToolStripMenuItem
            // 
            đăngKíĐềTàiToolStripMenuItem.Name = "đăngKíĐềTàiToolStripMenuItem";
            đăngKíĐềTàiToolStripMenuItem.Size = new Size(116, 24);
            đăngKíĐềTàiToolStripMenuItem.Text = "Đăng kí đề tài";
            đăngKíĐềTàiToolStripMenuItem.Click += đăngKíĐềTàiToolStripMenuItem_Click;
            // 
            // thanhToánToolStripMenuItem
            // 
            thanhToánToolStripMenuItem.Name = "thanhToánToolStripMenuItem";
            thanhToánToolStripMenuItem.Size = new Size(97, 24);
            thanhToánToolStripMenuItem.Text = "Thanh toán";
            thanhToánToolStripMenuItem.Click += thanhToánToolStripMenuItem_Click;
            // 
            // btnDangXuat
            // 
            btnDangXuat.AutoSize = true;
            btnDangXuat.Location = new Point(670, 28);
            btnDangXuat.Margin = new Padding(0);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(101, 33);
            btnDangXuat.TabIndex = 2;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = true;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 492);
            Controls.Add(btnDangXuat);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormMain";
            FormClosed += FormMain_FormClosed;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem đềTàiToolStripMenuItem;
        private ToolStripMenuItem sinhViênToolStripMenuItem;
        private ToolStripMenuItem gIảngViênToolStripMenuItem;
        private ToolStripMenuItem thanhToánToolStripMenuItem;
        private ToolStripMenuItem đăngKíĐềTàiToolStripMenuItem;
        private Button btnDangXuat;
    }
}