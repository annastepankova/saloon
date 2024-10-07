using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace парикмахерская
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 MasterForm = new Form6();
            MasterForm.ShowDialog();//мастера
        }
// Удалить неиспользуемые методы
        private void button5_Click(object sender, EventArgs e)
        {
            //Form8 FeedbackForm = new Form8();
            //FeedbackForm.ShowDialog();//отзывы
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form10 ServicesForm = new Form10();
            ServicesForm.ShowDialog();//услуги
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //свободное время и дата (будет форма 11)
            Form11 TimeForm = new Form11();
            TimeForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form12 RecordForm = new Form12();//запись (будет форма 12)
            RecordForm.ShowDialog();
        }
    }
}
