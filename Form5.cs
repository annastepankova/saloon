
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySql.Data.MySqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


// Объявление пространства имен проекта. Название слишком длинное и неинформативное. Рекомендуется заменить на более короткое и осмысленное, например, `SalonBeauty.Forms`.
namespace курсовая_работа_3_курс__салон_красоты_
{
    // Объявление частичного класса Form5, наследуемого от класса Form. `partial` указывает, что определение класса разделено на несколько файлов (один генерируется дизайнером форм, другой пишется вручную).
    public partial class Form5 : Form
    {
        // Строка подключения к базе данных. Хранение строки подключения напрямую в коде не рекомендуется - лучше использовать файл конфигурации или переменные окружения.
        private string connectionString = "Server=localhost;Database=saloon;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";
        // Переменная для хранения имени текущей таблицы.
        string currentTableName; // Хранит имя текущей таблицы
        // Переменная для хранения ссылки на текущую вкладку.
        TabPage currentTabPage; // Хранит текущую вкладку
        // Переменная для хранения ссылки на текущий DataGridView.
        DataGridView currentDataGridView; // Хранит ссылку на текущий DataGridView

        // Объект подключения к базе данных. Следует инициализировать в конструкторе и освобождать в Dispose.
        private MySqlConnection connection;

        // Свойство DatabaseConnection (не используется в коде).
        public object DatabaseConnection { get; private set; }
        // Конструктор формы.
        public Form5()
        {
            InitializeComponent();
            // Установка символа для отображения пароля в textBox4.
            textBox4.PasswordChar = '*';


            // Установка соединения с базой данных. Лучше использовать try-catch для обработки ошибок подключения.
            connection = new MySqlConnection(connectionString);
            connection.Open();

            // Вызов метода DisplayDataInTab для отображения данных в каждой вкладке.
            DisplayDataInTab("SELECT * FROM saloon.users;", tabPage1);
            DisplayDataInTab("SELECT * FROM saloon.mastera;", tabPage2);
            DisplayDataInTab("SELECT * FROM saloon.services;", tabPage3);
            DisplayDataInTab("SELECT * FROM saloon.freetime;", tabPage4);
            DisplayDataInTab("SELECT * FROM saloon.appointments;", tabPage5);
        }
        // Метод для отображения данных из базы данных в указанной вкладке.
        private void DisplayDataInTab(string query, TabPage tabPage)
        {
            // Создание DataGridView.
            DataGridView dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BackgroundColor = Color.MistyRose,
                ColumnHeadersDefaultCellStyle = { BackColor = Color.White },
                DefaultCellStyle = { SelectionBackColor = Color.White, BackColor = Color.White }
            };

            // Выполнение запроса к базе данных. Лучше использовать try-catch для обработки ошибок запроса.
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Привязка данных к DataGridView.
            dataGridView.DataSource = dataTable;


            // Добавление DataGridView на вкладку.
            tabPage.Controls.Add(dataGridView);

            // Автонастройка ширины столбцов.
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Сохранение ссылок на текущий DataGridView и вкладку.
            currentDataGridView = dataGridView;
            currentTabPage = tabPage;

            // Извлечение имени таблицы из запроса. Этот метод ненадежный и может сломаться, если запрос изменится.
            string[] parts = query.Split(' ');
            currentTableName = parts[2].Substring(parts[2].IndexOf('.') + 1);
        }

