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
    public partial class AgencyForm : Form
    {
        public AgencyForm()
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
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string readdText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\cityes.txt");
            string[] readded = Regex.Split(readdText, ", ");
            AddToCombo(readded, comboBox1);

            if (comboBox1.Text == "London")
            {
                string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\london\london_hotels.txt");
                string[] readed = Regex.Split(readText, ", ");
                AddToCombo(readed, comboBox2);
            }

            if (comboBox1.Text == "Krakow")
            {
                string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\krakow\krakow_hotels.txt");
                string[] readed = Regex.Split(readText, ", ");
                AddToCombo(readed, comboBox2);
            }

            if (comboBox1.Text == "Warsaw")
            {
                string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\warsaw\warsaw_hotels.txt");
                string[] readed = Regex.Split(readText, ", ");
                AddToCombo(readed, comboBox2);
            }
            if (comboBox1.Text == "Lviv")
            {
                string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\lviv\lviv_hotels.txt");
                string[] readed = Regex.Split(readText, ", ");
                AddToCombo(readed, comboBox2);
            }
            //kracow
            if (comboBox2.Text == "Kanonicza 22")
            {
                if(checkBox1.Checked)
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\krakow\kanonicza_22(2).txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }
                else
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\krakow\kanonicza_22.txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }

            }
            if (comboBox2.Text == "H15 Palace Hotel")
            {
                if (checkBox1.Checked)
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\krakow\h15_palace_hotel(2).txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }
                else
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\krakow\h15_palace_hotel.txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }

            }
            if (comboBox2.Text == "The Bonerowski Palace")
            {
                if (checkBox1.Checked)
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\krakow\the_bonerowski_palace(2).txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }
                else
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\krakow\the_bonerowski_palace.txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }

            }

            //london
            if (comboBox2.Text == "Bulgari")
            {
                if (checkBox1.Checked)
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\london\bulgari(2).txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }
                else
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\london\bulgari.txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }

            }
            if (comboBox2.Text == "The Savoy Hotel")
            {
                if (checkBox1.Checked)
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\london\the_savoy_hotel(2).txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }
                else
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\london\the_savoy_hotel.txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }

            }
            if (comboBox2.Text == "The Lanesborough")
            {
                if (checkBox1.Checked)
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\london\the_lanesborough(2).txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }
                else
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\london\the_lanesborough.txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }

            }
            //lviv
            if (comboBox2.Text == "BANKHOTEL")
            {
                if (checkBox1.Checked)
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\lviv\bankhotel(2).txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }
                else
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\lviv\bankhotel.txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }

            }
            if (comboBox2.Text == "Leopolis")
            {
                if (checkBox1.Checked)
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\lviv\leopolis(2).txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }
                else
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\lviv\leopolis.txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }

            }
            if (comboBox2.Text == "Grand Hotel Lviv Casino & Spa")
            {
                if (checkBox1.Checked)
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\lviv\grand_hotel_lviv(2).txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }
                else
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\lviv\grand_hotel_lviv.txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }

            }

            //warsaw

            if (comboBox2.Text == "Raffles Europejski Warsaw")
            {
                if (checkBox1.Checked)
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\warsaw\raffles_europejski_warsaw(2).txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }
                else
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\warsaw\raffles_europejski_warsaw.txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }

            }
            if (comboBox2.Text == "Nobu Hotel Warsaw")
            {
                if (checkBox1.Checked)
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\warsaw\nobu_hotel_warsaw(2).txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }
                else
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\warsaw\nobu_hotel_warsaw.txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }

            }
            if (comboBox2.Text == "Hotel Warszawa in the Prudential Building")
            {
                if (checkBox1.Checked)
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\warsaw\prudential_building(2).txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }
                else
                {
                    string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\warsaw\prudential_building.txt");
                    string[] readed = Regex.Split(readText, ", ");
                    AddToCombo(readed, comboBox3);
                }

            }


        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\transport.txt");
            string[] readed = Regex.Split(readText, ", ");
            AddToCombo(readed, comboBox4);
            if(comboBox4.Text == "Bus")
            {
                int price = 134;
                if(comboBox1.Text == "London")
                {
                    label7.Text = (price * 14).ToString();
                }
                if (comboBox1.Text == "Krakow")
                {
                    label7.Text = (price * 7).ToString();
                }
                if (comboBox1.Text == "Lviv")
                {
                    label7.Text = (price * 4).ToString();
                }
                if (comboBox1.Text == "Warsaw")
                {
                    label7.Text = (price * 9).ToString();
                }
            }
            if (comboBox4.Text == "Train")
            {
                int price = 186;
                if (comboBox1.Text == "London")
                {
                    label7.Text = (price * 14).ToString();
                }
                if (comboBox1.Text == "Krakow")
                {
                    label7.Text = (price * 7).ToString();
                }
                if (comboBox1.Text == "Lviv")
                {
                    label7.Text = (price * 4).ToString();
                }
                if (comboBox1.Text == "Warsaw")
                {
                    label7.Text = (price * 9).ToString();
                }
            }
            if (comboBox4.Text == "Plane")
            {
                int price = 289;
                if (comboBox1.Text == "London")
                {
                    label7.Text = (price * 14).ToString();
                }
                if (comboBox1.Text == "Krakow")
                {
                    label7.Text = (price * 7).ToString();
                }
                if (comboBox1.Text == "Lviv")
                {
                    label7.Text = (price * 4).ToString();
                }
                if (comboBox1.Text == "Warsaw")
                {
                    label7.Text = (price * 9).ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int price = 0;
            price += Convert.ToInt32(label7.Text);
            int hotel = Convert.ToInt32(comboBox3.Text) * Convert.ToInt32(textBox1.Text);
            price += hotel;
            int number_of_days = Convert.ToInt32(textBox1.Text);
            if(radioButton1.Checked)
            {
                price += 125 * number_of_days;
            }
            if (radioButton2.Checked)
            {
                price += 145 * number_of_days;
            }
            if (radioButton3.Checked)
            {
                price += 201 * number_of_days;
            }
            label9.Text =  price.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = @"D:\Навчання\3 семестр\Програмування (C#)\Виробнича практика\Travel\Travel\order.txt";
            File.WriteAllText(path, "");
            if(radioButton1.Checked)
            {
                File.WriteAllText(path, "");
                string order = comboBox1.Text + ", " + comboBox2.Text + ", " + textBox1.Text + ", " + comboBox4.Text + ", " + label9.Text + ", " + textBox2.Text + ", " + "1";
                File.AppendAllText(path, order);
            }
            else if(radioButton2.Checked)
            {
                File.WriteAllText(path, "");
                string order = comboBox1.Text + ", " + comboBox2.Text + ", " + textBox1.Text + ", " + comboBox4.Text + ", " + label9.Text + ", " + textBox2.Text + ", " + "2";
                File.AppendAllText(path, order);
            }
            else if(radioButton3.Checked)
            {
                File.WriteAllText(path, "");
                string order = comboBox1.Text + ", " + comboBox2.Text + ", " + textBox1.Text + ", " + comboBox4.Text + ", " + label9.Text + ", " + textBox2.Text + ", " + "3";
                File.AppendAllText(path, order);
            }
            else
            {
                File.WriteAllText(path, "");
                string order = comboBox1.Text + ", " + comboBox2.Text + ", " + textBox1.Text + ", " + comboBox4.Text + ", " + label9.Text + ", " + textBox2.Text + ", " + "0";
                File.AppendAllText(path, order);
            }
            
            MessageBox.Show("Ви успішно замовили подорож. \nДля перегляду останнього замовлення скористайтесь меню");
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            OrderForm newForm = new OrderForm();
            newForm.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            AgencyForm fr = new AgencyForm();
            fr.Show();
            this.Hide();
        }

    }
}
