// Подключение для работы с MySQL базой данных.
using MySql.Data.MySqlClient;
// Подключение пространства имен System, содержащее базовые типы данных и функции.
using System;
// Подключение пространства имен System.Data, содержащее классы для работы с данными.
using System.Data;
// Подключение пространства имен System.Windows.Forms, содержащее классы для работы с Windows Forms.
using System.Windows.Forms;

// Объявление пространства имен проекта. Название слишком длинное и неинформативное. Рекомендуется заменить на что-то более короткое и осмысленное, например, `SalonBeauty.Forms`.
namespace курсовая_работа_3_курс__салон_красоты_
{
   
    public partial class Form9 : Form
    {
        
        private string connectionString = "Server=localhost;Database=saloon;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";
        public Form9()
        {
            InitializeComponent();
          
            LoadFreeTime();
        }
     
        private void LoadFreeTime()
        {
          
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                   
                    using (MySqlCommand command = new MySqlCommand("SELECT id, date, time FROM freetime WHERE isBooked = 0", connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            
                            DataTable freeTimeTable = new DataTable();
                       
                            adapter.Fill(freeTimeTable);
                  
                            dataGridView1.DataSource = freeTimeTable;

                         
                            dataGridView1.Columns[0].HeaderText = "ID";
                            dataGridView1.Columns[1].HeaderText = "Дата";
                            dataGridView1.Columns[2].HeaderText = "Время";

                        }
                    }
                }
             
                catch (Exception ex)
                {
                
                    MessageBox.Show("Ошибка при загрузке свободного времени: " + ex.Message);
                }
            }
        }

    
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
      
            if (e.RowIndex >= 0)
            {
             
                int freeTimeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                DateTime selectedDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["date"].Value);
                string selectedTime = dataGridView1.Rows[e.RowIndex].Cells["time"].Value.ToString();
          
                Form10 form10 = new Form10(freeTimeId, selectedDate, selectedTime, connectionString);
        
                form10.ShowDialog(); 
              
                LoadFreeTime(); 
            }
        }

    
        private void button1_Click(object sender, EventArgs e)
        {
           
            Close();
        }
    }
}
