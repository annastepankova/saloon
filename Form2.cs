using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace парикмахерская
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Класс User, определяющий структуру объекта User со свойствами Id, Familiya, Imya, Login, Parol, Kodovoeslovo
        public class User
        {
            public int Id { get; set; }
            public string Familiya { get; set; }
            public string Imya { get; set; }
            public string Login { get; set; }
            public string Parol { get; set; }
            public string Kodovoeslovo { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
              // Получение данных из полей ввода
                string familiya = textBox1.Text;
                string imya = textBox2.Text;
                string login = textBox3.Text;
                string parol = textBox5.Text;
                string kodovoeslovo = textBox4.Text;
                // Добавление пользователей в БД
                using (ApplicationContext db = new ApplicationContext())
                {
                    //
                    db.Database.EnsureCreated();
                     // Создание нового пользователя
                    User user = new User
                    {
                        Familiya = familiya,
                        Imya = imya,
                        Login = login,
                        Parol = parol,
                        Kodovoeslovo = kodovoeslovo
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Пользователь успешно сохранен!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении пользователя: " + ex.Message);

            }
        }
        // Класс, предоставляющий контекст для взаимодействия с БД
        public class ApplicationContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            // Строка подключения к базе данных - лучше хранить в конфигурационном файле
                string connectionString = "Server=localhost;Database=registration2;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";
                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 25)));
            }
        }
    }
}
