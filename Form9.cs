
using MySql.Data.MySqlClient;// Подключение для работы с MySQL базой данных.
using System;// Подключение пространства имен System, содержащее базовые типы данных и функции.
using System.Data;// Подключение пространства имен System.Data, содержащее классы для работы с данными.
using System.Windows.Forms;// Подключение пространства имен System.Windows.Forms, содержащее классы для работы с Windows Forms.

// Объявление пространства имен проекта. Название слишком длинное и неинформативное. Рекомендуется заменить на что-то более короткое и осмысленное, например, `SalonBeauty.Forms`.
namespace курсовая_работа_3_курс__салон_красоты_
{
   
      public partial class Form9 : Form
    {
        // Строка подключения к базе данных. Хранение строки подключения напрямую в коде не рекомендуется - лучше использовать файл конфигурации или переменные окружения.
        private string connectionString = "Server=localhost;Database=saloon;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";
        public Form9()
        {
            InitializeComponent();
            // Загрузка свободного времени при инициализации формы.
            LoadFreeTime();
        }
        // Метод для загрузки данных о свободном времени из базы данных.
        private void LoadFreeTime()
        {
            // Используется using для автоматического закрытия соединения с базой данных.
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Открытие соединения с базой данных.
                    connection.Open();
                    // SQL-запрос для выбора id, даты и времени из таблицы freetime, где isBooked = 0 (не забронировано).
                    using (MySqlCommand command = new MySqlCommand("SELECT id, date, time FROM freetime WHERE isBooked = 0", connection))
                    {
                        // Используется MySqlDataAdapter для заполнения DataTable данными из базы данных.
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            // Создание DataTable для хранения данных.
                            DataTable freeTimeTable = new DataTable();
                            // Заполнение DataTable данными из базы данных.
                            adapter.Fill(freeTimeTable);
                            // Установка DataTable в качестве источника данных для DataGridView.
                            dataGridView1.DataSource = freeTimeTable;

                            // Установка заголовков столбцов. Лучше получать эти заголовки динамически из схемы БД.
                            dataGridView1.Columns[0].HeaderText = "ID";
                            dataGridView1.Columns[1].HeaderText = "Дата";
                            dataGridView1.Columns[2].HeaderText = "Время";

                        }
                    }
                }
                // Обработка исключений, возникающих при работе с базой данных.
                catch (Exception ex)
                {
                    // Отображение сообщения об ошибке пользователю.
                    MessageBox.Show("Ошибка при загрузке свободного времени: " + ex.Message);
                }
            }
        }

        // Обработчик события Click на ячейку DataGridView.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Проверка на корректность индекса строки.
            if (e.RowIndex >= 0)
            {
                // Извлечение ID, даты и времени из выбранной строки DataGridView.
                int freeTimeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                DateTime selectedDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["date"].Value);
                string selectedTime = dataGridView1.Rows[e.RowIndex].Cells["time"].Value.ToString();
                // Создание экземпляра формы Form10 и передача необходимых данных.
                Form10 form10 = new Form10(freeTimeId, selectedDate, selectedTime, connectionString);
                // Отображение формы Form10 в модальном режиме.
                form10.ShowDialog(); // ShowDialog() блокирует Form9 пока Form10 открыта
                // Обновление таблицы свободного времени после закрытия Form10.
                LoadFreeTime(); //Обновляем таблицу после закрытия Form10

            }
        }

        // Обработчик события Click для кнопки button1.
        private void button1_Click(object sender, EventArgs e)
        {
            // Закрытие текущей формы (Form9).
            Close();
        }
    }
}
