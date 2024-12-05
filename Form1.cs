namespace курсовая_работа_3_курс__салон_красоты_//Название пространства имен слишком длинное и неудобное. Использование подчеркиваний (`_`) также не рекомендуется в соответствии с рекомендациями по написанию кода C#.
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

        private void button3_Click(object sender, EventArgs e)//В методе `button3_Click` используется та же форма, что и для администратора (`Form3`). Это неправильно, если функционал для клиента отличается.
        {
            //переъод на форму клиента
            Form3 klientForm = new Form3();
            klientForm.ShowDialog();//ShowDialog()` блокирует основную форму до тех пор, пока модальная форма не будет закрыта. Это может быть неудобно для пользователя.
        }
    }
}

