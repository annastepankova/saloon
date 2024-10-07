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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace парикмахерская
{
    public partial class Form10 : Form
    {
        private string connectionString = "server=localhost;database=hair1;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";
        public Form10()
        {
            InitializeComponent();
        }
        public class Service  // Класс сервиса
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }


        public class HairContext : DbContext
        {
            private readonly string connectionString = "server=localhost;database=hair1;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";

            public DbSet<Service> Services { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем поисковый запрос
            string searchQuery = textBox1.Text;

            // Получаем данные из БД
            using (var context = new HairContext())
            {
                var services = context.Services.ToList();

                // Фильтруем данные
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    services = services.Where(s => s.Name.Contains(searchQuery)).ToList();
                }

                // Отображаем данные в DataGridView
                dataGridView1.DataSource = services;
            }
        }
   // Обработка клика по кнопке "Закрыть"
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
// Неиспользуемый метод 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

