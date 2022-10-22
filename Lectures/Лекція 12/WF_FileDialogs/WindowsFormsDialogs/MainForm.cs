using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsDialogs
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStartLoadDialog_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog.ShowDialog();
            tBxDialogResult.Text = dr.ToString();
            tBxFileName.Text = openFileDialog.FileName;

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog.FileName);
                if (file.Exists)
                {
                    //StreamReader reader = file.OpenText();
                    StreamReader reader = new StreamReader(file.FullName);
                    
                    tBxContent.Text = reader.ReadToEnd();
                    reader.Close();
                }
                else
                    tBxContent.Text = "A new file: type your text here";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tBxFileName.Text = String.Empty;
            tBxDialogResult.Text = String.Empty;
        }

        private void btnStartSaveDialog_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = tBxFileName.Text;
            DialogResult dr = saveFileDialog.ShowDialog();
            tBxDialogResult.Text = dr.ToString();
            tBxFileName.Text = saveFileDialog.FileName;
            if (dr == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog.FileName);
                writer.WriteLine(tBxContent.Text);
                writer.Close();
            }
        }
    }
}
