
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySqlConnector;
using System.Data;


namespace курсовая_работа_3_курс__салон_красоты_
{

    public partial class Form8 : Form
    {
               // Строка подключения к базе данных MySQL
        string connectionString = "Server=localhost;Database=saloon;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";

        public Form8()
        {
            // Инициализация компонентов формы (автоматически генерируется)
            InitializeComponent();

            // Создание объекта DataGridView
            dataGridView1 = new DataGridView();
            // Установка режима отображения DataGridView на заполнение всей формы
            dataGridView1.Dock = DockStyle.Fill;
            // Добавление DataGridView на форму
            this.Controls.Add(dataGridView1);

            // Установка цвета фона DataGridView
            dataGridView1.BackgroundColor = Color.MistyRose;

            // Заполнение DataGridView данными из базы данных
            PopulateTable();
        }

        private void PopulateTable()
        {
            // Используем using для автоматического закрытия соединения с базой данных
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Открытие соединения с базой данных
                connection.Open();

                // SQL-запрос для выборки всех данных из таблицы Mastera
                string query = "SELECT * FROM Mastera";
                // Создание объекта MySqlCommand для выполнения запроса
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Выполнение запроса и получение результата в виде MySqlDataReader
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Создание объекта DataTable для хранения данных
                        DataTable dt = new DataTable();
                        // Загрузка данных из MySqlDataReader в DataTable
                        dt.Load(reader);

                        // Установка источника данных DataGridView
                        dataGridView1.DataSource = dt;

                        // Автоматическая настройка ширины столбцов DataGridView
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                        // Установка заголовков столбцов на русском языке
                        dataGridView1.Columns[0].HeaderText = "ID";
                        dataGridView1.Columns[1].HeaderText = "ФИО мастера";
                        dataGridView1.Columns[2].HeaderText = "Услуги";
                        dataGridView1.Columns[3].HeaderText = "Стоимость";
                    }
                }
            }
        }

        // Обработчик события нажатия на кнопку "Закрыть"
        private void button1_Click(object sender, EventArgs e)
        {
            // Закрытие формы
            Close();
        }
    }
}
