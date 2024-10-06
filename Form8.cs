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
    public partial class Form8 : Form
    {
        private string connectionString = "server=localhost;database=hair1;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";
        public Form8()
        {
            InitializeComponent();
        }

        public class Master
        {
            public int Id { get; set; }
            public string familiya { get; set; }
            public string name { get; set; }
            public string otchectvo { get; set; }
        }

        public class HairContext : DbContext
        {
            private readonly string connectionString = "server=localhost;database=hair1;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";

            public DbSet<Master> Master { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем поисковый запрос
            string searchQuery = textBox1.Text;

            // Получаем данные из БД
            using (var context = new HairContext())
            {
                var master = context.Master.ToList();

                // Фильтруем данные
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    master = master.Where(s => s.name.Contains(searchQuery)).ToList();
                }

                // Отображаем данные в DataGridView
                dataGridView1.DataSource = master;
            }
        }
    }
}
