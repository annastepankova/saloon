using Microsoft.EntityFrameworkCore; // Для работы с Entity Framework Core
using MongoDB.Driver.Core.Configuration; // Для работы с MongoDB (хотя в этом коде он не используется)
using MySqlConnector; // Для работы с базой данных MySQL
using System; // Базовое пространство имен .NET
using System.Collections.Generic; // Для работы со списками
using System.ComponentModel; // Для работы со свойствами компонентов
using System.Data; // Для работы с данными
using System.Drawing; // Для работы с графикой
using System.Linq; // Для использования LINQ запросов
using System.Text; // Для работы со строками
using System.Threading.Tasks; // Для асинхронного программирования
using System.Windows.Forms; // Для работы с Windows Forms
using static System.Windows.Forms.VisualStyles.VisualStyleElement; // Для работы со стилями


namespace парикмахерская
{
    public partial class Form3 : Form
    {
        // Строка подключения к базе данных MySQL.  Хранит строку подключения к базе данных.
        private string connectionString = "server=localhost;database=registration2;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";

        public Form3()
        {
            InitializeComponent(); // Инициализация компонентов формы.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close(); // Закрытие текущей формы.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем логин и пароль от пользователя из полей ввода.
            string login = textBox1.Text;
            string password = textBox2.Text;

            // Проверяем, существует ли пользователь в базе данных.  Используем Entity Framework для работы с базой.
            using (var context = new RegistrationContext(connectionString))
            {
                // LINQ запрос для поиска пользователя по логину и паролю.
                var user = context.Users.FirstOrDefault(u => u.Login == login && u.Parol == password);

                if (user != null) // Проверка на существование пользователя.
                {
                    // Пользователь найден - определяем роль. Проверяем кодовое слово для определения роли.
                    if (user.Kodovoeslovo == "администратор")
                    {
                        // Авторизация администратора.  Выводим сообщение об успешной авторизации.
                        MessageBox.Show("Вы авторизовались как администратор!");
                        // Переход на форму админа. Создаем и отображаем форму админа.
                        Form5 newForm = new Form5();
                        newForm.Show();
                    }
                    else
                    {
                        // Проверка на роль "клиент".
                        if (user.Kodovoeslovo == "клиент")
                        {
                            // Авторизация клиента.  Выводим сообщение об успешной авторизации.
                            MessageBox.Show("Вы авторизовались как клиент!");
                            // Переход на форму клиента. Создаем и отображаем форму клиента.
                            Form4 newForm = new Form4();
                            newForm.Show();
                        }
                    }
                }
                else // Пользователь не найден.
                {
                    // Выводим сообщение об ошибке.
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
        }
    }

    // Модель сущности для таблицы Users.  Представляет данные о пользователе.
    public class User
    {
        public int Id { get; set; } // ID пользователя.
        public string Login { get; set; } // Логин пользователя.
        public string Parol { get; set; } // Пароль пользователя.
        public string Kodovoeslovo { get; set; } // Кодовое слово, определяющее роль пользователя.
    }

    // Контекст Entity Framework.  Предоставляет доступ к базе данных.
    public class RegistrationContext : DbContext
    {
        private readonly string connectionString; // Строка подключения к базе данных.

        public RegistrationContext(string connectionString) : base() // Конструктор, который принимает строку подключения.
        {
            this.connectionString = connectionString; // Инициализация поля connectionString.
            this.Database.EnsureCreated(); // Создает базу данных, если она еще не существует.  Обычно используется только для разработки и тестирования.  В продакшне - не использовать!
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(this.connectionString, ServerVersion.AutoDetect(connectionString)); // Установка строки подключения к MySQL.
        }
        public DbSet<User> Users { get; set; } // DbSet для работы с таблицей Users.
    }
}
  











