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

namespace balls_game
{
    public partial class balls_game_main : Form
    {
        public balls_game_main()
        {
            InitializeComponent();
        }
        private void balls_game_main_Load(object sender, EventArgs e)
        {
            var path1 = @"D:\Навчання\1 - 4 семестр\Програмування (C#)\Практичні\11\balls_game\result1.txt";
            string[] lines = File.ReadAllLines(path1, Encoding.UTF8);
            foreach (string line in lines)
            {
                level1.Text = "Найкращий результат 1 рівня: " + line;
            }

        var path2 = @"D:\Навчання\1 - 4 семестр\Програмування (C#)\Практичні\11\balls_game\result2.txt";
            string[] lines_2 = File.ReadAllLines(path2, Encoding.UTF8);
            foreach (string line in lines_2)
            {
                level2.Text = "Найкращий результат 2 рівня: " + line;
            }

            var path3 = @"D:\Навчання\1 - 4 семестр\Програмування (C#)\Практичні\11\balls_game\result3.txt";
            string[] lines_3 = File.ReadAllLines(path3, Encoding.UTF8);
            foreach (string line in lines_3)
            {
                level3.Text = "Найкращий результат 3 рівня: " + line;
            }

            var path4 = @"D:\Навчання\1 - 4 семестр\Програмування (C#)\Практичні\11\balls_game\result4.txt";
            string[] lines_4 = File.ReadAllLines(path4, Encoding.UTF8);
            foreach (string line in lines_4)
            {
                level4.Text = "Найкращий результат 4 рівня: " + line;
            }

            var path5 = @"D:\Навчання\1 - 4 семестр\Програмування (C#)\Практичні\11\balls_game\result5.txt";
            string[] lines_5 = File.ReadAllLines(path5, Encoding.UTF8);
            foreach (string line in lines_5)
            {
                level5.Text = "Найкращий результат 5 рівня: " + line;
            }
        }

        private void play_button_Click(object sender, EventArgs e)
        {
            if (levels_comboBox.Text == "1 рівень")
            {
                level_1 newForm = new level_1();
                newForm.Show();
            }
            if (levels_comboBox.Text == "2 рівень")
            {
                level_2 newForm = new level_2();
                newForm.Show();
            }
            if (levels_comboBox.Text == "3 рівень")
            {
                level_3 newForm = new level_3();
                newForm.Show();
            }
            if (levels_comboBox.Text == "4 рівень")
            {
                level_4 newForm = new level_4();
                newForm.Show();
            }
            if (levels_comboBox.Text == "5 рівень")
            {
                level_5 newForm = new level_5();
                newForm.Show();
            }
        }

        private void update_button_Click(object sender, EventArgs e)
        { 
            var path1 = @"D:\Навчання\1 - 4 семестр\Програмування (C#)\Практичні\11\balls_game\result1.txt";
            string[] lines = File.ReadAllLines(path1);
            foreach (string line in lines)
            {
                level1.Text = "Найкращий результат 1 рівня: " + line;
            }

            var path2 = @"D:\Навчання\1 - 4 семестр\Програмування (C#)\Практичні\11\balls_game\result2.txt";
            string[] lines2 = File.ReadAllLines(path2);
            foreach (string line in lines2)
            {
                level2.Text = "Найкращий результат 2 рівня: " + line;
            }

            var path3 = @"D:\Навчання\1 - 4 семестр\Програмування (C#)\Практичні\11\balls_game\result3.txt";
            string[] lines3 = File.ReadAllLines(path3);
            foreach (string line in lines3)
            {
                level3.Text = "Найкращий результат 3 рівня: " + line;
            }

            var path4 = @"D:\Навчання\1 - 4 семестр\Програмування (C#)\Практичні\11\balls_game\result4.txt";
            string[] lines4 = File.ReadAllLines(path4);
            foreach (string line in lines4)
            {
                level4.Text = "Найкращий результат 4 рівня: " + line;
            }

            var path5 = @"D:\Навчання\1 - 4 семестр\Програмування (C#)\Практичні\11\balls_game\result5.txt";
            string[] lines5 = File.ReadAllLines(path5);
            foreach (string line in lines5)
            {
                level5.Text = "Найкращий результат 5 рівня: " + line;
            }
        }

    }
}
