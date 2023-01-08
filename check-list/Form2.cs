using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace check_list
{
    public partial class glavnaya : Form
    {
        public glavnaya()
        {
            InitializeComponent();
        }

        private void glavnaya_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Tag = this; // сохраняем ссылку в form2.Tag
            this.Hide();
            form1.Show();

        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Делоникс, это мультитул для тестировщика, где есть все для работы: \n\n-Чек-листы, \n-Тест-кейсы \n-Баг-репорты \n-Документация \n-Калькулятор. \n\nОфициальный сайт  https://hackqa.site", "О программе");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
                      
            form3.Show();
        }
    }
}
