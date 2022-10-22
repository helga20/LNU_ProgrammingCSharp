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

namespace TeachingChildren
{
    public partial class Writing : Form
    {
        public Writing()
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
        int counter = 0;
        private void Examine_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == textBox1.Text)
            {
                counter++;
                MessageBox.Show("Вітаю! Правильно написаних слів: " + counter);
                textBox1.Text = "";
            }
            else if(textBox2.Text == textBox1.Text)
            {
                counter++;
                MessageBox.Show("Вітаю! Правильно написаних слів: " + counter);
                textBox1.Text = "";
            }
            else
            {
                string path = @"D:\Навчання\3 семестр\Програмування (C#)\Практичні\12\TeachingChildren\results.txt";
                File.AppendAllText(path, counter + " ");
                MessageBox.Show(":( помилка, твій найкращий результат: " + counter + " \n Спробуй ще раз!");
                counter = 0;
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            string path = @"D:\Навчання\3 семестр\Програмування (C#)\Практичні\12\TeachingChildren\results.txt";
            File.AppendAllText(path, counter + " ");
            counter = 0;
            this.Close();
        }
        private void Writing_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("морква");
            comboBox1.Items.Add("огірок");
            comboBox1.Items.Add("гриби");
            comboBox1.Items.Add("ананас");
            comboBox1.Items.Add("картопля");
        }
     
        private void show_Click(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    pictureBox1.ImageLocation = @"D:\Навчання\3 семестр\Програмування (C#)\Практичні\12\TeachingChildren\Images\carrot.png";
                    break;
                case 1:
                    pictureBox1.ImageLocation = @"D:\Навчання\3 семестр\Програмування (C#)\Практичні\12\TeachingChildren\Images\cucumber.png";
                    break;
                case 2:
                    pictureBox1.ImageLocation = @"D:\Навчання\3 семестр\Програмування (C#)\Практичні\12\TeachingChildren\Images\mushroom.png";
                    break;
                case 3:
                    pictureBox1.ImageLocation = @"D:\Навчання\3 семестр\Програмування (C#)\Практичні\12\TeachingChildren\Images\pineapple.png";
                    break;
                case 4:
                    pictureBox1.ImageLocation = @"D:\Навчання\3 семестр\Програмування (C#)\Практичні\12\TeachingChildren\Images\potato.png";
                    break;
            }
        }

        private void addpicturebutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                }
                catch
                {
                    MessageBox.Show("Can't open file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
