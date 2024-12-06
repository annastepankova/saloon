using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace курсовая_работа_3_курс__салон_красоты_
{
    public partial class Form2 : Form
    {
        string connectionString = "Server=localhost;Database=saloon;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";
        public Form2()
        {
            InitializeComponent();
      
            textBox4.PasswordChar = '*';
        }
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
                string familiya = textBox1.Text;
                string imya = textBox2.Text;
                string login = textBox3.Text;
                string parol = textBox4.Text;
                string kodovoeslovo = textBox5.Text;
              
            
                using (ApplicationContext db = new ApplicationContext())
                {
  
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
       
        public class ApplicationContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                string connectionString = "Server=localhost;Database=saloon;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";
                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 25)));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
