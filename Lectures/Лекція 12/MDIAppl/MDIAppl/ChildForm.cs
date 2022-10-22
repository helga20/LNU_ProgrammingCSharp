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
    public partial class ChildForm : Form
    {
        public ChildForm(Form parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
        }

    }
}
