
using System;// Подключение пространства имен System, содержащее базовые типы данных и функции.
using System.Collections.Generic;// Подключение пространства имен System.Collections.Generic, содержащее интерфейсы и классы для работы со списками и коллекциями.
using System.Data;// Подключение пространства имен System.Data, содержащее классы для работы с данными. В данном коде не используется.
using System.Windows.Forms;// Подключение пространства имен System.Windows.Forms, содержащее классы для работы с Windows Forms.
using MySql.Data.MySqlClient;// Подключение для работы с MySQL базой данных. В данном коде не используется.


namespace курсовая_работа_3_курс__салон_красоты_// Объявление пространства имен проекта. Название слишком длинное и неинформативное. Рекомендуется заменить на более короткое и осмысленное, например, `SalonBeauty.Forms`.
{
   
    public partial class Form11 : Form // Объявление частичного класса Form11, наследуемого от класса Form. `partial` указывает, что определение класса разделено на несколько файлов (один генерируется дизайнером форм, другой пишется вручную).
    {
       
        string connectionString = "Server=localhost;Database=saloon;Uid=root;Pwd=vekzIc-gyxqi1-syjjiw;"; // Строка подключения к базе данных. Хранение строки подключения напрямую в коде не рекомендуется - лучше использовать файл конфигурации или переменные окружения.
      
        private Dictionary<string, string> serviceDescriptions = new Dictionary<string, string>()  // Словарь для хранения описаний услуг. Инициализация в самом классе - хороший подход.
    {
        { "Стрижка", " Стрижка - это не просто удаление лишних волос, а искусство, требующее мастерства и индивидуального подхода. Наши стилисты учитывают форму лица, текстуру волос и личные предпочтения клиента, чтобы создать идеальный образ. Мы предлагаем различные техники стрижки: от классических до современных, включая градуировку, каскад и боб. Каждая стрижка завершается укладкой, чтобы подчеркнуть вашу новую прическу." },
        { "Укладка", "Укладка - это процесс, который превращает обычные волосы в произведение искусства. Мы используем профессиональные средства и техники, чтобы достичь желаемого результата, будь то легкие волны, гладкие локоны или объемная укладка. Наша команда поможет выбрать стиль, который будет гармонировать с вашим образом и подходит для любого мероприятия - от повседневной жизни до торжественных событий." },
        { "Окрашивание", " Окрашивание волос - это отличный способ изменить свой образ и подчеркнуть индивидуальность. Мы предлагаем разнообразные техники окрашивания: от однотонного до сложных техник, таких как балаяж, омбре и мелирование. Используя качественные и безопасные краски, наши специалисты позаботятся о здоровье ваших волос и создадут насыщенный цвет, который будет радовать вас долгое время." },
        { "Наращивание волос", " Наращивание волос - это идеальное решение для тех, кто мечтает о длинных и густых локонах. Мы используем современные технологии наращивания, которые обеспечивают естественный вид и комфорт. Наши специалисты подберут цвет и текстуру волос, чтобы они идеально сочетались с вашими натуральными. Наращивание волос позволит вам экспериментировать с различными прическами и стилями.\r\n" },
        { "Восстановление волос", " Восстановление волос - это комплекс процедур, направленных на восстановление структуры волос после повреждений. Мы используем профессиональные маски и сыворотки, которые питают и увлажняют волосы, возвращая им здоровье и блеск. Эта услуга особенно актуальна для тех, кто подвергает свои волосы частому окрашиванию или укладке с использованием горячих инструментов. " },
        { "Наращивание ресниц", "  Наращивание ресниц - это процедура, которая позволяет добиться эффекта длинных и густых ресниц без использования туши. Мы предлагаем различные варианты наращивания: от натурального до объемного. Наши мастера используют высококачественные материалы, чтобы обеспечить долговечность и безопасность процедуры. Вы будете выглядеть привлекательно и ухоженно каждый день! " },
        { "Ламинирование ресниц", " Ламинирование ресниц  - это процедура, которая укрепляет и придает форму вашим натуральным ресницам. Специальный состав проникает в структуру ресницы, делая их более крепкими и блестящими. Ламинирование позволяет достичь эффекта завивки без использования механических средств и туши, придавая взгляду выразительность и глубину.\r\n " },
        { "Окрашивание бровей", " Окрашивание бровей помогает подчеркнуть форму лица и выразить индивидуальность. Мы используем безопасные краски, которые не только окрашивают, но и ухаживают за волосками. Вы сможете выбрать желаемый оттенок - от натурального до более яркого, чтобы добиться идеального результата. " },
        { "Коррекция бровей", " Коррекция бровей - это важный этап в создании гармоничного образа. Наши специалисты помогут подобрать идеальную форму бровей в соответствии с вашими чертами лица. Мы используем различные техники коррекции: восковая депиляция, щипцы или нить, чтобы добиться аккуратного и естественного результата. " },
        { "Ламинирование бровей", " Ламинирование бровей - это процедура, которая придает бровям ухоженный вид и помогает сохранить их форму на длительное время. Специальный состав укрепляет волоски и делает их более послушными, что позволяет легко укладывать брови в желаемую форму. Это отличное решение для тех, кто хочет иметь аккуратные брови без ежедневных усилий. " },
        { "Вечерний макияж", "Вечерний макияж - это искусство подчеркивать красоту в особых случаях. Наши визажисты создадут уникальный образ с учетом вашего наряда и стиля мероприятия. Мы используем профессиональную косметику, чтобы добиться стойкости и выразительности макияжа, который будет выглядеть великолепно при любом освещении. " },
        { "Свадебный макияж", " Свадебный макияж - это важный элемент образа невесты в самый главный день ее жизни. Мы предлагаем индивидуальный подход к каждой невесте, учитывая ее пожелания и особенности внешности. Наши специалисты помогут создать нежный и романтичный образ или яркий и выразительный - все зависит от ваших предпочтений.\r\n " },
        { "Повседневный макияж", " Повседневный макияж должен быть легким и естественным, подчеркивающим вашу красоту без излишней яркости. Мы поможем вам выбрать подходящие оттенки и текстуры, чтобы вы чувствовали себя комфортно в течение всего дня. Этот макияж подходит для работы, учебы или встреч с друзьями. " },
        { "Наращивание ногтей", "  Наращивание ногтей - это способ создать идеальные ногти любой формы и длины. Мы используем качественные материалы для наращивания, которые обеспечивают долговечность и красивый внешний вид. Наши мастера помогут выбрать дизайн ногтей, который будет отражать ваш стиль и настроение.\r\n " },
        { "Снятие ногтей", "Снятие ногтей - это важный процесс для поддержания здоровья натуральных ногтей после наращивания или покрытия гель-лаком. Мы аккуратно удалим искусственные материалы без повреждения ваших натуральных ногтей, а также предложим уходовые процедуры для их восстановления. " },
        { "Аппаратный маникюр", " Аппаратный маникюр - это современная техника ухода за ногтями, которая позволяет достичь идеальной формы и состояния кутикулы без использования ножниц. Аппаратный маникюр обеспечивает более длительный эффект по сравнению с классическим и подходит для людей с чувствительной кожей. " },
        { "Косметологические процедуры", "Косметологические процедуры направлены на решение различных проблем кожи: акне, пигментация, морщины и др. Наши опытные косметологи подберут эффективные методы лечения с использованием современных технологий и препаратов для достижения видимого результата.\r\n " },
        { "Уход за лицом", "Уход за лицом включает в себя ряд процедур, направленных на поддержание здоровья кожи и предотвращение возрастных изменений. Мы предлагаем очищение, пилинг, маски и массажи с использованием профессиональной косметики, подобранной индивидуально под тип вашей кожи. " }
    };

       
public Form11()
{
    InitializeComponent();
   
    LoadServices(); // Вызов метода для загрузки данных об услугах из базы данных.
}

private void LoadServices()
{
  
    using (MySqlConnection connection = new MySqlConnection(connectionString))// Создание подключения к базе данных с использованием строки подключения
    {
        try
        {
          
            connection.Open();// Открытие подключения к базе данных
            // Создание команды SQL для выборки данных об услугах из таблицы Services.
            using (MySqlCommand command = new MySqlCommand("SELECT IDservices, service_name, price FROM Services", connection))// Создание команды SQL для выборки услуг
            {
                // Использование блока using для автоматического закрытия адаптера данных.
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))// Создание адаптера для заполнения данных из базы данных
                {
                   
                    DataTable dt = new DataTable();// Создание нового объекта DataTable для хранения загруженных данных
                    // Заполнение DataTable данными из базы данных.
                    adapter.Fill(dt);// Заполнение DataTable данными, полученными из базы данных
                    // Установка DataTable в качестве источника данных для DataGridView.
                    dataGridView1.DataSource = dt;// Установка источника данных для элемента управления DataGridView на загруженные данные
                    // Скрытие столбца IDservices в DataGridView.
                    dataGridView1.Columns["IDservices"].Visible = false;// Скрытие столбца IDservices в DataGridView

                    // Установка заголовков столбцов DataGridView.
                    // Важно: Это небезопасно, если структура таблицы изменится. Лучше использовать `dataGridView1.AutoGenerateColumns = true;` и настроить заголовки в дизайнере.
                    dataGridView1.Columns[0].HeaderText = "ID";
                    dataGridView1.Columns[1].HeaderText = "Наименование";
                    dataGridView1.Columns[2].HeaderText = "Стоимость";
                }
            }
        }
   
