using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsSemiApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dlgRes = DialogResult.Ignore;
            switch ((int)numericUpDown1.Value)
            {
                case 1: dlgRes = MessageBox.Show("Карантин продовжено до 11 травня");
                    break;
                case 2: dlgRes = MessageBox.Show("Карантин продовжено до 11 травня", "Важливе повідомлення");
                    break;
                case 3: dlgRes = MessageBox.Show("Карантин продовжено до 11 травня", "Важливе повідомлення",
                    MessageBoxButtons.OKCancel);
                    break;
                case 4: dlgRes = MessageBox.Show("Карантин продовжено до 11 травня", "Важливе повідомлення",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information); break;
                case 5: dlgRes = MessageBox.Show("Карантин продовжено до 11 травня.\nЧи очікували ви на таке?",
                    "Важливе повідомлення", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2); break;
            }
            label1.Text = dlgRes.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new AboutBox()).ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InputForm f2 = new InputForm("Повідомлення", "Заголовок", "Підказка");
            DialogResult dlgRes = f2.ShowDialog();
            label1.Text = dlgRes.ToString();
            if (dlgRes == DialogResult.OK) label1.Text += f2.Result;
            f2.Dispose();
            //f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "MessageBox");
            toolTip1.SetToolTip(button2, "AboutPanel");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Text = openFileDialog1.FileName;
            }
            else
                label1.Text = "No file choozen";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = (sender as ToolStripMenuItem).Text;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "CutCutCut";
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem.PerformClick();
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

    }
}
