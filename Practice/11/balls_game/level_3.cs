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
    public partial class level_3 : Form
    {
        int record_3 = 0;
        public level_3()
        {
            InitializeComponent();
        }
        private void play3_button_Click(object sender, EventArgs e)
        {
            play3_button.Visible = false;

            Random r = new Random();
            int widht_c = r.Next(0, 900);
            int height_c = r.Next(0, 600);

            Button button = new Button();
            button.Left = height_c;
            button.Top = widht_c;
            button.Name = "btn";
            button.Size = new System.Drawing.Size(40, 40);
            button.Click += ButtonOnClick;
            button.BackColor = Color.Yellow;
            button.FlatStyle = FlatStyle.Popup;

            System.Drawing.Drawing2D.GraphicsPath Button_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Button_Path.AddEllipse(0, 0, 40, 40);
            Region Button_Region = new Region(Button_Path);
            button.Region = Button_Region;

            this.Controls.Add(button);
            height_c = r.Next(0, 600);
            widht_c = r.Next(0, 900);

            Timer MyTimer = new Timer();
            MyTimer.Interval = 9000;
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
        }
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
            string level_3_rec;
            var path = @"D:\Навчання\3 семестр\Програмування (C#)\Практичні\11\balls_game\result3.txt";
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string line in lines)
            {
                level_3_rec = line;

                if (Convert.ToInt32(level_3_rec) < record_3)
                {
                    File.WriteAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Практичні\11\balls_game\result3.txt", record_3.ToString());
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
            button_temp.Size = new System.Drawing.Size(40, 40);
            button_temp.Click += ButtonOnClick;
            button_temp.BackColor = Color.Yellow;
            button_temp.FlatStyle = FlatStyle.Popup;

            System.Drawing.Drawing2D.GraphicsPath Button_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Button_Path.AddEllipse(0, 0, 40, 40);
            Region Button_Region = new Region(Button_Path);
            button_temp.Region = Button_Region;

            this.Controls.Add(button_temp);

            if (button != null)
            {
                record_3 += 3;
                result3_label.Text = "Result " + record_3;
                button.Dispose();
                if (record_3 >= 30)
                {
                    MessageBox.Show("Вітаю з переходом на 4 рівень.");
                    this.Close();

                    level_4 newForm = new level_4();
                    newForm.Show();
                }
            }
        }
    }
}
