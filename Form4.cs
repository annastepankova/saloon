
using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;
using System.Drawing;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Windows.Forms;


namespace курсовая_работа_3_курс__салон_красоты_
{
   
    public partial class Form4 : Form
    {
      
        public Form4()
        {
            
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            Form6 MasterForm = new Form6();
            MasterForm.ShowDialog();//мастера
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 DataForm = new Form9();
        
            DataForm.ShowDialog(); 
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            Form11 RecordForm = new Form11();
            RecordForm.ShowDialog(); 
        }
    }
}
