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

namespace TeachingChildren
{
    public partial class TeachingForm : Form
    {
        public TeachingForm()
        {
            InitializeComponent();
        }
        public void AddToResult(Array array, ListBox c)
        {
            foreach (var a in array)
            {
                c.Items.Add(a);
            }
        }
        private void Results_Click(object sender, EventArgs e)
        {
            string readText = File.ReadAllText(@"D:\Навчання\3 семестр\Програмування (C#)\Практичні\12\TeachingChildren\results.txt");
            string[] readed = Regex.Split(readText, " ");
            AddToResult(readed, resultListBox);
        }
        private void Start_Click(object sender, EventArgs e)
        {
            Writing newForm = new Writing();
            newForm.Show();
        }
    }
}
