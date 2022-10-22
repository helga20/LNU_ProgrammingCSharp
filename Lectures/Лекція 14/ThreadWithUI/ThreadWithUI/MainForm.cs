using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

// Як з породженого потоку оновити вигляд вікна (the User Interface)?

// Спробуйте клацнути кнопку двічі і спостерігайте "гонки"

namespace ThreadWithUI
{
    public partial class MainForm : Form
    {
        // тут буде потік паралельного потоку
        private Thread thread;
        // ці слова потік видаватиме в головне вікно
        private string[] names = { "first", "second", "third", "fourth", "fiveth", "sixth", "seventh", "eighth", "nineth", "tenth" };
        // тип делегата для процедури, що оновлюватиме вікно
        // без цього делегата ніяк!!!
        private delegate void SetTextCallback(string text);

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Changed by Main";
            thread = new Thread(new ThreadStart(DoWork));
            // ThreadStart - тип делегата роботи потоку, можна і без нього:
            //thread = new Thread(DoWork);
            thread.Start();
        }

        // робота в потоку легенька: спати й іноді видавати по одному слову :)
        private void DoWork()
        {
            for (int i = 0; i < names.Length; ++i)
            {
                Thread.Sleep(1000);

                // перевіримо можливість безпосереднього оновлення control'а
                if (this.label1.InvokeRequired)
                {
                    // напис в іншому потоці, тому потрібне асинхронне звертання
                    this.Invoke(
                        new SetTextCallback(ChangeName), // делегат огортає метод оновлення
                        new object[] { names[i] + " (Invoke)" }); // параметр(и) методу оновлення
                }
                else
                {
                    // в тому самому потоці можна просто (в цій програмі не спрацьовує)
                    this.label1.Text = "(No Invoke)";
                }
            }
        }

        private void ChangeName(string name)
        {
            label1.Text = name;
        }

        // застарілий спосіб керування активністю потоку
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) thread.Suspend();
            else thread.Resume();
        }
    }
}
