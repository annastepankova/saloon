// Использует Entity Framework Core для работы с базами данных (но в данном коде не используется).
using Microsoft.EntityFrameworkCore;
// Использует пространство имен System, содержащее базовые типы данных и функции.
using System;
// Использует пространство имен System.Collections.Generic, содержащее интерфейсы и классы для работы со списками и коллекциями. В данном коде не используется.
using System.Collections.Generic;
// Использует пространство имен System.ComponentModel, содержащее классы для работы со свойствами компонентов и данных. В данном коде не используется.
using System.ComponentModel;
// Использует пространство имен System.Data, содержащее классы для работы с данными. В данном коде частично используется.
using System.Data;
// Использует пространство имен System.Drawing, содержащее классы для работы с графикой.
using System.Drawing;
// Использует пространство имен System.Linq, содержащее классы для работы с запросами LINQ. В данном коде не используется.
using System.Linq;
// Использует пространство имен System.Text, содержащее классы для работы со строками. В данном коде не используется.
using System.Text;
// Использует пространство имен System.Threading.Tasks, содержащее классы для работы с асинхронными операциями. В данном коде не используется.
using System.Threading.Tasks;
// Использует пространство имен System.Windows.Forms, содержащее классы для работы с Windows Forms.
using System.Windows.Forms;
// Использует пространство имен VisualStyles.VisualStyleElement (неясно зачем). Рекомендуется удалить, если не используется.
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
// Использует MySqlConnector для работы с MySQL базой данных.
using MySqlConnector;
// Использует пространство имен System.Data (дублируется). Удалить лишнюю строку.
using System.Data;

// Объявление пространства имен проекта. Название слишком длинное и неинформативное. Рекомендуется заменить на более короткое и осмысленное, например, `SalonBeauty.Forms`.
namespace курсовая_работа_3_курс__салон_красоты_
{
    // Объявление частичного класса Form8, наследуемого от класса Form. `partial` указывает, что определение класса разделено на несколько файлов (один генерируется дизайнером форм, другой пишется вручную).
    public partial class Form8 : Form
    {
        // Строка подключения к базе данных MySQL. Хранение строки подключения напрямую в коде не рекомендуется - лучше использовать файл конфигурации.
        string connectionString = "Server=localhost;Database=saloon;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";
        public Form8()
        {
            InitializeComponent();
            // Динамически создается DataGridView и добавляется на форму. Лучше добавить DataGridView через дизайнер форм.
            dataGridView1 = new DataGridView();
            dataGridView1.Dock = DockStyle.Fill; // Заполняет всю форму
            this.Controls.Add(dataGridView1);
            // Устанавливается фон DataGridView в цвет MistyRose.
            dataGridView1.BackgroundColor = Color.MistyRose;

            // Вызов метода для заполнения DataGridView данными из базы данных.
            PopulateTable();
        }
        private void PopulateTable()
        {
            // Используется using для автоматического закрытия соединения с базой данных.
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open(); // Открывает соединение с базой данных.

                // SQL-запрос для выбора всех данных из таблицы Mastera.
                string query = "SELECT * FROM Mastera";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Используется using для автоматического закрытия MySqlDataReader.
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Создается DataTable для хранения данных, полученных из базы данных.
                        DataTable dt = new DataTable();
                        dt.Load(reader); // Загружает данные из reader в DataTable.

                        // Устанавливает DataTable в качестве источника данных для DataGridView.
                        dataGridView1.DataSource = dt;
                        // Автоматически устанавливает ширину столбцов DataGridView в соответствии с содержимым.
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


                        // Устанавливает заголовки столбцов DataGridView. Лучше получить эти заголовки из базы данных, а не прописывать вручную.
                        dataGridView1.Columns[0].HeaderText = "ID";
                        dataGridView1.Columns[1].HeaderText = "ФИО мастера";
                        dataGridView1.Columns[2].HeaderText = "Услуги";
                        dataGridView1.Columns[3].HeaderText = "Стоимость";

                    }

                }
            }
        }

        // Обработчик события Click для кнопки button1.
        private void button1_Click(object sender, EventArgs e)
        {
            // Закрывает текущую форму (Form8).
            Close();
        }
    }
}
