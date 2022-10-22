using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabeledTextboxHostProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LabelTextButton_Click(object sender, EventArgs e)
        {
            labeledTextbox1.LabelText = "Hello:)";
        }

        private void labeledTextbox1_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Text changed raised!", "Information");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                labeledTextbox1.Position = LebeledTextboxControl.LabeledTextbox.PositionEnum.Below;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                labeledTextbox1.Position = LebeledTextboxControl.LabeledTextbox.PositionEnum.Right;
            }
        }

        private void labeledTextbox1_PositionChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Position changed!");
        }
    }
}
