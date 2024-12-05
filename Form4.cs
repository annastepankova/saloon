// Подключение пространства имен System, содержащего базовые типы данных и функции.
using System;
// Подключение пространства имен System.Collections.Generic, содержащего интерфейсы и классы для работы со списками и коллекциями.
using System.Collections.Generic;
// Подключение пространства имен System.ComponentModel, содержащего классы для работы со свойствами компонентов и данных.
using System.ComponentModel;
// Подключение пространства имен System.Data, содержащего классы для работы с данными.
using System.Data;
// Подключение пространства имен System.Drawing, содержащего классы для работы с графикой.
using System.Drawing;
// Подключение пространства имен System.Linq, содержащего классы для работы с запросами LINQ.
using System.Linq;
// Подключение пространства имен System.Text, содержащего классы для работы со строками.
using System.Text;
// Подключение пространства имен System.Threading.Tasks, содержащего классы для работы с асинхронными операциями.
using System.Threading.Tasks;
// Подключение пространства имен System.Windows.Forms, содержащего классы для работы с Windows Forms.
using System.Windows.Forms;

// Объявление пространства имен проекта. Название слишком длинное и неинформативное.
namespace курсовая_работа_3_курс__салон_красоты_
{
    // Объявление частичного класса Form4, наследуемого от класса Form. Partial указывает на то, что определение класса разделено на несколько файлов (один генерируется дизайнером форм, другой пишется вручную).
    public partial class Form4 : Form
    {
        // Конструктор класса Form4.
        public Form4()
        {
            // Вызов метода InitializeComponent(), автоматически генерируемого дизайнером форм, для инициализации компонентов формы.
            InitializeComponent();
        }

        // Обработчик события Click для кнопки button3.
        private void button3_Click(object sender, EventArgs e)
        {
            // Создание экземпляра формы Form6 (форма, предположительно, отображает информацию о мастерах).
            Form6 MasterForm = new Form6();
            // Отображение формы Form6 в модальном режиме (пользователь не сможет взаимодействовать с формой Form4, пока не закроет Form6).
            MasterForm.ShowDialog();//мастера
        }

        // Обработчик события Click для кнопки button2.
        private void button2_Click(object sender, EventArgs e)
        {
            // Создание экземпляра формы Form9 (форма, предположительно, отображает свободное время и дату).
            Form9 DataForm = new Form9();
            // Отображение формы Form9 в модальном режиме.
            DataForm.ShowDialog(); //свободное время и дата
        }

        // Обработчик события Click для кнопки button1.
        private void button1_Click(object sender, EventArgs e)
        {
            // Создание экземпляра формы Form11 (форма, предположительно, отображает список услуг и их описание).
            Form11 RecordForm = new Form11();
            // Отображение формы Form11 в модальном режиме.
            RecordForm.ShowDialog(); //список услуг и их описание
        }
    }
}