        // Обработчик события Click для кнопки button1 (неполный код).
        private void button1_Click(object sender, EventArgs e)//для таблицы пользователь
            {
            string Familiya = textBox1.Text;
            string Imya = textBox2.Text;
            string Login = textBox3.Text;
            string Parol = textBox4.Text;
            string Kodovoeslovo = textBox5.Text;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO users (Familiya, Imya, Login, Parol, Kodovoeslovo) VALUES (@Familiya, @Imya, @Login, @Parol, @Kodovoeslovo)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Familiya", Familiya);
                        command.Parameters.AddWithValue("@Imya", Imya);
                        command.Parameters.AddWithValue("@Login", Login);
                        command.Parameters.AddWithValue("@Parol", Parol); // Не забудьте зашифровать пароль!
                        command.Parameters.AddWithValue("@Kodovoeslovo", Kodovoeslovo);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Пользователь добавлен!");
                            // Обновляем DataGridView
                            RefreshDataGridView(tabPage1, "users"); // Передаем вкладку и имя таблицы
                            ClearTextBoxes(); // Очищаем TextBox пользователь
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при добавлении пользователя.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }

        }
        // Метод для обновления DataGridView пользователь
        private void RefreshDataGridView(TabPage tabPage, string tableName)
        {
            foreach (Control control in tabPage.Controls)
            {
                if (control is DataGridView dataGridView)
                {
                    dataGridView.DataSource = null; // Очищаем текущий источник данных

                    // Выполняем запрос для обновления данных в DataGridView
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM saloon.{tableName}", connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            

                            dataGridView.DataSource = dataTable;
                        }
                    }
                    break; // Выходим из цикла после обновления
                }
            }
        }
        // Метод для очистки TextBox пользователь
        private void ClearTextBoxes()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)//для мастера кнопка добавить 
        {
            string name = textBox6.Text;// Получение текста из textBox6
            string services = textBox7.Text;// Получение текста из textBox7
            string price = textBox8.Text;// Получение текста из textBox8
            using (MySqlConnection connection = new MySqlConnection(connectionString))// Создание подключения к базе данных с использованием заданной строки подключения
            {
                try
                {
                    connection.Open();// Открытие подключения к базе данных
                    string query = "INSERT INTO mastera (name, services, price) VALUES (@name, @services, @price)";// Определение SQL-запроса для вставки новой записи в таблицу mastera с параметрами
                    using (MySqlCommand command = new MySqlCommand(query, connection))// Создание команды SQL с указанным запросом и открытым подключением
                    {
                        command.Parameters.AddWithValue("@name", name);// Добавление параметра @name с значением переменной name в команду
                        command.Parameters.AddWithValue("@services", services);// Добавление параметра @services с значением переменной services в команду
                        command.Parameters.AddWithValue("@price", price);// Добавление параметра @price с значением переменной price в команду
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)// Проверка, была ли добавлена хотя бы одна запись
                        {
                            MessageBox.Show("Мастер добавлен!");
                            // Обновляем DataGridView
                            RefreshDataGridView1(tabPage2, "mastera"); // Передаем вкладку и имя таблицы
                            ClearTextBoxes1(); // Очищаем TextBox мастера
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при добавлении мастера.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }

        }
        // Метод для обновления DataGridView мастера
        private void RefreshDataGridView1(TabPage tabPage, string tableName)
        {
            foreach (Control control in tabPage.Controls)
            {
                if (control is DataGridView dataGridView)
                {
                    dataGridView.DataSource = null; // Очищаем текущий источник данных

                    // Выполняем запрос для обновления данных в DataGridView
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM saloon.{tableName}", connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            

                            dataGridView.DataSource = dataTable;
                        }
                    }
                    break; // Выходим из цикла после обновления
                }
            }
        }
        // Метод для очистки TextBox мастера
        private void ClearTextBoxes1()
        {
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }


        private void button3_Click(object sender, EventArgs e)//обновить услуги 
        {
            string service_name = textBox9.Text;
            string price = textBox10.Text;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO services (service_name, price) VALUES (@service_name,  @price)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@service_name", service_name);
                        command.Parameters.AddWithValue("@price", price);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Услуга добавлена!");
                            // Обновляем DataGridView
                            RefreshDataGridView2(tabPage3, "services"); // Передаем вкладку и имя таблицы
                            ClearTextBoxes2(); // Очищаем TextBox услуги
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при добавлении услуги.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }

        }
        // Метод для обновления DataGridView мастера
        private void RefreshDataGridView2(TabPage tabPage, string tableName)
        {
            foreach (Control control in tabPage.Controls)
            {
                if (control is DataGridView dataGridView)
                {
                    dataGridView.DataSource = null; // Очищаем текущий источник данных

                    // Выполняем запрос для обновления данных в DataGridView
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM saloon.{tableName}", connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                           
                            dataGridView.DataSource = dataTable;
                        }
                    }
                    break; // Выходим из цикла после обновления
                }
            }
        }
        // Метод для очистки TextBox услуги
        private void ClearTextBoxes2()
        {
            textBox9.Text = "";
            textBox10.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)//добавить для свободное время и дата
        {
            string date = textBox11.Text;
            string time = textBox12.Text;
            string isBooked = textBox13.Text;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO freetime (date, time,isBooked) VALUES (@date,  @time, @isBooked)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@time", time);
                        command.Parameters.AddWithValue("@isBooked", isBooked);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Свободное время добавлено!");
                            // Обновляем DataGridView
                            RefreshDataGridView3(tabPage4, "freetime"); // Передаем вкладку и имя таблицы
                            ClearTextBoxes3(); // Очищаем TextBox свободное время и дата
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при добавлении свободного времени.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
        // Метод для обновления DataGridView время
        private void RefreshDataGridView3(TabPage tabPage, string tableName)
        {
            foreach (Control control in tabPage.Controls)
            {
                if (control is DataGridView dataGridView)
                {
                    dataGridView.DataSource = null; // Очищаем текущий источник данных

                    // Выполняем запрос для обновления данных в DataGridView
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM saloon.{tableName}", connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            

                            dataGridView.DataSource = dataTable;
                        }
                    }
                    break; // Выходим из цикла после обновления
                }
            }
        }
        // Метод для очистки TextBox свободное время и дата
        private void ClearTextBoxes3()
        {
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)//добавить запись клиента
        {
            string lastName = textBox14.Text;
            string firstName = textBox15.Text;
            string appointmentDate = textBox16.Text;
            string appointmentTime = textBox17.Text;
            string IDservices = textBox18.Text;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO appointments (lastName, firstName,appointmentDate,appointmentTime,IDservices) VALUES (@lastName,  @firstName, @appointmentDate,@appointmentTime,@IDservices)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@lastName", lastName);
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@appointmentDate", appointmentDate);
                        command.Parameters.AddWithValue("@appointmentTime", appointmentTime);
                        command.Parameters.AddWithValue("@IDservices", IDservices);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show(" Запись клиента добавлена!");
                            // Обновляем DataGridView
                            RefreshDataGridView4(tabPage5, "appointments"); // Передаем вкладку и имя таблицы
                            ClearTextBoxes4(); // Очищаем TextBox запись клиента
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при добавлении  записи клиента.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
        // Метод для обновления DataGridView запись
        private void RefreshDataGridView4(TabPage tabPage, string tableName)
        {
            foreach (Control control in tabPage.Controls)
            {
                if (control is DataGridView dataGridView)
                {
                    dataGridView.DataSource = null; // Очищаем текущий источник данных

                    // Выполняем запрос для обновления данных в DataGridView
                    using (MySqlCommand cmd = new MySqlCommand($"SELECT * FROM saloon.{tableName}", connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            

                            dataGridView.DataSource = dataTable;
                        }
                    }
                    break; // Выходим из цикла после обновления
                }
            }
        }
        // Метод для очистки TextBox запись клиента
        private void ClearTextBoxes4()
        {
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button11_Click(object sender, EventArgs e)//удалить для пользователей
        {
            if (string.IsNullOrWhiteSpace(textBox19.Text)) // Предполагаем, что в textBox19 вводится ID пользователя
            {
                MessageBox.Show("Введите ID пользователя для удаления!");
                return;
            }

            int userId;
            if (!int.TryParse(textBox19.Text, out userId))
            {
                MessageBox.Show("Неверный формат ID!");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM users WHERE Id = @Id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", userId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Пользователь удален!");
                            RefreshDataGridView(tabPage1, "users");
                            textBox19.Text = ""; // Добавлена строка для очистки TextBox

                        }
                        else
                        {
                            MessageBox.Show("Пользователь не найден.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении пользователя: " + ex.Message);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)//удалить мастера
        {
            if (string.IsNullOrWhiteSpace(textBox20.Text)) // Предполагаем, что в textBox20 вводится ID 
            {
                MessageBox.Show("Введите ID мастера для удаления!");
                return;
            }
            int masteraId;
            if (!int.TryParse(textBox20.Text, out masteraId))
            {
                MessageBox.Show("Неверный формат ID!");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM mastera WHERE Id = @Id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", masteraId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("мастер удален!");
                            RefreshDataGridView(tabPage2, "mastera");
                            textBox20.Text = ""; // Добавлена строка для очистки TextBox

                        }
                        else
                        {
                            MessageBox.Show("мастер не найден.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении мастера: " + ex.Message);
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)//свободное время удалить
        {
            if (string.IsNullOrWhiteSpace(textBox22.Text)) // Предполагаем, что в textBox22вводится ID 
            {
                MessageBox.Show("Введите ID свободного времени для удаления!");
                return;
            }

            int freetimeId;
            if (!int.TryParse(textBox22.Text, out freetimeId))
            {
                MessageBox.Show("Неверный формат ID!");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM freetime WHERE Id = @Id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", freetimeId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Свободное время удалено!");
                            RefreshDataGridView(tabPage4, "freetime");
                            textBox22.Text = ""; // Добавлена строка для очистки TextBox

                        }
                        else
                        {
                            MessageBox.Show("Свободное время не найдено.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении свободного времени: " + ex.Message);
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)//удалить запись
        {
            if (string.IsNullOrWhiteSpace(textBox23.Text)) // Предполагаем, что ID записи вводится в textBox
            {
                MessageBox.Show("Введите ID записи для удаления!");
                return;
            }

            int appointmentId;
            if (!int.TryParse(textBox23.Text, out appointmentId))
            {
                MessageBox.Show("Неверный формат ID!");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM appointments WHERE IDappointments = @Id"; // Используем IDappointments как имя столбца ID
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", appointmentId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Запись удалена!");
                            RefreshDataGridView4(tabPage5, "appointments");
                            textBox23.Text = ""; // Добавлена строка для очистки TextBox

                        }
                        else
                        {
                            MessageBox.Show("Запись не найдена.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)//удалить услуги
        {
            if (string.IsNullOrWhiteSpace(textBox21.Text)) // Предполагаем, что ID записи вводится в textBox
            {
                MessageBox.Show("Введите ID услуги для удаления!");
                return;
            }

            int servicesId;
            if (!int.TryParse(textBox21.Text, out servicesId))
            {
                MessageBox.Show("Неверный формат ID!");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM services WHERE IDservices = @Id"; // Используем  как имя столбца ID
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", servicesId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Услуга удалена!");
                            RefreshDataGridView2(tabPage3, "services");
                            textBox21.Text = ""; // Добавлена строка для очистки TextBox

                        }
                        else
                        {
                            MessageBox.Show("Услуга не найдена.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении услуги: " + ex.Message);
                }
            }
        }
    }
}






