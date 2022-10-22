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
using System.Text.RegularExpressions;

namespace lab_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void AddToList(Array array, ListBox c)
        {
            foreach (var a in array)
            {
                c.Items.Add(a);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            WriteForm newForm = new WriteForm();
            newForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"D:\Навчання\3 семестр\Програмування (C#)\Практичні\12\lab_12\lab_12\words.txt";
            File.AppendAllText(path, textBox1.Text + " ");
            label3.Visible = true;
            string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Практичні\12\lab_12\lab_12\words.txt");
            string[] readed = Regex.Split(readText, " ");
            label3.Text = "Кількість слів для перевірки - " + readed.Length;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Практичні\12\lab_12\lab_12\records.txt");
            string[] readed = Regex.Split(readText, " ");
            AddToList(readed, listBox1);
        }
    }
}
