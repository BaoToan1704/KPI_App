namespace KPI
{
    internal static class Program
    {
        private static Mutex mutex = new Mutex(true, "{B1A9D5A1-5C3B-4D3A-8A1A-5D3B4D3A8A1A}");

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();
                Application.Run(new SplashScreen());
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("Application is already running.");
            }
        }
    }
}