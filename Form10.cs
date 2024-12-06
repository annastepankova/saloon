
using MySql.Data.MySqlClient;// Подключение для работы с MySQL базой данных.
using System;// Подключение пространства имен System, содержащее базовые типы данных и функции.
using System.Data;// Подключение пространства имен System.Data, содержащее классы для работы с данными.
using System.Windows.Forms;// Подключение пространства имен System.Windows.Forms, содержащее классы для работы с Windows Forms.


namespace курсовая_работа_3_курс__салон_красоты_
{

    public partial class Form10 : Form    // Объявление частичного класса Form10, наследуемого от класса Form. `partial` указывает, что определение класса разделено на несколько файлов (один генерируется дизайнером форм, другой пишется вручную).
    {
       
        private int freeTimeId;
        private DateTime selectedDate;
        private string selectedTime;
        private string connectionString;
      
        public Form10(int freeTimeId, DateTime selectedDate, string selectedTime, string connectionString)
        {
            InitializeComponent();
          
            this.freeTimeId = freeTimeId;
            this.selectedDate = selectedDate;
            this.selectedTime = selectedTime;
            this.connectionString = connectionString;
         
            dateTimePicker1.Value = selectedDate;
          
            textBox3.Text = selectedTime;
         
            LoadServices();
        }


        public class ServiceItem
        {
            
            public int Id { get; set; }
       
            public string Name { get; set; }
           
            public decimal Price { get; set; }
           
            public override string ToString()
            {
                return $"{Name} ({Price:C})"; 
            }
        }
    
        private void LoadServices()
        {
           
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                 
                    connection.Open();
                
                    using (MySqlCommand command = new MySqlCommand("SELECT IDservices, service_name, price FROM Services", connection))
                    {
                       
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                         
                            comboBox1.Items.Clear();
                       
                            while (reader.Read())
                            {
                                try
                                {
                                   
                                    int id = reader.GetInt32("IDservices");
                                    string serviceName = reader.GetString("service_name");
                                    decimal price = reader.GetDecimal("price");
                                  
                                    comboBox1.Items.Add(new ServiceItem { Id = id, Name = serviceName, Price = price });
                                }
                           
                                catch (Exception innerEx)
                                {
                                    MessageBox.Show("Ошибка при чтении данных: " + innerEx.Message);
                                    break; // Прекращаем цикл, если произошла ошибка
                                }
                            }
                        }
                    }
                }
               
                catch (MySqlException ex)
                {
                    MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show("Неизвестная ошибка: " + ex.Message);
                }
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                   
                    connection.Open();
                 
                    using (MySqlCommand command = new MySqlCommand("", connection))
                    {
                       
                        using (MySqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                
                                if (comboBox1.SelectedItem == null)
                                {
                                    throw new Exception("Выберите услугу!");
                                }

                               
                                ServiceItem selectedService = (ServiceItem)comboBox1.SelectedItem;

int IDservices = selectedService.Id;


command.CommandText = "INSERT INTO appointments (lastName, firstName, appointmentDate, appointmentTime, IDservices) VALUES (@lastName, @firstName, @appointmentDate, @appointmentTime, @IDservices)";

command.Parameters.AddWithValue("@lastName", textBox2.Text);

command.Parameters.AddWithValue("@firstName", textBox1.Text);

command.Parameters.AddWithValue("@appointmentDate", selectedDate);

command.Parameters.AddWithValue("@appointmentTime", selectedTime);

command.Parameters.AddWithValue("@IDservices", IDservices); 
command.ExecuteNonQuery();


command.CommandText = "UPDATE freetime SET isBooked = 1 WHERE id = @id";

command.Parameters.Clear();

command.Parameters.AddWithValue("@id", freeTimeId);

command.ExecuteNonQuery();


transaction.Commit();

MessageBox.Show("Запись успешно добавлена!");

this.Close();

}
catch (Exception ex)
{
    
    transaction.Rollback();
  
    MessageBox.Show("Ошибка при записи: " + ex.Message);
}

}

}
catch (Exception ex)
{
    MessageBox.Show("Ошибка: " + ex.Message);
}

private void button2_Click(object sender, EventArgs e)
{
   
    Close();
}
}
}
