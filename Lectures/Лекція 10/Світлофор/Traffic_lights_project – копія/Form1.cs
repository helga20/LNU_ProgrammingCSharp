using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Traffic_lights_project
{
    public partial class Traffic_lights : Form
    {
        public Traffic_lights()
        {
            InitializeComponent();
            Red.Visible = true;
            Yellow.Visible = false;
            Green.Visible = false;

            light_timer = new Timer();
            light_timer.Tick += new EventHandler(light_timer_Tick);
            light_timer.Interval = 2000;
        }
        private void start_button_Click(object sender, EventArgs e)
        {
            light_timer.Enabled = true;
        }
        private void end_button_Click(object sender, EventArgs e)
        {
            light_timer.Enabled = false;
        }
        private void light_timer_Tick(object sender, EventArgs e)
        {
            light_timer.Start();

            if (Red.Visible == true)
            {
                Red.Visible = false;
                Yellow.Visible = true;
                Green.Visible = false;
            }
            else if (Yellow.Visible == true)
            {
                Red.Visible = false;
                Yellow.Visible = false;
                Green.Visible = true;
            }
            else if (Green.Visible == true)
            {
                Red.Visible = true;
                Yellow.Visible = false;
                Green.Visible = false;
            }
        }
        private void RedButton_Click(object sender, EventArgs e)
        {
            Red.Visible = true;
            Yellow.Visible = false;
            Green.Visible = false;
        }
        private void YellowButton_Click(object sender, EventArgs e)
        {
            Red.Visible = false;
            Yellow.Visible = true;
            Green.Visible = false;
        }
        private void GreenButton_Click(object sender, EventArgs e)
        {
            Red.Visible = false;
            Yellow.Visible = false;
            Green.Visible = true;
        }

    }
}
