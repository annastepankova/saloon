using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace парикмахерская
{
    public partial class Form5 : Form
    {
    // Подключение к базе данных MySQL
        MySqlConnection connection;

        string currentTableName; // Хранит имя текущей таблицы
        TabPage currentTabPage; // Хранит текущую вкладку
        DataGridView currentDataGridView; // Хранит ссылку на текущий DataGridView



        public Form5()
        {
            InitializeComponent();

            // Настройка подключения к базе данных
            string connectionString = "server=localhost;database=hair1;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";
            connection = new MySqlConnection(connectionString);
            connection.Open();

            // Отображение данных таблицы appointments на tabPage1
            DisplayDataInTab("SELECT * FROM hair1.appointments;", tabPage1);
            // Отображение данных таблицы freetime на tabPage2
            DisplayDataInTab("SELECT * FROM hair1.freetime;", tabPage2);
            // Отображение данных таблицы services на tabPage3
            DisplayDataInTab("SELECT * FROM hair1.services;", tabPage3);
            // Отображение данных таблицы users на tabPage4
            DisplayDataInTab("SELECT * FROM registration2.users;", tabPage4);
            // Отображение данных таблицы users на tabPage5
            DisplayDataInTab("SELECT * FROM hair1.master;", tabPage5);
        }
        private void DisplayDataInTab(string query, TabPage tabPage)
        {
            // Создание DataGridView для каждой вкладки
            DataGridView dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BackgroundColor = Color.LavenderBlush,
                ColumnHeadersDefaultCellStyle = { BackColor = Color.LavenderBlush },
                DefaultCellStyle = { SelectionBackColor = Color.Snow, BackColor = Color.Snow }
            };

            // Выполнение запроса к базе данных
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Привязка данных к DataGridView
            dataGridView.DataSource = dataTable;

            // Добавление DataGridView на вкладку
            tabPage.Controls.Add(dataGridView);

            // Добавление TextBox для ввода запроса
            TextBox textBox = new TextBox
            {
                Dock = DockStyle.Top,
                Height = 30,
                Multiline = true,
                Name = "textBoxQuery", // Имя TextBox
                Text = "Введите SQL-запрос..."
            };
            tabPage.Controls.Add(textBox);

            // Добавление кнопок "Удалить", "Изменить", "Добавить"
            Button deleteButton = new Button { Text = "Удалить", Dock = DockStyle.Right, Width = 100, Name = "buttonDelete", BackColor = Color.LavenderBlush }; // Имя кнопки
            Button updateButton = new Button { Text = "Изменить", Dock = DockStyle.Right, Width = 100, Name = "buttonUpdate", BackColor = Color.LavenderBlush }; // Имя кнопки
            Button insertButton = new Button { Text = "Добавить", Dock = DockStyle.Right, Width = 100, Name = "buttonInsert" , BackColor = Color.LavenderBlush }; // Имя кнопки
            tabPage.Controls.Add(deleteButton);
            tabPage.Controls.Add(updateButton);
            tabPage.Controls.Add(insertButton);

            // Обработчики событий для кнопок
            deleteButton.Click += (sender, e) =>
            {
                ExecuteQuery(textBox.Text, tabPage, dataGridView);
            };
            updateButton.Click += (sender, e) =>
            {
                ExecuteQuery(textBox.Text, tabPage, dataGridView);
            };
            insertButton.Click += (sender, e) =>
            {
                ExecuteQuery(textBox.Text, tabPage, dataGridView);
            };

            // Сохранение имени текущей таблицы и вкладки
            currentTableName = query.Split(' ')[2].Replace(";", ""); // Получение имени таблицы из запроса
            currentTabPage = tabPage;
        }
 // Метод для выполнения SQL-запроса
        private void ExecuteQuery(string query, TabPage tabPage, DataGridView dataGridView)
        {
            try
            {
                // Выполнение запроса к базе данных
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                // Обновление данных в DataGridView
                DisplayDataInTab($"SELECT * FROM {currentTableName};", currentTabPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Правильное выполнение запроса");
            }
        }
    }
}







