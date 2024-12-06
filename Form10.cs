
using MySql.Data.MySqlClient;// Подключение для работы с MySQL базой данных.
using System;// Подключение пространства имен System, содержащее базовые типы данных и функции.
using System.Data;// Подключение пространства имен System.Data, содержащее классы для работы с данными.
using System.Windows.Forms;// Подключение пространства имен System.Windows.Forms, содержащее классы для работы с Windows Forms.


namespace курсовая_работа_3_курс__салон_красоты_
{

    public partial class Form10 : Form    // Объявление частичного класса Form10, наследуемого от класса Form. `partial` указывает, что определение класса разделено на несколько файлов (один генерируется дизайнером форм, другой пишется вручную).
    {
       
             // Переменные для хранения данных о свободном времени и строки подключения.
        private int freeTimeId;
        private DateTime selectedDate;
        private string selectedTime;
        private string connectionString;
        // Конструктор класса Form10, принимающий данные о свободном времени и строку подключения.
        public Form10(int freeTimeId, DateTime selectedDate, string selectedTime, string connectionString)
        {
            InitializeComponent();
            // Инициализация переменных класса.
            this.freeTimeId = freeTimeId;
            this.selectedDate = selectedDate;
            this.selectedTime = selectedTime;
            this.connectionString = connectionString;
            // Установка значения dateTimePicker1.
            dateTimePicker1.Value = selectedDate;
            // Установка значения textBox3.
            textBox3.Text = selectedTime;
            // Загрузка списка услуг из базы данных.
            LoadServices();
        }


        // Вложенный класс для представления данных об услуге.
        public class ServiceItem
        {
            // Id услуги.
            public int Id { get; set; }
            // Название услуги.
            public string Name { get; set; }
            // Цена услуги.
            public decimal Price { get; set; }
            // Переопределение метода ToString() для удобного отображения данных об услуге в ComboBox.
            public override string ToString()
            {
                return $"{Name} ({Price:C})"; //Форматирование цены
            }
        }
        // Метод для загрузки списка услуг из базы данных.
        private void LoadServices()
        {
            // Используется using для автоматического закрытия соединения с базой данных.
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Открытие соединения с базой данных.
                    connection.Open();
                    // SQL-запрос для выбора ID, названия и цены услуг из таблицы Services.
                    using (MySqlCommand command = new MySqlCommand("SELECT IDservices, service_name, price FROM Services", connection))
                    {
                        // Используется using для автоматического закрытия MySqlDataReader.
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            // Очистка ComboBox перед загрузкой новых данных.
                            comboBox1.Items.Clear();
                            // Цикл для чтения данных из базы данных.
                            while (reader.Read())
                            {
                                try
                                {
                                    // Извлечение данных из reader.
                                    int id = reader.GetInt32("IDservices");
                                    string serviceName = reader.GetString("service_name");
                                    decimal price = reader.GetDecimal("price");
                                    // Добавление объекта ServiceItem в ComboBox.
                                    comboBox1.Items.Add(new ServiceItem { Id = id, Name = serviceName, Price = price });
                                }
                                // Обработка исключений при чтении данных.
                                catch (Exception innerEx)
                                {
                                    MessageBox.Show("Ошибка при чтении данных: " + innerEx.Message);
                                    break; // Прекращаем цикл, если произошла ошибка
                                }
                            }
                        }
                    }
                }
                // Обработка исключений при подключении к базе данных.
                catch (MySqlException ex)
                {
                    MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
                }
                // Обработка других исключений.
                catch (Exception ex)
                {
                    MessageBox.Show("Неизвестная ошибка: " + ex.Message);
                }
            }
        }
        // Обработчик события Click для кнопки button1.
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Используется using для автоматического закрытия соединения с базой данных.
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    // Открытие соединения с базой данных.
                    connection.Open();
                    // Создание объекта MySqlCommand.
                    using (MySqlCommand command = new MySqlCommand("", connection))
                    {
                        // Начало транзакции.
                        using (MySqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // Проверка на выбор услуги.
                                if (comboBox1.SelectedItem == null)
                                {
                                    throw new Exception("Выберите услугу!");
                                }

                                // Получение выбранного элемента.
                                ServiceItem selectedService = (ServiceItem)comboBox1.SelectedItem;
// Получение ID выбранной услуги из объекта ServiceItem.
int IDservices = selectedService.Id;

// Задание текста SQL-запроса для добавления новой записи в таблицу appointments. Используются параметры для предотвращения SQL-инъекций.
command.CommandText = "INSERT INTO appointments (lastName, firstName, appointmentDate, appointmentTime, IDservices) VALUES (@lastName, @firstName, @appointmentDate, @appointmentTime, @IDservices)";
// Добавление параметра @lastName со значением из textBox2.
command.Parameters.AddWithValue("@lastName", textBox2.Text);
// Добавление параметра @firstName со значением из textBox1.
command.Parameters.AddWithValue("@firstName", textBox1.Text);
// Добавление параметра @appointmentDate со значением selectedDate.
command.Parameters.AddWithValue("@appointmentDate", selectedDate);
// Добавление параметра @appointmentTime со значением selectedTime.
command.Parameters.AddWithValue("@appointmentTime", selectedTime);
// Добавление параметра @IDservices со значением IDservices.
command.Parameters.AddWithValue("@IDservices", IDservices); // Используем ID выбранной услуги
// Выполнение SQL-запроса.
command.ExecuteNonQuery();

// Задание текста SQL-запроса для обновления записи в таблице freetime. Используются параметры для предотвращения SQL-инъекций.
command.CommandText = "UPDATE freetime SET isBooked = 1 WHERE id = @id";
// Очистка параметров. Важно для повторного использования command объекта.
command.Parameters.Clear();
// Добавление параметра @id со значением freeTimeId.
command.Parameters.AddWithValue("@id", freeTimeId);
// Выполнение SQL-запроса.
command.ExecuteNonQuery();

// Подтверждение транзакции. Все изменения, внесенные в базу данных в рамках этой транзакции, сохраняются.
transaction.Commit();
// Отображение сообщения об успешном добавлении записи.
MessageBox.Show("Запись успешно добавлена!");
// Закрытие текущей формы.
this.Close();
// Блок catch для обработки исключений, которые могут возникнуть во время выполнения SQL-запросов внутри транзакции.
}
catch (Exception ex)
{
    // Отмена транзакции. Все изменения, внесенные в базу данных в рамках этой транзакции, отменяются.
    transaction.Rollback();
    // Отображение сообщения об ошибке.
    MessageBox.Show("Ошибка при записи: " + ex.Message);
}
// Блок finally для выполнения кода вне зависимости от того, произошла ошибка или нет (в данном случае не используется).
}
// Блок catch для обработки исключений, которые могут возникнуть вне блока try...catch внутри транзакции. Например, ошибка подключения к БД.
}
catch (Exception ex)
{
    // Отображение сообщения об ошибке.
    MessageBox.Show("Ошибка: " + ex.Message);
}
// Обработчик события Click для кнопки button2.
private void button2_Click(object sender, EventArgs e)
{
    // Закрытие текущей формы.
    Close();
}
}
}
