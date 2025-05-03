namespace GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            using (ConfigForm configForm = new ConfigForm())
            {
                configForm.ShowDialog();

                if (configForm.IsConfigured)
                {
                    // Nếu đã cấu hình -> mở form đăng nhập
                    Application.Run(new DangNhap());
                }
                else
                {
                    // Nếu người dùng tắt form cấu hình (nhấn X hoặc Cancel) -> thoát ứng dụng
                    Application.Exit();
                }
            }
        }
    }
}