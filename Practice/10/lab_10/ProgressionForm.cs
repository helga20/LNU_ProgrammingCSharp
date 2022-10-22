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

namespace lab_10
{
    public partial class ProgressionForm : Form
    {
        ArithmeticProgression ap1 = new ArithmeticProgression();
        GeometryProgression gp2 = new GeometryProgression();
        ArithmeticProgression ap3 = new ArithmeticProgression();
        ArithmeticProgression ap4 = new ArithmeticProgression();
        GeometryProgression gp5 = new GeometryProgression();

        static int n = 5;
        Progression[] progressions = new Progression[n];

        public ProgressionForm()
        {
            InitializeComponent();
        }

        private void add_progression_Click(object sender, EventArgs e)
        {
            double a, b;
            a = Double.Parse(first_member_textBox.Text);
            b = Double.Parse(d_or_q_textBox.Text);
            info.Text = "Введені дані: \nперший член = " + a + "\nd/q = " + b;

            if (first_member_textBox.Text != "" && d_or_q_textBox.Text != "")
            {
                ap1.setFirst_member = Convert.ToDouble(first_member_textBox.Text);
                ap1.setD_or_q = Convert.ToDouble(d_or_q_textBox.Text);
            }
        }
        private void clean_Click(object sender, EventArgs e)
        {
            first_member_textBox.Text = "";
            d_or_q_textBox.Text = "";
            info.Text = "";
        }
        int counter = 0;
        private void addInFile_Click(object sender, EventArgs e)
        {
            addInFilrLabel.Text = "Заповнення контейнера - " + (counter + 1).ToString();
            string path = @"D:\Навчання\3_курс\Програмування (C#)\Практичні\10\lab_10\ProgressionData.txt";
            string[] createText = { first_member_textBox.Text, d_or_q_textBox.Text };
            File.WriteAllLines(path, createText);
            counter++;
        }
        private void print_Click(object sender, EventArgs e)
        {
            string path = @"D:\Навчання\3_курс\Програмування (C#)\Практичні\10\lab_10\ProgressionData.txt";
            string[] readText = File.ReadAllLines(path);
            string term = "";
            foreach (string s in readText)
            {
                term += s + "\n";
            }
            datas.Text = term;
        }
        private void printFromFile_Click(object sender, EventArgs e)
        {
            string path = @"D:\Навчання\3_курс\Програмування (C#)\Практичні\10\lab_10\ProgressionData.txt";
            string[] readText = File.ReadAllLines(path);

            ap1.setType = readText[0];
            ap1.setFirst_member = Convert.ToDouble(readText[1]);
            ap1.setD_or_q = Convert.ToDouble(readText[2]);

            gp2.setType = readText[3];
            gp2.setFirst_member = Convert.ToDouble(readText[4]);
            gp2.setD_or_q = Convert.ToDouble(readText[5]);

            ap3.setType = readText[6];
            ap3.setFirst_member = Convert.ToDouble(readText[7]);
            ap3.setD_or_q = Convert.ToDouble(readText[8]);

            ap4.setType = readText[9];
            ap4.setFirst_member = Convert.ToDouble(readText[10]);
            ap4.setD_or_q = Convert.ToDouble(readText[11]);

            gp5.setType = readText[12];
            gp5.setFirst_member = Convert.ToDouble(readText[13]);
            gp5.setD_or_q = Convert.ToDouble(readText[14]);

            first_member_textBox.Text = ap1.setFirst_member.ToString();
            d_or_q_textBox.Text = ap1.setD_or_q.ToString();

            first_member_textBox.Text = gp2.setFirst_member.ToString();
            d_or_q_textBox.Text = gp2.setD_or_q.ToString();

            first_member_textBox.Text = ap3.setFirst_member.ToString();
            d_or_q_textBox.Text = ap3.setD_or_q.ToString();

            first_member_textBox.Text = ap4.setFirst_member.ToString();
            d_or_q_textBox.Text = ap4.setD_or_q.ToString();

            first_member_textBox.Text = gp5.setFirst_member.ToString();
            d_or_q_textBox.Text = gp5.setD_or_q.ToString();
        }

        private void max_sum_Click(object sender, EventArgs e)
        {
            if (first_member_textBox.Text != "" && d_or_q_textBox.Text != "")
            {
                if (ap1.Sum_of_prog(5) > gp2.Sum_of_prog(3))
                { max_sum_label.Text = "Найбільша сума в 1 прогресії"; }
                else
                { max_sum_label.Text = "Найбільша сума в 2 прогресії"; }
            }
            if (first_member_textBox.Text != "" && d_or_q_textBox.Text != "")
            {
                if (gp2.Sum_of_prog(3) > ap3.Sum_of_prog(4))
                { max_sum_label.Text = "Найбільша сума в 2 прогресії"; }
                else
                { max_sum_label.Text = "Найбільша сума в 3 прогресії"; }
            }
            if (first_member_textBox.Text != "" && d_or_q_textBox.Text != "")
            {
                if (ap3.Sum_of_prog(4) > ap4.Sum_of_prog(8))
                { max_sum_label.Text = "Найбільша сума в 3 прогресії"; }
                else
                { max_sum_label.Text = "Найбільша сума в 4 прогресії"; }
            }
            if (first_member_textBox.Text != "" && d_or_q_textBox.Text != "")
            {
                if (ap4.Sum_of_prog(8) > gp5.Sum_of_prog(7))
                { max_sum_label.Text = "Найбільша сума в 4 прогресії"; }
                else
                { max_sum_label.Text = "Найбільша сума в 5 прогресії"; }
            }
        }

    }
}