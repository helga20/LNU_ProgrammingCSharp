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
    public partial class level_2 : Form
    {
        int record_2 = 0;

        public level_2()
        {
            InitializeComponent();
        }

        private void game_Activated(object sender, EventArgs e)
        {
            //private void graphics_Click(object sender, EventArgs e)
            //{
            //    Random rd = new Random();
            //    float widht_c = rd.Next(0, this.Width);
            //    float height_c = rd.Next(0, this.Height);
            //    int w = 20;
            //    int h = w;
            //    Graphics graphics = CreateGraphics();
            //    graphics.Clear(BackColor);
            //    graphics.FillEllipse(Brushes.DarkOrange, widht_c, height_c, w, h);
            //    graphics.Dispose();
            //}
        }



        private void MyTimer_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("Час вичерпаний. \n Ваш рекорд - " + record_2);
            this.Close();
            string level_2_rec;
            var path = @"e:\C# програмування\Lab_11\game\game\record_2.txt";
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string line in lines)
            {
                level_2_rec = line;

                if (Convert.ToInt32(level_2_rec) < record_2)
                {
                    File.WriteAllText(@"e:\C# програмування\Lab_11\game\game\record_2.txt", record_2.ToString());
                }

            }
        }

        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            Random rd = new Random();
            int widht_c = rd.Next(0, 900);
            int height_c = rd.Next(0, 600);

            Button button_temp = new Button();
            button_temp.Left = widht_c;
            button_temp.Top = height_c;
            button_temp.Name = "btn";
            button_temp.Size = new System.Drawing.Size(29, 29);
            button_temp.Click += ButtonOnClick;
            button_temp.BackColor = Color.Olive;
            button_temp.FlatStyle = FlatStyle.Popup;

            System.Drawing.Drawing2D.GraphicsPath Button_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Button_Path.AddEllipse(0, 0, 29, 29);
            Region Button_Region = new Region(Button_Path);
            button_temp.Region = Button_Region;

            this.Controls.Add(button_temp);

            if (button != null)
            {
                record_2 += 10;
                label1.Text = "Point - " + record_2;
                button.Dispose();
                if (record_2 >= 190)
                {
                    MessageBox.Show("Вітаю. \n Ви перейшли на 3 рівень.");
                    this.Close();
                    level_3 newForm = new level_3();
                    newForm.Show();
                }
            }
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Visible = false;

            Random rd = new Random();
            int widht_c = rd.Next(0, 900);
            int height_c = rd.Next(0, 600);

            Button button = new Button();
            button.Left = height_c;
            button.Top = widht_c;
            button.Name = "btn";
            button.Size = new System.Drawing.Size(29, 29);
            button.Click += ButtonOnClick;
            button.BackColor = Color.Olive;
            button.FlatStyle = FlatStyle.Popup;

            System.Drawing.Drawing2D.GraphicsPath Button_Path = new System.Drawing.Drawing2D.GraphicsPath();
            Button_Path.AddEllipse(0, 0, 29, 29);
            Region Button_Region = new Region(Button_Path);
            button.Region = Button_Region;

            this.Controls.Add(button);
            height_c = rd.Next(0, 600);
            widht_c = rd.Next(0, 900);

            Timer MyTimer = new Timer();
            MyTimer.Interval = (15 * 1000); // 10 sec
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();

            //for (int i = 0; i < n; ++i)
            //{
            //    Random rd = new Random();
            //    int widht_c = rd.Next(0, this.Width);
            //    int height_c = rd.Next(0, this.Height);

            //    Button button = new Button();
            //    button.Left = widht_c;
            //    button.Top = height_c;
            //    button.Name = "btn" + i;
            //    button.Click += ButtonOnClick;

            //    this.Controls.Add(button);
            //    height_c += button.Height + 2;



            //}
        }
    }
}
