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
    public partial class level_1 : Form
    {
        int record_1 = 0;
        public level_1()
        {
            InitializeComponent();
        }
        private void play1_button_Click(object sender, EventArgs e)
        {
            play1_button.Visible = false;

            Random r = new Random();
            int widht_c = r.Next(0, 900);
            int height_c = r.Next(0, 600);

            Button button = new Button();
            button.Left = height_c;
            button.Top = widht_c;
            button.Name = "btn";
            button.Size = new System.Drawing.Size(50, 50);
            button.Click += ButtonOnClick;
            button.BackColor = Color.Yellow;
            button.FlatStyle = FlatStyle.Popup;

            System.Drawing.Drawing2D.GraphicsPath Button_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Button_Path.AddEllipse(0, 0, 50, 50);
            Region Button_Region = new Region(Button_Path);
            button.Region = Button_Region;

            this.Controls.Add(button);
            height_c = r.Next(0, 600);
            widht_c = r.Next(0, 900);

            Timer MyTimer = new Timer();
            MyTimer.Interval = 13000;
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
        }
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
            string level_1_rec;
            var path = @"D:\Навчання\3 семестр\Програмування (C#)\Практичні\11\balls_game\result1.txt";
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string line in lines)
            {
                level_1_rec = line;

                if (Convert.ToInt32(level_1_rec) < record_1)
                {
                    File.WriteAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Практичні\11\balls_game\result1.txt", record_1.ToString());
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
            button_temp.Size = new System.Drawing.Size(50, 50);
            button_temp.Click += ButtonOnClick;
            button_temp.BackColor = Color.Yellow;
            button_temp.FlatStyle = FlatStyle.Popup;

            System.Drawing.Drawing2D.GraphicsPath Button_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Button_Path.AddEllipse(0, 0, 50, 50);
            Region Button_Region = new Region(Button_Path);
            button_temp.Region = Button_Region;

            this.Controls.Add(button_temp);

            if (button != null)
            {
                record_1 += 1;
                result1_label.Text = "Result " + record_1;
                button.Dispose();
                if (record_1 >= 10)
                {
                    MessageBox.Show("Вітаю з переходом на 2 рівень.");
                    this.Close();

                    level_2 newForm = new level_2();
                    newForm.Show();
                }
            }
        }
       
    }
}

