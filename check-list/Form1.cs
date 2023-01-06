using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace check_list
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void обПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Чек-лист для работы с Делоникс", "О программе");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnDow_Click(object sender, EventArgs e)
        {
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=check.mdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            string query = "SELECT * FROM list";
            OleDbCommand dbCommand =new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();
            if(dbReader.HasRows == false)
            {
                MessageBox.Show("Данные не найдены!", "Ошибка!");
            }
            else
            {
               while(dbReader.Read())
                {
                    dataGridView1.Rows.Add(dbReader["id"], dbReader["proverka"], dbReader["exres"], dbReader["prioritet"]);
                }
            }
            dbReader.Close();
            dbConnection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count !=1)
            {
                MessageBox.Show("Выберите одну строку", "Внимание!");
                return;
            }
            int index = dataGridView1.SelectedRows[0].Index;
            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string proverka = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string exres = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string prioritet = dataGridView1.Rows[index].Cells[0].Value.ToString();
           
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=check.mdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            string query = "INSERT INTO list VALUES ("+ id +",'"+ proverka +"','"+ exres +"', '"+ prioritet +"')";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            if(dbCommand.ExecuteNonQuery()!=1)
        }

        private void btnUpt_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
