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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
 // Закрыть текущую форму
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
 // Открыть форму для добавления информации о мастере
        private void button2_Click(object sender, EventArgs e)
        {

            Form8 Master1Form = new Form8();
            Master1Form.ShowDialog();
        }
    }
}
