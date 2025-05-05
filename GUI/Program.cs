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
            ApplicationConfiguration.Initialize();
            using (ConfigForm configForm = new ConfigForm())
            {
                configForm.ShowDialog();

                if (configForm.IsConfigured)
                {
                    Application.Run(new DangNhap());
                }
                else
                {
                    Environment.Exit(0); // Thoát triệt để nếu không cấu hình
                }
            }
        }

    }
}