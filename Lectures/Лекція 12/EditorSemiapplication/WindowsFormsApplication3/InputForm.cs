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
    public partial class InputForm : Form
    {
        public string Result { get; private set; }
        public InputForm()
        {
            InitializeComponent();
            Result = "";
        }
        public InputForm(string mess, string title, string deflt)
        {
            InitializeComponent();
            this.Text = title;
            this.label1.Text = mess;
            this.textBox1.Text = deflt;
            Result = deflt;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Result = textBox1.Text;
            Close();
        }
    }
}
