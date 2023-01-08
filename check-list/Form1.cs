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
using System.Reflection.Emit;
using Excel = Microsoft.Office.Interop.Excel;

namespace check_list
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label3.MaximumSize = new Size(350, 0);
            label3.AutoSize = true;
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
            Excel.Application exApp = new Excel.Application();
            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;
            int i, j;
            for (i = 0;i <= dataGridView1.RowCount-2; i++)
            {
                for(j = 0;j<=dataGridView1.ColumnCount-1;j++)
                {
                    wsh.Cells[i+1, j+1]= dataGridView1[j,i].Value.ToString();
                }
            }

            exApp.Visible = true;
        }

        private void btnDow_Click(object sender, EventArgs e)
        {
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=check.mdb";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            string query = "SELECT * FROM list";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();
            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Данные не найдены!", "Ошибка!");
            }
            else
            {
                while (dbReader.Read())
                {
                    dataGridView1.Rows.Add(dbReader["id"], dbReader["proverka"], dbReader["exres"], dbReader["prioritet"]);
                }
            }
            dbReader.Close();
            dbConnection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
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
            string proverka = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string exres = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string prioritet = dataGridView1.Rows[index].Cells[3].Value.ToString();

            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=check.mdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            string query = "INSERT INTO list VALUES (" + id + ",'" + proverka + "','" + exres + "', '" + prioritet + "')";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
                MessageBox.Show("Данные добавлены!", "Внимание!");
            dbConnection.Close();
        }

        private void btnUpt_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
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
            string proverka = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string exres = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string prioritet = dataGridView1.Rows[index].Cells[3].Value.ToString();

            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=check.mdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            string query = "UPDATE list SET proverka = '" + proverka + "', exres = '" + exres + "', prioritet ='" + prioritet + "' WHERE id = " + id;
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
            {
                MessageBox.Show("Данные изменены!", "Внимание!");
            }
            dbConnection.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку", "Внимание!");
                return;
            }
            int index = dataGridView1.SelectedRows[0].Index;
            if (dataGridView1.Rows[index].Cells[0].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();


            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=check.mdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            string query = "DELETE FROM list WHERE id = " + id;
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
            {
                MessageBox.Show("Данные удалены", "Внимание!");
                dataGridView1.Rows.RemoveAt(index);
            }
            dbConnection.Close();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            glavnaya glav = new glavnaya();
            glav.Show();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
    }

        private void dataGridiew1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count >= 0)
                {
                    label1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    label2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    label3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    label4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!", "Ошибка");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;
            exApp.Columns.ColumnWidth = 15;

            exApp.Cells[1, 1] = "ID";
            exApp.Cells[1, 2] = "Проверка";
            exApp.Cells[1, 3] = "Ожидаемый результат";
            exApp.Cells[1, 4] = "Приоритет";
            


            int i, j;
            for (i = 0; i <= dataGridView1.RowCount - 2; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    wsh.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
                }
            }

            exApp.Visible = true;
        }
    }
}
