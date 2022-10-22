using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDIAppl
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDIAppl.ChildForm child = new ChildForm(this);
            child.Show();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void hTailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void vTailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        private void Application_Idle(object sender, EventArgs e)
        {
            ChildForm child = this.ActiveMdiChild as ChildForm;
            if (child != null)
                toolStripStatusLabel1.Text = "Кількість символів " + child.textBox1.Text.Length;
            else toolStripStatusLabel1.Text = "";
            toolStripStatusLabel2.Text = DateTime.Now.ToLongTimeString(); 
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Application.Idle += new EventHandler(Application_Idle);
            newToolStripButton.PerformClick();
        }
    }
}
