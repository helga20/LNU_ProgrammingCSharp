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
    public partial class level_2 : Form
    {
        int record_2 = 0;
        public level_2()
        {
            InitializeComponent();
        }

        private void play2_button_Click(object sender, EventArgs e)
        {
            play2_button.Visible = false;

            Random r = new Random();
            int widht_c = r.Next(0, 900);
            int height_c = r.Next(0, 600);

            Button button = new Button();
            button.Left = height_c;
            button.Top = widht_c;
            button.Name = "btn";
            button.Size = new System.Drawing.Size(45, 45);
            button.Click += ButtonOnClick;
            button.BackColor = Color.Yellow;
            button.FlatStyle = FlatStyle.Popup;

            System.Drawing.Drawing2D.GraphicsPath Button_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Button_Path.AddEllipse(0, 0, 45, 45);
            Region Button_Region = new Region(Button_Path);
            button.Region = Button_Region;

            this.Controls.Add(button);
            height_c = r.Next(0, 600);
            widht_c = r.Next(0, 900);

            Timer MyTimer = new Timer();
            MyTimer.Interval = 11000;
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
            string level_2_rec;
            var path = @"D:\Навчання\3 семестр\Програмування (C#)\Практичні\11\balls_game\result2.txt";
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string line in lines)
            {
                level_2_rec = line;

                if (Convert.ToInt32(level_2_rec) < record_2)
                {
                    File.WriteAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Практичні\11\balls_game\result2.txt", record_2.ToString());
                }
            }
        }
        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            Random r = new Random();
            int widht_c = r.Next(0, 900);
            int height_c = r.Next(0, 600);

            Button button_temp = new Button();
            button_temp.Left = widht_c;
            button_temp.Top = height_c;
            button_temp.Name = "btn";
            button_temp.Size = new System.Drawing.Size(45, 45);
            button_temp.Click += ButtonOnClick;
            button_temp.BackColor = Color.Yellow;
            button_temp.FlatStyle = FlatStyle.Popup;

            System.Drawing.Drawing2D.GraphicsPath Button_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Button_Path.AddEllipse(0, 0, 45, 45);
            Region Button_Region = new Region(Button_Path);
            button_temp.Region = Button_Region;

            this.Controls.Add(button_temp);

            if (button != null)
            {
                record_2 += 2;
                result2_label.Text = "Result " + record_2;
                button.Dispose();
                if (record_2 >= 20)
                {
                    MessageBox.Show("Вітаю з переходом на 3 рівень.");
                    this.Close();

                    level_3 newForm = new level_3();
                    newForm.Show();
                }
            }
        }
    }
}


