using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Core.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace парикмахерская
{
    public partial class Form3 : Form
    {
        // Строка подключения к базе данных MySQL
        private string connectionString = "server=localhost;database=registration2;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";


        public Form3()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем логин и пароль от пользователя
            string login = textBox1.Text;
            string password = textBox2.Text;

            // Проверяем, существует ли пользователь в базе данных
            using (var context = new RegistrationContext(connectionString))
            {
                var user = context.Users.FirstOrDefault(u => u.Login == login && u.Parol == password);

                if (user != null)
                {
                    // Пользователь найден - определяем роль
                    if (user.Kodovoeslovo == "администратор")
                    {
                        // Авторизация администратора
                        MessageBox.Show("Вы авторизовались как администратор!");
                        // Переход на форму админа
                        Form5 newForm = new Form5();
                        newForm.Show();
                    }
                    else
                    {
                        if (user.Kodovoeslovo == "клиент")
                        {
                            MessageBox.Show("Вы авторизовались как клиент!");
                            // Переход на форму клиента
                            Form4 newForm = new Form4();
                            newForm.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                }
            }
        }
    }

    // Модель сущности для таблицы Users
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Parol { get; set; }
        public string Kodovoeslovo { get; set; } // "admin" для администратора, другое значение для клиента
    }

    // Контекст Entity Framework
    public class RegistrationContext : DbContext
    {
      // Строка подключения к базе данных - лучше хранить в конфигурационном файле
        private readonly string connectionString; // Объявление поля

        public RegistrationContext(string connectionString) : base()
        {
            this.connectionString = connectionString;
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(this.connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<User> Users { get; set; } // Объявление DbSet<User>
    }
}

    

  











