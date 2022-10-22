using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabeledTextboxHost
{
    public partial class HostForm : Form
    {
        public HostForm()
        {
            InitializeComponent();
        }
        private void labeledTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Key pressed in LabeledTextbox", "Event handler");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labeledTextbox2.Position = labeledTextbox2.Position == LabeledTextControl.LabeledTextbox.PositionEnum.Below ?
                LabeledTextControl.LabeledTextbox.PositionEnum.Right : LabeledTextControl.LabeledTextbox.PositionEnum.Below;
        }

        private void labeledTextbox2_PositionChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Position was changed");
        }

        private void labeledTextbox4_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("Leaved");
        }

        private void labeledTextbox3_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Textbox3_TextChanged");
        }
    }
}
