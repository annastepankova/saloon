using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient; // Добавлен using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace парикмахерская
{

    public partial class Form12 : Form
    {
        private string connectionString = "Server=localhost;Database=hair1;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";


        public Form12()
        {
            InitializeComponent();
            LoadServices();
            LoadMaster();

        }

        private void LoadServices()
        {
            // Пример: Загрузите услуги из таблицы `services` в базе данных
            using (MySqlConnection connection = new MySqlConnection(connectionString)) // MySqlConnection больше не подчеркивается
            {
                try
                {
                    connection.Open();
                    string query = "SELECT name FROM hair1.services;"; // Предполагается, что у вас есть таблица services
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBoxServices.Items.Add(reader["name"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }
        

        private void LoadMaster()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT name FROM hair1.master;"; // Предполагается, что у вас есть таблица services
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                      
                        ComboBoxMaster.Items.Add(reader["name"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string fio = textBoxFio.Text;
            string date = textBoxDate.Text;
            string time = textBoxTime.Text;
            string service = comboBoxServices.SelectedItem?.ToString(); // Получаем выбранное значение
            string master = ComboBoxMaster.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(service))
            {
                MessageBox.Show("Пожалуйста, выберите услугу.");
                return;
            }


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO appointments (fio, date, time, service) VALUES (@fio, @date, @time, @service)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@fio", fio);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@time", time);
                    command.Parameters.AddWithValue("@service", service);
                    command.Parameters.AddWithValue("@master", master);

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Запись успешно сохранена!");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при сохранении записи.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }


        }
// Удалить неиспользуемые методы
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
    

    

