using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrossLightsModel
{
    public partial class CLForm : Form
    {
        private TrafficLights trafficLight;

        public CLForm()
        {
            InitializeComponent();
        }

        private void CLForm_Load(object sender, EventArgs e)
        {
            trafficLight = new TrafficLights(lampsPanel.CreateGraphics());
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void autoButton_Click(object sender, EventArgs e)
        {
            periodGroupBox.Visible = true;
            redTextBox.Focus();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            periodGroupBox.Visible = false;
            timer.Enabled = true;
        }

        private void manualButton_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            trafficLight.ChangeLamp();
        }

        private uint GetPeriod(TextBox box)
        {
            uint period = 0;
            try
            {
                 period = uint.Parse(box.Text) * 1000;
            }
            catch
            {
                MessageBox.Show("Введіть ціле число (секунди)", "Помилка введення",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                box.Focus();
            }
            return period;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            trafficLight.ChangeLamp();
            timer.Interval = trafficLight.GetInterval();
        }

        private void lampsPanel_Paint(object sender, PaintEventArgs e)
        {
            trafficLight.Draw();
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox box = sender as TextBox;
            trafficLight.SetInterval(box.TabIndex, GetPeriod(box));
        }

        private void nightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                trafficLight.BlinkOn();
                lampsPanel.Invalidate();
            }
            else trafficLight.BlinkOff();
        }
    }
}
