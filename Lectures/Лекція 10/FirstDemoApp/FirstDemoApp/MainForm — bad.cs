using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstDemoApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            switch ((int)nud.Value)
            {
                case 1: labelAnswer.Text = "Неявка"; break;
                case 2: labelAnswer.Text = "Незадовільно"; break;
                case 3: labelAnswer.Text = "Задовільно, можна краще"; break;
                case 4: labelAnswer.Text = "Вже добре"; break;
                case 5: labelAnswer.Text = "Відмінно, але треба постаратися!"; break;
                default: labelAnswer.Text = "???"; break;
            }
        }
    }
}
