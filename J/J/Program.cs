namespace J
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm
            {
                Width = 1023,
                Height = 768,
                Text = "Main",
                StartPosition = FormStartPosition.CenterScreen
            });
        }
    }
}
