using System;
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
            labelAnswer.Text = ResponseProvider.GetAnswer((int)nud.Value);
        }
    }
}
