using System;
// Подключение пространства имен System.Collections.Generic, содержащего интерфейсы и классы для работы со списками и коллекциями.
using System.Collections.Generic;
// Подключение пространства имен System.ComponentModel, содержащего классы для работы со свойствами компонентов и данных.
using System.ComponentModel;
// Подключение пространства имен System.Data, содержащего классы для работы с данными. В данном коде не используется.
using System.Data;
// Подключение пространства имен System.Drawing, содержащего классы для работы с графикой. В данном коде не используется.
using System.Drawing;
// Подключение пространства имен System.Linq, содержащего классы для работы с запросами LINQ. В данном коде не используется.
using System.Linq;
// Подключение пространства имен System.Text, содержащего классы для работы со строками. В данном коде не используется.
using System.Text;
// Подключение пространства имен System.Threading.Tasks, содержащего классы для работы с асинхронными операциями. В данном коде не используется.
using System.Threading.Tasks;
// Подключение пространства имен System.Windows.Forms, содержащего классы для работы с Windows Forms.
using System.Windows.Forms;

// Объявление пространства имен проекта. Название слишком длинное и неинформативное. Рекомендуется изменить на более короткое и осмысленное, например, `SalonBeauty.Forms`.
namespace курсовая_работа_3_курс__салон_красоты_
{
    // Объявление частичного класса Form6, наследуемого от класса Form. `partial` указывает на то, что определение класса разделено на несколько файлов (один генерируется дизайнером форм, другой пишется вручную).
    public partial class Form6 : Form
    {
        // Конструктор класса Form6.
        public Form6()
        {
            // Вызов метода InitializeComponent(), автоматически генерируемого дизайнером форм, для инициализации компонентов формы.
            InitializeComponent();
        }

        // Обработчик события Click для кнопки button1. Закрывает текущую форму.
        private void button1_Click(object sender, EventArgs e)
        {
            // Закрывает текущую форму (Form6).
            Close();
        }

        // Обработчик события Click для кнопки button2.
        private void button2_Click(object sender, EventArgs e)
        {
            // Создает экземпляр формы Form7.
            Form7 MasterForm = new Form7();
            // Отображает форму Form7 в модальном режиме. Это блокирует взаимодействие с Form6, пока Form7 не будет закрыта.
            MasterForm.ShowDialog();
        }
    }
}

