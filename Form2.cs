using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace курсовая_работа_3_курс__салон_красоты_// Название пространства имен, может быть улучшено для соответствия стандартам кодирования.
{
    public partial class Form2 : Form
    {
        string connectionString = "Server=localhost;Database=saloon;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";// Строка подключения к базе данных. Рекомендуется использовать конфигурационные файлы для хранения таких данных.
        public Form2()
        {
            InitializeComponent();
            // Устанавливаем символ для отображения пароля
            textBox4.PasswordChar = '*';
        }
        public class User
        {
            public int Id { get; set; }
            public string Familiya { get; set; }
            public string Imya { get; set; }
            public string Login { get; set; }
            public string Parol { get; set; }// Свойство пароля пользователя. Рекомендуется хранить пароли в зашифрованном виде.
            public string Kodovoeslovo { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string familiya = textBox1.Text;
                string imya = textBox2.Text;
                string login = textBox3.Text;
                string parol = textBox4.Text;// Свойство пароля пользователя. Рекомендуется хранить пароли в зашифрованном виде.
                string kodovoeslovo = textBox5.Text;
              
                // Добавление пользователей в БД
                using (ApplicationContext db = new ApplicationContext())
                {
                    //
                    db.Database.EnsureCreated();
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
                string connectionString = "Server=localhost;Database=saloon;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";// Строка подключения. Рекомендуется использовать конфигурационные файлы для хранения таких данных.
                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 25)));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
