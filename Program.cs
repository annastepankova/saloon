namespace парикмахерская
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          // Инициализация конфигурации приложения
            // Запуск приложения с начальной формой Form1
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
