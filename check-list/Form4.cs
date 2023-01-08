using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace check_list
{
    public partial class Form4 : Form
    {
        public string filename;
        public bool isFileChanged;


        public Form4()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            filename = "";
            isFileChanged = false;
            UpdateTextWithTitle();
        }
        public void CreateNewDocument(object sender, EventArgs e)
        {
            NoteTextBox.Text = "";
            filename = "";
            UpdateTextWithTitle();
        }
        public void OpenFile(object sender, EventArgs e)

        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    NoteTextBox.Text = sr.ReadToEnd();
                    sr.Close();
                    filename = openFileDialog1.FileName;
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть файл!", "Внимение!");
                }
            }
        }
        public void SaveFile(string _filename)
        {
            if (_filename == "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    _filename = saveFileDialog1.FileName;
                }
                try
                {
                    StreamWriter sw = new StreamWriter(_filename);
                    sw.Write(NoteTextBox.Text);
                    filename = _filename;
                    isFileChanged = false;
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить файл!");
                }
                UpdateTextWithTitle();
            }
        }

            public void Save(object sender, EventArgs e)
            {
                SaveFile(filename);
            }
            public void SaveAs(object sender, EventArgs e)
            {
                SaveFile("");
            }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)

            {
                glavnaya glav = new glavnaya();
                glav.Show();
            }

            private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
            {

            }

        private void OnTextChanged(object sender, EventArgs e)
        {
            if (!isFileChanged) 
            {
                this.Text = this.Text.Replace('*', ' ');
            isFileChanged= true;
            this.Text= "*"+ this.Text;
            }
        }
        public void UpdateTextWithTitle()
        {
            if(filename!="")
            this.Text = filename + "-Блокнот";
            else this.Text =  "Безымянный-Блокнот";
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
