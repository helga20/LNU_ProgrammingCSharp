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

namespace Travel
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\order.txt");
            string[] readed = Regex.Split(readText, ", ");
            label1.Text = "City - " + readed[0];
            label2.Text = "Hotel - " + readed[1];
            label3.Text = "Number of days - " + readed[2];
            label4.Text = "Type of transport - " + readed[3];
            label5.Text = "General price - " + readed[4];
            label6.Text = "Your name - " + readed[5];
            if(readed[6] == "0")
            {
                label7.Text = "Accommodation only";
            }
            else if (readed[6] == "1")
            {
                label7.Text = "Breakfast only";
            }
            else if (readed[6] == "2")
            {
                label7.Text = "Supper only";
            }
            else if (readed[6] == "3")
            {
                label7.Text = "All inclusive";
            }
            else
            {
                label7.Visible = false;
            }
            Random rd = new Random();
            if(readed[3] == "Plane")
            {
                int number = rd.Next(1, 35);
                label8.Text = "Number of pasagers - " + number;
            }
            else if (readed[3] == "Train")
            {
                int number = rd.Next(1, 30);
                label8.Text = "Number of pasagers in your vagon - " + number;
            }
            else if (readed[3] == "Bus")
            {
                int number = rd.Next(1, 44);
                label8.Text = "Number of pasagers in your vagon - " + number;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
