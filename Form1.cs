namespace парикмахерская
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 registrationForm = new Form2();
            registrationForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenAuthorizationForm3(); // Вызов метода для открытия формы
           
        }
 // Удалить ненужные методы
        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 klientForm = new Form3();
            klientForm.ShowDialog();
            
        }
    }
}
