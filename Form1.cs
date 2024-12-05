namespace курсовая_работа_3_курс__салон_красоты_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //переход на форму регистрации
            Form2 registrationForm = new Form2();
            registrationForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //переход на форму админа
            Form3 authorizationForm = new Form3();
            authorizationForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //переъод на форму клиента
            Form3 klientForm = new Form3();
            klientForm.ShowDialog();
        }
    }
}