        catch (Exception ex)
        {
            // Вывод сообщения об ошибке пользователю.
            MessageBox.Show("Ошибка при загрузке услуг: " + ex.Message);// Вывод сообщения об ошибке, если загрузка услуг не удалась
        }
    }
}
// Обработчик события CellClick для DataGridView. Вызывается при клике на ячейку DataGridView.
private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
{
    // Проверка на корректность индекса строки (клик не по заголовку).
    if (e.RowIndex >= 0)// Проверка, что клик был по допустимой строке (не заголовку)
    {
        // Получение имени услуги из выбранной строки.
        string serviceName = dataGridView1.Rows[e.RowIndex].Cells["service_name"].Value.ToString();// Получение имени услуги из выбранной строки
        // Проверка наличия описания для данной услуги в словаре.
        if (serviceDescriptions.ContainsKey(serviceName))// Проверка, существует ли описание для выбранной услуги в словаре serviceDescriptions
        {
            // Установка описания услуги в textBoxDescription.
            textBoxDescription.Text = serviceDescriptions[serviceName];// Установка текста в textBoxDescription на соответствующее описание услуги
        }
        else
        {
            // Установка сообщения об отсутствии описания.
            textBoxDescription.Text = "Описание отсутствует для этой услуги.";// Установка текста в textBoxDescription на сообщение об отсутствии описания
        }
    }
}
// Обработчик события Click для кнопки button1.
private void button1_Click(object sender, EventArgs e)
{
    // Закрытие формы.
    Close();
}
}
} 
