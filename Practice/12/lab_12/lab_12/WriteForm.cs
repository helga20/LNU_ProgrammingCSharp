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
    public partial class WriteForm : Form
    {
        public WriteForm()
        {
            InitializeComponent();
        }

        public void AddToCombo(Array array, ComboBox c)
        {
            foreach (var a in array)
            {
                c.Items.Add(a);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Практичні\12\lab_12\lab_12\words.txt"); 
            string[] readed = Regex.Split(readText, " ");
            AddToCombo(readed, comboBox1);
            

            
        }
        int counter = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == textBox1.Text)
            {
                counter++;
                MessageBox.Show("Вітаю у Вас - " + counter + " правильних відповідей.");
                textBox1.Text = "";
            }
            else
            {
                string path = @"D:\Навчання\3 семестр\Програмування (C#)\Практичні\12\lab_12\lab_12\records.txt";
                File.AppendAllText(path, counter + " ");
                MessageBox.Show("Нажаль Ви відповіли неправильно, Ваш рекорд - " + counter + " \n Спробуйте ще раз.");
                counter = 0;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string path = @"D:\Навчання\3 семестр\Програмування (C#)\Практичні\12\lab_12\lab_12\records.txt";
            File.AppendAllText(path, counter + " ");
            counter = 0;
            this.Close();
        }
    }
}
