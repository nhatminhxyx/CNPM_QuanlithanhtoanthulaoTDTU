using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class ConfigForm : Form
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsConfigured { get; private set; } = false;


        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            chkWindowsAuth_CheckedChanged(null, null); // Disable UID/Password if needed
        }

        private void chkWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu dùng Windows Authentication thì disable nhập UID & Password
            bool isChecked = chkWindowsAuth.Checked;
            txtUID.Enabled = !isChecked;
            txtPassword.Enabled = !isChecked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string server = txtServer.Text.Trim();
            string database = txtDatabase.Text.Trim();
            string uid = txtUID.Text.Trim();
            string password = txtPassword.Text.Trim();
            bool useWindowsAuth = chkWindowsAuth.Checked;

            if (string.IsNullOrWhiteSpace(server) || string.IsNullOrWhiteSpace(database))
            {
                MessageBox.Show("Vui lòng nhập Server và Database.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Thêm TrustServerCertificate=True để tránh lỗi chứng chỉ
            string connectionString = useWindowsAuth
                ? $"Data Source={server};Initial Catalog={database};Integrated Security=True;TrustServerCertificate=True"
                : $"Data Source={server};Initial Catalog={database};User ID={uid};Password={password};TrustServerCertificate=True";

            try
            {
                File.WriteAllText("connection.txt", connectionString);
                MessageBox.Show("Lưu cấu hình thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsConfigured = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu cấu hình: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Thoát ứng dụng nếu người dùng hủy cấu hình
        }
    }
}
