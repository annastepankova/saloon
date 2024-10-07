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
    public partial class Form9 : Form
    {
    // Строка подключения к базе данных - лучше хранить в конфигурационном файле
        private string connectionString = "server=localhost;database=hair1;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Получаем поисковый запрос из TextBox
            string searchQuery = textBox1.Text;

            // Получаем данные из БД
            using (var context = new HairContext())
            {
                var services = context.Services.ToList();

                // Проверка на пустоту поискового запроса
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    services = services.Where(s => s.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList(); // IgnoreCase для игнорирования регистра
                }

              // Очистка DataGridView, если запрос пустой
                dataGridView1.DataSource = services;
            }
        }
    }
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class HairContext : DbContext
    {
        private readonly string connectionString = "server=localhost;database=hair;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";

        public DbSet<Service> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }

}
