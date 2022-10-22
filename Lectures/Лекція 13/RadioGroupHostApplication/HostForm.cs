using RadioGroupControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioGroupHostApplication
{
    public partial class HostForm : Form
    {
        private RadioGroup rg = null;
        public HostForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.radioGroup1.Click += radioGroup1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioGroup2.Items.AddRange(new string[]{"777","99"});
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioGroup2.Items.Remove("777");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int position = radioGroup2.Items.IndexOf("99");
            radioGroup2.Items[position] = textBox1.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            radioGroup1.Items.Sort();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            radioGroup2.Items.Sort();
        }

        private void radioGroup_IndexChanged(object sender, EventArgs e)
        {
            RadioGroup rb = sender as RadioGroup;
            MessageBox.Show(String.Format("Selected index in {0} is {1}\nName of selected button {2}",
                rb.Text, rb.IndexSelected, rb.Items[rb.IndexSelected]),
                "IndexChanged event handler");
        }

        private void radioGroup1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The first radioGroup is clicked\n on a button "
                + radioGroup1.Items[radioGroup1.IndexSelected],
                "Mouse event of RadioGroup");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            radioGroup1.IndexSelected = 3;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            radioGroup2.Items.Clear();
        }

        private void radioGroup1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("The first radioGroup is double clicked", "Mouse event of RadioGroup");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            rg = new RadioGroup();
            rg.Text = "Color";
            rg.Size = new Size(93, 100);
            rg.Location = new Point(256, 101);
            rg.Items.AddRange(new string[] { "Red", "Green", "Blue" });
            rg.IndexSelected = 1;
            rg.IndexChanged += this.radioGroup_IndexChanged;
            rg.TabIndex = 13;
            this.Controls.Add(rg);
            button9.Enabled = false;
            button8.Visible = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            radioGroup2.ColumnCount = (int)numericUpDown1.Value;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (radioGroup2.Items[radioGroup2.IndexSelected] == "Restore")
            {
                radioGroup2.ResetForeColors();
                return;
            }
            Color c = new Color();
            switch (rg.IndexSelected)
            {
                case 0: c = Color.Red; break;
                case 1: c = Color.Green; break;
                case 2: c = Color.Blue; break;
                default: c = Color.Brown; break;
            }
            if (radioGroup2.Items[radioGroup2.IndexSelected] == "Title")
            {
                radioGroup2.TitleForeColor = c;
            }
            else if (radioGroup2.Items[radioGroup2.IndexSelected] == "Buttons")
            {
                radioGroup2.ButtonsForeColor = c;
            }
            else if (radioGroup2.Items[radioGroup2.IndexSelected] == "Form")
            {
                this.ForeColor = c;
            }
        }
    }
}
