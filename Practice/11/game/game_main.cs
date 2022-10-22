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

namespace game
{
    public partial class game_main : Form
    {
        public game_main()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            var path = @"e:\C# програмування\Lab_11\game\game\record_1.txt";
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string line in lines)
            {
                label1.Text = "Record of 1 level is " + line;
            }
            var path_2 = @"e:\C# програмування\Lab_11\game\game\record_2.txt";
            string[] lines_2 = File.ReadAllLines(path_2, Encoding.UTF8);
            foreach (string line in lines_2)
            {
                label2.Text = "Record of 2 level is " + line;
            }
            var path_3 = @"e:\C# програмування\Lab_11\game\game\record_3.txt";
            string[] lines_3 = File.ReadAllLines(path_3, Encoding.UTF8);
            foreach (string line in lines)
            {
                label3.Text = "Record of 3 level is " + line;
            }



        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "1 level")
            {
                level_1 newForm = new level_1();
                newForm.Show();
            }
            if (comboBox1.Text == "2 level")
            {
                level_2 newForm = new level_2();
                newForm.Show();
            }
            if (comboBox1.Text == "3 level")
            {
                level_3 newForm = new level_3();
                newForm.Show();
            }

            if(checkBox1.Checked == true)
            {
                level_1_arcade newForm = new level_1_arcade();
                newForm.Show();
                
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var path = @"e:\C# програмування\Lab_11\game\game\record_1.txt";
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                label1.Text = "Record of 1 level is " + line;
            }
            var path_2 = @"e:\C# програмування\Lab_11\game\game\record_2.txt";
            string[] lines_2 = File.ReadAllLines(path_2);
            foreach (string line in lines_2)
            {
                label2.Text = "Record of 2 level is " + line;
            }
            var path_3 = @"e:\C# програмування\Lab_11\game\game\record_3.txt";
            string[] lines_3 = File.ReadAllLines(path_3);
            foreach (string line in lines_3)
            {
                label3.Text = "Record of 3 level is " + line;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
