
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
       
        string connectionString = "Server=localhost;Database=saloon;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;";
        public Form8()
        {
            InitializeComponent();
      
            dataGridView1 = new DataGridView();
            dataGridView1.Dock = DockStyle.Fill; 
            this.Controls.Add(dataGridView1);
       
            dataGridView1.BackgroundColor = Color.MistyRose;

      
            PopulateTable();
        }
        private void PopulateTable()
        {
        
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open(); 

             
                string query = "SELECT * FROM Mastera";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                   
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                      
                        DataTable dt = new DataTable();
                        dt.Load(reader); 

                  
                        dataGridView1.DataSource = dt;
                
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


                       
                        dataGridView1.Columns[0].HeaderText = "ID";
                        dataGridView1.Columns[1].HeaderText = "ФИО мастера";
                        dataGridView1.Columns[2].HeaderText = "Услуги";
                        dataGridView1.Columns[3].HeaderText = "Стоимость";

                    }

                }
            }
        }

    
        private void button1_Click(object sender, EventArgs e)
        {
        
            Close();
        }
    }
}
