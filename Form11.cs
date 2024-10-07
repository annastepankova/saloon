using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
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
    public partial class Form11 : Form
    {
        private string connectionString = "server=localhost;database=hair1;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";

        public Form11()
        {
            InitializeComponent();
            LoadFreeTimeData();
        }

        private void LoadFreeTimeData()
        {
            using (var context = new HairContext(connectionString))
            {
                var freeTimes = context.FreeTime.ToList();
                dataGridView1.DataSource = freeTimes;
            }

            // Настройка DataGridView для отображения времени
            dataGridView1.Columns["Date"].HeaderText = "Дата";
            dataGridView1.Columns["StartTime"].HeaderText = "Начало";
            dataGridView1.Columns["EndTime"].HeaderText = "Окончание";
            dataGridView1.Columns["IsFree"].HeaderText = "Свободно";
            dataGridView1.Columns["IsFree"].DefaultCellStyle.BackColor = Color.LightGreen; // Свободно - зеленый
            dataGridView1.Columns["IsFree"].DefaultCellStyle.ForeColor = Color.Black; // Черный текст
            dataGridView1.Columns["IsFree"].ReadOnly = true; // Сделайте столбец "IsFree" не редактируемым

            // Добавьте обработчик события CellClick для DataGridView
            dataGridView1.CellClick += dataGridView1_CellContentClick;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, была ли щелкнута ячейка в столбце "IsFree"
            if (e.ColumnIndex == dataGridView1.Columns["IsFree"].Index)
            {
                // Получаем ID записи из выбранной строки
                int selectedId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);

                using (var context = new HairContext(connectionString))
                {
                    var freeTime = context.FreeTime.Find(selectedId);
                    if (freeTime != null)
                    {
                        // Покажите статус в MessageBox
                        string statusMessage = freeTime.IsFree ? "Время свободно" : "Время занято";
                        MessageBox.Show(statusMessage);



                    }
                }
            }
        }
        // Модель сущности FreeTime
        public class FreeTime
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public TimeSpan StartTime { get; set; }
            public TimeSpan EndTime { get; set; }
            public bool IsFree { get; set; }
        }

        // Контекст базы данных
        public class HairContext : DbContext
        {
            private readonly string connectionString;

            public HairContext(string connectionString) : base()
            {
                this.connectionString = connectionString;
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseMySql(this.connectionString, ServerVersion.AutoDetect(connectionString));
            }

            public DbSet<FreeTime> FreeTime { get; set; }
        }
// Удалить неиспользуемые методы
        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
